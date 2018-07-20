using LiteNetLib;

public class Player : Entity
{
    public string Name;
    public NetPeer Peer;
    public Map Map;
    public void ChangeMap(Map map)
    {
        Map.Players.Remove(this);
        Map.Channel.Subscribers.Remove(this);

        Map = map;

        Map.Players.Add(this);
        Map.Channel.Subscribers.Add(this);
    }
}