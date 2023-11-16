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

    // ×¢²árealmÕËºÅ
    public async FTask Register(string username, string password)
    {
        R2C_RegisterResponse register = (R2C_RegisterResponse)await GameEntry.Fantasy.Realm.Session.Call(new C2R_RegisterRequest()
        {
            UserName = username,
            Password = password
        });
        UnityGameFramework.Runtime.Log.Info(register.Message);
    }

    // µÇÂ¼realmÕËºÅ
    public async FTask Login(string username, string password)
    {
        R2C_LoginResponse loginRealm = (R2C_LoginResponse)await GameEntry.Fantasy.Realm.Session.Call(new C2R_LoginRequest()
        {
            UserName = username,
            Password = password
        });
        UnityGameFramework.Runtime.Log.Info(loginRealm.Message);
    }
}
