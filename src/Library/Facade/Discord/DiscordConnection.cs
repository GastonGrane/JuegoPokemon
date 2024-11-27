
using Discord;

namespace Library.Facade.Discord;

public class DiscordConnection : IExternalConnection
{
    private IDMChannel p1Channel;
    private IDMChannel p2Channel;

    public DiscordConnection(IDMChannel p1Channel, IDMChannel p2Channel)
    {
        this.p1Channel = p1Channel;
        this.p2Channel = p2Channel;
    }
}
