using Fantasy;
using Fantasy.Core.Network;
using Fantasy.Helper;

public class G2C_TestPushMessageHandler : Message<G2C_TestPushMessage>
{
    protected override async FTask Run(Session session, G2C_TestPushMessage message)
    {
        Log.Info("----> 接收到服务器的推送消息 "+ message.Message);
        
        await FTask.CompletedTask;
    }
}