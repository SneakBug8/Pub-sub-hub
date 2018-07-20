using System;
using System.Threading;
using LiteNetLib;
using LiteNetLib.Utils;

namespace PP2P_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server");

            EventBasedNetListener listener = new EventBasedNetListener();
            NetManager server = new NetManager(listener);
            server.Start(9051 /* port */);

            listener.ConnectionRequestEvent += (connection) =>
            {
                connection.Accept();
            };


            listener.PeerConnectedEvent += peer =>
            {
                Console.WriteLine("We got connection: {0}", peer.EndPoint); // Show peer ip
                NetDataWriter writer = new NetDataWriter();                 // Create writer class
                writer.Put("Hello client!");                                // Put some string
                peer.Send(writer, DeliveryMethod.ReliableOrdered);             // Send with reliability
            };

            Console.WriteLine("Server started");


            while (true)
            {
                server.PollEvents();
                Thread.Sleep(15);
            }

            server.Stop();
        }
    }
}
