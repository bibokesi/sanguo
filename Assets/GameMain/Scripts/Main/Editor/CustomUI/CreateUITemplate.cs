﻿using Main.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace GameMain.Editor
{
    public class CreateUITemplate
    {

        [MenuItem("GameObject/CustomUI/Form", false, 1)]
        static void CreateUIPanelObj(MenuCommand menuCommand)
        {
            GameObject panel = SaveObject(menuCommand, "Form");
            panel.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            panel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            panel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            panel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        [MenuItem("GameObject/CustomUI/Model", false, 2)]
        static void CreateUIModel(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "Model");
        }






        [MenuItem("GameObject/CustomUI/Toggle - TextMeshPro", false, 21)]
        static void CreateUIToggle(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "Toggle");
        }

        [MenuItem("GameObject/CustomUI/Button - TextMeshPro", false, 22)]
        static void CreateUISuperButton(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "Button");
        }

        [MenuItem("GameObject/CustomUI/InputField - TextMeshPro", false, 23)]
        static void CreateUIInputField(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "InputField");
        }





        [MenuItem("GameObject/CustomUI/ScrollView/HListScroll View", false, 31)]
        static void CreateHListScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/HListScrollView");
        }

        [MenuItem("GameObject/CustomUI/ScrollView/HGridScroll View", false, 32)]
        static void CreateHGridScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/HGridScrollView");
        }

        [MenuItem("GameObject/CustomUI/ScrollView/VListScroll View", false, 33)]
        static void CreateVListScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/VListScrollView");
        }

        [MenuItem("GameObject/CustomUI/ScrollView/VGridScroll View", false, 34)]
        static void CreateVGridScroll(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/VGridScrollView");
        }

        [MenuItem("GameObject/CustomUI/ScrollView/ScrollVItemPrefab", false, 35)]
        static void CreateScrollVItemPrefab(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "ScrollView/ScrollVItemPrefab");
        }



        [MenuItem("GameObject/CustomUI/UIHealthBar", false, 101)]
        static void CreateUIHealthbar(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "HealthBar");
        }

        [MenuItem("GameObject/CustomUI/SpriteAnimation", false, 102)]
        static void CreateUGUISpriteAnimation(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "SpriteAnimation");
        }

        [MenuItem("GameObject/CustomUI/Radar Map", false, 103)]
        static void CreateUIRadarMap(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "Radar Map");
        }


        static GameObject SaveObject(MenuCommand menuCommand, string prefabName, string objName = "")
        {
            var path = FileUtils.GetPath($@"Assets\GameMain\BaseAssets\UI\Template\{prefabName}.prefab");
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