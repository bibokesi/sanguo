using Fantasy;
using Fantasy.Core.Network;
using Fantasy.Helper;

public class G2C_TestPushMessageHandler : Message<G2C_TestPushMessage>
{
    protected override async FTask Run(Session session, G2C_TestPushMessage message)
    {
        Log.Info("----> ���յ���������������Ϣ "+ message.Message);
        
        await FTask.CompletedTask;
    }
}