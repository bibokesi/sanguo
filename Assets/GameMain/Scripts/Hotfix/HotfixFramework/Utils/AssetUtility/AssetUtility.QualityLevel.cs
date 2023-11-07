using GameMain;

public static partial class AssetUtility
{
    /// <summary>
    /// 特效质量等级
    /// </summary>
    public static string EffectQualityLevelName
    {
        get
        {
            return "";
        }
    }

    /// <summary>
    /// 角色材质球质量等级
    /// </summary>
    public static string CharacterSceneMatQualityLevelName
    {
        get
        {
            /*            int qualityLevel = GameEntry.Setting.GetInt(Constant.Setting.QualityLevel, 3);
                        switch (qualityLevel)
                        {
                            case 1:
                            case 2:
                                return "_l";
                            case 3:
                                return "_m";
                            case 4:
                            case 5:
                                return "_h";
                            default:
                                return "";
                        }*/
            return "";
        }
    }
}
