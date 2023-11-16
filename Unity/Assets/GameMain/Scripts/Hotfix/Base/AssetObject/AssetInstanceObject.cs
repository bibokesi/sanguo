﻿using GameFramework;
using GameFramework.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetInstanceObject : ObjectBase
{
    private object m_AssetObject;

    public AssetInstanceObject()
    {
        m_AssetObject = null;
    }


    public static AssetInstanceObject Create(string name, object unityObjectAsset, object uiFormInstance)
    {
        if (unityObjectAsset == null)
        {
            throw new GameFrameworkException("Asset is invalid.");
        }

        AssetInstanceObject unityAssetObject = ReferencePool.Acquire<AssetInstanceObject>();
        unityAssetObject.Initialize(name, uiFormInstance);
        unityAssetObject.m_AssetObject = unityObjectAsset;
        return unityAssetObject;
    }

    public override void Clear()
    {
        base.Clear();
        m_AssetObject = null;

    }

    protected override void Release(bool isShutdown)
    {
        GameEntry.Resource.UnloadAsset(m_AssetObject);
        UnityEngine.Object.Destroy((Object)Target);
    }
}
