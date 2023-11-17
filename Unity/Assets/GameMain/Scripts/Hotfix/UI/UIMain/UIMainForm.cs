﻿using Main.Runtime;
using UnityGameFramework.Runtime;

public partial class UIMainForm : UIFixBaseForm
{
	protected override void OnInit(object userData) {
		base.OnInit(userData);
		GetBindComponents(gameObject);

		m_Button_Text.onClick.AddListener(Button_TextEvent);
	}

	private void Button_TextEvent(){
        if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
        {
            procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Const.Procedure.ProcedureFight);
            procedureBase.ChangeStateByType(procedureBase.ProcedureOwner, typeof(ProcedureCheckAssets));
        }
    }
}

