using System;
using System.Threading;
using System.Threading.Tasks;
using LiteNetLib;
using LiteNetLib.Utils;

class Program
{
    public static NetManager Server;
    public static NetPacketProcessor NetPacketProcessor;
    static void Main(string[] args)
    {
        Logger.Log("Starting server");

        EventBasedNetListener listener = new EventBasedNetListener();
        Server = new NetManager(listener);
        Server.Start(9051 /* port */);

        NetPacketProcessor = new NetPacketProcessor();

        listener.ConnectionRequestEvent += (connection) =>
        {
            connection.Accept();
        };

        new ChannelManager();
        new ChannelAction();
        new SubscribeAction();
        new UnsubscribeAction();

        listener.PeerConnectedEvent += peer =>
        {
            Logger.Log($"New connection from: {peer.EndPoint}"); // Show peer ip
        };

        listener.PeerDisconnectedEvent += (peer, disconnectinfo) =>
        {
            Logger.Log($"Player disconnected from: {peer.EndPoint} because of {disconnectinfo.Reason}"); // Show peer ip
        };

        listener.NetworkReceiveEvent += (peer, reader, method) =>
        {
            try
            {
                NetPacketProcessor.ReadAllPackets(reader, peer);
            }
            catch (Exception e)
            {
                Logger.Log(e.Message + " " + e.StackTrace);
            }
        };

        Logger.Log("Server started");

        MinuteLoop();

        try
        {
            while (true)
            {
                Server.PollEvents();
                Thread.Sleep(15);
            }
        }
        catch (Exception e)
        {
            Logger.Log(e.Message + " " + e.StackTrace);
        }

        Server.Stop();
    }

    static async void MinuteLoop()
    {
        while (true)
        {
            Logger.Log("Players online: " + Server.GetPeersCount(ConnectionState.Connected));
            await Task.Delay(60 * 1000);
        }
    }
}
