using System.Collections;
using System.Collections.Generic;
using Main.Runtime;
using UnityEngine;

/// <summary>
/// 热更逻辑入口
/// </summary>
public static class AppMain 
{
    public static void Entrance(object[] objects) 
    {
        GameEntry.UI.GameMainUIInitRootForm().OnOpenLoadingForm(true);
        GameEntry.Entrance(objects);
    }
}
