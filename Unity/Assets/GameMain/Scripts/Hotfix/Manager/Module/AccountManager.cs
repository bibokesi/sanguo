using Fantasy;
using UnityEngine;

public class AccountManager:Singleton<AccountManager>,BaseModuleManager
{
    public void OnInit()
    {
        Logger.Debug("AccountManager:OnInit");
    }

    public void OnLeave()
    {
        Logger.Debug("AccountManager:OnLeave");
    }

    public void OnUpdate()
    {

    }

}
