// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Items;

namespace Library.Player;

/// <summary>
/// Un jugador de pokemon.
/// </summary>
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
            throw new ArgumentOutOfRangeException(nameof(pokemons), "Player no puede tener más de 6 pokemons");
        }

        if (pokemons.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pokemons), "Player no puede tener 0 pokemones");
        }

        this.Name = name;
        this.Pokemons = pokemons;
        this.Items = new List<IItem>();
        this.Items.Add(new Revive());

        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());

        this.Items.Add(new TotalCure());
        this.Items.Add(new TotalCure());
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
    public void ApplyItem(Pokemon target, int item)
    {
        if (this.Pokemons.Contains(target))
        {
            if (this.Items.Count <= item)
            {
                this.Items[item].Use(target);
                this.Items.Remove(this.Items[item]); // Remtiro los items utilizados.
            }
            else
            {
                throw new KeyNotFoundException("Player no tiene este item disponible.");
            }
        }
        else
        {
            throw new InvalidOperationException("Player no tiene este pokemon en su equipo.");
        }
    }
}
