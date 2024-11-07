// -----------------------------------------------------------------------
// <copyright file="Game.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

using System.Globalization;

/// <summary>
/// Maneja la dinamica del juego, incluye los turnos de los jugadores, ataques, y los cambios de pokemones.
/// </summary>
public class Game
{
    /// <summary>
    /// El primer jugador en el juego.
    /// </summary>
    private Player playerOne;

    /// <summary>
    /// El segundo jugador en el juego.
    /// </summary>
    private Player playerTwo;

    /// <summary>
    /// Variable que se utiliza temporalmente para suprimir las advertencias por no utilizar atributos de instancia en algunos metodos.
    /// </summary>
    // FIXME: Esto es para suprimir las advertencias por no utilizar atributos de instancia en algunos métodos.
    // Cuando se añada una "Message Gateway" esto se podría ir, porque se irían las advertencias para estos métodos.
    private int tmp;

    /// <summary>
    /// Inicializa el juego.
    /// </summary>
    /// <param name="p1">El primer jugador <see cref="playerOne"/>.</param>
    /// <param name="p2">El segundo jugador <see cref="playerTwo"/>.</param>
    private Game(Player p1, Player p2)
    {
        this.playerOne = p1;
        this.playerTwo = p2;
    }

    /// <summary>
    /// Crea un nuevo juego con jugadores predefinidos.
    /// </summary>
    /// <param name="pokemon">Una lista de <see cref="Pokemon"/> para usar en el juego.</param>
    /// <returns>Una nueva instancia de <see cref="Game"/> que es hard-coded.</returns>
    public static Game CreateGame(List<Pokemon> pokemon)
    {
        // Por ahora es hard-coded, porque es más importante jugar al juego, y no ver el proceso de crearlo
        Player p1 = new Player("Axel", new List<Pokemon>());
        Player p2 = new Player("Sharon", new List<Pokemon>());
        return new Game(p1, p2);
    }

    /// <summary>
    /// Comienza el juego, va alternando el turno entre los jugadores.
    /// </summary>
    /// <remarks>
    /// El juego continua hasta que uno de los dos jugadores se quede sin ningun pokemon en su lista. Por el momento
    /// siempre ataca primero el @b PlayerOne y luego **PlayerTwo**
    /// De todas formas entendemos que este no justo para el jugador dos por ello tendriamos que implementar algo distinto en el futuro.
    /// </remarks>
    public void Play()
    {
        Console.WriteLine("-------------------");
        Console.WriteLine(" COMIENZA EL JUEGO ");
        Console.WriteLine("-------------------");

        bool inGame = true;
        while (inGame)
        {
            // FIXME: Tengo entendido que Pokemon permite que ambos jugadores hagan movidas, y luego se selecciona quién ataca primero por su velocidad. Acá se juego siempre primero el turno del jugador uno, o hay otra manera de selección?
            this.PlayTurnP1();
            if (this.CheckDead(this.playerTwo))
            {
                Console.WriteLine($"{this.playerTwo.Name} todos sus Pokemon han muerto, y ha perdido. Pua pua");
                break;
            }

            this.PlayTurnP2();
            if (this.CheckDead(this.playerOne))
            {
                Console.WriteLine($"{this.playerOne.Name} todos sus Pokemon han muerto, y ha perdido. Pua pua");
                break;
            }
        }
    }

    /// <summary>
    /// Ejecuta un ataque por el jugador que le toca hacia el contrincante.
    /// </summary>
    /// <param name="active">El <see cref="Player"/> que va a atacar.</param>
    /// <param name="other">El <see cref="Player"/> que va a ser atacado.</param>
    private void AttackPlayer(Player active, Player other)
    {
        this.tmp++;
        while (true)
        {
            Console.WriteLine("Ingrese el nombre del ataque para utilizar:");
            var attacks = active.ActivePokemon.Attacks;
            for (int i = 0; i < attacks.Count; ++i)
            {
                var attack = attacks[i];

                // Console.WriteLine($"{i + 1} - {attack.Name}");
                Console.WriteLine($"- {attack.Name}");
            }

            string attackName = Console.ReadLine()!;
            Console.WriteLine();

            // Esto es sucio, sí, pero no quiero hacer que Attack devuelva la vida o algo porque la verdad que es tarde y no tengo ganas
            // Es más, esto tendría que ser actualizado para ataques especiales, pero bueno
            double oldHP = other.ActivePokemon.Health;
            try
            {
                active.Attack(other, attackName);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("El nombre de ataque fue inválido, intente de nuevo");
                continue;
            }

            double newHP = other.ActivePokemon.Health;
            Console.WriteLine(
                $"{active.ActivePokemon.Name} atacó a {other.ActivePokemon.Name}, haciéndole {oldHP - newHP} de daño, y dejándolo en {newHP}/{other.ActivePokemon.MaxHealth}");
            break;
        }
    }

    /// <summary>
    /// Maneja el turno del jugador activo.
    /// </summary>
    /// <param name="active">El <see cref="Player"/> que toma el turno.</param>
    /// <param name="other">El <see cref="Player"/> que no le toca atacar.</param>
    /// <remarks>
    /// Todos los jugadores deben poder atacar con el pokemon seleccionado, o en cambio realizar un cambio de pokemon
    /// Si el usuario genera una opcion invalida tendra que realizar nuevamente una de estas dos opciones.
    /// </remarks>
    private void PlayTurn(Player active, Player other)
    {
        Console.WriteLine($"{active.Name} es su turno de jugar");
        int selection;
        while (true)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Cambiar de Pokemon");
            Console.WriteLine();

            string input = Console.ReadLine()!;
            Console.WriteLine();

            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida, se esperaba un número entre 1 y 2");
            }
        }

        switch (selection)
        {
            case 1:
                this.AttackPlayer(active, other);
                break;
            case 2:
                this.ChangePokemon(active);
                break;
        }
    }

    // Ejecuta el turno del primero jugador
    private void PlayTurnP1()
    {
        this.PlayTurn(this.playerOne, this.playerTwo);
    }

    // Ejecuta el turno del segundo jugador
    private void PlayTurnP2()
    {
        this.PlayTurn(this.playerTwo, this.playerOne);
    }

    /// <summary>
    /// Deja que el jugador pueda hacer un cambio de pokemon dentro de su lista ya proporcionada en <see cref="Player"/>.
    /// </summary>
    /// <param name="p">El <see cref="Player"/> quien es que esta haciendo el cambio.</param>
    private void ChangePokemon(Player p)
    {
        this.tmp++;
        while (true)
        {
            Console.WriteLine("Ingrese el nombre del Pokemon para utilizar");
            for (int i = 0; i < p.Pokemons.Count; ++i)
            {
                var pokemon = p.Pokemons[i];

                // Console.WriteLine($"{i + 1} - {pokemon.Name}");
                Console.WriteLine($"- {pokemon.Name}");
            }

            string input = Console.ReadLine()!;
            if (!p.ChangePokemon(input))
            {
                Console.WriteLine("El nombre que ha ingresado no pertenece a ningún Pokemon suyo, intente de nuevo");
            }
            else
            {
                break;
            }
        }
    }

    /// <summary>
    /// Comprueba si un pokemon del jugador ha muerto.
    /// </summary>
    /// <param name="p">El <see cref="Player"/> el cual estamos viendo el estado de su pokemon.</param>
    /// <returns>
    /// <c>true</c> Si el <paramref name="p"/> no tiene ningun Pokemon restante, sino <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Si el ha muerto el pokemon activo de <paramref name="p"/> esta obligado a hacer un cambio de pokemon.
    /// </remarks>
    private bool CheckDead(Player p)
    {
        if (p.IsDead())
        {
            return true;
        }

        if (p.ActivePokemon.Health == 0)
        {
            Console.WriteLine($"{p}, su Pokemon ha muerto, elija otro Pokemon para continuar el juego");
            this.ChangePokemon(p);
            return false;
        }

        return false;
    }
}
