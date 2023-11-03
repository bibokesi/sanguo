using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public static class FrameworkSettingsUtils
{
    private static readonly string FrameworkSettingsPath = $"Settings/FrameworkSettings";
    private static readonly string HybridCLRSettingsPath = $"Settings/HybridCLRSettings";
    private static FrameworkSettings _mFrameworkGlobalSettings;
    private static HybridCLRSettings _mHybridCLRSettings;

    static CustomPathSetting m_CustomPathSetting;
    public static CustomPathSetting CustomPathConfig
    {
        get
        {
            if (m_CustomPathSetting == null)
            {
                m_CustomPathSetting = GetSingletonAssetsByResources<CustomPathSetting>("Settings/CustomPathSetting");
            }
            return m_CustomPathSetting;
        }
    }
    public static FrameworkSettings FrameworkSettings
    {
        get
        {
            if (_mFrameworkGlobalSettings == null)
            {
                _mFrameworkGlobalSettings = GetSingletonAssetsByResources<FrameworkSettings>(FrameworkSettingsPath);
            }
            return _mFrameworkGlobalSettings;
        }
    }
    public static HybridCLRSettings HybridCLRSettings
    {
        get
        {
            if (_mHybridCLRSettings == null)
            {
                _mHybridCLRSettings = GetSingletonAssetsByResources<HybridCLRSettings>(HybridCLRSettingsPath);
            }
            return _mHybridCLRSettings;
        }
    }
    public static ResourcesArea ResourcesArea { get { return FrameworkSettings.ResourcesArea; } }

    public static void SetHybridCLRHotUpdateAssemblies(List<string> hotUpdateAssemblies) 
    {
        foreach (var hotUpdate in hotUpdateAssemblies)
        {
            bool isFind = false;
            List<string> _RepetitionAssembly = new List<string>();
            foreach (var hotUpdateAssembly in HybridCLRSettings.HotUpdateAssemblies)
            {
                if (hotUpdate == hotUpdateAssembly.Assembly)
                {
                    if (isFind)
                    {
                        //_RepetitionAssembly.Add(hotUpdate);
                        Logger.Error("HotUpdateAssemblie is repetition. Name:"+hotUpdate);
                    }
                    isFind = true;
                }
            }
            if (!isFind)
            {
                HybridCLRSettings.HotUpdateAssemblies.Add(new HotUpdateAssemblie("",hotUpdate));
            }
        }

        List<HotUpdateAssemblie> listRemove = new();
        foreach (var hotUpdateAssembly in HybridCLRSettings.HotUpdateAssemblies)
        {
            bool isFind = false;
            foreach (var hotUpdate in hotUpdateAssemblies)
            {
                if (hotUpdate == hotUpdateAssembly.Assembly)
                {
                    isFind = true;
                }
            }
            if (!isFind)
            {
                listRemove.Add(hotUpdateAssembly);
            }
        }
        foreach (var item in listRemove)
        {
            HybridCLRSettings.HotUpdateAssemblies.Remove(item);
        }
        listRemove.Clear();
    }

    public static void SetHybridCLRAOTMetaAssemblies(List<string> aOTMetaAssemblies)
    {
        HybridCLRSettings.AOTMetaAssemblies = aOTMetaAssemblies;
    }

    public static List<string> GetHotUpdateAssemblies(string assetGroupName)
    {
        List<string> hotUpdateAssemblies = new List<string>();
        for (int i = 0; i < HybridCLRSettings.HotUpdateAssemblies.Count; i++)
        {
            var hotUpdateAssembly = HybridCLRSettings.HotUpdateAssemblies.ElementAt(i);
            if (hotUpdateAssembly.AssetGroupName == assetGroupName)
            {
                hotUpdateAssemblies.Add(hotUpdateAssembly.Assembly);
            }
        }
        return hotUpdateAssemblies;
    }

    public static void AddOrRemoveHotUpdateAssemblies(bool isAdd, string assetGroupName,string assemblyName)
    {
        bool isFind = false;
        HotUpdateAssemblie findHotUpdateAssembly = null;
        foreach (var hotUpdateAssembly in HybridCLRSettings.HotUpdateAssemblies)
        {
            if (assemblyName == hotUpdateAssembly.Assembly)
            {
                isFind = true;
                findHotUpdateAssembly = hotUpdateAssembly;
                break;
            }
        }
        if (!isFind)
        {
            if (isAdd)
            {
                HybridCLRSettings.HotUpdateAssemblies.Add(new HotUpdateAssemblie(assetGroupName,assemblyName));
            }
        }
        else
        {
            if (!isAdd)
            {
                HybridCLRSettings.HotUpdateAssemblies.Remove(findHotUpdateAssembly);
            } 
        }
    }

    /// <summary>
    /// app 下载地址
    /// </summary>
    /// <returns></returns>
    public static string GetAppUpdateUrl()
    {
        string url = null;
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        url = FrameworkSettings.WindowsAppUrl;
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
            url = FrameworkSettings.MacOSAppUrl;
#elif UNITY_IOS
            url = FrameworkSettings.IOSAppUrl;
#elif UNITY_ANDROID
            url = FrameworkSettings.AndroidAppUrl;
#endif
        return url;
    }

    public static string GetResDownLoadPath(string fileName = "")
    {
        string adminDir = ResourcesArea.ResAdminType+ResourcesArea.ResAdminCode;
        if (string.IsNullOrEmpty(adminDir))
        {   
            return Path.Combine(CompleteDownLoadPath , GetPlatformName(), fileName).Replace("\\","/");
        }
        else
        {
            return Path.Combine(CompleteDownLoadPath,adminDir , GetPlatformName(), fileName).Replace("\\","/");
        }
    }
    public static string CompleteDownLoadPath
    {
        get
        {
            string url = "";
            if (ResourcesArea.ServerType == ServerTypeEnum.Extranet)
            {
                url = ResourcesArea.ExtraResourceSourceUrl;
            }
            else if (ResourcesArea.ServerType == ServerTypeEnum.Formal)
            {
                url = ResourcesArea.FormalResourceSourceUrl;
            }else
            {
                url = ResourcesArea.InnerResourceSourceUrl;
            }
            return url;
        }
    }

    private static ServerIpAndPort FindServerIpAndPort(string channelName = "")
    {
        if (string.IsNullOrEmpty(channelName))
        {
            channelName = FrameworkSettings.CurUseServerChannel;
        }

        if (string.IsNullOrEmpty(channelName))
        {
            Logger.Error("当前网络频道名为null");
            return null;
        }
        foreach (var serverChannelInfo in FrameworkSettings.ServerChannelInfos)
        {
            if (serverChannelInfo.ChannelName.Equals(channelName))
            {
                foreach (var serverIpAndPort in serverChannelInfo.ServerIpAndPorts)
                {
                    if (serverIpAndPort.ServerName.Equals(serverChannelInfo.CurUseServerName))
                    {
                        return serverIpAndPort;
                    }
                }
            }
        }
        return null;
    }
    public static string GetServerIp(string channelName = "")
    {
        ServerIpAndPort serverIpAndPort = FindServerIpAndPort(channelName);
        if (serverIpAndPort != null)
        {
            return serverIpAndPort.Ip;
        }
        return string.Empty;
    }
    public static int GetServerPort(string channelName = "")
    {
        ServerIpAndPort serverIpAndPort = FindServerIpAndPort(channelName);
        if (serverIpAndPort != null)
        {
            return serverIpAndPort.Port;
        }
        return 0;
    }

    public static void SetCurUseServerChannel(string channelName = "Default")
    {
        FrameworkSettings.CurUseServerChannel = channelName;
    }

    public static void AddServerChannel(string ip, int port, string serverName,bool isUse,string channelName = "Default")
    {
        if (!string.IsNullOrEmpty(channelName))
        {
            ServerChannelInfo findServerChannelInfo = null; 
            foreach (var serverChannelInfo in FrameworkSettings.ServerChannelInfos)
            {
                if (serverChannelInfo.ChannelName.Equals(channelName))
                {
                    findServerChannelInfo = serverChannelInfo;
                    break;
                }
            }
            if (findServerChannelInfo != null)
            {
                if (findServerChannelInfo.ServerIpAndPorts != null)
                {
                    bool isFind = false;
                    foreach (var serverIpAndPort in findServerChannelInfo.ServerIpAndPorts)
                    {
                        if (serverIpAndPort.ServerName == serverName)
                        {
                            isFind = true;
                            if (isUse)
                            {
                                findServerChannelInfo.CurUseServerName = serverName;
                            }
                            serverIpAndPort.Ip = ip;
                            serverIpAndPort.Port = port;
                            break;
                        }
                    }
                    if (!isFind)
                    {
                        if (isUse)
                        {
                            findServerChannelInfo.CurUseServerName = serverName;
                        }
                        findServerChannelInfo.ServerIpAndPorts.Add(new ServerIpAndPort(serverName,ip,port));
                    }
                }
                else
                {
                    findServerChannelInfo.ChannelName = channelName;
                    findServerChannelInfo.CurUseServerName = serverName;
                    findServerChannelInfo.ServerIpAndPorts = new List<ServerIpAndPort>();
                    findServerChannelInfo.ServerIpAndPorts.Add(new ServerIpAndPort(serverName,ip,port));
                }
            }
            else
            {
                FrameworkSettings.ServerChannelInfos.Add(new ServerChannelInfo(channelName,serverName,new List<ServerIpAndPort>()
                {
                    new ServerIpAndPort(serverName,ip,port)
                }));
            }
        }
    }

    private static T GetSingletonAssetsByResources<T>(string assetsPath) where T : ScriptableObject, new()
    {
        string assetType = typeof(T).Name;
#if UNITY_EDITOR
        string[] globalAssetPaths = UnityEditor.AssetDatabase.FindAssets($"t:{assetType}");
        if (globalAssetPaths.Length > 1)
        {
            foreach (var assetPath in globalAssetPaths)
            {
                Debug.LogError($"不能有多个 {assetType}. 路径: {UnityEditor.AssetDatabase.GUIDToAssetPath(assetPath)}");
            }
            throw new Exception($"不能有多个 {assetType}");
        }
#endif
        T customGlobalSettings = Resources.Load<T>(assetsPath);
        if (customGlobalSettings == null)
        {
            Logger.Error($"没找到 {assetType} asset，自动创建创建一个:{assetsPath}.");
            return null;
        }

        return customGlobalSettings;
    }
    /// <summary>
    /// 平台名字
    /// </summary>
    /// <returns></returns>
    public static string GetPlatformName()
    {
#if UNITY_EDITOR
        switch (EditorUserBuildSettings.activeBuildTarget)
        {
            case BuildTarget.StandaloneWindows:
                return "Windows64";
            case BuildTarget.StandaloneWindows64:
                return "Windows64";
            case BuildTarget.StandaloneOSX:
                return "";
            case BuildTarget.Android:
                return "Android";
            case BuildTarget.iOS:
                return "IOS";
            case BuildTarget.WebGL:
                return "";
            case BuildTarget.WSAPlayer:
                return "";
            default:
                throw new System.NotSupportedException(string.Format("Platform '{0}' is not supported.",
                    Application.platform.ToString()));
        }
#else 
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                return "Windows64";
            case RuntimePlatform.WindowsPlayer:
                return "Windows64";
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                return "MacOS";
            case RuntimePlatform.IPhonePlayer:
                return "IOS";
            case RuntimePlatform.Android:
                return "Android";

            default:
                throw new System.NotSupportedException(string.Format("Platform '{0}' is not supported.",
                    Application.platform.ToString()));
        }
#endif
    }

    public static string HotfixNode = "Hotfix";
    public static string AotNode = "AOT";
    /// <summary>
    /// 热更程序集文件资源地址
    /// </summary>
    public static string HotfixAssemblyTextAssetPath()
    {
        return Path.Combine(Application.dataPath,"..", HybridCLRSettings.HybridCLRDataPath,HybridCLRSettings.HybridCLRAssemblyPath,HotfixNode);
    }

    /// <summary>
    /// AOT程序集文件资源地址
    /// </summary>
    public static string AOTAssemblyTextAssetPath
    {
        get { return Path.Combine(Application.dataPath,"..", HybridCLRSettings.HybridCLRDataPath,HybridCLRSettings.HybridCLRAssemblyPath, AotNode); }
    }
    /// <summary>
    /// AOT程序集文件资源地址
    /// </summary>
    public static string HybridCLRAssemblyPath
    {
        get { return Path.Combine(Application.dataPath,"..", HybridCLRSettings.HybridCLRDataPath,HybridCLRSettings.HybridCLRAssemblyPath); }
    }
    public static string GetLibil2cppBuildPath()
    {
        return $"{HybridCLRSettings.HybridCLRIosBuildPath}/build";
    }
    
    public static string GetOutputXCodePath()
    {
        return HybridCLRSettings.HybridCLRIosXCodePath;
    }
}