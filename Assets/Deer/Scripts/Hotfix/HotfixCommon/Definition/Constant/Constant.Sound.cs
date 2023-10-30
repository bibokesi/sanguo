using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Constant 
{
    public static class SoundGroup
    {
        public const string Music = "Music";
        public const string Sound = "Sound";
        public const string UISound = "UISound";
    }
}

/// <summary>
/// 音乐编号
/// </summary>
public enum SoundId : int
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,

    /// <summary>
    /// 主菜单背景音乐
    /// </summary>
    MenuBGM = 10001,

    /// <summary>
    /// 游戏背景音乐
    /// </summary>
    GameBGM = 10101,

}