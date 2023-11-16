using GameFramework;
using GameFramework.Network;
using System.Collections.Generic;
using System.IO;
using System.Net;
using GameMain;
using UnityEngine;
using UnityGameFramework.Runtime;
using Fantasy.Core.Network;
using Fantasy;
using System.Reflection;
using Fantasy.Model;


/* 

（普通消息：网关服 + 客户端）
IMessage：单向，非RPC，C2G / G2C
前后端发送都是session.Send(...)
前后端接收都是xxxHandler : Message<xxxMessage>

IRequest + IResponse：双向，RPC，C2G + G2C
前端请求session.Call(...)
后端接收xxxHandler : MessageRPC<xxxRequest, xxxResponse>


（路由消息：网关服 + 其他Scene服）
IRouteRequest + IRouteResponse，双向，G2M + M2G
请求都是MessageHelper.CallInnerRoute(...)
响应都是xxxHandler : RouteRPC<xxxRequest, xxxResponse>

*/

[DisallowMultipleComponent]
[AddComponentMenu("GameMain/FantasyComponent")]
public partial class FantasyComponent : GameFrameworkComponent
{
    public Scene Realm;
    public Scene Gate;
    public bool IsRealmConnect;
    public bool IsGateConnect;

    // 这个对应的是AssemblyCSharp工程、也就是unity默认的工程
    public const int AssemblyCSharp = 1;

    // 网络初始化
    public void Init()
    {
        // 框架初始化
        Realm = Fantasy.Entry.Initialize();
        Gate = Scene.Create();

        // 把当前工程的程序集装载到框架中、这样框架才会正常的操作
        // 装载后例如网络协议等一些框架提供的功能就可以使用了
        Fantasy.Helper.AssemblyManager.Load(AssemblyCSharp, GetType().Assembly);
    }

    // 连接服务器
    public void ConnectServer()
    {
        // 创建网络连接
        // 外网访问的是SceneConfig配置文件中配置的Gate 20000端口,Realm 20001端口
        // networkProtocolType:网络协议类型
        // 这里要使用与后端SceneConfig配置文件中配置的NetworkProtocolType类型一样才能建立连接
        Realm.CreateSession("127.0.0.1:20000", NetworkProtocolType.KCP, OnRealmConnectSuccessed, OnRealmConnectFailed, OnRealmConnectDisconected, 3000);

        // 建立与网关的连接，只有与网关的连接才需要挂心跳
        Gate.CreateSession("127.0.0.1:20001", NetworkProtocolType.KCP, OnGateConnectSuccessed, OnGateConnectFailed, OnGateConnectDisconected, 3000);
    }

    private void OnRealmConnectSuccessed()
    {
        UnityGameFramework.Runtime.Log.Info("Realm连接成功");
        IsRealmConnect = true;
        RealmTest().Coroutine();
    }

    private void OnRealmConnectFailed()
    {
        UnityGameFramework.Runtime.Log.Info("Realm连接失败");
        IsRealmConnect = false;
        
    }

    private void OnRealmConnectDisconected()
    {
        UnityGameFramework.Runtime.Log.Info("Realm连接断开");
        IsRealmConnect = false;
    }

    private void OnGateConnectSuccessed()
    {
        UnityGameFramework.Runtime.Log.Info("Gate连接成功");
        IsGateConnect = true;
        // 挂载心跳组件，设置每隔3000毫秒发送一次心跳给服务器
        // 只需要给客户端保持连接的服务器挂心跳
        Gate.Session.AddComponent<SessionHeartbeatComponent>().Start(3000);

        // 测试非RPC消息和服务器推送消息
        MessageTest();

        GateTest().Coroutine();
    }

    private void OnGateConnectFailed()
    {
        UnityGameFramework.Runtime.Log.Error("Gate连接失败");
        IsGateConnect = false;
    }

    private void OnGateConnectDisconected()
    {
        UnityGameFramework.Runtime.Log.Error("Gate连接断开");
        IsGateConnect = false;
    }

    private async FTask RealmTest()
    {
        // 请求realm验证
        R2C_RegisterResponse register = (R2C_RegisterResponse)await Realm.Session.Call(new C2R_RegisterRequest()
        {
            UserName = "test",
            Password = ""
        });
        UnityGameFramework.Runtime.Log.Info(register.Message);

        // 登录realm账号
        R2C_LoginResponse loginRealm = (R2C_LoginResponse)await Realm.Session.Call(new C2R_LoginRequest()
        {
            UserName = "test",
            Password = ""
        });
        UnityGameFramework.Runtime.Log.Info(loginRealm.Message);
    }

    private async FTask GateTest()
    {
        // 登录网关
        // 登录网关后创建角色，或者加载角色列表，选择角色进入游戏地图
        G2C_LoginGateResponse loginGate = (G2C_LoginGateResponse)await Gate.Session.Call(new C2G_LoginGateRequest()
        {
            Message = "请求登录网关"
        });
        UnityGameFramework.Runtime.Log.Info(loginGate.Message);
        UnityGameFramework.Runtime.Log.Info(loginGate.ErrorCode.ToString());

        // 创建角色请求
        G2C_CreateCharacterResponse create = (G2C_CreateCharacterResponse)await Gate.Session.Call(new C2G_CreateCharacterRequest()
        {
            Message = "请求创建角色"
        });
        UnityGameFramework.Runtime.Log.Info(create.Message);

        // 进入地图请求
        G2C_EnterMapResponse enter = (G2C_EnterMapResponse)await Gate.Session.Call(new C2G_EnterMapRequest()
        {
            Message = "请求进入地图"
        });
        UnityGameFramework.Runtime.Log.Info(enter.Message);
    }

    // 测试非RPC消息
    private void MessageTest()
    {
        Gate.Session.Send(new C2G_TestMessage()
        {
            Message = "测试非RPC消息"
        });
    }


}