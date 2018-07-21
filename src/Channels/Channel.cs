using System.Collections.Generic;
using System.Linq;
using LiteNetLib;

public class Channel
{
    public Channel(string name)
    {
        ChannelManager.Global.Channels.Add(name, this);
    }
    public List<NetPeer> Subscibers = new List<NetPeer>();

    public void SendToAll(ChannelPacket packet, params NetPeer[] exclude)
    {
        var excludelist = exclude.ToList();
        foreach (var peer in Subscibers)
        {
            if (!excludelist.Contains(peer))
            {
                Program.NetPacketProcessor.Send(peer, packet, DeliveryMethod.ReliableUnordered);
            }
        }
    }
}