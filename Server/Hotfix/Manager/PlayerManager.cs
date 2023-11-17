using Fantasy;

public class PlayerManager : Entity 
{
    /// playerEntity容器
    public readonly Dictionary<long, PlayerEntity> playerList = new Dictionary<long, PlayerEntity>();

    public PlayerEntity Get(long id)
    {
        playerList.TryGetValue(id, out PlayerEntity playerEntity);
        return playerEntity;
    }

    public PlayerEntity[] GetAll()
    {
        return playerList.Values.ToArray();
    }

    public void Add(PlayerEntity playerEntity)
    {
        playerList.Add(playerEntity.Id, playerEntity);
    }

    public void Remove(long id)
    {
        PlayerEntity playerEntity;
        playerList.TryGetValue(id, out playerEntity);
        playerList.Remove(id);
        playerEntity?.Dispose();
    }
}