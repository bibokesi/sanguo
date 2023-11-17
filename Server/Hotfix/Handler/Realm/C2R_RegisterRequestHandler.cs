using Fantasy.Core.Network;
using Fantasy.Helper;
using Fantasy;
using Fantasy.Hotfix;

public class C2R_RegisterRequestHandler : MessageRPC<C2R_RegisterRequest, R2C_RegisterResponse>
{
    protected override async FTask Run(Session session, C2R_RegisterRequest request, R2C_RegisterResponse response, Action reply)
    {
        if (request.UserName == "" || request.Password == "")
        {
            return;
        }

        var db = session.Scene.World.DateBase;
        var queryList = await db.Query<PlayerEntity>(data => data.UserName == request.UserName);
        if (queryList.Count != 0)
        {
            // 用户名重复
            response.ErrorCode = 1;
            await FTask.CompletedTask;
        }

        var playerEntity = session.AddComponent<PlayerEntity>();

        //// 永久唯一，每毫秒可生成65535个
        //var nextEntityId = IdFactory.NextEntityId(ServerConfigID.Realm);

        //// 基于当前进程生成的id，下次开服可能会重复
        //var nextRuntimeEntityId = IdFactory.NextRunTimeId();

        playerEntity.PlayerId = playerEntity.Id;
        playerEntity.UserName = request.UserName;
        playerEntity.PassWord = request.Password;
        await db.Save(playerEntity);

        await FTask.CompletedTask;
    }
}