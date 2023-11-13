using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeshTools
{
    [MenuItem("GameMainTools/MeshTools/SetOptimizeGameObjects")]
    public static void Optimize()
    {
        var fbxGo = Selection.activeGameObject;
        var fbxPath = AssetDatabase.GetAssetPath(fbxGo);
        var importer = AssetImporter.GetAtPath(fbxPath) as ModelImporter;
        if (importer == null)
        {
            return;
        }
        importer.optimizeGameObjects = true;
        importer.SaveAndReimport();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    [MenuItem("GameMainTools/MeshTools/UndoOptimizeGameObjects")]
    public static void UndoOptimize()
    {
        var fbxGo = Selection.activeGameObject;
        var fbxPath = AssetDatabase.GetAssetPath(fbxGo);//获取fbx在Project中的路径
        var importer = AssetImporter.GetAtPath(fbxPath) as ModelImporter;
        if (importer == null)
        {
            return;
        }
        importer.optimizeGameObjects = false;
        importer.SaveAndReimport();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    [MenuItem("GameMainTools/MeshTools/SearchSkinnedMeshRenderer")]
    public static void SearchSkinnedMeshRenderer()
    {
        var fbxGos = Selection.gameObjects;
        for (int i = 0; i < fbxGos.Length; i++)
        {
            SkinnedMeshRenderer[] skinnedMeshRenderers = fbxGos[i].GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int j = 0; j < skinnedMeshRenderers.Length; j++)
            {
                if (skinnedMeshRenderers[j].skinnedMotionVectors)
                {
                    Debug.Log($"Prefab:{fbxGos[i].name} RootName:{skinnedMeshRenderers[j].gameObject.name} skinnedMotionVectors is True");
                }
            }
        }
    }
    [MenuItem("GameMainTools/MeshTools/SetSkinnedMeshRenderer")]
    public static void SetSkinnedMeshRenderer() 
    {
        var fbxGos = Selection.gameObjects;
        for (int i = 0; i < fbxGos.Length; i++)
        {
            SkinnedMeshRenderer[] skinnedMeshRenderers = fbxGos[i].GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int j = 0; j < skinnedMeshRenderers.Length; j++)
            {
                if (skinnedMeshRenderers[j].skinnedMotionVectors)
                {
                    skinnedMeshRenderers[j].skinnedMotionVectors = false;
                }
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

}