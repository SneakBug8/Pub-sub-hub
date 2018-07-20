using System.Collections.Generic;

public class Map
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Channel Channel;
    public List<Player> Players;
}