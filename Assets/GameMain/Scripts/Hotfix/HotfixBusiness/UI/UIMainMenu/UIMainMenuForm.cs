using HotfixFramework;
using System.Collections;
using System.Collections.Generic;
using HotfixBusiness.Procedure;
using Main.Runtime;
using Main.Runtime.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HotfixBusiness.UI
{
	/// <summary>
	/// Please modify the description.
	/// </summary>
	public partial class UIMainMenuForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			m_Btn_GameMainExample.onClick.AddListener(Btn_GameMainExampleEvent);
			m_Btn_GameMainGame.onClick.AddListener(Btn_GameMainGameEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		private void Btn_GameMainExampleEvent()
		{
			if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
			{
				procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureGameMainExample);
				procedureBase.ChangeStateByType(procedureBase.ProcedureOwner,typeof(ProcedureCheckAssets));
			}
		}

		private void Btn_GameMainGameEvent()
		{
			if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
			{
				procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureAGameExample);
				procedureBase.ChangeStateByType(procedureBase.ProcedureOwner,typeof(ProcedureCheckAssets));
			}
		}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
