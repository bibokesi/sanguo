using Fantasy;
using Fantasy.Helper;
using UnityEngine;


public class MoveComponent : Entity 
{
    /// 测试练习，这里不在服务器上做位置的计算与寻路验证
    public async FTask MoveToAsync(MoveInfo moveInfo)
    {
        // 是否禁止移动
        // 获取数值组件，移动速度
        // 寻路，目标点是否有效，是否查找附近有效点

        // 添加广播消息
        MoveToAndSendAsync(moveInfo).Coroutine();
        await FTask.CompletedTask;
    }

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
        EventSystem.Instance.Publish(new EventSystemStruct.StartMove{
            playerEntity = playerEntity, moveInfo = moveInfo
        });

        // 服务器上playerEntity的位置移动计算
        InnerMoveToAsync(playerEntity,moveInfo,speed).Coroutine();
        await FTask.CompletedTask;
    }

    public async FTask InnerMoveToAsync(PlayerEntity playerEntity, MoveInfo moveInfo, float speed)
    {
        // 测试练习，略插值计算过程...
        playerEntity.moveInfo = moveInfo;

        await FTask.CompletedTask;
    }
}