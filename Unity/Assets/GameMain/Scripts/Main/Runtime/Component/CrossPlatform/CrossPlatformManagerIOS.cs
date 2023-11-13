using System.Runtime.InteropServices;
/// <summary>
/// 调用Ios原生
/// </summary>
public partial class CrossPlatformManagerIOS:ICrossPlatformManager
{
#if UNITY_IOS
    [DllImport("__Internal")]
#endif
    private static extern void HandelCamera();
}
