using GameMain;
using System.Collections;
using System.Collections.Generic;
using HotfixFramework.Runtime;
using UnityEngine;

public static class AssetObjectComponentExtension
{
	public static int LoadGameObject(this AssetObjectComponent assetObjectComponent, string strPath, string strShowName, LoadAssetObjectComplete loadAssetObjectComplete = null)
	{
		return assetObjectComponent.LoadAssetAsync(strPath, strShowName, typeof(GameObject), loadAssetObjectComplete);
	}
	public static int LoadTexture2D(this AssetObjectComponent assetObjectComponent, string strPath, string strShowName, LoadAssetObjectComplete loadAssetObjectComplete = null)
	{
		return assetObjectComponent.LoadAssetAsync(strPath, strShowName, typeof(Texture2D), loadAssetObjectComplete);
	}
	public static void LoadAnimatorControllerCollection(this AssetObjectComponent assetObjectComponent, int nLoadSerial, string strPath, string strShowName, LoadAssetObjectComplete loadAssetObjectComplete = null)
	{
		//assetObjectComponent.LoadAssetAsync(nLoadSerial, strPath, strShowName, typeof(AnimatorControllerCollection), loadAssetObjectComplete);
	}
}