using HotfixFramework.Runtime;
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
			if (!GameMainSettingsUtils.GameMainGlobalSettings.m_UseGameMainExample)
			{
				DialogParams dialogParams = new DialogParams();
				dialogParams.Mode = 1;
				dialogParams.Title = "提示";
				dialogParams.Message = "GameMain例子已经被移除! [GameMainTools/GameMainExample/AddExample]可以添加GameMain例子。";
				dialogParams.ConfirmText = "确定";
				GameEntry.UI.OpenDialog(dialogParams);
				return;
			}
			if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
			{
				procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureGameMainExample);
				procedureBase.ChangeStateByType(procedureBase.ProcedureOwner,typeof(ProcedureCheckAssets));
			}
		}

		private void Btn_GameMainGameEvent()
		{
			if (!GameMainSettingsUtils.GameMainGlobalSettings.m_UseGameMainExample)
			{
				DialogParams dialogParams = new DialogParams();
				dialogParams.Mode = 1;
				dialogParams.Title = "提示";
				dialogParams.Message = "GameMain游戏例子已经被移除! [GameMainTools/GameMainExample/AddExample]可以添加GameMain游戏例子。";
				dialogParams.ConfirmText = "确定";
				GameEntry.UI.OpenDialog(dialogParams);
				return;
			}
			if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
			{
				procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureAGameExample);
				procedureBase.ChangeStateByType(procedureBase.ProcedureOwner,typeof(ProcedureCheckAssets));
			}
		}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
