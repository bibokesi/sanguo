using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameFramework;
using GameFramework.Resource;
using UnityEngine;

/// <summary>
/// 程序集管理器，程序集读取
/// </summary>
public partial class AssembliesManager
{
    private OnLoadAssembliesCompleteCallback m_OnLoadHotfixAssembliesCompleteCallback;
    private OnLoadAssembliesCompleteCallback m_OnLoadAotAssembliesCompleteCallback;
    private int m_LoadHotfixAssemblyCount = 0;
    private Dictionary<string,byte[]> m_LoadHotfixAssemblyBytes = new();
    private Dictionary<string,byte[]> m_LoadAotAssemblyBytes = new();
    private List<string> m_LoadAssemblies;
    public void LoadHotUpdateAssembliesByGroupName(string groupName,OnLoadAssembliesCompleteCallback onLoadAssembliesComplete)
    {
        m_LoadHotfixAssemblyBytes.Clear();
        m_OnLoadHotfixAssembliesCompleteCallback = onLoadAssembliesComplete;
        m_LoadAssemblies = FrameworkSettingsUtils.GetHotUpdateAssemblies(groupName);
        m_LoadHotfixAssemblyCount = m_LoadAssemblies.Count;
        if (m_LoadHotfixAssemblyCount == 0)
        {
            m_OnLoadHotfixAssembliesCompleteCallback?.Invoke(new());
            return;
        }
        foreach (var assemblyName in m_LoadAssemblies)
        {
            AssemblyInfo assemblyInfo = FindAssemblyInfoByName(assemblyName);
            if (assemblyInfo !=null)
            {
                string fileName = assemblyInfo.IsLoadReadOnly ? $"{assemblyInfo.Name}.{assemblyInfo.HashCode}{FrameworkSettingsUtils.GameMainHybridCLRSettings.AssemblyAssetExtension}" : $"{assemblyInfo.Name}{FrameworkSettingsUtils.GameMainHybridCLRSettings.AssemblyAssetExtension}";
                LoadBytes(Utility.Path.GetRemotePath(Path.Combine(assemblyInfo.IsLoadReadOnly ? GameEntryMain.Resource.ReadOnlyPath : GameEntryMain.Resource.ReadWritePath,FrameworkSettingsUtils.GameMainHybridCLRSettings.HybridCLRAssemblyPath, assemblyInfo.PathRoot, fileName)), 
                    new LoadBytesCallbacks(OnLoadHotfixAssemblySuccess, OnLoadHotfixAssemblyFailure), assemblyInfo);
            }
        }
    }
    /// <summary>
    /// 为aot assembly加载原始metadata， 这个代码放aot或者热更新都行。
    /// 一旦加载后，如果AOT泛型函数对应native实现不存在，则自动替换为解释模式执行
    /// </summary>
    public void LoadMetadataForAOTAssembly(OnLoadAssembliesCompleteCallback onLoadAssembliesComplete)
    {
        m_LoadAotAssemblyBytes.Clear();
        m_OnLoadAotAssembliesCompleteCallback = onLoadAssembliesComplete;
        // 可以加载任意aot assembly的对应的dll。但要求dll必须与unity build过程中生成的裁剪后的dll一致，而不能直接使用原始dll。
        // 我们在BuildProcessor_xxx里添加了处理代码，这些裁剪后的dll在打包时自动被复制到 {项目目录}/HybridCLRData/AssembliesPostIl2CppStrip/{Target} 目录。

        // 注意，补充元数据是给AOT dll补充元数据，而不是给热更新dll补充元数据。
        // 热更新dll不缺元数据，不需要补充，如果调用LoadMetadataForAOTAssembly会返回错误

        if (FrameworkSettingsUtils.GameMainHybridCLRSettings.AOTMetaAssemblies.Count == 0)
        {
            //m_OnLoadAotAssembliesCompleteCallback?.Invoke(new());
            //return;
        }
        string mergedFileName = AssemblyFileData.GetMergedFileName();
        AssemblyInfo assemblyInfo = FindAssemblyInfoByName(mergedFileName);
        if (assemblyInfo != null)
        {
            string fileName = assemblyInfo.IsLoadReadOnly ? $"{assemblyInfo.Name}.{assemblyInfo.HashCode}{FrameworkSettingsUtils.GameMainHybridCLRSettings.AssemblyAssetExtension}" : $"{assemblyInfo.Name}{FrameworkSettingsUtils.GameMainHybridCLRSettings.AssemblyAssetExtension}";
            LoadBytes(Utility.Path.GetRemotePath(Path.Combine(assemblyInfo.IsLoadReadOnly ? GameEntryMain.Resource.ReadOnlyPath : GameEntryMain.Resource.ReadWritePath,FrameworkSettingsUtils.GameMainHybridCLRSettings.HybridCLRAssemblyPath, assemblyInfo.PathRoot, fileName)), 
                new LoadBytesCallbacks(OnLoadAotAssemblySuccess, OnLoadAotAssemblyFailure), assemblyInfo);
        }
    }

    private void OnLoadHotfixAssemblyFailure(string fileUri, string errorMessage, object userData)
    {
        throw new GameFrameworkException(Utility.Text.Format("Load assembly '{0}' is invalid, error message is '{1}'.", fileUri, string.IsNullOrEmpty(errorMessage) ? "<Empty>" : errorMessage));
    }
    private void OnLoadHotfixAssemblySuccess(string fileUri, byte[] bytes, float duration, object userData)
    {
        AssemblyInfo assemblyInfo = userData as AssemblyInfo;
        m_LoadHotfixAssemblyCount--;
        byte[] newBytes = Utility.Compression.Decompress(bytes);
        if (assemblyInfo != null) m_LoadHotfixAssemblyBytes.Add(assemblyInfo.Name, newBytes);
        if (m_LoadHotfixAssemblyCount == 0)
        {
            Dictionary<string,byte[]> dic = new Dictionary<string,byte[]>(m_LoadHotfixAssemblyBytes);
            m_LoadHotfixAssemblyBytes.Clear();
            for (int i = 0; i < m_LoadAssemblies.Count; i++)
            {
                var item = m_LoadAssemblies.ElementAt(i);
                if (dic.ContainsKey(item))
                {
                    m_LoadHotfixAssemblyBytes.Add(item,dic[item]);
                }
            }
            m_OnLoadHotfixAssembliesCompleteCallback?.Invoke(m_LoadHotfixAssemblyBytes);
            m_OnLoadHotfixAssembliesCompleteCallback = null;
        }
    }
    private void OnLoadAotAssemblyFailure(string fileUri, string errorMessage, object userData)
    {
        throw new GameFrameworkException(Utility.Text.Format("Load assembly '{0}' is invalid, error message is '{1}'.", fileUri, string.IsNullOrEmpty(errorMessage) ? "<Empty>" : errorMessage));
    }

    private void OnLoadAotAssemblySuccess(string fileUri, byte[] bytes, float duration, object userData)
    {
        byte[] newBytes = Utility.Compression.Decompress(bytes);
        using MemoryStream stream = new MemoryStream(newBytes);
        using BinaryReader binaryReader = new BinaryReader(stream);
        foreach (var assemblyName in FrameworkSettingsUtils.GameMainHybridCLRSettings.AOTMetaAssemblies)
        {
            AssemblyFileData assemblyFileData = FindAssemblyFileDataByName(assemblyName);
            if (assemblyFileData != null)
            {
                stream.Seek(assemblyFileData.StartPosition, SeekOrigin.Begin);
                int length = (int)(assemblyFileData.EndPosition - assemblyFileData.StartPosition + 1);
                byte[] byteArray = binaryReader.ReadBytes(length);
                m_LoadAotAssemblyBytes.Add(assemblyFileData.Name, byteArray);
            }
        }
        stream.Close();
        stream.Dispose();
        m_OnLoadAotAssembliesCompleteCallback?.Invoke(m_LoadAotAssemblyBytes);
        m_OnLoadAotAssembliesCompleteCallback = null;
    }
}