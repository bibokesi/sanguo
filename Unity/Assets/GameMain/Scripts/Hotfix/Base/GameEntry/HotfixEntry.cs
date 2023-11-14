using System.Collections;
using System.Collections.Generic;
using Main.Runtime;
using UnityEngine;

/// <summary>
/// 业务入口
/// </summary>
public static class HotfixEntry
{
    public static void Entrance(object[] objects) 
    {
        GameEntry.Entrance(objects);
    }
}
