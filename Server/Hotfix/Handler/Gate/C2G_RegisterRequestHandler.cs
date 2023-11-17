using Fantasy.Core.Network;
using Fantasy;


public class C2G_RegisterRequestHandler : MessageRPC<C2G_RegisterRequest, G2C_RegisterResponse>
{
    protected override async FTask Run(Session session, C2G_RegisterRequest request, G2C_RegisterResponse response, Action reply)
    {
        if (request.UserName == "" || request.PassWord == "")
        {
            return;
        }

        var db = session.Scene.World.DateBase;
        var queryList = await db.Query<PlayerDatabase>(data => data.UserName == request.UserName);
        if (queryList.Count != 0)
        {
            // 用户名重复
            response.ErrorCode = 1;
            return;
        }

        var playerDatabase = Entity.Create<PlayerDatabase>(session.Scene);

        playerDatabase.UserName = request.UserName;
        playerDatabase.PassWord = request.PassWord;
        playerDatabase.CreateTime = DateTime.Now.ToString();

        await db.Save(playerDatabase);

        playerDatabase.Dispose();

        await FTask.CompletedTask;
    }
}