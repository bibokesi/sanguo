using GameFramework;

public static partial class AssetUtility
{
    /// <summary>
    /// 角色相关
    /// </summary>
    public static class Entity
    {
        /// <summary>
        /// 获取Entity路径
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <param name="entityModelName">模型名</param>
        /// <returns></returns>
        public static string GetEntityAsset(string groupName, string entityModelName)
        {
            return $"Assets/GameMain/BaseAssets/Entity/{groupName}/{entityModelName}.prefab";
        }

   

    }


}
