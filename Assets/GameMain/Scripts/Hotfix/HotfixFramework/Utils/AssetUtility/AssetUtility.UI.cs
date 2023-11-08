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
        /// <summary>
        /// 获取界面路径
        /// </summary>
        /// <param name="uiFormInfo"></param>
        /// <returns></returns>
        public static string GetUIFormAsset(ConstUI.UIFormInfo uiFormInfo)
        {
            string assetName = uiFormInfo.AssetName;
            return Utility.Text.Format("Assets/GameMain/BaseAssets/UI/UIForm/{0}/{1}.prefab", assetName.Replace("Form", ""), assetName);
        }

        /// <summary>
        /// 获取界面路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/BaseAssets/UI/UIForm/{0}/{1}.prefab", assetName.Replace("UIForm", ""), assetName);
        }

        /// <summary>
        /// 获取精灵资源名称
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetSpritePath(string spriteName)
        {
            return string.Format("Assets/GameMain/BaseAssets/UI/UISprite/{0}.png", spriteName);
        }
        /// <summary>
        /// 获取精灵资源收集器
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetSpriteCollectionPath(string collectionName)
        {
            return string.Format("Assets/GameMain/BaseAssets/UI/UIAtlasCollection/{0}.asset", collectionName);
        }

        /// <summary>
        /// 获取大图
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetTexturePath(string textureName)
        {
            return string.Format("Assets/GameMain/BaseAssets/UI/UITexture/{0}.png", textureName);
        }

        /// <summary>
        /// 获取大图
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetRenderTexturePath(string textureName)
        {
            return string.Format("Assets/GameMain/BaseAssets/UI/UITexture/{0}.renderTexture", textureName);
        }

        /// <summary>
        /// 获取精灵资源
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="spriteName"></param>
        /// <returns></returns>
        public static string GetSpritePath(string groupName, string spriteName)
        {
            return $"Assets/GameMain/{groupName}/UI/UISprite/{spriteName}.png";
        }

        /// <summary>
        /// 获取精灵资源收集器
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static string GetSpriteCollectionPath(string groupName,string collectionName)
        {
            return $"Assets/GameMain/{groupName}/UI/UIAtlasCollection/{collectionName}.asset";
        }

        /// <summary>
        /// 获取大图
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="textureName"></param>
        /// <returns></returns>
        public static string GetTexturePath(string groupName,string textureName)
        {
            return $"Assets/GameMain/{groupName}/UI/UITexture/{textureName}.png";
        }

        /// <summary>
        /// 获取大图
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string GetRenderTexturePath(string groupName, string textureName)
        {
            return $"Assets/GameMain/{groupName}/UI/UITexture/{textureName}.renderTexture";
        }
    }
}