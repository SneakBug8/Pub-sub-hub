using System.Collections.Generic;

public class ChannelManager {
    public ChannelManager() {
        Global = this;
    }
    public static ChannelManager Global;
    public Dictionary<string, Channel> Channels = new Dictionary<string, Channel>();
}