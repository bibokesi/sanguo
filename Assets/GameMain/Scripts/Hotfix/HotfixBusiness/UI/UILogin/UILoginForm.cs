
using HotfixFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.Runtime;

namespace HotfixBusiness.UI
{
	/// <summary>
	/// Please modify the description.
	/// </summary>
	public partial class UILoginForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			m_Button_Login.onClick.AddListener(Button_LoginEvent);
			m_Button_Register.onClick.AddListener(Button_RegisterEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		private void Button_LoginEvent(){
			GameEntry.UI.OpenTips(m_InputField_UserName.text + "  " + m_InputField_PassWord.text);
		}
		private void Button_RegisterEvent(){

            UIDialogParams dialogParams = new UIDialogParams();
            dialogParams.Mode = 2;
            dialogParams.ConfirmText = "确定";
            dialogParams.CancelText = "取消";
            dialogParams.OnClickConfirm = delegate (object o)
            {
                GameEntry.UI.OpenTips("123");
            };
            dialogParams.OnClickCancel = delegate (object o)
            {
                GameEntry.UI.OpenTips("321");
            };
            dialogParams.OnClickBackground = delegate (object o)
            {
                GameEntry.UI.OpenTips("222");
            };
            dialogParams.Message = $"333";
            GameEntry.UI.OpenDialog(dialogParams);
        }
        /*--------------------Auto generate footer.Do not add anything below the footer!------------*/
    }
    }
