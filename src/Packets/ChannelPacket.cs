public class ChannelPacket
{
    public ChannelPacket() { }
    public ChannelPacket(string channel, string type, string content)
    {
        Channel = channel;
        Type = type;
        Content = content;
    }
    public string Channel { get; set; }
    public string Type { get; set; }
    //JSON
    public string Content { get; set; }
}