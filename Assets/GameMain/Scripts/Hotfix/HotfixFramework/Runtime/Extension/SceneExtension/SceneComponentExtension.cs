using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public static class SceneComponentExtension
    {
        public static void LoadSceneEx(this SceneComponent sceneComponent,string sceneName, int priority, object userData) 
        {
            string sceneFullName = AssetUtility.Scene.GetTempSceneAsset(sceneName);
            sceneComponent.LoadScene(sceneFullName, priority, userData);
        }
    }
}