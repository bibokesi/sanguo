using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>, BaseManager
{
    public Dictionary<long, PlayerEntityData> PlayerList = new Dictionary<long, PlayerEntityData>();

    private PlayerManager() { }
    public void OnInit()
    {
        Logger.Debug("PlayerManager:OnInit");
        PlayerList.Clear();
    }

    public void OnLeave()
    {
        Logger.Debug("PlayerManager:OnLeave");
        PlayerList.Clear();
    }

    public void OnUpdate()
    {

    }

    public void AddPlayer(long serverPlayerId, string username, string password, bool isOwner)
    {
        PlayerEntityData playerEntityData = new PlayerEntityData(GameEntry.Entity.GenEntityId(), 1, Const.EntityGroup.PlayerEntity, "Blade_girl");
        playerEntityData.Position = new UnityEngine.Vector3(142, 2, 68);
        playerEntityData.IsOwner = isOwner;
        playerEntityData.serverPlayerId = serverPlayerId;
        playerEntityData.username = username;
        playerEntityData.password = password;

        PlayerList[serverPlayerId] = playerEntityData;
    }

    public long GetOwnerId()
    {
        foreach (var item in PlayerList)
        {
            if (item.Value.IsOwner)
            {
                return item.Key;
            }
        }

        return 0;
    }
}