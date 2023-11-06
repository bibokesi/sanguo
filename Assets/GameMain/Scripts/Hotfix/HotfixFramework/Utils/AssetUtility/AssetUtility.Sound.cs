using GameFramework;

public static partial class AssetUtility
{
    public static class Sound
    {
        public static string GetMusicSoundAsset(string groupName,string assetName)
        {
            return $"Assets/GameMain/BaseAssets/Sound/{groupName}/{assetName}.mp3";
        }

        public static string GetUISoundAsset(string groupName,string assetName)
        {
            return $"Assets/GameMain/BaseAssets/Sound/{groupName}/{assetName}.wav";
        }

        public static string GetCommonSoundAsset(string groupName,string assetName)
        {
            return $"Assets/GameMain/BaseAssets/Sound/{groupName}/{assetName}.wav";
        }

        public static string GetBattleSoundAsset(string groupName, string assetName)
        {
            return $"Assets/GameMain/BaseAssets/Sound/{groupName}/{assetName}.wav";
        }
    }
}
