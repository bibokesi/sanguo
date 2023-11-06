using GameFramework;
using HotfixBusiness.Data;
using HotfixBusiness.UI;
using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HotfixBusiness.Procedure
{
    public class ProcedureMain : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        private int m_MainFormId = 0;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // 打开主界面
            ShowMainForm(true);

            // 播放背景音乐
            GameEntry.Sound.PlayMusic((int)SceneEnum.Main);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            ShowMainForm(false);            
        }

        private void ShowMainForm(bool isOpen)
        {
            if (isOpen)
            {
                if (!GameEntry.UI.HasUIForm(m_MainFormId) && !GameEntry.UI.IsLoadingUIForm(m_MainFormId))
                {
                    m_MainFormId = GameEntry.UI.OpenUIForm(ConstantUI.GetUIFormInfo<UILoginForm>());
                }
            }
            else
            {
                if (GameEntry.UI.HasUIForm(m_MainFormId) || GameEntry.UI.IsLoadingUIForm(m_MainFormId))
                {
                    GameEntry.UI.CloseUIForm(m_MainFormId);
                }
            }
        }
    }
}