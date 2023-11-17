using dnlib.DotNet;
using Fantasy;
using Fantasy.Core.Network;
using Main.Runtime;
using UnityGameFramework.Runtime;

public partial class UILoginForm : UIFixBaseForm
{
	protected override void OnInit(object userData) {
			base.OnInit(userData);
			GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
		m_Button_Login.onClick.AddListener(Button_LoginEvent);
		m_Button_Register.onClick.AddListener(Button_RegisterEvent);

        Show();

        /*--------------------Auto generate end button listener.Do not modify!----------------------*/
    }

    private void Show()
    {
        m_InputField_UserName.text = GameEntry.Setting.GetString(Const.Setting.UserName);
        m_InputField_PassWord.text = GameEntry.Setting.GetString(Const.Setting.PassWord);
    }

	private void Button_RegisterEvent()
    {
        if (m_InputField_UserName.text == "")
        {
            GameEntry.UI.OpenTips("请输入用户名");
            return;
        }
        if (m_InputField_PassWord.text == "")
        {
            GameEntry.UI.OpenTips("请输入密码");
            return;
        }

        Register(m_InputField_UserName.text, m_InputField_PassWord.text).Coroutine();
    }

    private void Button_LoginEvent()
    {
        if (m_InputField_UserName.text == "")
        {
            GameEntry.UI.OpenTips("请输入用户名");
            return;
        }
        if (m_InputField_PassWord.text == "")
        {
            GameEntry.UI.OpenTips("请输入密码");
            return;
        }

        Login(m_InputField_UserName.text, m_InputField_PassWord.text).Coroutine();
    }

    // 注册realm账号
    public async FTask Register(string username, string password)
    {
        G2C_RegisterResponse response = (G2C_RegisterResponse)await GameEntry.Fantasy.Gate.Session.Call(new C2G_RegisterRequest()
        {
            UserName = username,
            Password = password
        });
        if (response.ErrorCode != 0)
        {
            if (response.ErrorCode == 1)
            {
                GameEntry.UI.OpenTips("用户名重复");
            }
            return;
        }

        GameEntry.UI.OpenTips("注册成功");
    }

    // 登录realm账号
    public async FTask Login(string username, string password)
    {
        G2C_LoginResponse response = (G2C_LoginResponse)await GameEntry.Fantasy.Gate.Session.Call(new C2G_LoginRequest()
        {
            UserName = username,
            Password = password
        });
        if (response.ErrorCode != 0)
        {
            if (response.ErrorCode == 1)
            {
                GameEntry.UI.OpenTips("用户名不存在");
            }
            return;
        }

        GameEntry.UI.OpenTips("登录成功");
        GameEntry.Setting.SetString(Const.Setting.UserName, m_InputField_UserName.text);
        GameEntry.Setting.SetString(Const.Setting.PassWord, m_InputField_PassWord.text);
        GameEntry.Setting.Save();

        if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
        {
            procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Const.Procedure.ProcedureMain);
            procedureBase.ChangeStateByType(procedureBase.ProcedureOwner, typeof(ProcedureCheckAssets));
        }
    }

    private void Test()
    {
        //m_RawImage_Test.SetTexture(AssetUtility.UI.GetTexturePath("login_bg"));
        //m_Image_Test.SetSprite(AssetUtility.UI.GetSpriteCollectionPath("Common"), AssetUtility.UI.GetSpritePath(groupName, "Common/loading"));
        // m_RawImage_Test.SetTextureByNetwork("https://www.baidu.com/img/PCtm_d9c8750bed0b3c7d089fa7d55720d6cf.png");

        //GameEntry.UI.OpenTips(m_InputField_UserName.text + "  " + m_InputField_PassWord.text);
        //         GameEntry.Sound.StopMusic((int)SceneEnum.Login);

        //GameEntry.UI.OpenUIForm(ConstUI.GetUIFormInfo<UIDemoListForm>());
        //GameEntry.UI.OpenUIForm(ConstUI.GetUIFormInfo<UIDemoGridListForm>());
        //GameEntry.UI.OpenUIForm(ConstUI.GetUIFormInfo<UIDemoEntityForm>());

        //UIDialogParams dialogParams = new UIDialogParams();
        //dialogParams.Mode = 2;
        //dialogParams.ConfirmText = "确定";
        //dialogParams.CancelText = "取消";
        //dialogParams.OnClickConfirm = delegate (object o)
        //{
        //    GameEntry.UI.OpenTips("123");
        //};
        //dialogParams.OnClickCancel = delegate (object o)
        //{
        //    GameEntry.UI.OpenTips("321");
        //};
        //dialogParams.OnClickBackground = delegate (object o)
        //{
        //    GameEntry.UI.OpenTips("222");
        //};
        //dialogParams.Message = $"333";
        //GameEntry.UI.OpenDialog(dialogParams);
    }

    /*--------------------Auto generate footer.Do not add anything below the footer!------------*/
}

