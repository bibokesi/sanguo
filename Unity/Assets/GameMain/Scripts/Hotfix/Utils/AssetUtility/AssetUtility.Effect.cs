using GameMain;
using GameFramework;
using GameFramework.Resource;
using UnityGameFramework.Runtime;

public static partial class AssetUtility
{
    /// <summary>
    /// 特效相关
    /// </summary>
    public static class Effect
    {
        /// <summary>
        /// 获取特效路径
        /// </summary>
        /// <param name="effectName">特效名</param>
        /// <returns></returns>
        public static string GetEffectPath(string effectName)
        {
            return Utility.Text.Format("Assets/BaseAsset/Effect/{0}.prefab", effectName);
        }
    }
}