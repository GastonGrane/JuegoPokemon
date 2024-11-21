// -----------------------------------------------------------------------
// <copyright file="PokemonRegistry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Attacks;

namespace Library.GameLogic;

/// <summary>
/// Colección de Pokémon pre-definidos.
/// </summary>
/// <remarks>
/// Se podría decir que es una implementación de <see href="https://refactoring.guru/design-patterns/prototype">Prototype</see>.
/// Esto es porque esta clase permite conseguir un objeto de la clase Pokemon sin conocer su estructura, a través de el nombre del objeto, clonando un prototipo pre-definido.
/// </remarks>
public class PokemonRegistry
{
    private static PokemonRegistry? instance;

    /// <summary>
    /// El diccionario entre nombre de Pokemon y Pokemon. Lo devuelto al usuario será una copia de un elemento de este diccionario.
    /// </summary>
    private Dictionary<string, Pokemon> pokemon;

    private PokemonRegistry(Dictionary<string, Pokemon> pokemon)
    {
        this.pokemon = pokemon;
    }

    /// <summary>
    /// El singleton del registro.
    /// </summary>
    public static PokemonRegistry Instance
    {
        get
        {
            if (instance == null)
            {
                InitSingleton();
            }

            return instance!;
        }
    }

    /// <summary>
    /// Inicializa <see cref="Instance"/> con los ataques predefinidos.
    /// </summary>
    public static void InitSingleton()
    {
        Dictionary<string, Pokemon> pokemon = new();
        void Add(string name, PokemonType type, int maxHealth, List<NormalAttack> attacks)
        {
            pokemon.Add(name, new Pokemon(name, type, maxHealth, attacks));
        }

        // Estos son los primero 40 y algo, y algunos al final que quería poner porque eran piola.
        Add("Pikachu", PokemonType.Electric, 35, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Thunder Shock"),
            AttackRegistry.GetNormalAttack("Quick Attack"),
            AttackRegistry.GetNormalAttack("Thunder Wave"),
            AttackRegistry.GetNormalAttack("Thunderbolt"),
        });
        Add("Bulbasaur", PokemonType.Grass, 45, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Tackle"),
            AttackRegistry.GetNormalAttack("Vine Whip"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
        });
        Add("Ivysaur", PokemonType.Grass, 60, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Vine Whip"),
            AttackRegistry.GetNormalAttack("Razor Leaf"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
        });
        Add("Venusaur", PokemonType.Grass, 80, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Razor Leaf"),
            AttackRegistry.GetNormalAttack("Solar Beam"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Petal Dance"),
        });
        Add("Charmander", PokemonType.Fire, 39, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Scratch"),
            AttackRegistry.GetNormalAttack("Ember"),
            AttackRegistry.GetNormalAttack("Fire Spin"),
            AttackRegistry.GetNormalAttack("Slash"),
        });
        Add("Charmeleon", PokemonType.Fire, 58, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Slash"),
            AttackRegistry.GetNormalAttack("Flamethrower"),
            AttackRegistry.GetNormalAttack("Fire Spin"),
            AttackRegistry.GetNormalAttack("Dragon Rage"),
        });
        Add("Charizard", PokemonType.Fire, 78, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Air Slash"),
            AttackRegistry.GetNormalAttack("Flamethrower"),
            AttackRegistry.GetNormalAttack("Fire Spin"),
            AttackRegistry.GetNormalAttack("Fire Blast"),
        });
        Add("Squirtle", PokemonType.Water, 44, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Tackle"),
            AttackRegistry.GetNormalAttack("Water Gun"),
            AttackRegistry.GetNormalAttack("Bubble"),
            AttackRegistry.GetNormalAttack("Bite"),
        });
        Add("Wartortle", PokemonType.Water, 59, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Water Gun"),
            AttackRegistry.GetNormalAttack("Bite"),
            AttackRegistry.GetNormalAttack("Water Pulse"),
            AttackRegistry.GetNormalAttack("Aqua Tail"),
        });
        Add("Blastoise", PokemonType.Water, 79, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Water Gun"),
            AttackRegistry.GetNormalAttack("Hydro Pump"),
            AttackRegistry.GetNormalAttack("Ice Beam"),
            AttackRegistry.GetNormalAttack("Flash Cannon"),
        });
        Add("Caterpie", PokemonType.Bug, 45, new List<NormalAttack>
        {
        AttackRegistry.GetNormalAttack("Tackle"),
        AttackRegistry.GetNormalAttack("Bug Bite"),
        AttackRegistry.GetNormalAttack("String Shot"),
        AttackRegistry.GetNormalAttack("Poison Powder"),
        });
        Add("Metapod", PokemonType.Bug, 50, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Tackle"),
            AttackRegistry.GetNormalAttack("Bug Bite"),
            AttackRegistry.GetNormalAttack("Harden"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
        });
        Add("Butterfree", PokemonType.Bug, 60, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Air Slash"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
            AttackRegistry.GetNormalAttack("Bug Buzz"),
        });
        Add("Weedle", PokemonType.Bug, 40, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Poison Sting"),
            AttackRegistry.GetNormalAttack("Bug Bite"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
            AttackRegistry.GetNormalAttack("String Shot"),
        });
        Add("Kakuna", PokemonType.Bug, 45, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Poison Sting"),
            AttackRegistry.GetNormalAttack("Bug Bite"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
            AttackRegistry.GetNormalAttack("Harden"),
        });
        Add("Beedrill", PokemonType.Bug, 65, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Twineedle"),
            AttackRegistry.GetNormalAttack("Poison Jab"),
            AttackRegistry.GetNormalAttack("Toxic"),
            AttackRegistry.GetNormalAttack("Pin Missile"),
        });
        Add("Pidgey", PokemonType.Bug, 40, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Tackle"),
            AttackRegistry.GetNormalAttack("Gust"),
            AttackRegistry.GetNormalAttack("Quick Attack"),
            AttackRegistry.GetNormalAttack("Wing Attack"),
        });
        Add("Pidgeotto", PokemonType.Bug, 63, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Wing Attack"),
            AttackRegistry.GetNormalAttack("Air Slash"),
            AttackRegistry.GetNormalAttack("Quick Attack"),
            AttackRegistry.GetNormalAttack("Aerial Ace"),
        });
        Add("Pidgeot", PokemonType.Bug, 83, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Air Slash"),
            AttackRegistry.GetNormalAttack("Hurricane"),
            AttackRegistry.GetNormalAttack("Quick Attack"),
            AttackRegistry.GetNormalAttack("Sky Attack"),
        });
        Add("Rattata", PokemonType.Normal, 30, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Tackle"),
            AttackRegistry.GetNormalAttack("Quick Attack"),
            AttackRegistry.GetNormalAttack("Bite"),
            AttackRegistry.GetNormalAttack("Hyper Fang"),
        });
        Add("Raticate", PokemonType.Normal, 55, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Quick Attack"),
            AttackRegistry.GetNormalAttack("Hyper Fang"),
            AttackRegistry.GetNormalAttack("Super Fang"),
            AttackRegistry.GetNormalAttack("Double-Edge"),
        });
        Add("Spearow", PokemonType.Flying, 40, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Peck"),
            AttackRegistry.GetNormalAttack("Fury Attack"),
            AttackRegistry.GetNormalAttack("Aerial Ace"),
            AttackRegistry.GetNormalAttack("Quick Attack"),
        });
        Add("Fearow", PokemonType.Flying, 65, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Drill Peck"),
            AttackRegistry.GetNormalAttack("Aerial Ace"),
            AttackRegistry.GetNormalAttack("Sky Attack"),
            AttackRegistry.GetNormalAttack("Quick Attack"),
        });
        Add("Ekans", PokemonType.Poison, 35, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Wrap"),
            AttackRegistry.GetNormalAttack("Poison Sting"),
            AttackRegistry.GetNormalAttack("Toxic"),
            AttackRegistry.GetNormalAttack("Bite"),
        });
        Add("Arbok", PokemonType.Poison, 60, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Poison Fang"),
            AttackRegistry.GetNormalAttack("Crunch"),
            AttackRegistry.GetNormalAttack("Toxic"),
            AttackRegistry.GetNormalAttack("Gunk Shot"),
        });
        Add("Raichu", PokemonType.Electric, 60, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Thunderbolt"),
            AttackRegistry.GetNormalAttack("Thunder"),
            AttackRegistry.GetNormalAttack("Thunder Wave"),
            AttackRegistry.GetNormalAttack("Iron Tail"),
        });
        Add("Jigglypuff", PokemonType.Normal, 115, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Pound"),
            AttackRegistry.GetNormalAttack("Sing"),
            AttackRegistry.GetNormalAttack("Body Slam"),
            AttackRegistry.GetNormalAttack("Double Slap"),
        });
        Add("Wigglytuff", PokemonType.Normal, 140, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Double Slap"),
            AttackRegistry.GetNormalAttack("Body Slam"),
            AttackRegistry.GetNormalAttack("Sing"),
            AttackRegistry.GetNormalAttack("Hyper Voice"),
        });
        Add("Zubat", PokemonType.Poison, 40, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Wing Attack"),
            AttackRegistry.GetNormalAttack("Supersonic"),
            AttackRegistry.GetNormalAttack("Poison Fang"),
            AttackRegistry.GetNormalAttack("Air Cutter"),
        });
        Add("Golbat", PokemonType.Poison, 75, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Air Slash"),
            AttackRegistry.GetNormalAttack("Toxic"),
            AttackRegistry.GetNormalAttack("Poison Fang"),
            AttackRegistry.GetNormalAttack("Cross Poison"),
        });
        Add("Oddish", PokemonType.Grass, 45, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Absorb"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
            AttackRegistry.GetNormalAttack("Razor Leaf"),
        });
        Add("Gloom", PokemonType.Poison, 60, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Petal Dance"),
            AttackRegistry.GetNormalAttack("Stun Spore"),
            AttackRegistry.GetNormalAttack("Acid"),
            AttackRegistry.GetNormalAttack("Mega Drain"),
        });
        Add("Vileplume", PokemonType.Poison, 75, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Petal Blizzard"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Sludge Bomb"),
            AttackRegistry.GetNormalAttack("Solar Beam"),
        });
        Add("Paras", PokemonType.Bug, 35, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Scratch"),
            AttackRegistry.GetNormalAttack("Spore"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
            AttackRegistry.GetNormalAttack("Fury Cutter"),
        });
        Add("Parasect", PokemonType.Bug, 60, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("X-Scissor"),
            AttackRegistry.GetNormalAttack("Spore"),
            AttackRegistry.GetNormalAttack("Cross Poison"),
            AttackRegistry.GetNormalAttack("Giga Drain"),
        });
        Add("Venonat", PokemonType.Bug, 60, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Confusion"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Poison Fang"),
            AttackRegistry.GetNormalAttack("Signal Beam"),
        });
        Add("Venomoth", PokemonType.Bug, 70, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Bug Buzz"),
            AttackRegistry.GetNormalAttack("Sleep Powder"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
            AttackRegistry.GetNormalAttack("Psychic"),
        });
        Add("Diglett", PokemonType.Ground, 10, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Dig"),
            AttackRegistry.GetNormalAttack("Scratch"),
            AttackRegistry.GetNormalAttack("Sand Attack"),
            AttackRegistry.GetNormalAttack("Mud Slap"),
        });
        Add("Dugtrio", PokemonType.Ground, 35, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Earthquake"),
            AttackRegistry.GetNormalAttack("Earth Power"),
            AttackRegistry.GetNormalAttack("Sand Tomb"),
            AttackRegistry.GetNormalAttack("Slash"),
        });
        Add("Meowth", PokemonType.Normal, 40, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Scratch"),
            AttackRegistry.GetNormalAttack("Pay Day"),
            AttackRegistry.GetNormalAttack("Screech"),
            AttackRegistry.GetNormalAttack("Fury Swipes"),
        });
        Add("Snorlax", PokemonType.Normal, 160, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Body Slam"),
            AttackRegistry.GetNormalAttack("Yawn"),
            AttackRegistry.GetNormalAttack("Giga Impact"),
            AttackRegistry.GetNormalAttack("Crunch"),
        });
        Add("Articuno", PokemonType.Ice, 90, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Ice Beam"),
            AttackRegistry.GetNormalAttack("Freeze-Dry"),
            AttackRegistry.GetNormalAttack("Hurricane"),
            AttackRegistry.GetNormalAttack("Blizzard"),
        });
        Add("Zapdos", PokemonType.Electric, 90, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Thunder"),
            AttackRegistry.GetNormalAttack("Thunder Wave"),
            AttackRegistry.GetNormalAttack("Drill Peck"),
            AttackRegistry.GetNormalAttack("Thunderbolt"),
        });
        Add("Moltres", PokemonType.Fire, 90, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Fire Blast"),
            AttackRegistry.GetNormalAttack("Heat Wave"),
            AttackRegistry.GetNormalAttack("Hurricane"),
            AttackRegistry.GetNormalAttack("Sky Attack"),
        });
        Add("Mewtwo", PokemonType.Psychic, 106, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Psychic"),
            AttackRegistry.GetNormalAttack("Hypnosis"),
            AttackRegistry.GetNormalAttack("Aura Sphere"),
            AttackRegistry.GetNormalAttack("Psystrike"),
        });
        Add("Mew", PokemonType.Bug, 100, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Psychic"),
            AttackRegistry.GetNormalAttack("Hypnosis"),
            AttackRegistry.GetNormalAttack("Thunder Wave"),
            AttackRegistry.GetNormalAttack("Ancient Power"),
        });
        Add("Dragonair", PokemonType.Dragon, 61, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Dragon Rage"),
            AttackRegistry.GetNormalAttack("Thunder Wave"),
            AttackRegistry.GetNormalAttack("Aqua Tail"),
            AttackRegistry.GetNormalAttack("Slam"),
        });
        Add("Dragonite", PokemonType.Dragon, 91, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Dragon Rush"),
            AttackRegistry.GetNormalAttack("Thunder Wave"),
            AttackRegistry.GetNormalAttack("Fire Punch"),
            AttackRegistry.GetNormalAttack("Hurricane"),
        });
        Add("Geodude", PokemonType.Rock, 40, new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Rock Throw"),
            AttackRegistry.GetNormalAttack("Magnitude"),
            AttackRegistry.GetNormalAttack("Sand Attack"),
            AttackRegistry.GetNormalAttack("Rock Blast"),
        });

        instance = new(pokemon);
    }

    /// <summary>
    /// Retorna una copia del Pokémon cuyo nombre es <paramref name="name"/>, si se encuentra en el registro.
    /// </summary>
    /// <param name="name">El nombre del <see cref="Pokemon"/>.</param>
    /// <exception cref="KeyNotFoundException">
    /// Si el Pokémon no está en el registro.
    /// </exception>
    /// <returns>
    /// Una copia del Pokémon cuyo nombre es <paramref name="name"/>.
    /// </returns>
    public static Pokemon GetPokemon(string name)
    {
        Pokemon p = Instance.pokemon[name];
        return new Pokemon(p);
    }

    /// <summary>
    /// Retorna una lista de todos los Pokemon del registro.
    /// </summary>
    /// <returns>
    /// Lista de todos los Pokemon del registro.
    /// </returns>
    public static List<Pokemon> GetAllPokemon()
    {
        return Instance.pokemon.Values.ToList();
    }

    /// <summary>
    /// Retorna una lista de tuplas donde cada una es el nombre y tipo de un Pokémon del registro.
    /// </summary>
    /// <returns>
    /// Lista de (Nombre, Tipo).
    /// </returns>
    public static List<(string Name, PokemonType Type)> GetPokemonNamesAndTypes()
    {
        return Instance.pokemon.Values.Select(p => (p.Name, p.Type)).ToList();
    }
}
