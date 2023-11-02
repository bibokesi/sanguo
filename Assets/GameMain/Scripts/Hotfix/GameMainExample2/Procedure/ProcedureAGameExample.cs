using GameFramework;
using HotfixBusiness.Procedure;
using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMainExample2.Procedure
{
    public class ProcedureAGameExample : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
            {
                procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureGameMenu);
                procedureBase.ChangeStateByType(procedureBase.ProcedureOwner,typeof(ProcedureCheckAssets));
            }
        }
    }
}