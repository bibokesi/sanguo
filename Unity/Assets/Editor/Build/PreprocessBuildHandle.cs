using HybridCLR.Editor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

/// <summary>
/// 构建包资源前的一些操作
/// </summary>
public class PreprocessBuildHandle : IPreprocessBuildWithReport
{
	public int callbackOrder => 0;
	public void OnPreprocessBuild(BuildReport report)
	{
		if (SettingsUtil.Enable)
		{
			//获取所有的AOT程序集
			AOTMetaAssembliesHelper.FindAllAOTMetaAssemblies(report.summary.platform);
		}
	}
}