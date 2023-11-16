using Fantasy.Core.Network;
using Fantasy.Helper;
using Fantasy;
using Fantasy.Hotfix;

public class C2R_RegisterRequestHandler : MessageRPC<C2R_RegisterRequest,R2C_RegisterResponse>
{
    protected override async FTask Run(Session session, C2R_RegisterRequest request, R2C_RegisterResponse response, Action reply)
    {
        Log.Debug($"<--收到注册账号的请求");
        response.Message = "-->注册账号成功";

        // 永久唯一，每毫秒可生成65535个
        var nextEntityId = IdFactory.NextEntityId(ServerConfigID.Realm);

        // 基于当前进程生成的id，下次开服可能会重复
        var nextRuntimeEntityId = IdFactory.NextRunTimeId();
    
        await FTask.CompletedTask;
    }
}