﻿#if ENABLE_HYBRID_CLR_UNITY
using System.IO;
using HybridCLR.Editor;
using UnityEditor;
using UnityEngine;

public static class AOTMetaAssembliesHelper
{
    [MenuItem("HybridCLR/CollectAOTMetaAssemblies/ActiveBuildTarget", priority = 100)]
    public static void AOTMetaAssembliesActiveBuildTarget()
    {
        FindAllAOTMetaAssemblies1(EditorUserBuildSettings.activeBuildTarget);
    }
    [MenuItem("HybridCLR/CollectAOTMetaAssemblies/Win32", priority = 200)]
    public static void AOTMetaAssembliesWin32()
    {
        FindAllAOTMetaAssemblies1(BuildTarget.StandaloneWindows);
    }
    [MenuItem("HybridCLR/CollectAOTMetaAssemblies/Win64", priority = 201)]
    public static void AOTMetaAssembliesWin64()
    {
        FindAllAOTMetaAssemblies1(BuildTarget.StandaloneWindows64);
    }
    [MenuItem("HybridCLR/CollectAOTMetaAssemblies/Android", priority = 202)]
    public static void AOTMetaAssembliesAndroid()
    {
        FindAllAOTMetaAssemblies1(BuildTarget.Android);
    }
    [MenuItem("HybridCLR/CollectAOTMetaAssemblies/IOS", priority = 203)]
    public static void AOTMetaAssembliesIOS()
    {
        FindAllAOTMetaAssemblies1(BuildTarget.iOS);
    }
    public static void FindAllAOTMetaAssemblies(BuildTarget buildTarget)
    {
        //        fixed by zh
        string folder = $"{SettingsUtil.GetAssembliesPostIl2CppStripDir(buildTarget)}";
        GameMainSettingsUtils.GameMainHybridCLRSettings.AOTMetaAssemblies.Clear();
        if (!Directory.Exists(folder))
        {
#if UNITY_EDITOR_WIN
            Logger.Error($"AOTMetaAssemblies文件夹不存在，因此需要你先在菜单栏中(HybridCLR>>Generate>>All)操作。FolderPath:{folder}");
#elif UNITY_EDITOR_OSX
            Logger.Error($"AOTMetaAssemblies文件夹不存在，请检查是否制作UnityEditor.CoreModule.dll,并修改覆盖Unity安装路径，然后需要你先在菜单栏中(HybridCLR>>Generate>>All)操作。FolderPath:{folder}");
#endif
            return;
        }
        DirectoryInfo root = new DirectoryInfo(folder);
        foreach (var fileInfo in root.GetFiles("*dll", SearchOption.AllDirectories))
        {
            string fileName = fileInfo.Name;
            GameMainSettingsUtils.GameMainHybridCLRSettings.AOTMetaAssemblies.Add(fileName);
        }
        EditorUtility.SetDirty(GameMainSettingsUtils.GameMainHybridCLRSettings);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public static void FindAllAOTMetaAssemblies1(BuildTarget buildTarget)
    {
        // fixed by zh
        string folder = $"{SettingsUtil.GetAssembliesPostIl2CppStripDir(buildTarget)}";
        GameMainSettingsUtils.GameMainHybridCLRSettings.AOTMetaAssemblies.Clear();
        if (!Directory.Exists(folder))
        {
#if UNITY_EDITOR_WIN
            Logger.Error($"AOTMetaAssemblies文件夹不存在，因此需要你先在菜单栏中(HybridCLR>>Generate>>All)操作。FolderPath:{folder}");
#elif UNITY_EDITOR_OSX
            Logger.Error($"AOTMetaAssemblies文件夹不存在，请检查是否制作UnityEditor.CoreModule.dll,并修改覆盖Unity安装路径，然后需要你先在菜单栏中(HybridCLR>>Generate>>All)操作。FolderPath:{folder}");
#endif
            return;
        }
        DirectoryInfo root = new DirectoryInfo(folder);
        foreach (var fileInfo in root.GetFiles("*dll", SearchOption.AllDirectories))
        {
            string fileName = fileInfo.Name;
            GameMainSettingsUtils.GameMainHybridCLRSettings.AOTMetaAssemblies.Add(fileName);
        }
        EditorUtility.SetDirty(GameMainSettingsUtils.GameMainHybridCLRSettings);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif
