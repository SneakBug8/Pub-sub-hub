using LiteNetLib;

public class UnsubscribeAction : Action
{
    public UnsubscribeAction()
    {
        Program.NetPacketProcessor.SubscribeReusable<UnsubscribePacket, NetPeer>(Process);
    }

    public void Process(UnsubscribePacket packet, NetPeer peer)
    {
        if (ChannelManager.Global.Channels.ContainsKey(packet.Channel))
        {
            var channel = ChannelManager.Global.Channels[packet.Channel];
            channel.Subscibers.Remove(peer);
        }
    }
}