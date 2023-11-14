using System;
using cfg.Custom;
using GameMain;
using GameFramework;
using GameFramework.UI;
using Main.Runtime;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// UI扩展
/// </summary>
public static class UIExtension
{
    private static Transform m_InstanceRoot;
    private static IUIManager m_UIManager;
    private static string m_UIGroupHelperTypeName = "Main.Runtime.CustomUIGroupHelper";
    private static UIGroupHelperBase m_CustomUIGroupHelper = null;
    private static int m_UILoadingFormId;
    private static int m_UIMaskFormId;
   
    public static Canvas GetCanvas(this UIComponent uiComponent)
    {
        return GameEntry.UI.GetInstanceRoot().GetComponent<Canvas>();
    }

    public static bool HasUIForm(this UIComponent uiComponent, ConstUI.UIFormId uiFormId, string uiGroupName = null)
    {
        var uiFormInfo = ConstUI.GetUIFormInfo(uiFormId);
        if (uiFormInfo == null)
        {
            return false;
        }

        string assetName = AssetUtility.UI.GetUIFormAsset(uiFormInfo);
        if (string.IsNullOrEmpty(uiGroupName))
        {
            return uiComponent.HasUIForm(assetName);
        }

        IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
        if (uiGroup == null)
        {
            return false;
        }

        return uiGroup.HasUIForm(assetName);
    }

    public static UIBaseForm GetUIForm(this UIComponent uiComponent, ConstUI.UIFormId uiFormId, string uiGroupName = null)
    {
        var uiFormInfo = ConstUI.GetUIFormInfo(uiFormId);
        if (uiFormInfo == null)
        {
            return null;
        }
        string assetName = AssetUtility.UI.GetUIFormAsset(uiFormInfo);
        UnityGameFramework.Runtime.UIForm uiForm = null;
        if (string.IsNullOrEmpty(uiGroupName))
        {
            uiForm = uiComponent.GetUIForm(assetName);
            if (uiForm != null)
            {
                return (UIBaseForm)uiForm.Logic;
            }

            return null;
        }
        IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
        if (uiGroup == null)
        {
            return null;
        }

        uiForm = (UnityGameFramework.Runtime.UIForm)uiGroup.GetUIForm(assetName);
        if (uiForm != null)
        {
            return (UIBaseForm)uiForm.Logic;
        }

        return null;
    }

    public static void CloseUIForm(this UIComponent uiComponent, UIBaseForm uiForm)
    {
        if (uiForm == null)
        {
            return;
        }
        uiComponent.CloseUIForm(uiForm.UIForm);
    }

    public static int OpenUIForm(this UIComponent uiComponent, ConstUI.UIFormId uiFormId, object userData = null)
    {
        return uiComponent.OpenUIForm(ConstUI.GetUIFormInfo(uiFormId), userData);
    }

    public static int OpenUIForm(this UIComponent uiComponent, ConstUI.UIFormInfo uiFormInfo, object userData = null)
    {
        if (uiFormInfo == null)
        {
            Log.Warning("Can not load UI from data table.");
            return 0;
        }

        string assetName = AssetUtility.UI.GetUIFormAsset(uiFormInfo);
        if (!uiFormInfo.AllowMultiInstance)
        {
            if (uiComponent.IsLoadingUIForm(assetName))
            {
                return 0;
            }

            if (uiComponent.HasUIForm(assetName))
            {
                return 0;
            }
        }
        Logger.Debug<UIComponent>("OpenUIForm: " + assetName);
        return uiComponent.OpenUIForm(assetName, uiFormInfo.UIGroupName.ToString(), Constant.AssetPriority.UIFormAsset, uiFormInfo.PauseCoveredUIForm, userData);
    }

    /// <summary>
    /// 打开飘字提示框
    /// </summary>
    /// <param name="uIComponent"></param>
    /// <param name="tips">显示内容</param>
    /// <param name="color">颜色（默认白色）</param>
    /// <param name="openBg">背景框（默认打开）</param>
    //	GameEntry.UI.OpenTips("xxxxxxxx",color:Color.white,openBg:false);
    public static void OpenTips(this UIComponent uIComponent, string tips, Color? color = null, bool openBg = true)
    {
        MessengerInfo info = ReferencePool.Acquire<MessengerInfo>();
        info.param1 = tips;
        info.param2 = color ?? Color.white;
        info.param3 = openBg;

        uIComponent.OpenUIForm(ConstUI.UIFormId.UITipsForm, info);
    }

    //  UIDialogParams dialogParams = new UIDialogParams();
    //  dialogParams.Mode = 2;
    //	dialogParams.ConfirmText = "确定";
    //	dialogParams.CancelText = "取消";
    //	dialogParams.OnClickConfirm = delegate(object o)
    //	{
    //		GameEntry.UI.OpenTips("");
    //	};
    //  dialogParams.OnClickCancel = delegate (object o)
    //  {
    //      GameEntry.UI.OpenTips("");
    //  };
    //  dialogParams.OnClickBackground = delegate (object o)
    //  {
    //      GameEntry.UI.OpenTips("");
    //  };
    //  dialogParams.Message = $"";
    //  GameEntry.UI.OpenDialog(dialogParams);
    public static void OpenDialog(this UIComponent uiComponent, UIDialogParams dialogParams)
    {
        uiComponent.OpenUIForm(ConstUI.UIFormId.UIDialogForm, dialogParams);
    }

    public static void OpenUILoadingForm(this UIComponent uiComponent)
    {
        var uiFormInfo = ConstUI.GetUIFormInfo(ConstUI.UIFormId.UILoadingForm);
        if (uiFormInfo == null)
        {
            return;
        }
        string assetName = AssetUtility.UI.GetUIFormAsset(uiFormInfo);
        if (uiComponent.IsLoadingUIForm(assetName))
        {
            /*MessengerInfo __messengerInfo = ReferencePool.Acquire<MessengerInfo>();
            __messengerInfo.param1 = sceneName;
            GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_REFRESH_LOADING_VIEW, __messengerInfo);*/
            return;
        }
        if (uiComponent.HasUIForm(assetName))
        {
            if (uiComponent.GetUIForm(assetName).Logic.Available)
            {
                /*MessengerInfo _messengerInfo = ReferencePool.Acquire<MessengerInfo>();
                _messengerInfo.param1 = sceneName;
                GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_REFRESH_LOADING_VIEW, _messengerInfo);*/
                return;
            }
        }
        MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
        //messengerInfo.param1 = sceneName;
        m_UILoadingFormId = uiComponent.OpenUIForm(uiFormInfo, messengerInfo);
    }
    public static void CloseUILoadingForm(this UIComponent uiComponent)
    {
        Log.Info($"UILoadingFormId：{m_UILoadingFormId}    {uiComponent.HasUIForm(m_UILoadingFormId)}");
        if (m_UILoadingFormId != 0 && (uiComponent.HasUIForm(m_UILoadingFormId) || uiComponent.IsLoadingUIForm(m_UILoadingFormId)))
        {
            uiComponent.CloseUIForm(m_UILoadingFormId);
        }
    }

    public static void OpenUIMaskForm(this UIComponent uiComponent, int timeOut = 10, Action onTimeOut = null)
    {
        var uiFormInfo = ConstUI.GetUIFormInfo(ConstUI.UIFormId.UIMaskForm);
        if (uiFormInfo == null)
        {
            return;
        }
        string assetName = AssetUtility.UI.GetUIFormAsset(uiFormInfo);
        if (uiComponent.IsLoadingUIForm(assetName))
        {
            return;
        }
        if (uiComponent.HasUIForm(assetName))
        {
            if (uiComponent.GetUIForm(assetName).Logic.Available)
            {
                return;
            }
        }
        MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
        messengerInfo.param1 = timeOut;
        messengerInfo.action1 = onTimeOut;
        m_UIMaskFormId = uiComponent.OpenUIForm(uiFormInfo, messengerInfo);
    }

    public static void CloseUIMaskForm(this UIComponent uiComponent)
    {
        if (m_UIMaskFormId != 0 && (uiComponent.HasUIForm(m_UIMaskFormId) || uiComponent.IsLoadingUIForm(m_UIMaskFormId)))
        {
            uiComponent.CloseUIForm(m_UIMaskFormId);
        }
    }

}