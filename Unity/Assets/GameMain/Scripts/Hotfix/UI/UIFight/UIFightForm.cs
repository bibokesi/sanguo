﻿using Hotfix;
using System.Collections;
using System.Collections.Generic;
using Hotfix.Procedure;
using Main.Runtime;
using Main.Runtime.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Hotfix.UI
{
	public partial class UIFightForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			m_Button_Text.onClick.AddListener(Button_TextEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		private void Button_TextEvent(){
            if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
            {
                procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureMain);
                procedureBase.ChangeStateByType(procedureBase.ProcedureOwner, typeof(ProcedureCheckAssets));
            }
        }
        /*--------------------Auto generate footer.Do not add anything below the footer!------------*/
    }
}