using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library.Facade.Discord.Commands;

/// <summary>
/// Esta clase implementa el comando 'join' del bot. Este comando une al
/// jugador que envía el mensaje a la lista de espera. Una vez dos jugadores
/// se encuentren en la lista de espera, comienza una batalla entre ellos.
/// </summary>
public class WaitListCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'battle'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("join")]
    [Summary(
        """
        Une al jugador que envía el mensaje a lista de espera.
        """)]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Display name del oponente, opcional")]
        string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(this.Context);

        await ReplyAsync("hola bro");
    }
}

