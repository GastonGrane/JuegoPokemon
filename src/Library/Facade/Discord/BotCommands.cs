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

        var waiting = WaitingList.Instance.GetWaiting();

        string output = string.Empty;
        output += $"Hay {waiting.Count} jugadores en la lista de espera:\n";
        foreach (Player p in WaitingList.Instance.GetWaiting())
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
}
