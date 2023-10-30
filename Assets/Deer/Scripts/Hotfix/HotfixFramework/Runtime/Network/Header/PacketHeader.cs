using GameFramework;
using GameFramework.Network;
public class PacketHeader : IPacketHeader, IReference
{
    public short Id
    {
        get;
        set;
    }
    public int PacketLength
    {
        get;
        set;
    }
    public bool IsValid
    {
        get
        {
            return PacketLength >= 0;
        }
    }

    public void Clear()
    {
        PacketLength = 0;
    }
}