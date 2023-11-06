using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantUI 
{
    public class UIFormInfo
    {
        /// <summary>
        /// 界面类型
        /// </summary>
        public UIFormType FormType { get; }
        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName { get; }
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

        public UIFormInfo(UIFormType formType,string moduleName, string assetName, UIGroupName groupName, bool allowMultiInstance, bool pauseCoveredUIForm)
        {
            this.FormType = formType;
            this.ModuleName = moduleName;
            this.AssetName = assetName;
            this.UIGroupName = groupName;
            this.AllowMultiInstance = allowMultiInstance;
            this.PauseCoveredUIForm = pauseCoveredUIForm;
        }
    }
    public enum UIGroupName
    {
        AlwaysBottom,
        Background,
        Common,
        AnimationOn,
        PopUI,
        Guide,
    }
    /// <summary>
    /// 界面类型
    /// </summary>
    public enum UIFormType
    {
        /// <summary>
        /// 独立主界面
        /// </summary>
        Alone = 1,
        /// <summary>
        /// 独立主界面下子界面
        /// </summary>
        Sub = 2,
        /// <summary>
        /// 公共子界面
        /// </summary>
        ComSub = 3,
    }
    
    public static Dictionary<UIGroupName, int> UIGroups = new Dictionary<UIGroupName, int>() {
        {UIGroupName.AlwaysBottom,1000},
        {UIGroupName.Background,2000 },
        {UIGroupName.Common,3000 },
        {UIGroupName.AnimationOn,4000 },
        {UIGroupName.PopUI,5000 },
        {UIGroupName.Guide,6000 },
    };

    private static Dictionary<UIFormId, UIFormInfo> uiForms = new Dictionary<UIFormId, UIFormInfo>()
    {
        {UIFormId.UIDialogForm, new UIFormInfo(UIFormType.Alone,"BaseAssets","UIDialogForm",UIGroupName.PopUI,false,true)},
        {UIFormId.UITipsForm, new UIFormInfo(UIFormType.Alone,"BaseAssets","UITipsForm",UIGroupName.PopUI,true,false)},
        {UIFormId.UILoadingForm, new UIFormInfo(UIFormType.Alone,"BaseAssets","UILoadingForm",UIGroupName.AnimationOn,false,true)},
        {UIFormId.UILoadingOneForm, new UIFormInfo(UIFormType.Alone,"BaseAssets","UILoadingOneForm",UIGroupName.PopUI,false,true)},
        {UIFormId.UIMainMenuForm, new UIFormInfo(UIFormType.Alone,"BaseAssets","UIMainMenuForm",UIGroupName.Background,false,true)},

        {UIFormId.UILoginForm, new UIFormInfo(UIFormType.Alone,"BaseAssets","UILoginForm",UIGroupName.Background,false,false)},
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
        Undefined = 0,
        
        /// <summary>
        /// 弹出框。
        /// </summary>
        UIDialogForm = 2,
        /// <summary>
        /// 提示框。
        /// </summary>
        UITipsForm = 3,
        /// <summary>
        /// 业务逻辑加载界面。
        /// </summary>
        UILoadingForm = 4,
        /// <summary>
        /// 业务逻辑单次请求加载界面。
        /// </summary>
        UILoadingOneForm = 5,
        /// <summary>
        /// 游戏入口菜单
        /// </summary>
        UIMainMenuForm = 6,

        /// <summary>
        /// 登录界面
        /// </summary>
        UILoginForm = 7,
    }
}
    