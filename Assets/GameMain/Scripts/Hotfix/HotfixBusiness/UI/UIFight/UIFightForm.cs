
using HotfixFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotfixBusiness.UI
{
	/// <summary>
	/// Please modify the description.
	/// </summary>
	public partial class UIFightForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			m_Button_Login.onClick.AddListener(Button_LoginEvent);
			m_Button_Register.onClick.AddListener(Button_RegisterEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		private void Button_LoginEvent(){}
		private void Button_RegisterEvent(){}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
