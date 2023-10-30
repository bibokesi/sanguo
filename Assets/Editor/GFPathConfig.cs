using GameFramework;
using System.IO;
using UnityEngine;
using UnityGameFramework.Editor;
using UnityGameFramework.Editor.ResourceTools;

public static class GFPathConfig
{
    [BuildSettingsConfigPath]
    public static string BuildSettingsConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Deer/GameConfigs/BuildSettings.xml"));

    [ResourceCollectionConfigPath]
    public static string ResourceCollectionConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Deer/GameConfigs/ResourceCollection.xml"));

    [ResourceEditorConfigPath]
    public static string ResourceEditorConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Deer/GameConfigs/ResourceEditor.xml"));

    [ResourceBuilderConfigPath]
    public static string ResourceBuilderConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Deer/GameConfigs/ResourceBuilder.xml"));
}