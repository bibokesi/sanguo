using GameFramework;

namespace HotfixFramework
{
	public class AssetObjectInfo: IReference
	{
        private int m_SerialId;
        private string m_AssetObjectName;
        /// <summary>
        /// 是否加载其他bundle 非gf框架构建出来的资源
        /// </summary>
        private bool m_IsLoadOtherBundle;

        public AssetObjectInfo()
        {
            m_SerialId = 0;
            m_AssetObjectName = null;
        }

        public string ShowAssetObjectName
        {
            get;
            private set;
        }
        /// <summary>
        /// 获取UI序列号
        /// </summary>
        public int SerialId
        {
            get
            {
                return m_SerialId;
            }
        }

        /// <summary>
        /// 获取UI界面资源名称
        /// </summary>
        public string AssetObjectName
        {
            get
            {
                return m_AssetObjectName;
            }
        }
        /// <summary>
        /// 是否加载其他bundle 非gf框架构建出来的资源
        /// </summary>
        public bool IsLoadOtherBundle
        {
            get
            {
                return m_IsLoadOtherBundle;
            }
        }

        public static AssetObjectInfo Create(int serialId, string assetName, string showName, bool isLoadOtherBundle = false)
        {
            AssetObjectInfo assetObjectInfo = ReferencePool.Acquire<AssetObjectInfo>();
            assetObjectInfo.m_SerialId = serialId;
            assetObjectInfo.m_AssetObjectName = assetName;
            assetObjectInfo.ShowAssetObjectName = showName;
            assetObjectInfo.m_IsLoadOtherBundle = isLoadOtherBundle;
            return assetObjectInfo;
        }

        public void Clear()
        {
            m_SerialId = 0;
            m_AssetObjectName = null;
        }
    }
}