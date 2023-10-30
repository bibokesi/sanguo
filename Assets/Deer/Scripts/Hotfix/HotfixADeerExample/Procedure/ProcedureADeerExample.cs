using GameFramework;
using HotfixBusiness.Procedure;
using Main.Runtime.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HotfixADeerExample.Procedure
{
    public class ProcedureADeerExample : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            ChangeState<ProcedureDeerLogin>(procedureOwner);
        }
    }
}