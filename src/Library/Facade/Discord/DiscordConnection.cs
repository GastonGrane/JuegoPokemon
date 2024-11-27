// -----------------------------------------------------------------------
// <copyright file="DiscordConnection.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Globalization;
using Discord;
using Library.GameLogic.Attacks;
using Library.GameLogic.Entities;
using Library.GameLogic.Items;
using Library.GameLogic.Players;
using Library.GameLogic.Utilities;

namespace Library.Facade.Discord;

/// <summary>
/// Conexión entre dos jugadores en discord.
/// </summary>
/// <remarks>
/// Lo que te termina pasando con esta clase es que, como todos los métodos son asíncronos, y la interfaz
/// solo abarca métodos síncronos, tenés que wrappear todo con Task.Run, para esperar que termine en
/// contexto síncrono. Esto implicaría que hay que cambiar la interfaz a que sea asíncrona, pero no quiero.
/// </remarks>
public class DiscordConnection : IExternalConnection
{
    private IDMChannel p1Channel;
    private IDMChannel p2Channel;
    private bool currentTurnP1;

    /// <summary>
    /// Crea la conexión que comunica con los dos usuarios provistos.
    /// </summary>
    /// <param name="p1Channel">Canal para el primer jugador.</param>
    /// <param name="p2Channel">Canal para el segundo jugador.</param>
    public DiscordConnection(IDMChannel p1Channel, IDMChannel p2Channel)
    {
        this.p1Channel = p1Channel;
        this.p2Channel = p2Channel;
        this.currentTurnP1 = new SystemRandom().Chance(50);
    }

    private IDMChannel CurrentDM
    {
        get
        {
            if (this.currentTurnP1)
            {
                return this.p1Channel;
            }
            else
            {
                return this.p2Channel;
            }
        }
    }

    /// <inheritdoc/>
    public void PrintString(string str)
    {
        Task.Run(() => this.PrintStringInternal(str)).Wait();
    }

    /// <inheritdoc/>
    public void PrintWelcome(Player p1, Player p2)
    {
        Task.Run(() => this.PrintWelcomeInternal(p1, p2)).Wait();
    }

    /// <inheritdoc/>
    public void PrintPlayerWon(Player p1, Player p2)
    {
        Task.Run(() => this.PrintPlayerWonInternal(p1, p2)).Wait();
    }

    /// <inheritdoc/>
    public void PrintTurnHeading(Player player)
    {
        Task.Run(() => this.PrintTurnHeadingInternal(player)).Wait();
    }

    /// <inheritdoc/>
    public int ShowMenuAndReceiveInput(string selectionText, ReadOnlyCollection<string> options)
    {
        ArgumentNullException.ThrowIfNull(options);

        Task<int> t = Task.Run(() => this.ShowMenuAndReceiveInputInternal(selectionText, options));
        t.Wait();
        return t.Result;
    }

    /// <inheritdoc/>
    public string? ShowAttacksAndRecieveInput(Pokemon pokemon)
    {
        Task<string?> t = Task.Run(() => this.ShowAttacksAndRecieveInputInternal(pokemon));
        t.Wait();
        return t.Result;
    }

    /// <inheritdoc/>
    public Item? ShowItemsAndRecieveInput(Player player)
    {
        throw new NotImplementedException("ShowItemsAndRecieveInput");
    }

    /// <inheritdoc/>
    public int ShowPokemonMenu(Player player)
    {
        Task<int> t = Task.Run(() => this.ShowPokemonMenuInternal(player));
        t.Wait();
        return t.Result;
    }

    /// <inheritdoc/>
    public void ReportAttackResult(int oldHP, Player attacker, Player defender)
    {
        Task.Run(() => this.ReportAttackResultInternal(oldHP, attacker, defender)).Wait();
    }

    private async Task<IMessage> ShowStringToCurrentPlayer(string str)
    {
        return await this.CurrentDM.SendMessageAsync(str);
    }

    private async Task ShowStringToBothPlayers(string str)
    {
        await this.p1Channel.SendMessageAsync(str);
        await this.p2Channel.SendMessageAsync(str);
    }

    private async Task<string> ReceiveOneDMFromCurrent(IMessage lastMessage)
    {
        while (true)
        {
            List<IUserMessage> dms = await Helper.ReceiveDM(this.CurrentDM, lastMessage);
            List<IUserMessage> filtered = dms.Where(dm => !dm.Author.IsBot).ToList();
            if (dms.Count > 1)
            {
                await this.CurrentDM.SendMessageAsync("No envíe más de un mensaje");
                continue;
            }

            IUserMessage dm = dms[0];
            return dm.Content;
        }
    }

    private async Task PrintStringInternal(string str)
    {
        await this.ShowStringToCurrentPlayer(str);
    }

    private async Task PrintWelcomeInternal(Player p1, Player p2)
    {
        await this.ShowStringToBothPlayers("COMIENZA EL JUEGO");
        await this.ShowStringToBothPlayers($"Bienvenidos {p1.Name} y {p2.Name}");
    }

    private async Task PrintTurnHeadingInternal(Player player)
    {
        await this.ShowStringToBothPlayers($"Turno de {player.Name}");
    }

    private async Task PrintPlayerWonInternal(Player p1, Player p2)
    {
        await this.ShowStringToBothPlayers($"El ganador de la partida es {p1.Name}");
    }

    private async Task<int> ShowMenuAndReceiveInputInternal(string selectionText, ReadOnlyCollection<string> options)
    {
        while (true)
        {
            await this.ShowStringToCurrentPlayer(selectionText);

            int idx = 1;
            string output = string.Empty;
            foreach (string line in options)
            {
                output += $"{idx}: {line}\n";
                idx++;
            }

            IMessage last = await this.ShowStringToCurrentPlayer(output);

            string input = await this.ReceiveOneDMFromCurrent(last);
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
            }

            if (selection != -1)
            {
                if (selection >= 1 && selection <= options.Count)
                {
                    return selection - 1;
                }

                await this.ShowStringToCurrentPlayer($"Número inválido ingresado. Se esperaba un valor entre 1 y {options.Count}");
                continue;
            }

            for (int i = 0; i < options.Count; ++i)
            {
                string line = options[i];

                if (input == line)
                {
                    return i;
                }
            }

            await this.ShowStringToCurrentPlayer("Valor inválido ingresado, se esperaba un item del menú");
            continue;
        }
    }

    private async Task<string?> ShowAttacksAndRecieveInputInternal(Pokemon pokemon)
    {
        ReadOnlyCollection<NormalAttack> attacks = pokemon.AvailableAttacks;
        while (true)
        {
            await this.ShowStringToCurrentPlayer("Seleccione un ataque");

            await this.ShowStringToCurrentPlayer("0: Volver al menú anterior");
            int idx = 1;

            string output = string.Empty;
            foreach (NormalAttack attack in attacks)
            {
                output += $"{idx}: {attack.Name} ({attack.Type})\n";
                idx++;
            }

            IMessage last = await this.ShowStringToCurrentPlayer(output);

            string input = await this.ReceiveOneDMFromCurrent(last);
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
            }

            if (selection == 0)
            {
                return null;
            }

            if (selection != -1)
            {
                if (selection >= 1 && selection <= attacks.Count)
                {
                    return attacks[selection - 1].Name;
                }

                await this.ShowStringToCurrentPlayer($"Valor inválido ingresado. Se esperaba un valor entre 1-{attacks.Count}");
                continue;
            }

            for (int i = 0; i < attacks.Count; ++i)
            {
                NormalAttack attack = attacks[i];

                if (attack.Name == input)
                {
                    return input;
                }
            }

            await this.ShowStringToCurrentPlayer("Valor inválido ingresado, se esperaba un item del menú");
            continue;
        }
    }

    private async Task ReportAttackResultInternal(int oldHP, Player attacker, Player defender)
    {
        Pokemon defendingPokemon = defender.ActivePokemon;
        await this.ShowStringToBothPlayers(
            $"{attacker.ActivePokemon.Name} atacó a {defendingPokemon.Name}, haciéndole {oldHP - defendingPokemon.Health} de daño, y dejándolo en {defendingPokemon.Health}/{defendingPokemon.MaxHealth}");
    }

    private async Task<int> ShowPokemonMenuInternal(Player player)
    {
        ReadOnlyCollection<Pokemon> pokemons = player.Pokemons.AsReadOnly();
        while (true)
        {
            await this.ShowStringToCurrentPlayer("Seleccione un Pokémon");

            await this.ShowStringToCurrentPlayer("0: Volver al menú anterior");
            int idx = 1;

            string output = string.Empty;
            foreach (Pokemon pok in pokemons)
            {
                if (pok.Health != 0)
                {
                    output += $"{idx}: {pok.Name} ({pok.Type}) HP: {pok.Health}/{pok.MaxHealth}\n";
                    idx++;
                }
                else
                {
                    output += $"{idx}: {pok.Name} ({pok.Type}) (DEAD)\n";
                    idx++;
                }
            }

            IMessage last = await this.ShowStringToCurrentPlayer(output);

            string input = await this.ReceiveOneDMFromCurrent(last);
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
            }

            if (selection == 0)
            {
                return -1;
            }

            if (selection != -1)
            {
                if (selection >= 1 && selection <= pokemons.Count)
                {
                    return selection - 1;
                }

                await this.ShowStringToCurrentPlayer($"Valor inválido ingresado. Se esperaba un valor entre 1-{pokemons.Count}");
                continue;
            }

            for (int i = 0; i < pokemons.Count; ++i)
            {
                Pokemon pok = pokemons[i];

                if (pok.Name == input)
                {
                    return i;
                }
            }

            await this.ShowStringToCurrentPlayer("Valor inválido ingresado, se esperaba un item del menú");
            continue;
        }
    }

    private async Task<Item?> ShowItemsAndRecieveInputInternal(Player player)
    {
        ArgumentNullException.ThrowIfNull(player, nameof(player));

        Dictionary<string, int> itemCant = new();
        foreach (Item item in player.Items)
        {
            if (!itemCant.TryGetValue(item.Name, out int value))
            {
                value = 0;
                itemCant[item.Name] = value;
            }

            itemCant[item.Name] = ++value;
        }

        while (true)
        {
            await this.ShowStringToCurrentPlayer("Seleccione un ítem");
            await this.ShowStringToCurrentPlayer("0: Volver al menú anterior");

            int idx = 1;
            List<Item> orderedItems = new();
            string output = string.Empty;
            foreach (var itemGroup in itemCant)
            {
                output += $"{idx}: {itemGroup.Key} (x{itemGroup.Value})\n";
                orderedItems.Add(player.Items.First(i => i.Name == itemGroup.Key));
                idx++;
            }

            IMessage last = await this.ShowStringToCurrentPlayer(output);

            string input = await this.ReceiveOneDMFromCurrent(last);
            int selection = -1;
            try
            {
                selection = int.Parse(input, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                await this.ShowStringToCurrentPlayer("Opción inválida, ingrese un número válido.");
                continue;
            }

            if (selection == 0)
            {
                return null;
            }

            if (selection >= 1 && selection <= orderedItems.Count)
            {
                return orderedItems[selection - 1];
            }

            await this.ShowStringToCurrentPlayer($"Valor inválido. Ingrese un número entre 1 y {orderedItems.Count}.");
        }
    }
}
