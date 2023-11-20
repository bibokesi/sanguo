using Fantasy;
using Fantasy.Core.Network;
using Fantasy.Helper;

public class Map2C_MoveBroadcastHandler : Message<Map2C_MoveBroadcast>
{
    protected override async FTask Run(Session session, Map2C_MoveBroadcast message)
    {
        Log.Info("---->"+message.Moves.ToJson());
        
        await FTask.CompletedTask;
    }
}