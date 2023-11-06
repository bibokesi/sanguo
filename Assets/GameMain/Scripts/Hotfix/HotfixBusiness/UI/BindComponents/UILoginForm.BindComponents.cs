using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HotfixBusiness.UI
{
	public partial class UILoginForm
	{
		private Image m_Image_Bg;
		private UIButtonSuper m_Button_Login;
		private UIButtonSuper m_Button_Register;
		private TMP_InputField m_InputField_PassWord;
		private TMP_InputField m_InputField_UserName;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Image_Bg = autoBindTool.GetBindComponent<Image>(0);
			m_Button_Login = autoBindTool.GetBindComponent<UIButtonSuper>(1);
			m_Button_Register = autoBindTool.GetBindComponent<UIButtonSuper>(2);
			m_InputField_PassWord = autoBindTool.GetBindComponent<TMP_InputField>(3);
			m_InputField_UserName = autoBindTool.GetBindComponent<TMP_InputField>(4);
		}
	}
}
