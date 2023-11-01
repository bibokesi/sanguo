using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Main.Runtime;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor;

/// <summary>
/// 一键添加和移除GameMain例子
/// </summary>
public static class OneKeyAddOrRemoveGameMainExample
{
	private const string EnableEXAMPLE = "UNITY_ENABLE_GAMEMAIN_EXAMPLE";
	private static readonly BuildTargetGroup[] BuildTargetGroups = new BuildTargetGroup[]
	{
		BuildTargetGroup.Standalone,
		BuildTargetGroup.iOS,
		BuildTargetGroup.Android,
		BuildTargetGroup.WSA,
		BuildTargetGroup.WebGL
	};
	private static Dictionary<string,string> m_DicExamplePaths = new Dictionary<string, string>()
	{
		["Assets/GameMain/AssetsHotfix/GameMainExample1"] = "1",
		["Assets/GameMain/AssetsHotfix/GameMainExample2"] = "1",
		["Assets/GameMain/Scripts/Hotfix/GameMainExample1"] = "1",
		["Assets/GameMain/Scripts/Hotfix/GameMainExample2"] = "1",
		["Assets/Standard Assets/GameMainExample1"] = "1",
	};
	// 将"Assets/MyFolder"移动到“项目根路径/MyFolder”
	private static string m_DestFolderPath = Application.dataPath + "/../GameMainExample/";
	[MenuItem("GameMainTools/GameMainExample/AddExample")]
	public static void AddGameMainExample()
	{
		if (!Directory.Exists(m_DestFolderPath))
		{
			Logger.Warning("Path is not find, If there are examples in the project, remove them first[GameMainTools/GameMainExample/RemoveExample]. Path:"+ m_DestFolderPath);
			return;
		}
		foreach (var dicExample in m_DicExamplePaths)
		{
			string srcFolderPath = m_DestFolderPath + dicExample.Key;
			string strAsset = "Assets";
			string destFolderPath = Application.dataPath + dicExample.Key.Remove(dicExample.Key.IndexOf(strAsset, StringComparison.Ordinal),strAsset.Length);
			if (Directory.Exists(srcFolderPath))
			{
				FolderUtils.CopyFolder(srcFolderPath,destFolderPath);
			}

			if (File.Exists(srcFolderPath))
			{
				FileInfo destFileInfo = new FileInfo(destFolderPath);
				if (destFileInfo.Directory != null && !destFileInfo.Directory.Exists)
				{
					destFileInfo.Directory.Create();
				}
				File.Copy(srcFolderPath, destFolderPath, true);
			}
		}
		//Enable();
		AddOrRemoveAssembly(true);
		GameMainSettingsUtils.GameMainGlobalSettings.m_UseGameMainExample = true;
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		
	}
	[MenuItem("GameMainTools/GameMainExample/RemoveExample")]
	public static void RemoveGameMainExample()
	{
		if (!Directory.Exists(m_DestFolderPath))
		{
			Directory.CreateDirectory(m_DestFolderPath);
		}
		foreach (var dicExample in m_DicExamplePaths)
		{
			string destFolderPath = m_DestFolderPath +dicExample.Key;
			string strAsset = "Assets";
			string srcFolderPath = Application.dataPath+dicExample.Key.Remove(dicExample.Key.IndexOf(strAsset, StringComparison.Ordinal),strAsset.Length);
			if (Directory.Exists(srcFolderPath))
			{
				FolderUtils.CopyFolder(srcFolderPath,destFolderPath);
				FileUtil.DeleteFileOrDirectory(srcFolderPath);
				File.Delete(srcFolderPath+".meta");
			}

			if (File.Exists(srcFolderPath))
			{
				FileInfo destFileInfo = new FileInfo(destFolderPath);
				if (destFileInfo.Directory != null && !destFileInfo.Directory.Exists)
				{
					destFileInfo.Directory.Create();
				}
				File.Copy(srcFolderPath,destFolderPath, true);
				FileUtil.DeleteFileOrDirectory(srcFolderPath);
				File.Delete(srcFolderPath+".meta");
			}
		}
		//Disable();
		AddOrRemoveAssembly(false);
		GameMainSettingsUtils.GameMainGlobalSettings.m_UseGameMainExample = false;
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}

	public static bool IsUseGameMainExampleInProject()
	{
		return GameMainSettingsUtils.GameMainGlobalSettings.m_UseGameMainExample;
	}

	private static void AddOrRemoveAssembly(bool isAdd)
	{
		Dictionary<string, string> dicAssembly = new()
		{
			{ "GameMainExample1", "GameMainExample1.dll" },
			{ "GameMainExample2", "GameMainExample2.dll" }
		};
		foreach (var item in dicAssembly)
		{
			GameMainSettingsUtils.AddOrRemoveHotUpdateAssemblies(isAdd,item.Key,item.Value);
		}
		//弹出提示框
		string message;
		if (isAdd)
		{
			message =
				"GameMainExample 添加成功，需要在[HybridCLR/Settings]中添加热更新程序集(HotfixGameMainExample.dll,HotfixAGameExample.dll)才可以实现热更!";
		}
		else
		{
			message =
				"GameMainExample 移除成功，需要在[HybridCLR/Settings]中移除热更新程序集(HotfixGameMainExample.dll,HotfixAGameExample.dll)才可以完全移除!";
		}
		EditorUtility.DisplayDialog("GameMainExample",message,"已知晓");
	}

	/*private static void Enable()
	{
		AddScriptingDefineSymbol();
		GameMainSettingsUtils.GameMainGlobalSettings.m_UseGameMainExample = true;
	}

	private static void Disable()
	{
		bool isFind = false;
		foreach (var buildTargetGroup in BuildTargetGroups)
		{
			if (ScriptingDefineSymbols.HasScriptingDefineSymbol(buildTargetGroup,EnableEXAMPLE))
			{
				isFind = true;
			}
		}
		if (isFind)
		{
			AddScriptingDefineSymbol(false);
		}
	}
	private static void AddScriptingDefineSymbol(bool isAdd = true)
	{
		if (isAdd)
		{
			ScriptingDefineSymbols.AddScriptingDefineSymbol(EnableEXAMPLE);
		}
		else
		{
			ScriptingDefineSymbols.RemoveScriptingDefineSymbol(EnableEXAMPLE);
		}
	}*/
}