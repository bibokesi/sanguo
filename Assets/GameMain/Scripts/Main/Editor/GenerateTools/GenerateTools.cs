using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 框架配套工具
/// </summary>
public static class GenerateTools
{
    [MenuItem("GameMainTools/IOControls/Generate/GenerateProtobuf")]
	private static void GenProtoTools() 
	{
#if UNITY_EDITOR_WIN
		Application.OpenURL(Path.Combine(Application.dataPath, "../LubanTools/Proto/GameMain_Gen_Proto.bat"));
#else
		string shellPath = Path.Combine(Application.dataPath, "../LubanTools/Proto/GameMain_Gen_Proto.sh");

		System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
		psi.FileName = shellPath;
		psi.UseShellExecute = false;
		psi.StandardOutputEncoding = System.Text.Encoding.UTF8;
		psi.RedirectStandardOutput = true;
		System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
		string strOutput = p.StandardOutput.ReadToEnd();
		p.WaitForExit();
		p.Close();
		p.Dispose();
		UnityEngine.Debug.Log(strOutput);
#endif
	}
	[MenuItem("GameMainTools/IOControls/Generate/GenerateConfig")]
	private static void GenConfigToStreamingAssets()
	{
#if UNITY_EDITOR_WIN
		Application.OpenURL(Path.Combine(Application.dataPath, "../LubanTools/DesignerConfigs/GameMain_Build_Config.bat"));
#else
		string shellPath = Path.Combine(Application.dataPath, "../LubanTools/DesignerConfigs/GameMain_Build_Config.sh");
		//string shellPath = Application.dataPath + "/../LubanTools/DesignerConfigs/GameMain_Build_Config.sh";
		System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
		psi.FileName = shellPath;
		psi.UseShellExecute = false;
		psi.StandardOutputEncoding = System.Text.Encoding.UTF8;
		psi.RedirectStandardOutput = true;
        try
        {
			System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
			string strOutput = p.StandardOutput.ReadToEnd();
			p.WaitForExit();
			p.Close();
			p.Dispose();
			UnityEngine.Debug.Log(strOutput);
		}
        catch (System.Exception e)
        {
			if (e.ToString().Contains("0x80004005"))
			{
				throw new System.Exception($"请先修改文件权限，终端定位到[GameMain_Build_Config.sh]目录，执行[chmod 777 GameMain_Build_Config.sh]命令。 error: {e}");
			}
			else {
				throw new System.Exception($"可能文件格式编码不对，请核查！ error: {e}");
			}
		}

#endif
	}
}