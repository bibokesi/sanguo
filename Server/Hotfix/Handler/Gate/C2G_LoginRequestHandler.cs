using Fantasy.Core.Network;
using Fantasy.Helper;
using Fantasy;

public class C2G_LoginRequestHandler : MessageRPC<C2G_LoginRequest,G2C_LoginResponse>
{
    protected override async FTask Run(Session session, C2G_LoginRequest request, G2C_LoginResponse response, Action reply)
    {
        if (request.UserName == "" || request.PassWord == "")
        {
            return;
        }

        var db = session.Scene.World.DateBase;
        var queryList = await db.Query<PlayerDatabase>(data => data.UserName == request.UserName);
        if (queryList.Count != 1)
        {
            // 用户名不存在
            response.ErrorCode = 1;
            return;
        }

        if (queryList[0].UserName != request.UserName ||
            queryList[0].PassWord != request.PassWord)
        {
            // 账号或密码错误
            response.ErrorCode = 2;
            return;
        }

        response.PlayerId = queryList[0].Id;
        await FTask.CompletedTask;
    }
}