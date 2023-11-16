using System;
using System.Collections.Generic;

public class ModuleHelper : SingletonMono<ModuleHelper>
{
    public static AccountManager AccountMgr => _AccountMgr ??= AccountManager.Instance;
    private static AccountManager _AccountMgr;
    public static RoleManager RoleMgr => _RoleMgr ??= RoleManager.Instance;
    private static RoleManager _RoleMgr;


    private List<BaseModuleManager> m_AllModuleManagers = new();

    protected override void Awake()
    {
        base.Awake();
        m_AllModuleManagers.Add(AccountMgr);
        m_AllModuleManagers.Add(RoleMgr);
    }

    private void Start()
    {
        foreach (var t in m_AllModuleManagers)
        {
            t.OnInit();
        }
    }

    private void Update()
    {
        foreach (var t in m_AllModuleManagers)
        {
            t.OnUpdate();
        }
    }

    private void OnDestroy()
    {
        foreach (var t in m_AllModuleManagers)
        {
            t.OnLeave();
        }

        if (GetInstance() != null)
        {
            OnClear();
        }
    }
}
