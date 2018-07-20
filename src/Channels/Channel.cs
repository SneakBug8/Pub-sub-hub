using System.Collections.Generic;
using LiteNetLib;

public class Channel
{
    public List<Player> Players = new List<Player>();

    public void SendToAll(object packet)
    {
        foreach (var player in Players)
        {
            Program.NetPacketProcessor.Send(player.Peer, packet, DeliveryMethod.ReliableUnordered);
        }
    }
}