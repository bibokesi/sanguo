using UnityEngine;

/// <summary>
/// 游戏常量类
/// </summary>
public static partial class Constant
{
    /// <summary>
    /// 层级
    /// </summary>
    public static class Leyer
    {
        /// <summary>
        /// Default层
        /// </summary>
        public const string DefaultLayerName = "Default";
        public static readonly int DefaultLayerId = LayerMask.NameToLayer(DefaultLayerName);

        /// <summary>
        /// UI层
        /// </summary>
        public const string UILayerName = "UI";
        public static readonly int UILayerId = LayerMask.NameToLayer(UILayerName);

        /// <summary>
        /// Ground层
        /// </summary>
        public const string GroundLayerName = "Ground";
        public static readonly int GroundLayerId = LayerMask.NameToLayer(GroundLayerName);

        /// <summary>
        /// UIModel层
        /// </summary>
        public const string UIModelLayerName = "UIModel";
        public static readonly int UIModelLayerId = LayerMask.NameToLayer(UIModelLayerName);

        /// <summary>
        /// Player层
        /// </summary>
        public const string PlayerLayerName = "Player";
        public static readonly int PlayerLayerId = LayerMask.NameToLayer(PlayerLayerName);


        public static int GetLayerBits(params int[] layer)
        {
            int bits = 0;
            for (int i = 0; i < layer.Length; i++)
            {
                bits = bits | 1 << layer[i];
            }
            return bits;
        }
    }

}

