

public abstract class State
{
    protected StateController m_StateController;
    public virtual void SetParam(MessengerInfo messengerInfo)
    {

    }
    /// <summary>
    /// 进入状态时调用。
    /// </summary>
    /// <param name="stateController">持有者。</param>
    protected internal virtual void OnEnter(StateController stateController)
    {
        m_StateController = stateController;
    }

    /// <summary>
    /// 状态轮询时调用。
    /// </summary>
    /// <param name="stateController">持有者。</param>
    protected internal virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
    }

    /// <summary>
    /// 离开状态时调用。
    /// </summary>
    /// <param name="stateController">持有者。</param>
    /// <param name="isShutdown">是否是关闭状态机时触发。</param>
    protected internal virtual void OnLeave()
    {
    }
}
