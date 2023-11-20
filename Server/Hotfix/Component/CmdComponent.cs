using Fantasy;
using Fantasy.Helper;
using UnityEngine;


public class CmdComponent : Entity 
{
    public async FTask MoveToAndSendAsync(MoveInfo moveInfo)
    {
        var playerEntity = (PlayerEntity)Parent;
        // 计算移动距离与时间,略角度计算
        float dis = 0;
        float speed = 3;
        Vector3 p0 = MessageInfoHelper.Vector3(playerEntity.moveInfo);
        Vector3 p1 = MessageInfoHelper.Vector3(moveInfo);
        dis = Vector3.Distance(p0, p1);

        moveInfo.MoveEndTime = TimeHelper.Now + (long) (dis / speed * 1000);

        // 发事件给移动同步组件，收集移动状态
        EventSystem.Instance.Publish(new EventStruct.StartMove{
            playerEntity = playerEntity, moveInfo = moveInfo
        });

        playerEntity.moveInfo = moveInfo;
        await FTask.CompletedTask;
    }
}