using GameFramework.Debugger;
using UnityEngine;

public class DeerCustomSettingWindow : IDebuggerWindow
{
    private Vector2 m_ScrollPosition = Vector2.zero;
    private DeerCustomSettingWindowHelper m_CustomWindowHelper;

    public void Initialize(params object[] args)
    {
        
    }

    public void OnDraw()
    {
        m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);
        {
            OnDrawScrollableWindow();
        }
        GUILayout.EndScrollView();
    }

    public void OnEnter()
    {
        
    }

    public void OnLeave()
    {
        
    }

    public void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        
    }

    /// <summary>
    /// 设置辅助窗口
    /// </summary>
    /// <param name="customWindowHelper"></param>
    public void SetHelper(DeerCustomSettingWindowHelper customWindowHelper)
    {
        m_CustomWindowHelper = customWindowHelper;
    }

    public void Shutdown()
    {
    }

    protected void OnDrawScrollableWindow()
    {
        if (m_CustomWindowHelper != null)
        {
            m_CustomWindowHelper.OnDrawScrollableWindow();
        }
    }
}