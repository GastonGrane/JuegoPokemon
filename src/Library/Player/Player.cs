// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Items;

namespace Library;

/// <summary>
/// Este un jugador en el juego, el cual tiene un nombre, y una lista con sus pokemons.
/// El jugador puede cambiar de pokemon activo, atacar a aotro jugador y verificar si todos sus pokemons estan muertos.
/// </summary>
/// <remarks>
/// La clase <see cref="Player"/> esta encargada de gestionar las interacciones basicas que puede tener un jugador con
/// sus pokemon a lo largo de la batalla de pokemon.
/// </remarks>
public class Player
{
    /// <summary>
    /// Crea una instancia del jugador con su lista de los pokemons.
    /// </summary>
    /// <param name="name">El nombre del Jugador.</param>
    /// <param name="pokemons">La lista de los pokemons del jugador. No puede ser null, o con otras palabras debe ser non-null.</param>
    public Player(string name, List<Pokemon> pokemons)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, "Un jugador no puede inicializarse con el nombre null o vacio");
        ArgumentNullException.ThrowIfNull(pokemons, "Un jugador no puede tener una lista de pokemons null");
        if (pokemons.Count > 6)
        {
            throw new ArgumentException("Este player tiene mas de 6 pokemons");
        }

        if (pokemons.Count == 0)
        {
            throw new ArgumentException("Player no puede tener 0 pokemones");
        }

        this.Name = name;
        this.Pokemons = pokemons;

        // Nota de Guzmán: Esto es _una_ solución al problema. Lo ideal, creo yo, sería utilizar cantidades del item que vayan disminuyendo. Esto no lo implementé yo, entonces queda así.
        this.Items = new List<IItem>
        {
            new Revive(),

            new SuperPotion(),
            new SuperPotion(),
            new SuperPotion(),
            new SuperPotion(),

            new TotalCure(),
            new TotalCure(),
        };
        this.ActivePokemon = pokemons[0];
    }

    /// <summary>
    /// El nombre del jugador. Esto es visible al usuario, y no es interno al codigo.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// La lista de pokemon del jugador.
    /// </summary>
    /// <value>
    /// Esta lista tiene hasta 6 pokemons.
    /// </value>
    public List<Pokemon> Pokemons { get; }

    /// <summary>
    /// Lista de items disponibles para el jugador.
    /// </summary>
    public List<IItem> Items { get; }

    /// <summary>
    /// Este atributo hace referencia al pokemon que estaria en pantalla. Esto se acutaliza con <see cref="ChangePokemon(string)"/>.
    /// </summary>
    /// <value>
    /// Debe ser una referencia a alguno de los pokemon en la lista del jugador.
    /// </value>
    public Pokemon ActivePokemon { get; private set; }

    /// <summary>
    /// Cambia el pokemon que estaria en pantalla(<see cref="ActivePokemon"/>) del jugador.
    /// </summary>
    /// <param name="newPokemon">El nombre del pokemon por el cual quiere cambiar, este debe estar en su lista de pokemon.</param>
    /// <returns>
    /// <c>true</c> si se encontro <paramref name="newPokemon"/> en <see cref="Pokemon"/>, sino <c>false</c> y no se cambia el pokemon <see cref="ActivePokemon"/>.
    /// </returns>
    /// <remarks>Si el <paramref name="newPokemon"/> no es encontrado en este jugador, no hacer nada.</remarks>
    public bool ChangePokemon(string newPokemon)
    {
        Pokemon? pokemon = this.Pokemons.Find(pokemon => pokemon.Name == newPokemon);

        if (pokemon != null)
        {
            this.ActivePokemon = pokemon;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Cambia el pokemon que estaria en pantalla(<see cref="ActivePokemon"/>) del jugador.
    /// </summary>
    /// <param name="pokeIdx">El índice del pokemon por el cual quiere cambiar, este debe ser válido para su lista de pokemon.</param>
    /// <returns>
    /// <c>true</c> si se cambió de Pokemon, <c>false</c> si el Pokemon nuevo era el mismo que el anterior.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Si <paramref name="pokeIdx"/> no es un índice en la lista.
    /// </exception>
    public bool ChangePokemon(int pokeIdx)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(pokeIdx, this.Pokemons.Count, nameof(pokeIdx));
        ArgumentOutOfRangeException.ThrowIfLessThan(pokeIdx, 0, nameof(pokeIdx));
        if (this.Pokemons[pokeIdx] == this.ActivePokemon)
        {
            return false;
        }

        this.ActivePokemon = this.Pokemons[pokeIdx];
        return true;
    }

    /// <summary>
    /// Ataca al <see cref="ActivePokemon"/> de <paramref name="other"/> utilizando el
    /// <see cref="ActivePokemon"/> del jugador con el ataque <paramref name="attackName"/>.
    /// </summary>
    /// <param name="other">El jugador a atacar. Debe ser non-null.</param>
    /// <param name="attackName">El nombre del ataque a utlizar. Debe ser un ataque válido de <see cref="ActivePokemon"/>.</param>
    /// <exception cref="System.ArgumentNullException">Si <paramref name="other"/> es null.</exception>
    /// <remarks>
    /// Esto llama al metodo <see cref="Pokemon.Attack(Pokemon, string)"/>.
    /// </remarks>
    public void Attack(Player other, string attackName)
    {
        ArgumentNullException.ThrowIfNull(other, "No se puede atacar un jugador que es null");
        this.ActivePokemon.Attack(other.ActivePokemon, attackName);
    }

    /// <summary>
    /// Devuelve el estado de si todos los pokemons del jugador han muerto.
    /// </summary>
    /// <returns><c>true</c> si todos los pokemon del jugador estan muertos, <c>false</c> en cualquier otro caso.</returns>
    public bool AllAreDead()
    {
        return this.Pokemons.All(p => p.Health == 0);
    }

    /// <summary>
    /// Aplica los Items disponibles del jugador.
    /// </summary>
    /// <param name="target">El pokémon sobre el cual usar el item.</param>
    /// <param name="item">El índice del item para utilizar.</param>
    public void ApplyItem(Pokemon target, int item)
    {
        if (!this.Pokemons.Contains(target))
        {
            throw new InvalidOperationException("Player no tiene este pokemon en su equipo.");
        }

        ArgumentOutOfRangeException.ThrowIfGreaterThan(item, this.Items.Count, nameof(item));

        this.Items[item].Use(target);
        this.Items.Remove(this.Items[item]); // Retiro el item utilizado.
    }
}
