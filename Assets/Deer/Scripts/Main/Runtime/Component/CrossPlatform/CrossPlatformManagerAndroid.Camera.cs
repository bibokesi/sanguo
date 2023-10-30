using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 调用安卓原生
/// </summary>
public partial class CrossPlatformManagerAndroid:ICrossPlatformManager
{
    public void handelCamera()
    {
        Logger.Debug<CrossPlatformManagerAndroid>("handelCamera:调用原生handelCamera");
    }
}