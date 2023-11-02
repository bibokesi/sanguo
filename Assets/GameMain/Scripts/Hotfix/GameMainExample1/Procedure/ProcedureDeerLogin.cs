using GameMainExample1.UI;
using HotfixBusiness.Procedure;
using HotfixFramework.Runtime;
using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMainExample1.Procedure
{
    public class ProcedureGameMainLogin : ProcedureBase
    {
        private int m_UIFormSerialId;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_ProcedureOwner = procedureOwner;
            m_UIFormSerialId = GameEntry.UI.OpenUIForm(AGameMainConstantUI.GetUIFormInfo<UILoginForm>(),this);
        }
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            if (m_UIFormSerialId!=0 && GameEntry.UI.HasUIForm(m_UIFormSerialId))
            {
                GameEntry.UI.CloseUIForm((int)m_UIFormSerialId);
            }
        }
        public void ChangeStateToMain() 
        {
            m_ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureGameMainMain);
            ChangeState<ProcedureChangeScene>(m_ProcedureOwner);
        }
    }
}