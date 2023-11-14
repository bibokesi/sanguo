using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class OpenFolder
{
    [MenuItem("CustomTools/OpenFolder/DesignerConfigs")]
    public static void OpenDesignerConfigs()
    {
        Application.OpenURL($"file://{Application.dataPath}/../LubanTools/DesignerConfigs");
    }
    
    [MenuItem("CustomTools/OpenFolder/ProtoFiles")]
    public static void OpenProto()
    {
        Application.OpenURL($"file://{Application.dataPath}/../../Config/ProtoBuf");
    }
    
    [MenuItem("CustomTools/OpenFolder/Assemblies")]
    public static void OpenAssemblies()
    {
        Application.OpenURL($"file://{Application.dataPath}/../{FrameworkSettingsUtils.HybridCLRSettings.HybridCLRDataPath}/{FrameworkSettingsUtils.HybridCLRSettings.HybridCLRAssemblyPath}");
    }
    
    [MenuItem("CustomTools/OpenFolder/AssetsPath")]
    public static void OpenDataPath()
    {
        Application.OpenURL("file://" + Application.dataPath);
    }
    [MenuItem("CustomTools/OpenFolder/LibraryPath")]
    public static void OpenLibraryPath()
    {
        Application.OpenURL("file://" + Application.dataPath + "/../Library");
    }
    
    [MenuItem("CustomTools/OpenFolder/streamingAssetsPath")]
    public static void OpenStreamingAssetsPath()
    {
        Application.OpenURL("file://" + Application.streamingAssetsPath);
    }
    
    [MenuItem("CustomTools/OpenFolder/persistentDataPath")]
    public static void OpenPersistent()
    {
        Application.OpenURL("file://" + Application.persistentDataPath);
    }
    
    [MenuItem("CustomTools/OpenFolder/temporaryCachePath")]
    public static void OpenTemporaryCachePath()
    {
        Application.OpenURL("file://" + Application.temporaryCachePath);
    }
}
