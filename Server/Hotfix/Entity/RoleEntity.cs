using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Hotfix;

// Id：服务端全局唯一、客户端进程唯一、创建时生成的、并且不会再改变一般用于数据的的ID
// RuntineId：服务端金局唯一、客户端进程唯一、创建时生成的、会再Deserialize后改变、同样用来表示Entity在服务器的网络位置、通过这个ID可以知道Entity在网络中什么位置
// IsDisposed：是否已经销毁了
// Scene：这个组件所属于的Scene
// Parent：这个组件的上级

public class RoleEntity : Entity
{
    public string RoleName;
    public uint RoleId;
    public long CreateTime;

    public override void Dispose()
    {
        RoleName = "";
        RoleId = 0;
        CreateTime = 0;

        base.Dispose();
    }
}

// AwakeSystem是当组件创建的时候执行的一个事件、通常用于初始化
// Destroysystem是当组件销毁的时候执打的事件、通常用于清除一些数据
// UpdateSystem是当组件创建后、每帧执行的一个事件
// DeserializeSystem是当组件进行反序列化后执行的组件
// 一般当组件保存到数据或发送到其他Scene的时候、因为是先序列化成二进制再发送到目标的、
// 当目标服务器接收到这个二进制后、会反序列化这个二进制成指定的类型。
// 当调用了Entity的Deserialize方法后会执行这个事件
// 一般用于一些恢复状态的功能、比如buff恢复计时等操作

public class RoleEntityAwakeSystem : AwakeSystem<RoleEntity>
{
    protected override void Awake(RoleEntity self)
    {
        Log.Info("RoleEntityAwakeSystem");
    }
}

public class RoleEntityUpdateSystem : UpdateSystem<RoleEntity>
{
    protected override void Update(RoleEntity self)
    {
        Log.Info("RoleEntityUpdateSystem");
    }
}

public class RoleEntityDestroySystem : DestroySystem<RoleEntity>
{
    protected override void Destroy(RoleEntity self)
    {
        Log.Info("RoleEntityDestroySystem");
    }
}

// 从数据库反序列化
public class RoleEntityDeserializeSystem : DeserializeSystem<RoleEntity>
{
    protected override void Deserialize(RoleEntity self)
    {
        Log.Info("RoleEntityDeserializeSystem");
    }
}

// 扩展方式，数据逻辑分离
public static class RoleEntitySystem
{ 
    public static void Add(this RoleEntity self)
    {

    }
}


