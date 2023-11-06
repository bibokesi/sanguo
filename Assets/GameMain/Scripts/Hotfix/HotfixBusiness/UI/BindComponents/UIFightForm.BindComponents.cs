using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HotfixBusiness.UI
{
	public partial class UIFightForm
	{
		private UIButtonSuper m_Button_Login;
		private UIButtonSuper m_Button_Register;
		private TMP_InputField m_InputField_PassWord;
		private TMP_InputField m_InputField_UserName;
		private Image m_Image_Test;
		private RawImage m_RawImage_Test;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Button_Login = autoBindTool.GetBindComponent<UIButtonSuper>(0);
			m_Button_Register = autoBindTool.GetBindComponent<UIButtonSuper>(1);
			m_InputField_PassWord = autoBindTool.GetBindComponent<TMP_InputField>(2);
			m_InputField_UserName = autoBindTool.GetBindComponent<TMP_InputField>(3);
			m_Image_Test = autoBindTool.GetBindComponent<Image>(4);
			m_RawImage_Test = autoBindTool.GetBindComponent<RawImage>(5);
		}
	}
}
