// -----------------------------------------------------------------------
// <copyright file="JoinWaitingListCommand.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library.Facade.Discord.Commands;

/// <summary>
/// Esta clase implementa el comando 'join' del bot. Este comando une al
/// jugador que envía el mensaje a la lista de espera. Una vez dos jugadores
/// se encuentren en la lista de espera, comienza una batalla entre ellos.
/// </summary>
public class JoinWaitingListCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'battle'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    /// <returns>Un <see cref="Task"/> que espera a terminar el comando.</returns>
    [Command("join")]
    [Summary(
        """
        Une al jugador que envía el mensaje a lista de espera.
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(this.Context);

        await this.AddUser();
    }

    private async Task AddUser()
    {
        string username = this.Context.User.GlobalName;
        Console.WriteLine(username);
        if (WaitingList.Instance.ContainsPlayer(this.Context.User.GlobalName))
        {
            await this.Context.Channel.SendMessageAsync("Ya estás en la lista de espera");
        }

        await this.Context.Channel.SendMessageAsync("No estás en la lista de espera");
    }
}
