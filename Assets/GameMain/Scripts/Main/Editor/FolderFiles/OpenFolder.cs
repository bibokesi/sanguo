using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class OpenFolder
{
    [MenuItem("GameMainTools/IOControls/OpenFolder/DesignerConfigs")]
    public static void OpenDesignerConfigs()
    {
        Application.OpenURL($"file://{Application.dataPath}/../LubanTools/DesignerConfigs");
    }
    
    [MenuItem("GameMainTools/IOControls/OpenFolder/Proto")]
    public static void OpenProto()
    {
        Application.OpenURL($"file://{Application.dataPath}/../LubanTools/Proto");
    }
    
    [MenuItem("GameMainTools/IOControls/OpenFolder/Assemblies")]
    public static void OpenAssemblies()
    {
        Application.OpenURL($"file://{Application.dataPath}/../{GameMainSettingsUtils.GameMainHybridCLRSettings.HybridCLRDataPath}/{GameMainSettingsUtils.GameMainHybridCLRSettings.HybridCLRAssemblyPath}");
    }
    
    [MenuItem("GameMainTools/IOControls/OpenFolder/AssetsPath")]
    public static void OpenDataPath()
    {
        Application.OpenURL("file://" + Application.dataPath);
    }
    [MenuItem("GameMainTools/IOControls/OpenFolder/LibraryPath")]
    public static void OpenLibraryPath()
    {
        Application.OpenURL("file://" + Application.dataPath + "/../Library");
    }
    
    [MenuItem("GameMainTools/IOControls/OpenFolder/streamingAssetsPath")]
    public static void OpenStreamingAssetsPath()
    {
        Application.OpenURL("file://" + Application.streamingAssetsPath);
    }
    
    [MenuItem("GameMainTools/IOControls/OpenFolder/persistentDataPath")]
    public static void OpenPersistent()
    {
        Application.OpenURL("file://" + Application.persistentDataPath);
    }
    
    [MenuItem("GameMainTools/IOControls/OpenFolder/temporaryCachePath")]
    public static void OpenTemporaryCachePath()
    {
        Application.OpenURL("file://" + Application.temporaryCachePath);
    }
}
