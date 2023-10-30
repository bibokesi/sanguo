using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 事件组件。
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Game Framework/Messenger")]
public class MessengerComponent : GameFrameworkComponent
{

    private MessengerManager m_messengerManager;

    /// <summary>
    /// 游戏框架组件初始化。
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        m_messengerManager = new MessengerManager();
    }

    public void RegisterEvent(uint eventName, RegistFunction pFunction)
    {
        m_messengerManager.RegisterEvent(eventName, pFunction);
    }
    public void UnRegisterEvent(uint eventName, RegistFunction pFunction)
    {
        m_messengerManager.UnRegisterEvent(eventName, pFunction);
    }

    public object SendEvent(uint eventName, object pSender = null)
    {
        return m_messengerManager.SendEvent(eventName, pSender);
    }
}