using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Main.Runtime
{
    public class ProcedureLauncher : ProcedureBase
    {
        public override bool UseNativeDialog => true;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntryMain.UI.OpenUIInitForm();
            ChangeState<ProcedureSplash>(procedureOwner);
        }
    }
}