﻿using Hotfix;
using System.Collections;
using System.Collections.Generic;
using Hotfix.Procedure;
using Main.Runtime;
using Main.Runtime.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Hotfix.UI
{
	public partial class UILoginForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			m_Button_Login.onClick.AddListener(Button_LoginEvent);
			m_Button_Register.onClick.AddListener(Button_RegisterEvent);
            /*--------------------Auto generate end button listener.Do not modify!----------------------*/

            //m_RawImage_Test.SetTexture(AssetUtility.UI.GetTexturePath("login_bg"));
            //m_Image_Test.SetSprite(AssetUtility.UI.GetSpriteCollectionPath("Common"), AssetUtility.UI.GetSpritePath(groupName, "Common/loading"));
           // m_RawImage_Test.SetTextureByNetwork("https://www.baidu.com/img/PCtm_d9c8750bed0b3c7d089fa7d55720d6cf.png");

        }

		private void Button_LoginEvent()
        {
            //GameEntry.UI.OpenTips(m_InputField_UserName.text + "  " + m_InputField_PassWord.text);
            //         GameEntry.Sound.StopMusic((int)SceneEnum.Login);

            if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
            {
                procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Constant.Procedure.ProcedureMain);
                procedureBase.ChangeStateByType(procedureBase.ProcedureOwner, typeof(ProcedureCheckAssets));
            }
        }
		private void Button_RegisterEvent()
        {

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

            GameEntry.Fantasy.ConnectServer();
        }
        /*--------------------Auto generate footer.Do not add anything below the footer!------------*/
    }
    }