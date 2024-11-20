// -----------------------------------------------------------------------
// <copyright file="ConsoleConnection.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using Library.GameLogic.Attacks;
using Library.GameLogic.Items;
using Library.GameLogic.Players;
using Library.GameLogic.Pokemon;

namespace Library.Facade;

/// <summary>
/// Un <see cref="IExternalConnection"/> que imprime/toma entrada de la consola.
/// </summary>
/// <remarks>
/// Cumple con SRP "Single Responsability Principle", ya que su unica responsabilidad es manejar la interaccion con la consola.
/// Cumple con LSP "Liskov Substitution Principle" ya que al implementar el contrato de la interfaz, se puede utilizar en cualquier lugar
/// que se utilize la interfaz, mantienendo el comportamiento esperado.
/// Cumple con DIP "Dependency Inversion Principle" debido a que clases de alto nivel dependen de la
/// interfaz IExternalConnection en lugar de depender de ConsoleConnection directamente. Esto permite que las clases de alto nivel
/// puedan funcionar sin estar acopladas a una implementación concreta.
/// </remarks>
public class ConsoleConnection : IExternalConnection
{
    /// <inheritdoc/>
    public void PrintString(string str)
    {
        Console.WriteLine(str);
    }

    /// <inheritdoc/>
    public void PrintWelcome(Player p1, Player p2)
    {
        ArgumentNullException.ThrowIfNull(p1, nameof(p1));
        ArgumentNullException.ThrowIfNull(p2, nameof(p2));

        Console.WriteLine("-------------------");
        Console.WriteLine(" COMIENZA EL JUEGO ");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Bienvenidos {p1.Name} y {p2.Name}");
    }

    /// <inheritdoc/>
    public void PrintPlayerWon(Player p1, Player p2)
    {
        ArgumentNullException.ThrowIfNull(p1, nameof(p1));
        ArgumentNullException.ThrowIfNull(p2, nameof(p2));

        Console.WriteLine($"El ganador de la partida es {p1.Name}");
    }

    /// <inheritdoc/>
    public void PrintTurnHeading(Player player)
    {
        ArgumentNullException.ThrowIfNull(player, nameof(player));

        Console.WriteLine($"Turno de {player.Name}");
    }

    /// <inheritdoc/>
    public int ShowMenuAndReceiveInput(string selectionText, ReadOnlyCollection<string> options)
    {
        ArgumentNullException.ThrowIfNull(options, nameof(options));

        while (true)
        {
            Console.WriteLine(selectionText);
            int idx = 1;
            foreach (string line in options)
            {
                Console.WriteLine($"{idx}: {line}");
                idx++;
            }

            string input = Console.ReadLine()!;
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida, se esperaba un número entre 1 y 2");
            }

            if (selection != -1)
            {
                if (selection >= 1 && selection <= options.Count)
                {
                    return selection - 1;
                }

                Console.WriteLine($"Valor inválido ingresado. Se esperaba un valor entre 1-{options.Count}");
                continue;
            }

            for (int i = 0; i < options.Count; ++i)
            {
                string line = options[i];

                // FIXME(Guzmán): Sensible o no a mayús.?
                if (input == line)
                {
                    return i;
                }
            }

            Console.WriteLine("Valor inválido ingresado, se esperaba un item del menú");
        }
    }

    /// <inheritdoc/>
    public string? ShowAttacksAndRecieveInput(Pokemon pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));

        ReadOnlyCollection<NormalAttack> attacks = pokemon.Attacks;
        while (true)
        {
            Console.WriteLine("Seleccione un ataque");

            Console.WriteLine("0: Volver al menú anterior");
            int idx = 1;

            // FIXME(Guzmán): Esto sería algo como p.AttackAvailable, pero no está hecho eso.
            foreach (NormalAttack attack in attacks)
            {
                Console.WriteLine($"{idx}: {attack.Name} ({attack.Type})");
                idx++;
            }

            string input = Console.ReadLine()!;
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida, se esperaba un número entre 1 y 2");
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

                Console.WriteLine($"Valor inválido ingresado. Se esperaba un valor entre 1-{attacks.Count}");
                continue;
            }

            for (int i = 0; i < attacks.Count; ++i)
            {
                NormalAttack attack = attacks[i];

                // FIXME(Guzmán): Sensible o no a mayús.?
                if (attack.Name == input)
                {
                    return input;
                }
            }

            Console.WriteLine("Valor inválido ingresado, se esperaba un item del menú");
        }
    }

    /// <inheritdoc/>
    public void ReportAttackResult(int oldHp, Player attacker, Player defender)
    {
        ArgumentNullException.ThrowIfNull(attacker, nameof(attacker));
        ArgumentNullException.ThrowIfNull(defender, nameof(defender));

        Pokemon defendingPokemon = defender.ActivePokemon;
        Console.WriteLine(
            $"{attacker.ActivePokemon.Name} atacó a {defendingPokemon.Name}, haciéndole {oldHp - defendingPokemon.Health} de daño, y dejándolo en {defendingPokemon.Health}/{defendingPokemon.MaxHealth}");
    }

    /// <inheritdoc/>
    public int ShowChangePokemonMenu(Player player)
    {
        ArgumentNullException.ThrowIfNull(player, nameof(player));

        ReadOnlyCollection<Pokemon> pokemons = player.Pokemons.AsReadOnly();
        while (true)
        {
            Console.WriteLine("Seleccione un Pokémon");

            Console.WriteLine("0: Volver al menú anterior");
            int idx = 1;

            // FIXME(Guzmán): Esto sería algo como p.AttackAvailable, pero no está hecho eso.
            foreach (Pokemon pok in pokemons)
            {
                Console.WriteLine($"{idx}: {pok.Name} ({pok.Type})");
                idx++;
            }

            string input = Console.ReadLine()!;
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida, se esperaba un número entre 1 y 2");
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

                Console.WriteLine($"Valor inválido ingresado. Se esperaba un valor entre 1-{pokemons.Count}");
                continue;
            }

            for (int i = 0; i < pokemons.Count; ++i)
            {
                Pokemon pok = pokemons[i];

                // FIXME(Guzmán): Sensible o no a mayús.?
                if (pok.Name == input)
                {
                    return i;
                }
            }

            Console.WriteLine("Valor inválido ingresado, se esperaba un item del menú");
        }
    }

    /// <summary>
    /// Imprime el resumen de la partida, incluyendo el estado del ataque y el uso de ítems.
    /// </summary>
    /// <param name="attacker">El jugador que realizó el ataque.</param>
    /// <param name="defender">El jugador defensor cuyo Pokémon fue atacado.</param>
    /// <param name="game">El estado actual del juego, que contiene información del ataque e ítems utilizados.</param>
    public void PrintStatuses(Player attacker, Player defender, Game? game)
    {
        Debug.Assert(game?.AttackResult != null, "game.AttackResult != null");
        switch (game.AttackResult.AttackStatus)
        {
            case AttackStatus.CriticalHit:
                Console.WriteLine(
                    $"¡Golpe crítico! {attacker?.ActivePokemon.Name} atacó a {defender?.ActivePokemon.Name}, causando {game.AttackResult.Damage} de daño. Vida restante: {defender?.ActivePokemon.Health}/{defender?.ActivePokemon.MaxHealth}.");
                game.AttackResult = new AttackResult(AttackStatus.Empty, 0);
                break;

            case AttackStatus.NormalAttack:
                Console.WriteLine(
                    $"{attacker?.ActivePokemon.Name} atacó a {defender?.ActivePokemon.Name}, causando {game.AttackResult.Damage} de daño. Vida restante: {defender?.ActivePokemon.Health}/{defender?.ActivePokemon.MaxHealth}.");
                game.AttackResult = new AttackResult(AttackStatus.Empty, 0);
                break;

            case AttackStatus.EffectApplied:
                Console.WriteLine(
                    $"{attacker?.ActivePokemon.Name} aplicó un efecto especial a {defender?.ActivePokemon.Name}. Vida restante: {defender?.ActivePokemon.Health}/{defender?.ActivePokemon.MaxHealth}.");
                game.AttackResult = new AttackResult(AttackStatus.Empty, 0);
                break;

            case AttackStatus.NoEffect:
                Console.WriteLine(
                    $"El ataque de {attacker?.ActivePokemon.Name} no tuvo efecto sobre {defender?.ActivePokemon.Name}.");
                game.AttackResult = new AttackResult(AttackStatus.Empty, 0);
                break;

            case AttackStatus.HinderingEffect:
                Console.WriteLine(
                    $"El ataque de {attacker?.ActivePokemon.Name} fue bloqueado por un efecto en {defender?.ActivePokemon.Name}.");
                game.AttackResult = new AttackResult(AttackStatus.Empty, 0);
                break;

            case AttackStatus.NotAvailable:
                Console.WriteLine(
                    $"El ataque de {attacker?.ActivePokemon.Name} no esta disponible.");
                game.AttackResult = new AttackResult(AttackStatus.Empty, 0);
                break;

            case AttackStatus.Miss:
                Console.WriteLine(
                    $"El ataque falló. Intenta de nuevo en tu próximo turno..");
                game.AttackResult = new AttackResult(AttackStatus.Empty, 0);
                break;
        }

        if (game.ItemResult != null)
        {
            switch (game.ItemResult.ItemStatus)
            {
                case ItemStatus.Revive:
                    Console.WriteLine(
                        $"{attacker?.Name} usó Revive. {attacker?.ActivePokemon.Name} fue revivido y ahora tiene {attacker?.ActivePokemon.Health}/{attacker?.ActivePokemon.MaxHealth} puntos de vida.");
                    game.ItemResult = new ItemResult(ItemStatus.Empty);
                    break;

                case ItemStatus.SuperPotion:
                    Console.WriteLine(
                        $"{attacker?.Name} usó Super Poción en {attacker?.ActivePokemon.Name}. Vida actual: {attacker?.ActivePokemon.Health}/{attacker?.ActivePokemon.MaxHealth}.");
                    game.ItemResult = new ItemResult(ItemStatus.Empty);
                    break;

                case ItemStatus.TotalCure:
                    Console.WriteLine(
                        $"{attacker?.Name} usó Cura Total. {attacker?.ActivePokemon.Name} ya no está afectado por efectos negativos.");
                    game.ItemResult = new ItemResult(ItemStatus.Empty);
                    break;
                case ItemStatus.Empty:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attacker));
            }
        }
    }
}
