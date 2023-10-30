﻿using HotfixBusiness.Procedure;
using HotfixFramework.Runtime;
using System.Collections;
using System.Collections.Generic;
using HotfixAGameExample.Procedure;
using UnityEngine;

namespace HotfixBusiness.UI
{
	public partial class UIGameStopForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			 m_Btn_Resume.onClick.AddListener(Btn_ResumeEvent);
			 m_Btn_Restart.onClick.AddListener(Btn_RestartEvent);
			 m_Btn_Home.onClick.AddListener(Btn_HomeEvent);
			 m_Btn_Settings.onClick.AddListener(Btn_SettingsEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		protected override void OnClose(bool isShutdown, object userData)
		{
			base.OnClose(isShutdown, userData);
		}

		private void Btn_ResumeEvent(){
			Close();
			Time.timeScale = 1;
		}
		private void Btn_RestartEvent()
		{
			ProcedureGamePlay procedure = GameEntry.Procedure.CurrentProcedure as ProcedureGamePlay;
			procedure.ClearEnv();
			GameEntry.Setting.SetBool("IsRestart", true);
		}
		private void Btn_HomeEvent()
		{
			ProcedureGamePlay procedure = GameEntry.Procedure.CurrentProcedure as ProcedureGamePlay;
			procedure.ClearEnv();
			GameEntry.Setting.SetBool("IsRestart", false);
			//GameEntry.UI.CloseAllLoadedUIForms();
		}

		private void Btn_SettingsEvent()
		{
			GameEntry.UI.OpenUIForm(AGameConstantUI.GetUIFormInfo<UISettingsForm>(), this);
		}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
