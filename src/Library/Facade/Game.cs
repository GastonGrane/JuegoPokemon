// -----------------------------------------------------------------------
// <copyright file="Game.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Entities;
using Library.GameLogic.Items;
using Library.GameLogic.Players;

namespace Library.Facade;

/// <summary>
/// Maneja la dinamica del juego, incluye los turnos de los jugadores, ataques, y los cambios de pokemones.
/// </summary>
/// <remarks>
/// Esta clase se podría considerar como una fachada sobre el juego de Pokemon, ya que al pasarle la conexión externa, esta
/// clase se encarga de la lógica de cómo funciona el juego, escondiendo los detalles de las clases que lo implementan.
/// </remarks>
public class Game
{
    /// <summary>
    /// La conexión al servicio externo.
    /// </summary>
    /// <remarks>
    /// A través de depender de una interfaz, y no una clase explícita, esta clase cumple con DIP. Esto ayuda, ya que hace a la clase más reutilizable, porque sea imprimir a la consola, discord, o algo para un test,
    /// únicamente requiere cambios en esta clase para lograr cambiar dónde imprime. Esto también genera cumplimiento de SRP, ya que Game se ocupa solamente de jugar el juego, interactuando con esta clase para lograr hablar con el exterior.
    /// </remarks>
    private IExternalConnection externalConnection;

    /// <summary>
    /// El primer jugador en el juego.
    /// </summary>
    private Player playerOne;

    /// <summary>
    /// El segundo jugador en el juego.
    /// </summary>
    private Player playerTwo;

    /// <summary>
    /// Inicializa el juego.
    /// </summary>
    /// <param name="p1">El primer jugador <see cref="playerOne"/>.</param>
    /// <param name="p2">El segundo jugador <see cref="playerTwo"/>.</param>
    /// <param name="externalConnection">La conección con el servicio externo.</param>
    private Game(Player p1, Player p2, IExternalConnection externalConnection)
    {
        this.playerOne = p1;
        this.playerTwo = p2;
        this.externalConnection = externalConnection;
    }

    /// <summary>
    /// Crea un nuevo juego con jugadores predefinidos.
    /// </summary>
    /// <param name="pokemon">Una lista de <see cref="Pokemon"/> para usar en el juego.</param>
    /// <returns>Una nueva instancia de <see cref="Game"/> que es hard-coded.</returns>
    /// <param name="externalConnection">La conección con el servicio externo.</param>
    public static Game CreateGame(List<Pokemon> pokemon, IExternalConnection externalConnection)
    {
        // Por ahora es hard-coded, porque es más importante jugar al juego, y no ver el proceso de crearlo
        Player p1 = new Player(
            "Axel",
            new List<Pokemon>
            {
                PokemonRegistry.GetPokemon("Pikachu"), PokemonRegistry.GetPokemon("Ivysaur"),
                PokemonRegistry.GetPokemon("Metapod"), PokemonRegistry.GetPokemon("Charmander"),
            });
        Player p2 = new Player(
            "Sharon",
            new List<Pokemon>
            {
                PokemonRegistry.GetPokemon("Mewtwo"), PokemonRegistry.GetPokemon("Golbat"),
                PokemonRegistry.GetPokemon("Charmeleon"), PokemonRegistry.GetPokemon("Oddish"),
            });
        return new Game(p1, p2, externalConnection);
    }

    /// <summary>
    /// Shows the welcome message.
    /// </summary>
    public void ShowWelcome()
    {
        this.externalConnection.PrintWelcome(this.playerOne, this.playerTwo);
    }

    /// <summary>
    /// Comienza el juego, va alternando el turno entre los jugadores. Este método inicia un bucle hasta que termine el juego. Para jugar de a turnos, utilice <see cref="PlayGameTurn()"/>.
    /// </summary>
    /// <remarks>
    /// El juego continua hasta que uno de los dos jugadores se quede sin ningun pokemon en su lista. Por el momento
    /// siempre ataca primero el @b PlayerOne y luego **PlayerTwo**
    /// De todas formas entendemos que este no justo para el jugador dos por ello tendriamos que implementar algo distinto en el futuro.
    /// </remarks>
    public void Play()
    {
        this.ShowWelcome();

        bool inGame = true;
        while (inGame)
        {
            this.PlayGameTurn();
        }
    }

    /// <summary>
    /// Ejecuta un turno del juego, es decir, una acción realizada por cada jugador.
    /// </summary>
    public void PlayGameTurn()
    {
        this.PlayTurnP1();
        if (this.CheckDead(this.playerTwo))
        {
            this.externalConnection.PrintPlayerWon(this.playerOne, this.playerTwo);
            return;
        }

        this.PlayTurnP2();
        if (this.CheckDead(this.playerOne))
        {
            this.externalConnection.PrintPlayerWon(this.playerTwo, this.playerOne);
            return;
        }
    }

    /// <summary>
    /// Ejecuta un ataque por el jugador que le toca hacia el contrincante.
    /// </summary>
    /// <param name="active">El <see cref="Player"/> que va a atacar.</param>
    /// <param name="other">El <see cref="Player"/> que va a ser atacado.</param>
    private bool AttackPlayer(Player active, Player other)
    {
        string? attackName = this.externalConnection.ShowAttacksAndRecieveInput(active.ActivePokemon);
        if (attackName == null)
        {
            return false;
        }

        int oldHP = other.ActivePokemon.Health;

        // Nunca va a tirar una excepción porque si llegó hasta acá, el nombre existe en la lista del Pokémon.
        active.Attack(other, attackName);

        // FIXME(Guzmán): Reportar mejor el resultado del ataque.
        this.externalConnection.ReportAttackResult(oldHP, active, other);

        return true;
    }

    /// <summary>
    /// Ejecuta un ataque por el jugador que le toca hacia el contrincante.
    /// </summary>
    /// <param name="active">El <see cref="Player"/> que va a usar items.</param>
    private bool UseItem(Player active)
    {
        while (true)
        {
                Item? item = this.externalConnection.ShowAItemsAndRecieveInput(active);
                if (item == null)
                {
                    return false;
                }

                int numPok = this.externalConnection.ShowPokemonMenu(active);
                if (numPok == -1)
                {
                    continue;
                }

                Pokemon pok = active.Pokemons[numPok];
                try
                {
                    item.Use(pok);
                    return true;
                }
                catch (ArgumentNullException ex)
                {
                    // Si el Pokémon es nulo
                    this.externalConnection.PrintString($"{ex.Message}.");
                    return false;
                }
                catch (InvalidOperationException ex)
                {
                    // Si el Pokémon está vivo cuando no debería estarlo (por ejemplo, con Revive)
                    this.externalConnection.PrintString($"{ex.Message}.");
                    return false;
                }
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
        while (true)
        {
            int selection = this.externalConnection.ShowMenuAndReceiveInput(
                "Elija su acción:",
                new List<string> { "Atacar", "Cambiar de Pokémon", "Usar un item" }.AsReadOnly());
            switch (selection)
            {
                case 0:
                    if (this.AttackPlayer(active, other))
                    {
                        return;
                    }

                    break;
                case 1:
                    if (this.ChangePokemon(active))
                    {
                        return;
                    }

                    break;
                case 2:
                    if (this.UseItem(active))
                    {
                        return;
                    }

                    break;
            }
        }
    }

    // Ejecuta el turno del primero jugador
    private void PlayTurnP1()
    {
        this.externalConnection.PrintTurnHeading(this.playerOne);
        this.PlayTurn(this.playerOne, this.playerTwo);
        this.playerOne.UpdateTurn();
    }

    // Ejecuta el turno del segundo jugador
    private void PlayTurnP2()
    {
        this.externalConnection.PrintTurnHeading(this.playerTwo);
        this.PlayTurn(this.playerTwo, this.playerOne);
        this.playerTwo.UpdateTurn();
    }

    /// <summary>
    /// Deja que el jugador pueda hacer un cambio de pokemon dentro de su lista ya proporcionada en <see cref="Player"/>.
    /// </summary>
    /// <param name="p">El <see cref="Player"/> quien es que está haciendo el cambio.</param>
    private bool ChangePokemon(Player p)
    {
        while (true)
        {
            int idx = this.externalConnection.ShowPokemonMenu(p);
            if (idx == -1)
            {
                return false;
            }

            if (p.ChangePokemon(idx) == false)
            {
                this.externalConnection.PrintString(
                    "No se puede cambiar a utilizar el mismo Pokemon. Intente de nuevo");
            }
            else if (p.ChangePokemon(idx) == null)
            {
                this.externalConnection.PrintString(
                    "El Pokemon que seleccionó está muerto. Intente de nuevo");
            }
            else
            {
                return true;
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
        if (p.AllAreDead())
        {
            return true;
        }

        if (p.ActivePokemon.Health == 0)
        {
            this.externalConnection.PrintString(
                $"{p.Name}, su Pokemon ha muerto, elija otro Pokemon para continuar el juego");
            this.ChangePokemon(p);
            return false;
        }

        return false;
    }
}