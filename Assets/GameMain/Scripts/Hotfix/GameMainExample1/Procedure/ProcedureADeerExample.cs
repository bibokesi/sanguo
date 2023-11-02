using GameFramework;
using HotfixBusiness.Procedure;
using Main.Runtime.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMainExample1.Procedure
{
    public class ProcedureAGameMainExample : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            ChangeState<ProcedureGameMainLogin>(procedureOwner);
        }
    }
}