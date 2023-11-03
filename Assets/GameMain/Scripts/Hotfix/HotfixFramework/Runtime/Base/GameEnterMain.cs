using System.Collections;
using System.Collections.Generic;
using Main.Runtime;
using UnityEngine;

/// <summary>
/// 游戏入口
/// </summary>
public static class GameEnterLogic
{
    public static void Entrance(object[] objects) 
    {
        GameEntry.UI.GameMainUIInitRootForm().OnOpenLoadingForm(true);
        GameEntry.Entrance(objects);
    }
}
