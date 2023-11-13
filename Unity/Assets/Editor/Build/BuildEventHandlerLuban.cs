using Main.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor.ResourceTools;
using UnityGameFramework.Runtime;

public static class BuildEventHandlerLuban
{

    public static void OnPreprocessAllPlatforms(Platform platforms, bool outputFullSelected) 
    {
        if (outputFullSelected)
        {

        }
    }
    public static void OnPreprocessPlatform(Platform platform) 
    {

    }
    
    public static void OnPostprocessPlatform(Platform platform,bool outputPackageSelected, 
        bool outputFullSelected, bool outputPackedSelected,string commitResourcesPath) 
    {
        if (outputPackageSelected)
        {
            //CopyPackageFile();
            if (FolderUtils.CopyFolder(
                    $"{Application.dataPath}/../LubanTools/GenerateDatas/{FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName}",
                    Path.Combine(Application.streamingAssetsPath,FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName)))
            {
                Debug.Log("拷贝表资源文件成功！");
            }
        }
        if (!outputPackageSelected && outputPackedSelected)
        {
            if (FolderUtils.CopyFolder(
                    $"{Application.dataPath}/../LubanTools/GenerateDatas/{FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName}",
                    Path.Combine(Application.streamingAssetsPath,FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName)))
            {
                Debug.Log("拷贝表资源文件成功！");
            }
        }
        if (outputFullSelected)
        {
            string commitPath = commitResourcesPath + "/" + platform;
            if (FolderUtils.CopyFolder($"{Application.dataPath}/../LubanTools/GenerateDatas/{FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName}", 
                    Path.Combine(commitPath,FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName)))
            {
                Debug.Log("拷贝表资源文件成功！");
            }
        }
    }
    //[MenuItem("GameMainTools/Test")]
    private static void CopyPackageFile()
    {
        Dictionary<string, ConfigInfo> m_Configs ;
        string configFolderPath = Path.Combine(Application.dataPath,$"../LubanTools/GenerateDatas/{FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName}");
        string configVersionPath = Path.Combine(configFolderPath,FrameworkSettingsUtils.FrameworkSettings.ConfigVersionFileName);
        string xml = File.ReadAllText(configVersionPath);
        m_Configs = FileUtils.AnalyConfigXml(xml,out string version);
        string configDataPath = $"{configFolderPath}/Datas";
        string destDataPath = Path.Combine(Application.streamingAssetsPath,FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName,"Datas");
        if (!Directory.Exists(destDataPath))
        {
            Directory.CreateDirectory(destDataPath);
        }
        foreach (var item in m_Configs)
        {
            File.Copy(Path.Combine(configDataPath,$"{item.Value.NameWithoutExtension}.{item.Value.HashCode}{item.Value.Extension}"),
                Path.Combine(destDataPath,$"{item.Value.NameWithoutExtension}{item.Value.Extension}"));
        }
        File.Copy(configVersionPath,
            Path.Combine(Application.streamingAssetsPath,FrameworkSettingsUtils.FrameworkSettings.ConfigFolderName,FrameworkSettingsUtils.FrameworkSettings.ConfigVersionFileName));
        Debug.Log("拷贝表资源文件成功！");
        AssetDatabase.Refresh();
    }

}