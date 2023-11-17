using UnityEngine;
using TMPro;
using UnityEngine.UI;


public partial class UILoginForm
{
    private RectTransform m_Transform_LoginPanel;
    private UIButtonSuper m_Button_Login;
    private UIButtonSuper m_Button_Register;
    private TMP_InputField m_InputField_PassWord;
    private TMP_InputField m_InputField_UserName;
    private Image m_Image_Test;
    private RawImage m_RawImage_Test;
    private RectTransform m_Transform_EnterPanel;
    private UIButtonSuper m_Button_Enter;

    private void GetBindComponents(GameObject go)
    {
        ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

        m_Transform_LoginPanel = autoBindTool.GetBindComponent<RectTransform>(0);
        m_Button_Login = autoBindTool.GetBindComponent<UIButtonSuper>(1);
        m_Button_Register = autoBindTool.GetBindComponent<UIButtonSuper>(2);
        m_InputField_PassWord = autoBindTool.GetBindComponent<TMP_InputField>(3);
        m_InputField_UserName = autoBindTool.GetBindComponent<TMP_InputField>(4);
        m_Image_Test = autoBindTool.GetBindComponent<Image>(5);
        m_RawImage_Test = autoBindTool.GetBindComponent<RawImage>(6);
        m_Transform_EnterPanel = autoBindTool.GetBindComponent<RectTransform>(7);
        m_Button_Enter = autoBindTool.GetBindComponent<UIButtonSuper>(8);
    }
}
