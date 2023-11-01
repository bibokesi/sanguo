using Main.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace GameMain.Editor
{
    public class CreateUITemplatePrefab
    {
        #region 0 - 9
        [MenuItem("GameObject/UIGameMain/UIForm", false, 0)]
        static void CreateUIPanelObj(MenuCommand menuCommand)
        {
            GameObject panel = SaveObject(menuCommand, "UIForm");
            panel.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            panel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            panel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            panel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        #endregion

        #region 10 - 59
        //10 - 12  In OverrideUIComponent class
        [MenuItem("GameObject/UIGameMain/UIModel", false, 23)]
        static void CreateUIModel(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "UIModel");
        }
        [MenuItem("GameObject/UIGameMain/Toggle - TextMeshPro", false, 24)]
        static void CreateUIToggle(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "UIToggle");
        }
        [MenuItem("GameObject/UIGameMain/Button - TextMeshPro", false, 25)]
        static void CreateUISuperButton(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "UIButton");
        }

        [MenuItem("GameObject/UIGameMain/InputField - TextMeshPro", false, 28)]
        static void CreateUIInputField(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "UIInputField");
        }
        [MenuItem("GameObject/UIGameMain/Radar Map", false, 29)]
        static void CreateUIRadarMap(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "Radar Map");
        }

        #endregion

        #region 60 - 69
        [MenuItem("GameObject/UIGameMain/UIHealthBar", false, 60)]
        static void CreateUIHealthbar(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "UIHealthBar");
        }
        [MenuItem("GameObject/UIGameMain/SpriteAnimation", false, 61)]
        static void CreateUGUISpriteAnimation(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "UISpriteAnimation");
        }
        #endregion

        #region All ScrollView
        [MenuItem("GameObject/UIGameMain/All ScrollView/HListScroll View", false, 101)]
        static void CreateHListScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/HListScrollView");
        }
        [MenuItem("GameObject/UIGameMain/All ScrollView/HGridScroll View", false, 102)]
        static void CreateHGridScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/HGridScrollView");
        }
        [MenuItem("GameObject/UIGameMain/All ScrollView/VListScroll View", false, 103)]
        static void CreateVListScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/VListScrollView");
        }
        [MenuItem("GameObject/UIGameMain/All ScrollView/VGridScroll View", false, 104)]
        static void CreateVGridScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/VGridScrollView");
        }
        [MenuItem("GameObject/UIGameMain/All ScrollView/ScrollVItemPrefab", false, 105)]
        static void CreateScrollVItemPrefab(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/ScrollVItemPrefab");
        }
        #endregion

        static GameObject SaveObject(MenuCommand menuCommand, string prefabName, string objName = "")
        {
            var path = FileUtils.GetPath($@"Assets\GameMain\AssetsHotfix\BaseAssets\UITemplate\{prefabName}.prefab");
            GameObject prefab = (GameObject)AssetDatabase.LoadMainAssetAtPath(path);
            if (prefab)
            {
                GameObject inst = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                if (!string.IsNullOrEmpty(objName))
                {
                    inst.name = objName;
                }
                if (inst.name.Contains("(Clone)"))
                {
                    inst.name = inst.name[..^7];
                }

                var img = inst.GetComponent<Image>();
                if (img)
                {
                    img.color = new Color(1, 1, 1, 1);
                }
                var text = inst.GetComponent<Text>();
                if (text)
                {
                    text.text = "";
                }
                GameObjectUtility.SetParentAndAlign(inst, menuCommand.context as GameObject);
                Undo.RegisterCreatedObjectUndo(inst, $"Create {inst.name}__" + inst.name);
                Selection.activeObject = inst;
                AssetDatabase.Refresh();
                AssetDatabase.SaveAssets();
                return inst;
            }
            return null;
        }
    }
}
