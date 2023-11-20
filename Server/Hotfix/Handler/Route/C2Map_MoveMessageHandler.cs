using Fantasy.Core.Network;
using Fantasy.Helper;
using Fantasy;

public class C2Map_MoveMessageHandler : Addressable<PlayerEntity, C2Map_MoveMessage>
{
    protected override async FTask Run(PlayerEntity playerEntity, C2Map_MoveMessage message)
    {
        // 路径点合法判断略...
        // 移动停止检测略...
  
        // 调用MoveComponent
      //  playerEntity.GetComponent<CmdComponent>().MoveToAsync(message.MoveInfo).Coroutine();

        await FTask.CompletedTask;
    }
}