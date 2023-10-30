#if ENABLE_HYBRID_CLR_UNITY
using HybridCLR.Editor;
using UnityEditor;

/// <summary>
/// 同步程序集内容
/// </summary>
public static class SynAssemblysContent
{
    public static void RefreshAssembly()
    {
        DeerSettingsUtils.SetHybridCLRHotUpdateAssemblies(SettingsUtil.HotUpdateAssemblyFilesIncludePreserved);
        // 修改 obj 中的 MyField 属性...
        Undo.RecordObject(DeerSettingsUtils.DeerHybridCLRSettings, "Modify Enable");
        DeerSettingsUtils.DeerHybridCLRSettings.Enable = SettingsUtil.Enable;
        EditorUtility.SetDirty(DeerSettingsUtils.DeerHybridCLRSettings);
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }
}
#endif