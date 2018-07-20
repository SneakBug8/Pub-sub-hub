using System.Collections.Generic;
using LiteNetLib;

public class Channel
{
    public List<NetPeer> Subscribers = new List<NetPeer>();

    public void SendToAll(byte[] data)
    {
        foreach (var peer in Subscribers)
        {
            peer.Send(data, DeliveryMethod.ReliableUnordered);
        }
    }
}