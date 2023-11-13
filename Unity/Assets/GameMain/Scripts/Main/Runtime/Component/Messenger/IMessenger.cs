public interface IMessenger
{
    /// <summary>
    /// ע���¼����
    /// </summary>
    public void OnRegisterEvent();
    /// <summary>
    /// ȡ��ע���¼����
    /// </summary>
    public void OnUnRegisterEvent();
    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="eventName">ע���¼�����</param>
    /// <param name="pSender">�¼�����</param>
    public void SendEvent(uint eventName, object pSender = null);
    /// <summary>
    /// ע���¼�
    /// </summary>
    /// <param name="eventName">ע���¼�����</param>
    /// <param name="pFunction">ע���¼�����</param>
    public void RegisterEvent(uint eventName, RegistFunction pFunction);
    /// <summary>
    /// ע��ע���¼�
    /// </summary>
    /// <param name="eventName">ע��ע���¼�����</param>
    /// <param name="pFunction">ע��ע���¼�����</param>
    public void UnRegisterEvent(uint eventName, RegistFunction pFunction);
}