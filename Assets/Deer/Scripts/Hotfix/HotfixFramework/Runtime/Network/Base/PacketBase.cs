using GameFramework;
using GameFramework.Network;
public abstract class PacketBase : Packet
{
    public abstract PacketType PacketType
    {
        get;
    }
    //public int protoId;
    public byte[] protoBody;
    public void Close()
    {
    }
}