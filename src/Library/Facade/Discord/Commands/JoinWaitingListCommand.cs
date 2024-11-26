// -----------------------------------------------------------------------
// <copyright file="JoinWaitingListCommand.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library.GameLogic.Entities;

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
        ISocketMessageChannel channelSocket = this.Context.Channel;
        SocketUser userSocket = this.Context.User;

        if (WaitingList.Instance.ContainsPlayer(userSocket.GlobalName))
        {
            await channelSocket.SendMessageAsync("Ya estás en la lista de espera");
        }

        await channelSocket.SendMessageAsync("Añadiéndote a la lista de espera, mire sus mensajes");

        string output = string.Empty;
        int idx = 1;
        foreach (var pokemon in PokemonRegistry.GetAllPokemon())
        {
            output += $"{idx} - {pokemon.Name} - {pokemon.Type}\n";
            idx++;
        }

        while (true)
        {
            await userSocket.SendMessageAsync("Elija sus pokemon:");
            await userSocket.SendMessageAsync(output);

            string msg = await CommandHelper.WaitForUserMessage(this.Context, userSocket);
            Console.WriteLine("Got here");
            Console.WriteLine($"user sent {msg}");
        }
    }
}
