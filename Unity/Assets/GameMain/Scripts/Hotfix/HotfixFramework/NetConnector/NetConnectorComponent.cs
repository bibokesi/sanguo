using GameFramework;
using GameFramework.Network;
using System.Collections.Generic;
using System.IO;
using System.Net;
using GameMain;
//using Pb.Message;
using UnityEngine;
using UnityGameFramework.Runtime;

[DisallowMultipleComponent]
[AddComponentMenu("GameMain/NetConnector")]
public partial class NetConnectorComponent : GameFrameworkComponent
{

    private Dictionary<string, INetworkChannel> m_ListNetworkChannel = new Dictionary<string, INetworkChannel>();

    public NetworkChannelHelper channelHelper;
    public INetworkChannel CreateTcpNetworkChannel(string channelName = "Default") 
    {
        INetworkChannel networkChannel = null;
        if (m_ListNetworkChannel.ContainsKey(channelName))
        {
            m_ListNetworkChannel.TryGetValue(channelName,out networkChannel);
            return networkChannel;
        }
        channelHelper = ReferencePool.Acquire<NetworkChannelHelper>();
        networkChannel = GameEntry.Network.CreateNetworkChannel(channelName, ServiceType.Tcp, channelHelper);
        m_ListNetworkChannel.Add(channelName, networkChannel);
        //SetHeartBeatInterval(channelName,5f);
        return networkChannel;
    }

    public void Connect(string ip, int prot, string channelName = "Default", object userData = null) 
    {
        INetworkChannel networkChannel = null;
        m_ListNetworkChannel.TryGetValue(channelName, out networkChannel);
        if (networkChannel != null)
        {
            networkChannel.Connect(IPAddress.Parse(ip), prot, userData);
        }
        else 
        {
            Logger.Error($"channelName:{channelName},is null");
        }
    }

    public void Close(string channelName)
    {
        INetworkChannel networkChannel = null;
        m_ListNetworkChannel.TryGetValue(channelName, out networkChannel);
        if (networkChannel != null)
        {
            networkChannel.Close();
        }
    }

    public void SetHeartBeatInterval(string channelName,float heartBeatInterval)
    {
        //INetworkChannel networkChannel = null;
        //m_ListNetworkChannel.TryGetValue(channelName, out networkChannel);
        //if (networkChannel != null)
        //{
        //    networkChannel.HeartBeatInterval = heartBeatInterval;
        //}
    }

    public void Send(string channelName, ushort nProtocolId, byte[] v)
    {
        //INetworkChannel networkChannel = null;
        //m_ListNetworkChannel.TryGetValue(channelName, out networkChannel);
        //if (networkChannel != null)
        //{
        //    CSProtoPacket csProtoPacket = ReferencePool.Acquire<CSProtoPacket>();
        //    //csProtoPacket.protoId = nProtocolId;
        //    csProtoPacket.protoBody = v;
        //    networkChannel.Send(csProtoPacket);
        //}
        //else
        //{
        //    Log.Error($"channelName:{0},is nono", channelName);
        //}
    }
    public void Send(string channelName, int cmdMerge, byte[] v)
    {
        //m_ListNetworkChannel.TryGetValue(channelName, out var networkChannel);
        //if (networkChannel != null)
        //{
        //    CSProtoPacket csProtoPacket = ReferencePool.Acquire<CSProtoPacket>();
        //    ExternalMessage external = new ExternalMessage
        //    {
        //        CmdCode = 1,
        //        CmdMerge = cmdMerge,
        //        ProtocolSwitch = 0,
        //        Data = Google.Protobuf.ByteString.CopyFrom(v)
        //    };
        //    csProtoPacket.protoBody = ProtobufUtils.Serialize(external);
        //    networkChannel.Send(csProtoPacket);
        //    Logger.ColorInfo(ColorType.yellowgreen, $"发送{ProtobufUtils.GetHighOrder(cmdMerge)}_{ProtobufUtils.GetLowOrder(cmdMerge)}消息Id:{cmdMerge}");
        //}
        //else
        //{
        //    Logger.Error($"channelName:{channelName},is null");
        //}
    }
    public void Send(int cmdMerge, object message , string channelName = "Default")
    {
      //  Send(channelName,cmdMerge,ProtobufUtils.Serialize(message));
    }
}