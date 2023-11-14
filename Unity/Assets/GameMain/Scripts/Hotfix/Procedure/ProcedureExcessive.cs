using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Hotfix.Procedure
{
    public class ProcedureExcessive : ProcedureBase
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
                Logger.Error<ProcedureExcessive>("m_NextProcedure is Null");
                return;
            }
            bool needChangeScene = Constant.Procedure.NeedChangeScene(m_NextProcedure);
            if (needChangeScene)
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