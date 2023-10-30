using UnityGameFramework.Runtime;

public partial class CrossPlatformComponent:GameFrameworkComponent
{
    private ICrossPlatformManager m_CrossPlatformManager;
    protected override void Awake()
    {
        base.Awake();
#if UNITY_ANDROID
        m_CrossPlatformManager = new CrossPlatformManagerAndroid();
#elif UNITY_IOS
        m_CrossPlatformManager = new CrossPlatformManagerIOS();
#else
        m_CrossPlatformManager = new CrossPlatformManagerPC();
#endif
    }

    private void NativeCallUnity(string message)
    {
        Logger.Debug<CrossPlatformComponent>(message);
        GameEntryMain.Messenger.SendEvent(EventNameMain.EVENT_NATIVE_CALL_UNITY,message);
    }

    public void OpenCamera()
    {
        m_CrossPlatformManager.handelCamera();
    }
}