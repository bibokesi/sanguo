using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameFramework;
using UnityEditor;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UIElements;

public class GameMainHybridCLRSettingsProvider : SettingsProvider
{
    const string k_GameMainSettingsPath = "Assets/GameMain/Resources/Settings/GameMainHybridCLRSettings.asset";
    private const string headerName = "GameMain/GameMainHybridSettings";
    private SerializedObject m_CustomSettings;
    private SerializedProperty m_CompressionHelperTypeName;
    private const string NoneOptionName = "<None>";
    private string[] m_CompressionHelperTypeNames;
    private int m_CompressionHelperTypeNameIndex = 0;

    private static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GameMainSettingsUtils.GameMainHybridCLRSettings);
    }

    private static bool IsSettingsAvailable()
    {
        return File.Exists(k_GameMainSettingsPath);
    }

    public override void OnActivate(string searchContext, VisualElement rootElement)
    {
        base.OnActivate(searchContext, rootElement);
        m_CustomSettings = GetSerializedSettings();
        m_CompressionHelperTypeName = m_CustomSettings.FindProperty("CompressionHelperTypeName");
        List<string> compressionHelperTypeNames = new List<string>
        {
            NoneOptionName
        };

        compressionHelperTypeNames.AddRange( UnityGameFramework.Editor.Type.GetRuntimeOrEditorTypeNames(typeof(Utility.Compression.ICompressionHelper)));
        m_CompressionHelperTypeNames = compressionHelperTypeNames.ToArray();
        m_CompressionHelperTypeNameIndex = 0;
        if (!string.IsNullOrEmpty(m_CompressionHelperTypeName.stringValue))
        {
            m_CompressionHelperTypeNameIndex = compressionHelperTypeNames.IndexOf(m_CompressionHelperTypeName.stringValue);
            if (m_CompressionHelperTypeNameIndex <= 0)
            {
                m_CompressionHelperTypeNameIndex = 0;
                m_CompressionHelperTypeName = null;
            }
        }
    }

    public override void OnGUI(string searchContext)
    {
        base.OnGUI(searchContext);
        using var changeCheckScope = new EditorGUI.ChangeCheckScope();
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("m_Enable"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("m_Gitee"));
#if ENABLE_HYBRID_CLR_UNITY
        if ( GUILayout.Button( "Refresh HotUpdateAssemblies" ) )
        {

            SynAssemblysContent.RefreshAssembly();
            
            m_CustomSettings.ApplyModifiedPropertiesWithoutUndo();
            m_CustomSettings = null;
            m_CustomSettings = GetSerializedSettings();
        }
#endif
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("HotUpdateAssemblies"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("AOTMetaAssemblies"));
        
        int compressionHelperSelectedIndex = EditorGUILayout.Popup("Compression Helper", m_CompressionHelperTypeNameIndex, m_CompressionHelperTypeNames);
        if (compressionHelperSelectedIndex != m_CompressionHelperTypeNameIndex)
        {
            m_CompressionHelperTypeNameIndex = compressionHelperSelectedIndex;
            m_CompressionHelperTypeName.stringValue = compressionHelperSelectedIndex <= 0 ? null : m_CompressionHelperTypeNames[compressionHelperSelectedIndex];
        }
        
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("LogicMainDllName"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("AssemblyAssetExtension"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("HybridCLRDataPath"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("HybridCLRAssemblyPath"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("AssembliesVersionTextFileName"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("HybridCLRIosBuildPath"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("HybridCLRIosXCodePath"));
        EditorGUILayout.Space(20);
        if ( !changeCheckScope.changed ) return;
        m_CustomSettings.ApplyModifiedPropertiesWithoutUndo();
    }
    public GameMainHybridCLRSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords)
    {
    }
    [SettingsProvider]
    private static SettingsProvider CreateSettingProvider()
    {
        if (IsSettingsAvailable())
        {
            var provider = new GameMainHybridCLRSettingsProvider(headerName, SettingsScope.Project);
            provider.keywords = GetSearchKeywordsFromGUIContentProperties<GameMainHybridCLRSettings>();
            return provider;
        }
        return null;
    }
}
