using System;
using System.Collections.Generic;

public class ModuleManagerHelper : SingletonMono<ModuleManagerHelper>
{

    public static PlayerManager RoleMgr => _RoleMgr ??= PlayerManager.Instance;
    private static PlayerManager _RoleMgr;


    private List<BaseManager> m_AllModuleManagers = new();

    protected override void Awake()
    {
        base.Awake();
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
