using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : Singleton<RoleManager>, BaseModuleManager
{
    private RoleManager() { }
    public void OnInit()
    {
        Logger.Debug("RoleManager:OnInit");
    }

    public void OnLeave()
    {
        Logger.Debug("RoleManager:OnLeave");
    }

    public void OnUpdate()
    {

    }
}