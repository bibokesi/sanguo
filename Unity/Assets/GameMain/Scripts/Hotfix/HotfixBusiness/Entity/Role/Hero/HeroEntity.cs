using GameFramework;
using Pathfinding;
using System;
using UnityEngine;

namespace HotfixBusiness.Entity
{
    public partial class HeroEntity : EntityLogicBase
    {
        public EntityEnum EntityType = EntityEnum.Player;

        private bool m_isMoveing = false;

        private HeroEntityData m_CharacterData;
        public HeroEntityData HeroEntityData { get { return m_CharacterData; } private set { m_CharacterData = value; } }

        public GameObject CharacterModel { get; private set; }
        public Animator Animator { get; private set; }
        public StateController StateController { get; set; }
        public RoleControllerManager RoleControllerManager { get; set; }
        public bool IsOwner { get; set; }
        public IdleState IdleState { get; set; }
        public MoveState MoveState { get; set; }
        public JumpState JumpState { get; set; }

        private HeroEntity m_MyCurrentTarget;
        public HeroEntity MyCurrentTarget
        {
            get { return m_MyCurrentTarget; }
            set
            {
                m_MyCurrentTarget = value;
            }
        }

        private bool m_IsPauseFram;
        /// <summary>
        /// 速度
        /// </summary>
        protected internal Vector3 m_Velocity;
        /// <summary>
        /// 是否顿帧，顿帧只针对受击，击飞，技能位移有效果
        /// </summary>
        public bool IsPauseFram
        {
            get
            {
                return m_IsPauseFram;
            }
            set
            {
                m_IsPauseFram = value;
            }
        }
        /// <summary>
        /// 顿帧时，动画和移动速度减慢的百分比
        /// </summary>
        public float PauseFrameAniPercent { get; set; }
        /// <summary>
        /// 摇杆方向
        /// </summary>
        public Vector3 JoyStickDirection { get; set; }
        /// <summary>
        /// 是否是摇杆控制
        /// </summary>
        public bool IsJoyStickControl { get; set; } = false;
        /// <summary>
        /// 是否使用自定义面向
        /// </summary>
        public bool UseCustomFace { get; set; } = false;

        /// <summary>
        /// 角色面向限制
        /// </summary>
        public SceneCharacterFace UseFaceType = SceneCharacterFace.Free;

        private MoveDirection m_MoveDirection;

        /// <summary>
        /// 使用两个方向
        /// </summary>
        public bool UserTwoDirction = false;
        /// <summary>
        /// 角色朝向
        /// </summary>
        public MoveDirection MoveDirection
        {
            get
            {
                return m_MoveDirection;
            }
            set
            {
                switch (UseFaceType)
                {
                    case SceneCharacterFace.Free:
                    case SceneCharacterFace.LeftAndRight:
                    default:
                        m_MoveDirection = value;
                        break;
                    case SceneCharacterFace.Right:
                        m_MoveDirection = MoveDirection.Right;
                        break;
                    case SceneCharacterFace.Left:
                        m_MoveDirection = MoveDirection.Left;
                        break;
                }
            }
        }

        public void GetCharacterState()
        {
            MoveState = new MoveState();
            IdleState = new IdleState();
            JumpState = new JumpState();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            HeroEntityData = (HeroEntityData)userData;
            if (HeroEntityData == null) { Logger.Error("characterData is invalid."); return; }
            CachedTransform.position = HeroEntityData.Position;
            CharacterModel = CachedTransform.Find("Model").gameObject;
            Animator = CharacterModel.GetComponent<Animator>();
            CharacterController controller = CachedTransform.GetComponent<CharacterController>();
            controller.enabled = true;
            RoleControllerManager = new RoleControllerManager(this, controller);
            GetCharacterState();
            StateController = new StateController(this);
            StateController.OnChangeState(IdleState);

            GameEntry.Messenger.RegisterEvent(EventName.EVENT_CS_GAME_MOVE_DIRECTION, OnHandleMoveDirectionCallback);
            GameEntry.Messenger.RegisterEvent(EventName.EVENT_CS_GAME_MOVE_END, OnHandleMoveEndCallback);
            GameEntry.Messenger.RegisterEvent(EventName.EVENT_CS_GAME_START_JUMP, OnHandleJumpCallback);
            HeroEntityData entityData = userData as HeroEntityData;
            if (entityData == null)
                return;
            if (entityData.IsOwner)
            {
                IsOwner = true;
                //Transform transCamTarget = CachedTransform.Find("CamTaget");
                GameEntry.Camera.FollowAndFreeViewTarget(CachedTransform, CachedTransform);
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            if (!enabled || !Visible)
            {
                return;
            }
            if (RoleControllerManager != null)
            {
                RoleControllerManager.Update(elapseSeconds, realElapseSeconds);
            }
            if (StateController != null)
            {
                StateController.OnUpdate(elapseSeconds, realElapseSeconds);
            }
        }

        public void SetMoveMode(MoveMode moveMode)
        {
            MoveState.MoveMode = moveMode;
        }

        public void SetFaceDir(Vector3 vec3Dir)
        {
            if (vec3Dir == Vector3.zero)
            {
                return;
            }
            if (vec3Dir.magnitude > 0)
            {
                Quaternion freeRotation = Quaternion.LookRotation(vec3Dir);
                float diferenceRotation = freeRotation.eulerAngles.y - CachedTransform.eulerAngles.y;
                float eulerY = CachedTransform.eulerAngles.y;
                if (diferenceRotation < 0 || diferenceRotation > 0)
                {
                    eulerY = freeRotation.eulerAngles.y;
                }
                Vector3 euler = new Vector3(0, eulerY, 0);
                CachedTransform.rotation = Quaternion.Slerp(CachedTransform.rotation, Quaternion.Euler(euler), Time.deltaTime * HeroEntityData.TurningSpeed);
            }
        }

        public bool CanJump()
        {
            if (!RoleControllerManager.IsGround)
            {
                return false;
            }
            if (StateController.IsInState(JumpState))
            {
                return false;
            }
            return true;
        }


        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            GameEntry.Messenger.UnRegisterEvent(EventName.EVENT_CS_GAME_MOVE_DIRECTION, OnHandleMoveDirectionCallback);
            GameEntry.Messenger.UnRegisterEvent(EventName.EVENT_CS_GAME_MOVE_END, OnHandleMoveEndCallback);
            GameEntry.Messenger.UnRegisterEvent(EventName.EVENT_CS_GAME_START_JUMP, OnHandleJumpCallback);
            GameEntry.Camera.FollowAndFreeViewTarget(null, null);
        }


        private void Update()
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                m_isMoveing = true;
                MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
                messengerInfo.param1 = Input.GetAxisRaw("Horizontal");
                messengerInfo.param2 = Input.GetAxisRaw("Vertical");
                GameEntry.Messenger.SendEvent(EventName.EVENT_CS_GAME_MOVE_DIRECTION, messengerInfo);
            }
            else
            {
                if (m_isMoveing)
                {
                    MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
                    messengerInfo.param1 = false;
                    GameEntry.Messenger.SendEvent(EventName.EVENT_CS_GAME_MOVE_END, messengerInfo);
                    m_isMoveing = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnHandleJumpCallback(null);
            }
        }

        private object OnHandleMoveDirectionCallback(object pSender)
        {
            MessengerInfo messengerInfo = (MessengerInfo)pSender;
            if (messengerInfo == null) return null;
            if (!IsOwner)
            {
                return null;
            }
            Vector2 direction = new Vector2((float)messengerInfo.param1, (float)messengerInfo.param2);
            IsJoyStickControl = true;
            SetMoveMode(direction.magnitude >= 0.9f ? MoveMode.ForwardRun : MoveMode.Forward);
            JoyStickDirection = GameObjectUtils.GetFrezzeModeDirection(direction.x, direction.y);
            if (!StateController.IsInState(JumpState))
            {
                MessengerInfo messengerInfo1 = ReferencePool.Acquire<MessengerInfo>();
                messengerInfo1.param1 = MoveType.MoveToDir;
                messengerInfo1.param2 = JoyStickDirection;
                messengerInfo1.param3 = 1f;
                MoveState.SetParam(messengerInfo1);
                StateController.OnChangeState(MoveState);
            }
            if (HeroEntityData.JumpCanMove)
            {
                //RoleControllerManager.OnMove();
            }
            return null;
        }
        private object OnHandleMoveEndCallback(object pSender)
        {
            MessengerInfo messengerInfo = (MessengerInfo)pSender;
            if (messengerInfo == null) return null;
            if (!IsOwner)
            {
                return null;
            }
            IsJoyStickControl = false;
            JoyStickDirection = Vector3.zero;
            StateController.OnChangeState(IdleState);
            return null;
        }
        private object OnHandleJumpCallback(object pSender)
        {
            if (!CanJump())
            {
                return null;
            }
            SetMoveMode(MoveState.MoveMode == MoveMode.ForwardRun ? MoveMode.JumpRun : MoveMode.Jump);
            RoleControllerManager.CharacterGravitySpeed = HeroEntityData.JumpPower;
            StateController.OnChangeState(JumpState);
            return null;
        }
    }

}