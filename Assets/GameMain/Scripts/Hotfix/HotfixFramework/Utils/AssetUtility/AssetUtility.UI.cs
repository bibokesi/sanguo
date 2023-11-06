using System;
using GameFramework;

/// <summary>
/// 资源路径相关
/// </summary>
public static partial class AssetUtility
{
    /// <summary>
    /// UI相关
    /// </summary>
    public static class UI
    {

        public static string GetUIFormAsset(ConstantUI.UIFormInfo  uiFormInfo)
        {
            string moduleName = uiFormInfo.ModuleName;
            string assetName = uiFormInfo.AssetName;
            return Utility.Text.Format("Assets/GameMain/{0}/UI/UIForm/{1}/{2}.prefab", moduleName,assetName.Replace("Form",""), assetName);
        }

        public static string GetUISubFormAsset(ConstantUI.UIFormInfo  uiFormInfo)
        {
            string moduleName = uiFormInfo.ModuleName;
            string assetName = uiFormInfo.AssetName;
            string[] args = assetName.Split('_');
            if (args is { Length: > 1 })
            {
                return Utility.Text.Format("Assets/GameMain/{0}/UI/UIForm/{1}/{2}.prefab", moduleName,args[0], assetName);
            }
            Logger.Error("UISubForm prefab wrong name.It should be [UIxxx_xxxSubForm]");
            return string.Empty;
        }

        public static string GetUIComSubFormAsset(ConstantUI.UIFormInfo  uiFormInfo)
        {
            string moduleName = uiFormInfo.ModuleName;
            string assetName = uiFormInfo.AssetName;
            return Utility.Text.Format("Assets/GameMain/{0}/UI/UIForm/UISub/{1}.prefab", moduleName, assetName);
        }

        /// <summary>
        /// 获取精灵资源名称
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="spriteName"></param>
        /// <returns></returns>
        public static string GetSpritePath(string groupName, string spriteName)
        {
            return $"Assets/GameMain/{groupName}/UI/UIArt/UISprites/{spriteName}.png";
        }

        /// <summary>
        /// 获取精灵资源收集器
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static string GetSpriteCollectionPath(string groupName,string collectionName)
        {
            return $"Assets/GameMain/{groupName}/UI/UIArt/AtlasCollection/{collectionName}.asset";
        }

        /// <summary>
        /// 获取大图
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="textureName"></param>
        /// <returns></returns>
        public static string GetTexturePath(string groupName,string textureName)
        {
            return $"Assets/GameMain/{groupName}/UI/UIArt/Texture/{textureName}.png";
        }

        /// <summary>
        /// 获取大图
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetRenderTexturePath(string textureName)
        {
            return string.Format("Assets/GameMain/UI/UIArt/Texture/{0}.renderTexture", textureName);
        }
    }
}