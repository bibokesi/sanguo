using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HotfixBusiness.Procedure
{
    public class ProcedureResetMain : ProcedureBase
    {
        public override bool UseNativeDialog => false;
        private int m_UIEntranceMenuFormId;
        private string m_NextProcedure;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_NextProcedure = GameEntry.Setting.GetString("nextProcedure","");
            if (string.IsNullOrEmpty(m_NextProcedure))
            {
                Logger.Error<ProcedureResetMain>("m_NextProcedure is Null");
                return;
            }
            bool isJumpScene = Constant.Procedure.IsJumpScene(m_NextProcedure);
            if (isJumpScene)
            {
                m_ProcedureOwner.SetData<VarString>("nextProcedure", m_NextProcedure);
                ChangeState<ProcedureChangeScene>(m_ProcedureOwner);
            }
            else
            {
                ChangeState(procedureOwner, GameEntry.GetProcedureByName(m_NextProcedure).GetType());
            }
        }
    }
}