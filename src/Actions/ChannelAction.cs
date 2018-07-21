using System;
using LiteNetLib;

public class ChannelAction : Action
{
    public ChannelAction()
    {
        Program.NetPacketProcessor.SubscribeReusable<ChannelPacket, NetPeer>(Process);
    }

    public void Process(ChannelPacket packet, NetPeer peer)
    {
        if (ChannelManager.Global.Channels.ContainsKey(packet.Channel))
        {
            var channel = ChannelManager.Global.Channels[packet.Channel];
            Logger.Log($"{peer.EndPoint} [{packet.Type}: {packet.Content}");
            channel.SendToAll(packet, peer);
        }
    }
}