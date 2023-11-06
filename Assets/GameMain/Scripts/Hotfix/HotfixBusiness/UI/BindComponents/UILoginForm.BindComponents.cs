using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HotfixBusiness.UI
{
	public partial class UILoginForm
	{
		private UIButtonSuper m_Button_Login;
		private UIButtonSuper m_Button_Register;
		private TMP_InputField m_InputField_PassWord;
		private TMP_InputField m_InputField_UserName;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Button_Login = autoBindTool.GetBindComponent<UIButtonSuper>(0);
			m_Button_Register = autoBindTool.GetBindComponent<UIButtonSuper>(1);
			m_InputField_PassWord = autoBindTool.GetBindComponent<TMP_InputField>(2);
			m_InputField_UserName = autoBindTool.GetBindComponent<TMP_InputField>(3);
		}
	}
}
