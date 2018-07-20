using System.Collections.Generic;
using LiteNetLib;

public class Channel
{
    public List<Player> Subscribers = new List<Player>();

    public void SendToAll(object packet)
    {
        foreach (var player in Subscribers)
        {
            Program.NetPacketProcessor.Send(player.Peer, packet, DeliveryMethod.ReliableUnordered);
        }
    }
}