using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HotUpdateAssemblie
{
    public string AssetGroupName;
    public string Assembly;

    public HotUpdateAssemblie(string assetGroupName,string assembly)
    {
        AssetGroupName = assetGroupName;
        Assembly = assembly;
    }
}

/// <summary>
/// HybridCLR 自定义全局设置
/// </summary>
[CreateAssetMenu(fileName = "HybridCLRSettings", menuName = "GameMain/HybridCLR Settings", order = 41)]
public class HybridCLRSettings:ScriptableObject
{
    [Header("Auto sync with [HybridCLRSettings]")]
    [Tooltip("You should modify the file form file path [Assets/CustomHybridCLR/Settings/HybridCLRSettings.asset]")]
    [SerializeField] private bool m_Enable = false;
    public bool Enable { get { return m_Enable; }
        set { m_Enable = value; }
    }
    [SerializeField] private bool m_Gitee = true;
    public bool Gitee { get { return m_Gitee; }
        set { m_Gitee = value; }
    }
    [Header("Click up button sync with [HybridCLRSettings]")]
    //[Tooltip("You should modify the file form file path [Assets/CustomHybridCLR/Settings/HybridCLRSettings.asset]")]
    
    [SerializeField] public List<HotUpdateAssemblie> HotUpdateAssemblies;
    //[Header("Need manual setting!")]
    [SerializeField] public List<string> AOTMetaAssemblies;
    
    [SerializeField]
    public string CompressionHelperTypeName;
    
    /// <summary>
    /// Dll of main business logic assembly
    /// </summary>
    public string LogicMainDllName = "Hotfix.dll";

    /// <summary>
    /// 程序集文本资产打包Asset后缀名
    /// </summary>
    public string AssemblyAssetExtension = ".bytes";
    public string HybridCLRDataPath = "HybridCLRData";
    public string HybridCLRAssemblyPath = "HybridCLRAssemblies";
    public string AssembliesVersionTextFileName = "AssembliesVersion.dat";
    public string HybridCLRIosBuildPath = "HybridCLRData/iOSBuild";
    public string HybridCLRIosXCodePath = "";

}