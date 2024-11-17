using System.Collections.ObjectModel;
using NUnit.Framework;
using Library.GameLogic;
using Library.GameLogic.Players;
using Library.Facade;

/// <summary>
/// Pruebas unitarias para verificar el comportamiento de las funcionalidades relacionadas con el estado del juego,
/// incluyendo ataques y uso de ítems.
/// </summary>
[TestFixture]
public class GameStateTests
{
    /// <summary>
    /// Verifica que se imprime correctamente un ataque crítico y que el estado del ataque se restablece a vacío.
    /// </summary>
    [Test]
    public void PrintStatuses_CriticalHit()
    {
        var connection = new FakeConnection();
        var attacker = new Player("Jugador1", new List<Pokemon> { PokemonRegistry.GetPokemon("Pikachu") });
        var defender = new Player("Jugador2", new List<Pokemon> { PokemonRegistry.GetPokemon("Bulbasaur") });

        CommunicationUser.attackStatus = AttackStatus.CriticalHit;

        GameState.PrintStatuses(connection, attacker, defender);

        Assert.IsTrue(connection.Output.Contains("¡Golpe crítico!"));
        Assert.AreEqual(AttackStatus.Empty, CommunicationUser.attackStatus);
    }

    /// <summary>
    /// Verifica que se imprime correctamente el uso de una Super Poción y que el estado del ítem se restablece a vacío.
    /// </summary>
    [Test]
    public void PrintStatuses_SuperPotion()
    {
        var connection = new FakeConnection();
        var attacker = new Player("Jugador1", new List<Pokemon> { PokemonRegistry.GetPokemon("Pikachu") });
        attacker.ActivePokemon.Heal(50);

        CommunicationUser.itemStatus = ItemStatus.SuperPotion;
        
        GameState.PrintStatuses(connection, attacker, attacker);
        
        Assert.IsTrue(connection.Output.Contains("usó Super Poción"));
        Assert.AreEqual(ItemStatus.Empty, CommunicationUser.itemStatus);
    }

    /// <summary>
    /// Verifica que el cálculo de daño crítico retorna un valor mayor a cero.
    /// </summary>
    [Test]
    public void CalculateDamage_CriticalHit()
    {
        var attacker = new Player("Jugador1", new List<Pokemon> { PokemonRegistry.GetPokemon("Pikachu") });
        var defender = new Player("Jugador2", new List<Pokemon> { PokemonRegistry.GetPokemon("Bulbasaur") });

        int damage = GameState.CalculateDamage(attacker, defender, true);

        Assert.IsTrue(damage > 0, "El daño crítico debe ser mayor que 0.");
    }

    /// <summary>
    /// Clase FakeConnection para simular la conexión y almacenar el output generado durante los tests.
    /// </summary>
    private class FakeConnection : IExternalConnection
    {
        /// <summary>
        /// Salida generada por las interacciones con la conexión.
        /// </summary>
        public string Output { get; private set; } = "";

        /// <summary>
        /// Imprime una cadena de texto y la almacena en la salida.
        /// </summary>
        /// <param name="str">La cadena de texto a imprimir.</param>
        public void PrintString(string str)
        {
            Output += str + "\n";
        }

        /// <summary>
        /// Imprime un mensaje de bienvenida para los jugadores.
        /// </summary>
        public void PrintWelcome(Player p1, Player p2)
        {
            PrintString($"Bienvenidos {p1.Name} y {p2.Name}");
        }

        /// <summary>
        /// Imprime un mensaje anunciando al jugador ganador.
        /// </summary>
        public void PrintPlayerWon(Player p1, Player p2)
        {
            PrintString($"El ganador de la partida es {p1.Name}");
        }

        /// <summary>
        /// Imprime el encabezado del turno del jugador actual.
        /// </summary>
        public void PrintTurnHeading(Player player)
        {
            PrintString($"Turno de {player.Name}");
        }

        /// <summary>
        /// Simula la entrada del usuario para un menú de opciones.
        /// </summary>
        public int ShowMenuAndReceiveInput(string selectionText, ReadOnlyCollection<string> options)
        {
            return 0; // Placeholder para simular entradas de menú
        }

        /// <summary>
        /// Simula la entrada del usuario para seleccionar un ataque.
        /// </summary>
        public string? ShowAttacksAndRecieveInput(Pokemon pokemon)
        {
            return pokemon.Attacks[0].Name; // Siempre elige el primer ataque
        }

        /// <summary>
        /// Reporta el resultado de un ataque y almacena la salida.
        /// </summary>
        public void ReportAttackResult(int oldHP, Player attacker, Player defender)
        {
            PrintString($"{attacker.ActivePokemon.Name} atacó a {defender.ActivePokemon.Name}, haciendo {oldHP - defender.ActivePokemon.Health} de daño.");
        }

        /// <summary>
        /// Simula la entrada del usuario para cambiar de Pokémon.
        /// </summary>
        public int ShowChangePokemonMenu(Player player)
        {
            return 0; // Placeholder para cambio de Pokémon
        }
    }
}
