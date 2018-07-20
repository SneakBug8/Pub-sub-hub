using LiteNetLib;

public class SubscribeAction : Action {
    public SubscribeAction() {
        Program.NetPacketProcessor.SubscribeReusable<SubscribePacket, NetPeer>(Process);
    }

    public virtual void Process(SubscribePacket packet, NetPeer peer) {

    }
}