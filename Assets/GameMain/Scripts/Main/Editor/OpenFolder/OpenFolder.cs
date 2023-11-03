using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class OpenFolder
{
    [MenuItem("GameMainTools/OpenFolder/DesignerConfigs")]
    public static void OpenDesignerConfigs()
    {
        Application.OpenURL($"file://{Application.dataPath}/../LubanTools/DesignerConfigs");
    }
    
    [MenuItem("GameMainTools/OpenFolder/Proto")]
    public static void OpenProto()
    {
        Application.OpenURL($"file://{Application.dataPath}/../LubanTools/Proto");
    }
    
    [MenuItem("GameMainTools/OpenFolder/Assemblies")]
    public static void OpenAssemblies()
    {
        Application.OpenURL($"file://{Application.dataPath}/../{FrameworkSettingsUtils.GameMainHybridCLRSettings.HybridCLRDataPath}/{FrameworkSettingsUtils.GameMainHybridCLRSettings.HybridCLRAssemblyPath}");
    }
    
    [MenuItem("GameMainTools/OpenFolder/AssetsPath")]
    public static void OpenDataPath()
    {
        Application.OpenURL("file://" + Application.dataPath);
    }
    [MenuItem("GameMainTools/OpenFolder/LibraryPath")]
    public static void OpenLibraryPath()
    {
        Application.OpenURL("file://" + Application.dataPath + "/../Library");
    }
    
    [MenuItem("GameMainTools/OpenFolder/streamingAssetsPath")]
    public static void OpenStreamingAssetsPath()
    {
        Application.OpenURL("file://" + Application.streamingAssetsPath);
    }
    
    [MenuItem("GameMainTools/OpenFolder/persistentDataPath")]
    public static void OpenPersistent()
    {
        Application.OpenURL("file://" + Application.persistentDataPath);
    }
    
    [MenuItem("GameMainTools/OpenFolder/temporaryCachePath")]
    public static void OpenTemporaryCachePath()
    {
        Application.OpenURL("file://" + Application.temporaryCachePath);
    }
}
