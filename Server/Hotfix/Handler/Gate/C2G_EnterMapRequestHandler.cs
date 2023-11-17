using Fantasy.Core.Network;
using Fantasy;


public class C2G_EnterMapRequestHandler : MessageRPC<C2G_EnterMapRequest,G2C_EnterMapResponse>
{
    protected override async FTask Run(Session session, C2G_EnterMapRequest request, G2C_EnterMapResponse response, Action reply)
    {
        // 向map请求创建playerEntity
        var entityId = SceneHelper.GetSceneEntityId(ServerConfigID.Map);
        var createPlayerResponse = (Map2G_CreatePlayerResponse)await MessageHelper.CallInnerRoute(session.Scene, entityId,
        new G2Map_CreatePlayerRequest()
        {
            PlayerId = request.PlayerId,
            SessionRuntimeId = session.RuntimeId,
        });

        // 挂寻址路由组件，session就可以收、转发路由消息了
        // AddressableRouteComponent组件是只给session用的，SetAddressableId设置转发目标
        session.AddComponent<AddressableRouteComponent>().SetAddressableId(createPlayerResponse.AddressableId);

        Log.Debug($"<--收到进入地图的请求");
        await FTask.CompletedTask;
    }
}