// ================================================
//描 述:
//作 者:AlanDu
//创建时间:2023-07-13 11-31-26
//修改作者:AlanDu
//修改时间:2023-07-13 11-31-26
//版 本:0.1 
// ===============================================
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
        m_LoadAssemblies = DeerSettingsUtils.GetHotUpdateAssemblies(groupName);
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
                string fileName = assemblyInfo.IsLoadReadOnly ? $"{assemblyInfo.Name}.{assemblyInfo.HashCode}{DeerSettingsUtils.DeerHybridCLRSettings.AssemblyAssetExtension}" : $"{assemblyInfo.Name}{DeerSettingsUtils.DeerHybridCLRSettings.AssemblyAssetExtension}";
                LoadBytes(Utility.Path.GetRemotePath(Path.Combine(assemblyInfo.IsLoadReadOnly ? GameEntryMain.Resource.ReadOnlyPath : GameEntryMain.Resource.ReadWritePath,DeerSettingsUtils.DeerHybridCLRSettings.HybridCLRAssemblyPath, assemblyInfo.PathRoot, fileName)), 
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

        Debug.LogError("zhTest count = " + DeerSettingsUtils.DeerHybridCLRSettings.AOTMetaAssemblies.Count);
        if (DeerSettingsUtils.DeerHybridCLRSettings.AOTMetaAssemblies.Count == 0)
        {
            //m_OnLoadAotAssembliesCompleteCallback?.Invoke(new());
            //return;
        }
        string mergedFileName = AssemblyFileData.GetMergedFileName();
        AssemblyInfo assemblyInfo = FindAssemblyInfoByName(mergedFileName);
        if (assemblyInfo != null)
        {
            string fileName = assemblyInfo.IsLoadReadOnly ? $"{assemblyInfo.Name}.{assemblyInfo.HashCode}{DeerSettingsUtils.DeerHybridCLRSettings.AssemblyAssetExtension}" : $"{assemblyInfo.Name}{DeerSettingsUtils.DeerHybridCLRSettings.AssemblyAssetExtension}";
            LoadBytes(Utility.Path.GetRemotePath(Path.Combine(assemblyInfo.IsLoadReadOnly ? GameEntryMain.Resource.ReadOnlyPath : GameEntryMain.Resource.ReadWritePath,DeerSettingsUtils.DeerHybridCLRSettings.HybridCLRAssemblyPath, assemblyInfo.PathRoot, fileName)), 
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

        List<string> list = new List<string>();
        list.Add("Assembly-CSharp-firstpass.dll");
        list.Add("Assembly-CSharp.dll");
        list.Add("AstarPathfindingProject.dll");
        list.Add("BrunoMikoski.AnimationSequencer.dll");
        list.Add("CatJson.dll");
        list.Add("Cinemachine.dll");
        list.Add("DOTween.dll");
        list.Add("DOTween.Modules.dll");
        list.Add("DOTweenPro.dll");
        list.Add("GameFramework.dll");
        list.Add("Google.Protobuf.dll");
        list.Add("HybridCLR.Runtime.dll");
        list.Add("ICSharpCode.SharpZipLib.dll");
        list.Add("JoystickPack.dll");
        list.Add("LeanCommon.dll");

        list.Add("LeanCommonPlus.dll");
        list.Add("LeanTouch.dll");
        list.Add("LeanTouchPlus.dll");
        list.Add("Main.Runtime.dll");
        list.Add("MinimalistBarSystem.dll");
        list.Add("Mono.Security.dll");
        list.Add("mscorlib.dll");
        list.Add("Pathfinding.ClipperLib.dll");
        list.Add("Pathfinding.Ionic.Zip.Reduced.dll");
        list.Add("Pathfinding.Poly2Tri.dll");
        list.Add("PlayerPrefsEditor.dll");
        list.Add("QHierarchyNullable.dll");
        list.Add("QHierarchyRuntime.dll");
        list.Add("RaycastGizmosVisualizer.dll");
        list.Add("Sirenix.OdinInspector.Attributes.dll");
        list.Add("Sirenix.Serialization.Config.dll");
        list.Add("Sirenix.Serialization.dll");
        list.Add("Sirenix.Utilities.dll");

        list.Add("SuperScrollViewProject.dll");
        list.Add("System.Configuration.dll");
        list.Add("System.Core.dll");
        list.Add("System.dll");
        list.Add("System.Numerics.dll");
        list.Add("System.Runtime.CompilerServices.Unsafe.dll");
        list.Add("System.Xml.dll");
        list.Add("UIExtensions.dll");
        list.Add("UniTask.Addressables.dll");
        list.Add("UniTask.dll");
        list.Add("UniTask.DOTween.dll");
        list.Add("UniTask.Linq.dll");
        list.Add("UniTask.TextMeshPro.dll");
        list.Add("Unity.Burst.dll");
        list.Add("Unity.Burst.Unsafe.dll");
        list.Add("Unity.InputSystem.dll");
        list.Add("Unity.Mathematics.dll");
        list.Add("Unity.Networking.BackgroundDownload.dll");

        list.Add("Unity.RenderPipeline.Universal.ShaderLibrary.dll");
        list.Add("Unity.RenderPipelines.Core.Runtime.dll");
        list.Add("Unity.RenderPipelines.Universal.Runtime.dll");
        list.Add("Unity.TextMeshPro.dll");
        list.Add("Unity.Timeline.dll");
        list.Add("UnityEngine.AndroidJNIModule.dll");
        list.Add("UnityEngine.AnimationModule.dll");
        list.Add("UnityEngine.AssetBundleModule.dll");
        list.Add("UnityEngine.AudioModule.dll");
        list.Add("UnityEngine.CoreModule.dll");
        list.Add("UnityEngine.DirectorModule.dll");
        list.Add("UnityEngine.dll");
        list.Add("UnityEngine.GridModule.dll");
        list.Add("UnityEngine.ImageConversionModule.dll");
        list.Add("UnityEngine.IMGUIModule.dll");
        list.Add("UnityEngine.InputLegacyModule.dll");
        list.Add("UnityEngine.InputModule.dll");

        list.Add("UnityEngine.JSONSerializeModule.dll");
        list.Add("UnityEngine.ParticleSystemModule.dll");
        list.Add("UnityEngine.Physics2DModule.dll");
        list.Add("UnityEngine.PhysicsModule.dll");
        list.Add("UnityEngine.SharedInternalsModule.dll");
        list.Add("UnityEngine.SpriteShapeModule.dll");
        list.Add("UnityEngine.SubsystemsModule.dll");
        list.Add("UnityEngine.TerrainModule.dll");
        list.Add("UnityEngine.TextCoreFontEngineModule.dll");
        list.Add("UnityEngine.TextCoreTextEngineModule.dll");
        list.Add("UnityEngine.TextRenderingModule.dll");
        list.Add("UnityEngine.TilemapModule.dll");
        list.Add("UnityEngine.UI.dll");
        list.Add("UnityEngine.UIElementsModule.dll");
        list.Add("UnityEngine.UIElementsNativeModule.dll");
        list.Add("UnityEngine.UIModule.dll");
        list.Add("UnityEngine.UnityAnalyticsModule.dll");
        list.Add("UnityEngine.UnityWebRequestAudioModule.dll");

        list.Add("UnityEngine.UnityWebRequestModule.dll");
        list.Add("UnityEngine.VRModule.dll");
        list.Add("UnityEngine.XRModule.dll");
        list.Add("UnityGameFramework.Runtime.dll");

        foreach (var assemblyName in list)
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