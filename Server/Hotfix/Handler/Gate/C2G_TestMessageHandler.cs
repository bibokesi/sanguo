using Fantasy.Core.Network;
using Fantasy.Helper;
using Fantasy;

public class C2G_TestMessageHandler : Message<C2G_TestMessage>
{
    protected override async FTask Run(Session session, C2G_TestMessage message)
    {
        Log.Debug($"<--测试非RPC消息");
        message.Message = "-->测试非RPC消息";


        // 测试推送消息
        session.Send(new G2C_TestPushMessage()
        {
            Message = "test push message"
        });

        await FTask.CompletedTask;
    }
}