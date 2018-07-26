# Opensource Pub/Sub hub
Free to use C# server with pub/sub and multichannel functionality.

Made using [LiteNetLib](https://github.com/RevenantX/LiteNetLib) library and NetPacketProcessor from it.

## How to use
* Install LiteNetLib in your project
* Copy packets to your project
* Connect Client to Server using LiteNetLib's tutorials
* Create NetPacketProcessor, subscribe to ChannelAction's class with your main packet processor.

I suggest using json string in Content of ChannelAction, but you can replace it with byte[] for example.

* [Exapmle of packet processor for Unity game](https://pastebin.com/VKL3NpXg)

Send SubscribePacket and UnsubscribePacket to subscribe/unsubscribe from channels by string name.

ChannelPackets are resent to every Client in the Channel.

Enjoy!

Feel free to ask me questions in Issues. Pull requests are welcomed.