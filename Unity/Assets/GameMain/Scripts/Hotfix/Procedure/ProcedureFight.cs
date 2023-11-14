using GameFramework;
using Hotfix.Data;
using Hotfix.UI;
using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using Hotfix.Entity;

namespace Hotfix.Procedure
{
    public class ProcedureFight : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        private int m_UIFormSerialId = 0;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // 打开界面
            ShowSceneForm(true);

            // 播放背景音乐
            GameEntry.Sound.PlayMusic((int)SceneEnum.Fight);

            ShowEntity();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            ShowSceneForm(false);            
        }

        private void ShowSceneForm(bool isOpen)
        {
            if (isOpen)
            {
                if (!GameEntry.UI.HasUIForm(m_UIFormSerialId) && !GameEntry.UI.IsLoadingUIForm(m_UIFormSerialId))
                {
                    m_UIFormSerialId = GameEntry.UI.OpenUIForm(ConstUI.GetUIFormInfo<UIFightForm>());
                }
            }
            else
            {
                if (GameEntry.UI.HasUIForm(m_UIFormSerialId) || GameEntry.UI.IsLoadingUIForm(m_UIFormSerialId))
                { 
                    GameEntry.UI.CloseUIForm(m_UIFormSerialId);
                }
            }
        }

        void ShowEntity()
        {
            HeroEntityData characterData = new HeroEntityData(GameEntry.Entity.GenEntityId(), 1, Constant.EntityGroup.RoleEntity, "Blade_girl");
            characterData.Position = new UnityEngine.Vector3(142, 2, 68);
            characterData.IsOwner = true;
            GameEntry.Entity.ShowEntity(typeof(HeroEntity), Constant.EntityGroup.RoleEntity, 1, characterData);
        }
    }
}