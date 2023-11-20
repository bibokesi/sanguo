using Fantasy.Core.Network;
using Fantasy;

public class G2Map_CreatePlayerRequestHandler : RouteRPC<Scene,G2Map_CreatePlayerRequest,Map2G_CreatePlayerResponse>
{
    protected override async FTask Run(Scene scene, G2Map_CreatePlayerRequest request, Map2G_CreatePlayerResponse response, Action reply)
    {
        var playerManager = scene.GetComponent<PlayerManager>();

        var playerEntity = Entity.Create<PlayerEntity>(scene);
        playerEntity.SessionRuntimeId = request.SessionRuntimeId;
        playerEntity.moveInfo = MessageInfoHelper.MoveInfo(); //练习就给一个原点的默认位置，真实项目有地图配置文件的出生点位置，或者已经保存的玩家下线位置。
        playerManager.Add(playerEntity);

        // 2、挂AddressableMessageComponent组件、让这个PlayerEntity支持Address（可被寻址）、并且会自动注册到网格中
        await playerEntity.AddComponent<AddressableMessageComponent>().Register();

        // 3、挂移动组件，状态同步组件
        playerEntity.AddComponent<CmdComponent>();
        playerEntity.AddComponent<CmdSyncComponent>();
        response.AddressableId = playerEntity.Id;

        Log.Debug($"<--收到创建playerEntity请求");
        await FTask.CompletedTask;
    }
}