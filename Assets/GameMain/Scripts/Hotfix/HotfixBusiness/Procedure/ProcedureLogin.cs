using GameFramework;
using HotfixBusiness.Data;
using HotfixBusiness.UI;
using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HotfixBusiness.Procedure
{
    public class ProcedureLogin : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        private int m_LoginFormId = 0;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            //初始化所有信息管理器
            DataManagerEntry.Instance.OnInit();

            // 打开登陆界面
            ShowLoginForm(true);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            //清理所有信息管理器
            //DataManagerEntry.GetInstance()?.OnClear();

            ShowLoginForm(false);            
        }

        private void ShowLoginForm(bool isOpen)
        {
            if (isOpen)
            {
                if (!GameEntry.UI.HasUIForm(m_LoginFormId) && !GameEntry.UI.IsLoadingUIForm(m_LoginFormId))
                {
                    m_LoginFormId = GameEntry.UI.OpenUIForm(ConstantUI.GetUIFormInfo<UIMainMenuForm>());
                }
            }
            else
            {
                if (GameEntry.UI.HasUIForm(m_LoginFormId) || GameEntry.UI.IsLoadingUIForm(m_LoginFormId))
                {
                    GameEntry.UI.CloseUIForm(m_LoginFormId);
                }
            }
        }
    }
}