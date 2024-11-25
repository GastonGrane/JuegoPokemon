// -----------------------------------------------------------------------
// <copyright file="UserCommunicationTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Globalization;
using Library.Facade;
using Library.GameLogic.Attacks;
using Library.GameLogic.Entities;
using Library.GameLogic.Items;
using Library.GameLogic.Players;

#pragma warning disable SA1402 // Esta ocurre por definir el mock y los tests acá. está bien ignorarlo porque esta clase es únicamente para este archivo y nada más.

namespace Library.Tests
{
    /// <summary>
    /// Pruebas para las funcionalidades del juego utilizando una conexión externa falsa.
    /// </summary>
    [TestFixture]
    public class UserCommunicationTest
    {
        /// <summary>
        /// Verifica que el mensaje correcto se imprime al realizar un ataque crítico.
        /// </summary>
        [Test]
        public void TestCriticalHitMessage()
        {
            var connection = new FakeExternalConnection();
            var game = Game.CreateGame(new List<Pokemon>(), connection);

            game.TurnResult = new TurnResult(AttackStatus.CriticalHit, 50);
            connection.PrintStatusesAttack(game.GetPlayerOne, game.GetPlayerTwo, game.TurnResult);

            Assert.That(connection.PrintedStrings.Count, Is.EqualTo(1));
            Assert.That(
                connection.PrintedStrings[0],
                Does.Contain("¡Golpe crítico!"));
        }

        /// <summary>
        /// Verifica que el mensaje correcto se imprime al usar un item.
        /// </summary>
        [Test]
        public void TestUseItemMessage()
        {
            var connection = new FakeExternalConnection();
            var game = Game.CreateGame(new List<Pokemon>(), connection);

            game.TurnResult = new TurnResult(ItemStatus.SuperPotion);
            connection.PrintStatusesAttack(game.GetPlayerOne, game.GetPlayerTwo, game.TurnResult);

            Assert.That(connection.PrintedStrings.Count, Is.EqualTo(1));
            Assert.That(
                connection.PrintedStrings[0],
                Does.Contain("Super Poción"));
        }

        /// <summary>
        /// Verifica que se imprime el mensaje correcto al fallar un ataque.
        /// </summary>
        [Test]
        public void TestAttackMissedMessage()
        {
            var connection = new FakeExternalConnection();
            var game = Game.CreateGame(new List<Pokemon>(), connection);

            game.TurnResult = new TurnResult(AttackStatus.Miss, 0);
            connection.PrintStatusesAttack(game.GetPlayerOne, game.GetPlayerTwo, game.TurnResult);

            Assert.That(connection.PrintedStrings.Count, Is.EqualTo(1));
            Assert.That(
                connection.PrintedStrings[0],
                Does.Contain("El ataque de Pikachu falló."));
        }

        /// <summary>
        /// Verifica que el mensaje correcto se imprime al aplicar un efecto especial.
        /// </summary>
        [Test]
        public void TestSpecialEffectMessage()
        {
            var connection = new FakeExternalConnection();
            var game = Game.CreateGame(new List<Pokemon>(), connection);

            game.TurnResult = new TurnResult(AttackStatus.EffectApplied, 30);
            connection.PrintStatusesAttack(game.GetPlayerOne, game.GetPlayerTwo, game.TurnResult);

            Assert.That(connection.PrintedStrings.Count, Is.EqualTo(1));
            Assert.That(
                connection.PrintedStrings[0],
                Does.Contain("aplicó un efecto especial"));
        }
    }

    /// <summary>
    /// Implementación de una conexión externa falsa para pruebas unitarias.
    /// </summary>
    public class FakeExternalConnection : IExternalConnection
    {
        /// <summary>
        /// Obtiene una lista de mensajes impresos durante las pruebas.
        /// </summary>
        public List<string> PrintedStrings { get; } = new();

        /// <summary>
        /// Obtiene una lista de interacciones entre jugadores registradas durante las pruebas.
        /// </summary>
        public List<(Player PlayerOne, Player PlayerTwo)> PlayerInteractions { get; } = new();

        /// <summary>
        /// Obtiene una lista de resultados de ataques registrados durante las pruebas.
        /// </summary>
        public List<(int OldHp, Player Attacker, Player Defender)>? AttackResults { get; } = new();

        /// <summary>
        /// Cola de entradas simuladas para el menú.
        /// </summary>
        private Queue<int>? MenuInputs { get; } = new();

        /// <inheritdoc/>
        public void PrintString(string str)
        {
            this.PrintedStrings.Add(str);
        }

        /// <inheritdoc/>
        public void PrintWelcome(Player? p1, Player? p2)
        {
            this.PrintedStrings.Add($"Bienvenidos {p1?.Name} y {p2?.Name}");
            this.PlayerInteractions.Add(item: (p1, p2)!);
        }

        /// <inheritdoc/>
        public void PrintPlayerWon(Player? p1, Player? p2)
        {
            this.PrintedStrings.Add($"El ganador es {p1?.Name}");
            this.PlayerInteractions.Add(item: (p1, p2)!);
        }

        /// <inheritdoc/>
        public void PrintTurnHeading(Player? player)
        {
            this.PrintedStrings.Add($"Turno de {player?.Name}");
        }

        /// <inheritdoc/>
        public int ShowMenuAndReceiveInput(string selectionText, ReadOnlyCollection<string> options)
        {
            if (this.MenuInputs?.Count > 0)
            {
                return this.MenuInputs.Dequeue();
            }

            return 0;
        }

        /// <inheritdoc/>
        public string? ShowAttacksAndRecieveInput(Pokemon? pokemon)
        {
            if (this.MenuInputs?.Count > 0)
            {
                return this.MenuInputs.Dequeue()
                    .ToString(CultureInfo.InvariantCulture); // Especifica el formato invariable
            }

            return null;
        }

        /// <inheritdoc/>
        public int ShowChangePokemonMenu(Player? player)
        {
            return 0; // Simula siempre seleccionar el primer Pokémon.
        }

        /// <inheritdoc/>
        public void ReportAttackResult(int oldHP, Player? attacker, Player? defender)
        {
            this.AttackResults?.Add((oldHP, attacker, defender)!);
            var damage = defender?.ActivePokemon != null ? oldHP - defender.ActivePokemon.Health : 0;
            this.PrintedStrings.Add(
                $"{attacker?.ActivePokemon?.Name ?? "Un atacante desconocido"} atacó a {defender?.ActivePokemon?.Name ?? "un defensor desconocido"} causando {damage} de daño.");
        }

        /// <inheritdoc/>
        public void PrintStatusesAttack(Player attacker, Player defender, TurnResult turnResult)
        {
            ArgumentNullException.ThrowIfNull(turnResult, nameof(turnResult));

            switch (turnResult.AttackStatus)
            {
                case AttackStatus.CriticalHit:
                    this.PrintedStrings.Add(
                        $"¡Golpe crítico! {attacker.ActivePokemon.Name} atacó a {defender.ActivePokemon.Name}, causando {turnResult.Damage} de daño.");
                    break;

                case AttackStatus.NormalAttack:
                    this.PrintedStrings.Add(
                        $"{attacker.ActivePokemon.Name} atacó a {defender.ActivePokemon.Name}, causando {turnResult.Damage} de daño.");
                    break;

                case AttackStatus.Miss:
                    this.PrintedStrings.Add($"El ataque de {attacker.ActivePokemon.Name} falló.");
                    break;

                default:
                    this.PrintedStrings.Add("Estado de ataque desconocido.");
                    break;
            }
        }

        /// <inheritdoc/>
        public void PrintStatusesItem(Player attacker, TurnResult turnResult)
        {
            ArgumentNullException.ThrowIfNull(turnResult, nameof(turnResult));

            switch (turnResult.ItemStatus)
            {
                case ItemStatus.Revive:
                    this.PrintedStrings.Add(
                        $"{attacker.Name} usó Revive en {attacker.ActivePokemon.Name}. Vida actual: {attacker.ActivePokemon.Health}/{attacker.ActivePokemon.MaxHealth}");
                    break;

                case ItemStatus.SuperPotion:
                    this.PrintedStrings.Add(
                        $"{attacker.Name} usó Super Poción en {attacker.ActivePokemon.Name}. Vida actual: {attacker.ActivePokemon.Health}/{attacker.ActivePokemon.MaxHealth}");
                    break;

                case ItemStatus.TotalCure:
                    this.PrintedStrings.Add(
                        $"{attacker.Name} usó Cura Total en {attacker.ActivePokemon.Name}. Efectos negativos eliminados.");
                    break;

                default:
                    this.PrintedStrings.Add("Estado de ítem desconocido.");
                    break;
            }
        }
    }
}
