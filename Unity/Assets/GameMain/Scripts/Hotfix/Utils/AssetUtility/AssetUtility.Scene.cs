using GameFramework;
using System;

public static partial class AssetUtility 
{
    /// <summary>
    /// 场景相关
    /// </summary>
    public static class Scene
    {
        /// <summary>
        /// 获取场景资源
        /// </summary>
        /// <param name="sceneName">场景名称</param>
        /// <returns></returns>
        public static string GetSceneAsset(string sceneName)
        {
            return Utility.Text.Format("Assets/GameMain/BaseAssets/Scenes/{0}.unity", sceneName);
        }
    }

}
