using System.Collections.Generic;
using LiteNetLib;

public static class GameManager
{
    public static List<Map> Maps = new List<Map>();
    public static List<Player> Players = new List<Player>();
    public static Player PlayerByNetPeer(NetPeer user)
    {
        foreach (var Player in Players)
        {
            if (Player.Peer == user)
            {
                return Player;
            }
        }

        return null;
    }

    public static Player PlayerByName(string name)
    {
        foreach (var Player in Players)
        {
            if (Player.Name == name)
            {
                return Player;
            }
        }

        return null;
    }

    public static Map MapById(string id)
    {
        foreach (var Map in Maps)
        {
            if (Map.Id == id)
            {
                return Map;
            }
        }

        return null;
    }
}