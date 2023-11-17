
public class StateController
{
    public PlayerEntity Owner
    {
        get;
        set;
    }

    public State m_LastState
    {
        get;
        set;
    }

    public State m_CurrentState
    {
        get;
        set;
    }

    public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        if (m_CurrentState != null)
            m_CurrentState.OnUpdate(elapseSeconds, realElapseSeconds);
    }

    public StateController(PlayerEntity entityLogicBase)
    {
        Owner = entityLogicBase;
    }

    public void OnChangeState(State state)
    {
        if (m_CurrentState == state)
        {
            return;
        }
        if (m_CurrentState != null && state != m_CurrentState)
        {
            m_CurrentState.OnLeave();
        }
        m_LastState = m_CurrentState;
        m_CurrentState = state;
        m_CurrentState.OnEnter(this);
    }

    public bool IsInState(State state)
    {
        if (state == m_CurrentState)
        {
            return true;
        }
        return false;
    }
}
