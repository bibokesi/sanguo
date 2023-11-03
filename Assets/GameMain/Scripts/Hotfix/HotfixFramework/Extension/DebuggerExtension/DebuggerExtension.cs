using UnityGameFramework.Runtime;

public static class DebuggerExtension
{
    /// <summary>
    /// 设置网络窗口辅助器
    /// </summary>
    /// <param name="debuggerComponent"></param>
    /// <param name="netWindowHelper"></param>
    public static void SetGMNetWindowHelper(this DebuggerComponent debuggerComponent, GameMainGMNetWindowHelper netWindowHelper)
    {
        debuggerComponent.NetWindow.SetHelper(netWindowHelper);
    }

    public static void SetCustomSettingWindowHelper(this DebuggerComponent debuggerComponent, GameMainCustomSettingWindowHelper customSettingWindow)
    {
        debuggerComponent.CustomSettingWindow.SetHelper(customSettingWindow);
    }
}