// -----------------------------------------------------------------------
// <copyright file="BotCommands.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;
using Discord;
using Discord.Commands;
using Library.GameLogic.Entities;
using Library.GameLogic.Players;

namespace Library.Facade.Discord;

/// <summary>
/// La colección de los comandos.
/// </summary>
public static class BotCommands
{
    /// <summary>
    /// Añade al usuario a la lista de espera. A este le pide qué pokemon quiere usar mediante mensaje privado.
    /// </summary>
    /// <param name="commandContext">El contexto del comando.</param>
    /// <returns>Un <see cref="Task"/> representando la terminación de la solicitud..</returns>
    public static async Task AddToWaitingList(SocketCommandContext commandContext)
    {
        ArgumentNullException.ThrowIfNull(commandContext);

        string userName = Helper.GetDisplayName(commandContext);
        if (WaitingList.Instance.ContainsPlayer(userName))
        {
            await commandContext.Channel.SendMessageAsync("Ya está en la lista de espera");
            return;
        }

        await commandContext.Channel.SendMessageAsync("Añadiéndolo a lista de espera. Mire sus mensajes privados.");

        IDMChannel dmChannel = await commandContext.User.CreateDMChannelAsync();
        ulong userId = commandContext.User.Id;

        string pokemonListStr = string.Empty;
        int idx = 1;
        List<Pokemon> pokemonList = PokemonRegistry.GetAllPokemon();
        foreach (Pokemon pokemon in pokemonList)
        {
            pokemonListStr += $"{idx++} - {pokemon.Name} - {pokemon.Type}\n";
        }

        CultureInfo culture = new CultureInfo("en_US");
        List<Pokemon> selected = new();
        while (true)
        {
            await dmChannel.SendMessageAsync("Elija sus pokemon: ");
            var message = await dmChannel.SendMessageAsync(pokemonListStr);

            List<IUserMessage> dms = await Helper.ReceiveDM(dmChannel, message);
            if (dms.Count > 1)
            {
                await dmChannel.SendMessageAsync("No envíe más de un mensaje");
                continue;
            }

            IUserMessage dm = dms[0];
            bool parsed = true;
            foreach (var selection in dm.Content.Split(',').Select(s => s.Trim()))
            {
                if (string.IsNullOrEmpty(selection))
                {
                    continue;
                }

                if (int.TryParse(selection, culture, out var pokemonIdx))
                {
                    selected.Add(pokemonList[pokemonIdx]);
                    continue;
                }

                bool added = true;
                foreach (Pokemon p in pokemonList)
                {
                    if (p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase))
                    {
                        selected.Add(p);
                        break;
                    }
                }

                if (added)
                {
                    continue;
                }

                await dmChannel.SendMessageAsync($"El valor ingresado \"{selection}\" no es un pokémon");
                parsed = false;
                break;
            }

            if (!parsed)
            {
                continue;
            }

            if (selected.Count == 0 || selected.Count > 6)
            {
                await dmChannel.SendMessageAsync($"Debe ingresar de 1 a 6 pokemon, ingresó {selected.Count}");
            }

            break;
        }

        string name = Helper.GetDisplayName(commandContext);
        WaitingList.Instance.AddPlayer(name, selected);
        await dmChannel.SendMessageAsync("Fue añadido correctamente a la lista de espera");
        await commandContext.Channel.SendMessageAsync("Fue añadido correctamente a la lista de espera");
    }

    /// <summary>
    /// Muestra los jugadores actualmente en la lista de espera.
    /// </summary>
    /// <param name="commandContext">El contexto del comando.</param>
    /// <returns>Un <see cref="Task"/> representando el estado de la impresión de los jugadores.</returns>
    public static async Task DisplayWaitingList(SocketCommandContext commandContext)
    {
        ArgumentNullException.ThrowIfNull(commandContext);

        var waiting = WaitingList.Instance.Waiting;

        string output = string.Empty;
        output += $"Hay {waiting.Count} jugadores en la lista de espera:\n";
        foreach (Player p in WaitingList.Instance.Waiting)
        {
            output += p.Name;
            output += " - ";
            foreach (Pokemon pok in p.Pokemons)
            {
                output += pok.Name;
                output += ", ";
            }

            output += "\n";
        }

        await commandContext.Channel.SendMessageAsync(output);
    }

    /// <summary>
    /// Revisa si hay suficientes jugadores en la lista de espera para iniciar una batalla, y si los hay, lo hace.
    /// </summary>
    /// <param name="commandContext">El contexto del comando.</param>
    /// <returns>Un <see cref="Task"/> representando el estado de la determinación de si hacer batalla o no entre los jugadores.</returns>
    public static async Task CheckIfEnoughPlayers(SocketCommandContext commandContext)
    {
        var players = WaitingList.Instance.Waiting.ToList();
        if (players.Count < 2)
        {
            return;
        }

        Player p1 = players[0];
        Player p2 = players[1];
        WaitingList.Instance.RemovePlayer(p1);
        WaitingList.Instance.RemovePlayer(p2);
        await commandContext.Channel.SendMessageAsync($"Empezando una pelea entre {p1.Name} y {p2.Name}");

        var p1User = Helper.GetUser(commandContext, p1.Name);
        if (p1User == null)
        {
            await commandContext.Channel.SendMessageAsync($"Usuario {p1.Name} no encontrado");
            return;
        }

        var p2User = Helper.GetUser(commandContext, p2.Name);
        if (p2User == null)
        {
            await commandContext.Channel.SendMessageAsync($"Usuario {p2.Name} no encontrado");
            return;
        }

        var p1Channel = await p1User.CreateDMChannelAsync();
        var p2Channel = await p2User.CreateDMChannelAsync();

        DiscordConnection conn = new(p1Channel, p2Channel);
        Thread thread = new Thread(() => new Game(p1, p2, conn).Play());
        thread.Start();
    }
}
