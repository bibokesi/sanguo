using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstUI 
{
    public class UIFormInfo
    {
        /// <summary>
        /// 资源名字
        /// </summary>
        public string AssetName { get; }
        /// <summary>
        /// 界面组
        /// </summary>
        public UIGroupName UIGroupName { get; }
        /// <summary>
        /// 是否允许多个界面实例
        /// </summary>
        public bool AllowMultiInstance { get; }
        /// <summary>
        /// 是否暂停被其覆盖的界面
        /// </summary>
        public bool PauseCoveredUIForm { get; }

        public UIFormInfo(string assetName, UIGroupName groupName, bool allowMultiInstance, bool pauseCoveredUIForm)
        {
            this.AssetName = assetName;
            this.UIGroupName = groupName;
            this.AllowMultiInstance = allowMultiInstance;
            this.PauseCoveredUIForm = pauseCoveredUIForm;
        }
    }
    public enum UIGroupName
    {
        AlwaysBottom,
        State,
        Popup,
        Guide,
        Loading,
        AlwaysTop,
    }

    public static Dictionary<UIGroupName, int> UIGroups = new Dictionary<UIGroupName, int>() {
        {UIGroupName.AlwaysBottom,1000},
        {UIGroupName.State,2000 },
        {UIGroupName.Popup,3000 },
        {UIGroupName.Guide,4000 },
        {UIGroupName.Loading,5000 },
        {UIGroupName.AlwaysTop,6000 },
    };

    private static Dictionary<UIFormId, UIFormInfo> uiForms = new Dictionary<UIFormId, UIFormInfo>()
    {
        {UIFormId.UIDemoListForm, new UIFormInfo("UIDemoListForm",UIGroupName.Popup,false,true)},
        {UIFormId.UIDemoGridListForm, new UIFormInfo("UIDemoGridListForm",UIGroupName.Popup,false,true)},
        {UIFormId.UIDemoEntityForm, new UIFormInfo("UIDemoEntityForm",UIGroupName.Popup,false,true)},

        {UIFormId.UIDialogForm, new UIFormInfo("UIDialogForm",UIGroupName.Popup,false,true)},
        {UIFormId.UITipsForm, new UIFormInfo("UITipsForm",UIGroupName.Popup,true,false)},
        {UIFormId.UILoadingForm, new UIFormInfo("UILoadingForm",UIGroupName.Loading,false,true)},
        {UIFormId.UIMaskForm, new UIFormInfo("UIMaskForm",UIGroupName.AlwaysTop,false,true)},

        //-------------------------------------------------------------------------------------------

        {UIFormId.UILoginForm, new UIFormInfo("UILoginForm",UIGroupName.State,false,false)},
        {UIFormId.UIMainForm, new UIFormInfo("UIMainForm",UIGroupName.State,false,false)},
        {UIFormId.UIFightForm, new UIFormInfo("UIFightForm",UIGroupName.State,false,false)},
    };

    public static UIFormInfo GetUIFormInfo(UIFormId uiFormId)
    {
        if (uiForms.ContainsKey(uiFormId))
        {
            return uiForms[uiFormId];
        }
        return null;
    }
    public static UIFormInfo GetUIFormInfo<T>()
    {
        string name = typeof(T).Name;
        try
        {
            UIFormId uiFormId = (UIFormId)System.Enum.Parse( typeof(UIFormId),name);
            if (uiForms.ContainsKey(uiFormId))
            {
                return uiForms[uiFormId];
            }
        }
        catch (Exception e)
        {
            Logger.Error(e.ToString());
            return null;
        }
        return null;
    }
    /// <summary>
    /// 界面编号。
    /// </summary>
    public enum UIFormId
    {
        /// <summary>
        /// 测试界面
        /// </summary>
        UIDemoListForm = 1,

        /// <summary>
        /// 测试界面
        /// </summary>
        UIDemoGridListForm,

        /// <summary>
        /// 测试界面
        /// </summary>
        UIDemoEntityForm,

        /// <summary>
        /// 弹出框
        /// </summary>
        UIDialogForm,

        /// <summary>
        /// 提示框
        /// </summary>
        UITipsForm,

        /// <summary>
        /// 业务逻辑加载界面
        /// </summary>
        UILoadingForm,

        /// <summary>
        /// 遮罩界面
        /// </summary>
        UIMaskForm,

        /// <summary>
        /// 登录界面
        /// </summary>
        UILoginForm,

        /// <summary>
        /// 主界面
        /// </summary>
        UIMainForm,

        /// <summary>
        /// 战斗界面
        /// </summary>
        UIFightForm,
    }
}
    