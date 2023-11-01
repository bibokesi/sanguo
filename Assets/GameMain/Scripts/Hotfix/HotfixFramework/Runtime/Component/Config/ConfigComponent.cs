using System.Collections.Generic;
using CatJson;
using cfg;
using GameFramework.Localization;
using UnityEngine;
using UnityGameFramework.Runtime;

[DisallowMultipleComponent]
[AddComponentMenu("GameMain/Config")]
public class ConfigComponent : GameFrameworkComponent
{
    private ConfigManager m_ConfigManager;
    public Tables Tables { get; set; }
    protected override void Awake()
    {
        base.Awake();
        m_ConfigManager = gameObject.GetOrAddComponent<ConfigManager>();
    }
    public async void LoadAllUserConfig(OnLoadConfigCompleteCallback loadConfigCompleteCallback)
    {
        Tables = await m_ConfigManager.LoadAllUserConfig();
        LocalizationParseData();
        loadConfigCompleteCallback(true);
    }
    public void LocalizationParseData()
    {
        JsonParser parser = new JsonParser();
        Dictionary<Language, Dictionary<int, string>> dic = new Dictionary<Language, Dictionary<int, string>>();
        Dictionary<int, string> english = new Dictionary<int, string>();
        Dictionary<int, string> schinese = new Dictionary<int, string>();
        foreach (var item in Tables.TbLanguage_Config.DataList)
        {
            english.Add(item.Id, item.English);
            schinese.Add(item.Id, item.Schinese);
        }
        dic.Add(Language.English, english);
        dic.Add(Language.ChineseSimplified, schinese);
        string jsonStr = parser.ToJson(dic);
        GameEntry.Localization.ParseData(jsonStr, Tables.TbLanguage_Config);
    }
}