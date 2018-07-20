using System;
using System.Threading;
using LiteNetLib;
using LiteNetLib.Utils;

class Program
{
    public static NetManager Server;
    public static NetPacketProcessor NetPacketProcessor;
    static void Main(string[] args)
    {
        Console.WriteLine("Starting server");

        EventBasedNetListener listener = new EventBasedNetListener();
        Server = new NetManager(listener);
        Server.Start(9051 /* port */);

        NetPacketProcessor = new NetPacketProcessor();

        listener.ConnectionRequestEvent += (connection) =>
        {
            connection.Accept();
        };


        listener.PeerConnectedEvent += peer =>
        {
            Console.WriteLine("New connection from: {0}", peer.EndPoint); // Show peer ip
        };

        listener.NetworkReceiveEvent += (peer, reader, method) => NetPacketProcessor.ReadAllPackets(reader, peer);

        Console.WriteLine("Server started");


        while (true)
        {
            Server.PollEvents();
            Thread.Sleep(15);
        }

        Server.Stop();
    }
}
