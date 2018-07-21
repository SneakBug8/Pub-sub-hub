using System;
using LiteNetLib;

public class SubscribeAction : Action
{
    public SubscribeAction()
    {
        Program.NetPacketProcessor.SubscribeReusable<SubscribePacket, NetPeer>(Process);
    }

    public void Process(SubscribePacket packet, NetPeer peer)
    {
        Channel channel;

        if (ChannelManager.Global.Channels.ContainsKey(packet.Channel))
        {
            channel = ChannelManager.Global.Channels[packet.Channel];
        }
        else
        {
            channel = new Channel(packet.Channel);
        }

        channel.Subscibers.Add(peer);
        Logger.Log($"{peer.EndPoint} subscibed to {packet.Channel}.");
    }
}