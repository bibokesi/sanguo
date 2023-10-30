using UnityEngine;
/// <summary>
/// 优化设置界面
/// </summary>
[CreateAssetMenu(fileName = "DeerPathSetting", menuName = "Deer/Deer Path Setting", order = 40)]
public class DeerPathSetting : ScriptableObject
{
    [Header("Sublime文件路径")]
    [SerializeField]
    private string m_SublimePath = "";
    public string SublimePath => m_SublimePath;

    [Header("Notepad++文件路径")]
    [SerializeField]
    private string m_NotepadPath = "";
    public string NotepadPath => m_NotepadPath;

    [Header("SpriteCollection 图集资源存放地")]
    [SerializeField]
    private string m_AtlasFolder = "Assets/Deer/Atlas/";
    public string AtlasFolder => m_AtlasFolder;
        
    [Header("ResourceCollection Config Path")]
    [SerializeField]
    private string m_ResourceCollectionPath = "";
    //Assets/Deer/GameConfigs/ResourceRuleEditor.asset
    public string ResourceCollectionPath => m_ResourceCollectionPath;
}