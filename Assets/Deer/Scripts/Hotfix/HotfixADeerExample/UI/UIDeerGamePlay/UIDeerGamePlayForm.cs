using HotfixFramework.Runtime;
using System.Collections;
using System.Collections.Generic;
using HotfixBusiness.Procedure;
using Main.Runtime.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HotfixADeerExample.UI
{
	/// <summary>
	/// Please modify the description.
	/// </summary>
	public partial class UIDeerGamePlayForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			 m_Btn_Play.onClick.AddListener(Btn_PlayEvent);
			 m_Btn_Back.onClick.AddListener(Btn_BackEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		private void Btn_PlayEvent()
		{
			Logger.Debug<UIDeerGamePlayForm>("打出100暴击点！");
		}

		private void Btn_BackEvent()
		{
			if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
			{
				procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureDeerLogin);
				procedureBase.ChangeStateByType(procedureBase.ProcedureOwner,typeof(ProcedureCheckAssets));
			}
		}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
