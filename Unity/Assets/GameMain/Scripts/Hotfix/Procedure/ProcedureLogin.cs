using GameFramework;
using Hotfix.Data;
using Hotfix.UI;
using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Hotfix.Procedure
{
    public class ProcedureLogin : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        private int m_UIFormSerialId = 0;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // 初始化所有信息管理器
            DataManagerEntry.Instance.OnInit();

            // 打开界面
            ShowSceneForm(true);

            // 播放背景音乐
            GameEntry.Sound.PlayMusic((int)SceneEnum.Login);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            //清理所有信息管理器
            //DataManagerEntry.GetInstance()?.OnClear();

            ShowSceneForm(false);            
        }

        private void ShowSceneForm(bool isOpen)
        {
            if (isOpen)
            {
                if (!GameEntry.UI.HasUIForm(m_UIFormSerialId) && !GameEntry.UI.IsLoadingUIForm(m_UIFormSerialId))
                {
                    m_UIFormSerialId = GameEntry.UI.OpenUIForm(ConstUI.GetUIFormInfo<UILoginForm>());
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
    }
}