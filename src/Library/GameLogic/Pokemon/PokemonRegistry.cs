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
public static class PokemonRegistry
{
    /// <summary>
    /// El diccionario entre nombre de Pokemon y Pokemon. Lo devuelto al usuario será una copia de un elemento de este diccionario.
    /// </summary>
    /// <remarks>
    /// Estos son los primero 40 y algo, y algunos al final que quería poner porque eran piola.
    /// </remarks>
    private static readonly Dictionary<string, Pokemon> PokemonTemplates = new()
    {
        {
            "Pikachu", new Pokemon("Pikachu", PokemonType.Electric, 35, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Thunder Shock"),
                AttackRegistry.GetNormalAttack("Quick Attack"),
                AttackRegistry.GetNormalAttack("Thunder Wave"),
                AttackRegistry.GetNormalAttack("Thunderbolt"),
            })
        },
        {
            "Bulbasaur", new Pokemon("Bulbasaur", PokemonType.Grass, 45, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Tackle"),
                AttackRegistry.GetNormalAttack("Vine Whip"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
            })
        },
        {
            "Ivysaur", new Pokemon("Ivysaur", PokemonType.Grass, 60, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Vine Whip"),
                AttackRegistry.GetNormalAttack("Razor Leaf"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
            })
        },
        {
            "Venusaur", new Pokemon("Venusaur", PokemonType.Grass, 80, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Razor Leaf"),
                AttackRegistry.GetNormalAttack("Solar Beam"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Petal Dance"),
            })
        },
        {
            "Charmander", new Pokemon("Charmander", PokemonType.Fire, 39, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Scratch"),
                AttackRegistry.GetNormalAttack("Ember"),
                AttackRegistry.GetNormalAttack("Fire Spin"),
                AttackRegistry.GetNormalAttack("Slash"),
            })
        },
        {
            "Charmeleon", new Pokemon("Charmeleon", PokemonType.Fire, 58, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Slash"),
                AttackRegistry.GetNormalAttack("Flamethrower"),
                AttackRegistry.GetNormalAttack("Fire Spin"),
                AttackRegistry.GetNormalAttack("Dragon Rage"),
            })
        },
        {
            "Charizard", new Pokemon("Charizard", PokemonType.Fire, 78, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Air Slash"),
                AttackRegistry.GetNormalAttack("Flamethrower"),
                AttackRegistry.GetNormalAttack("Fire Spin"),
                AttackRegistry.GetNormalAttack("Fire Blast"),
            })
        },
        {
            "Squirtle", new Pokemon("Squirtle", PokemonType.Water, 44, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Tackle"),
                AttackRegistry.GetNormalAttack("Water Gun"),
                AttackRegistry.GetNormalAttack("Bubble"),
                AttackRegistry.GetNormalAttack("Bite"),
            })
        },
        {
            "Wartortle", new Pokemon("Wartortle", PokemonType.Water, 59, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Water Gun"),
                AttackRegistry.GetNormalAttack("Bite"),
                AttackRegistry.GetNormalAttack("Water Pulse"),
                AttackRegistry.GetNormalAttack("Aqua Tail"),
            })
        },
        {
            "Blastoise", new Pokemon("Blastoise", PokemonType.Water, 79, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Water Gun"),
                AttackRegistry.GetNormalAttack("Hydro Pump"),
                AttackRegistry.GetNormalAttack("Ice Beam"),
                AttackRegistry.GetNormalAttack("Flash Cannon"),
            })
        },
        {
            "Caterpie", new Pokemon("Caterpie", PokemonType.Bug, 45, new List<NormalAttack>
            {
            AttackRegistry.GetNormalAttack("Tackle"),
            AttackRegistry.GetNormalAttack("Bug Bite"),
            AttackRegistry.GetNormalAttack("String Shot"),
            AttackRegistry.GetNormalAttack("Poison Powder"),
            })
        },
        {
            "Metapod", new Pokemon("Metapod", PokemonType.Bug, 50, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Tackle"),
                AttackRegistry.GetNormalAttack("Bug Bite"),
                AttackRegistry.GetNormalAttack("Harden"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
            })
        },
        {
            "Butterfree", new Pokemon("Butterfree", PokemonType.Bug, 60, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Air Slash"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
                AttackRegistry.GetNormalAttack("Bug Buzz"),
            })
        },
        {
            "Weedle", new Pokemon("Weedle", PokemonType.Bug, 40, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Poison Sting"),
                AttackRegistry.GetNormalAttack("Bug Bite"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
                AttackRegistry.GetNormalAttack("String Shot"),
            })
        },
        {
            "Kakuna", new Pokemon("Kakuna", PokemonType.Bug, 45, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Poison Sting"),
                AttackRegistry.GetNormalAttack("Bug Bite"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
                AttackRegistry.GetNormalAttack("Harden"),
            })
        },
        {
            "Beedrill", new Pokemon("Beedrill", PokemonType.Bug, 65, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Twineedle"),
                AttackRegistry.GetNormalAttack("Poison Jab"),
                AttackRegistry.GetNormalAttack("Toxic"),
                AttackRegistry.GetNormalAttack("Pin Missile"),
            })
        },
        {
            "Pidgey", new Pokemon("Pidgey", PokemonType.Bug, 40, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Tackle"),
                AttackRegistry.GetNormalAttack("Gust"),
                AttackRegistry.GetNormalAttack("Quick Attack"),
                AttackRegistry.GetNormalAttack("Wing Attack"),
            })
        },
        {
            "Pidgeotto", new Pokemon("Pidgeotto", PokemonType.Bug, 63, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Wing Attack"),
                AttackRegistry.GetNormalAttack("Air Slash"),
                AttackRegistry.GetNormalAttack("Quick Attack"),
                AttackRegistry.GetNormalAttack("Aerial Ace"),
            })
        },
        {
            "Pidgeot", new Pokemon("Pidgeot", PokemonType.Bug, 83, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Air Slash"),
                AttackRegistry.GetNormalAttack("Hurricane"),
                AttackRegistry.GetNormalAttack("Quick Attack"),
                AttackRegistry.GetNormalAttack("Sky Attack"),
            })
        },
        {
            "Rattata", new Pokemon("Rattata", PokemonType.Normal, 30, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Tackle"),
                AttackRegistry.GetNormalAttack("Quick Attack"),
                AttackRegistry.GetNormalAttack("Bite"),
                AttackRegistry.GetNormalAttack("Hyper Fang"),
            })
        },
        {
            "Raticate", new Pokemon("Raticate", PokemonType.Normal, 55, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Quick Attack"),
                AttackRegistry.GetNormalAttack("Hyper Fang"),
                AttackRegistry.GetNormalAttack("Super Fang"),
                AttackRegistry.GetNormalAttack("Double-Edge"),
            })
        },
        {
            "Spearow", new Pokemon("Spearow", PokemonType.Flying, 40, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Peck"),
                AttackRegistry.GetNormalAttack("Fury Attack"),
                AttackRegistry.GetNormalAttack("Aerial Ace"),
                AttackRegistry.GetNormalAttack("Quick Attack"),
            })
        },
        {
            "Fearow", new Pokemon("Fearow", PokemonType.Flying, 65, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Drill Peck"),
                AttackRegistry.GetNormalAttack("Aerial Ace"),
                AttackRegistry.GetNormalAttack("Sky Attack"),
                AttackRegistry.GetNormalAttack("Quick Attack"),
            })
        },
        {
            "Ekans", new Pokemon("Ekans", PokemonType.Poison, 35, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Wrap"),
                AttackRegistry.GetNormalAttack("Poison Sting"),
                AttackRegistry.GetNormalAttack("Toxic"),
                AttackRegistry.GetNormalAttack("Bite"),
            })
        },
        {
            "Arbok", new Pokemon("Arbok", PokemonType.Poison, 60, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Poison Fang"),
                AttackRegistry.GetNormalAttack("Crunch"),
                AttackRegistry.GetNormalAttack("Toxic"),
                AttackRegistry.GetNormalAttack("Gunk Shot"),
            })
        },
        {
            "Raichu", new Pokemon("Raichu", PokemonType.Electric, 60, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Thunderbolt"),
                AttackRegistry.GetNormalAttack("Thunder"),
                AttackRegistry.GetNormalAttack("Thunder Wave"),
                AttackRegistry.GetNormalAttack("Iron Tail"),
            })
        },
        {
            "Jigglypuff", new Pokemon("Jigglypuff", PokemonType.Normal, 115, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Pound"),
                AttackRegistry.GetNormalAttack("Sing"),
                AttackRegistry.GetNormalAttack("Body Slam"),
                AttackRegistry.GetNormalAttack("Double Slap"),
            })
        },
        {
            "Wigglytuff", new Pokemon("Wigglytuff", PokemonType.Normal, 140, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Double Slap"),
                AttackRegistry.GetNormalAttack("Body Slam"),
                AttackRegistry.GetNormalAttack("Sing"),
                AttackRegistry.GetNormalAttack("Hyper Voice"),
            })
        },
        {
            "Zubat", new Pokemon("Zubat", PokemonType.Poison, 40, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Wing Attack"),
                AttackRegistry.GetNormalAttack("Supersonic"),
                AttackRegistry.GetNormalAttack("Poison Fang"),
                AttackRegistry.GetNormalAttack("Air Cutter"),
            })
        },
        {
            "Golbat", new Pokemon("Golbat", PokemonType.Poison, 75, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Air Slash"),
                AttackRegistry.GetNormalAttack("Toxic"),
                AttackRegistry.GetNormalAttack("Poison Fang"),
                AttackRegistry.GetNormalAttack("Cross Poison"),
            })
        },
        {
            "Oddish", new Pokemon("Oddish", PokemonType.Grass, 45, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Absorb"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
                AttackRegistry.GetNormalAttack("Razor Leaf"),
            })
        },
        {
            "Gloom", new Pokemon("Gloom", PokemonType.Poison, 60, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Petal Dance"),
                AttackRegistry.GetNormalAttack("Stun Spore"),
                AttackRegistry.GetNormalAttack("Acid"),
                AttackRegistry.GetNormalAttack("Mega Drain"),
            })
        },
        {
            "Vileplume", new Pokemon("Vileplume", PokemonType.Poison, 75, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Petal Blizzard"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Sludge Bomb"),
                AttackRegistry.GetNormalAttack("Solar Beam"),
            })
        },
        {
            "Paras", new Pokemon("Paras", PokemonType.Bug, 35, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Scratch"),
                AttackRegistry.GetNormalAttack("Spore"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
                AttackRegistry.GetNormalAttack("Fury Cutter"),
            })
        },
        {
            "Parasect", new Pokemon("Parasect", PokemonType.Bug, 60, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("X-Scissor"),
                AttackRegistry.GetNormalAttack("Spore"),
                AttackRegistry.GetNormalAttack("Cross Poison"),
                AttackRegistry.GetNormalAttack("Giga Drain"),
            })
        },
        {
            "Venonat", new Pokemon("Venonat", PokemonType.Bug, 60, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Confusion"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Poison Fang"),
                AttackRegistry.GetNormalAttack("Signal Beam"),
            })
        },
        {
            "Venomoth", new Pokemon("Venomoth", PokemonType.Bug, 70, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Bug Buzz"),
                AttackRegistry.GetNormalAttack("Sleep Powder"),
                AttackRegistry.GetNormalAttack("Poison Powder"),
                AttackRegistry.GetNormalAttack("Psychic"),
            })
        },
        {
            "Diglett", new Pokemon("Diglett", PokemonType.Ground, 10, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Dig"),
                AttackRegistry.GetNormalAttack("Scratch"),
                AttackRegistry.GetNormalAttack("Sand Attack"),
                AttackRegistry.GetNormalAttack("Mud Slap"),
            })
        },
        {
            "Dugtrio", new Pokemon("Dugtrio", PokemonType.Ground, 35, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Earthquake"),
                AttackRegistry.GetNormalAttack("Earth Power"),
                AttackRegistry.GetNormalAttack("Sand Tomb"),
                AttackRegistry.GetNormalAttack("Slash"),
            })
        },
        {
            "Meowth", new Pokemon("Meowth", PokemonType.Normal, 40, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Scratch"),
                AttackRegistry.GetNormalAttack("Pay Day"),
                AttackRegistry.GetNormalAttack("Screech"),
                AttackRegistry.GetNormalAttack("Fury Swipes"),
            })
        },
        {
            "Snorlax", new Pokemon("Snorlax", PokemonType.Normal, 160, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Body Slam"),
                AttackRegistry.GetNormalAttack("Yawn"),
                AttackRegistry.GetNormalAttack("Giga Impact"),
                AttackRegistry.GetNormalAttack("Crunch"),
            })
        },
        {
            "Articuno", new Pokemon("Articuno", PokemonType.Ice, 90, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Ice Beam"),
                AttackRegistry.GetNormalAttack("Freeze-Dry"),
                AttackRegistry.GetNormalAttack("Hurricane"),
                AttackRegistry.GetNormalAttack("Blizzard"),
            })
        },
        {
            "Zapdos", new Pokemon("Zapdos", PokemonType.Electric, 90, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Thunder"),
                AttackRegistry.GetNormalAttack("Thunder Wave"),
                AttackRegistry.GetNormalAttack("Drill Peck"),
                AttackRegistry.GetNormalAttack("Thunderbolt"),
            })
        },
        {
            "Moltres", new Pokemon("Moltres", PokemonType.Fire, 90, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Fire Blast"),
                AttackRegistry.GetNormalAttack("Heat Wave"),
                AttackRegistry.GetNormalAttack("Hurricane"),
                AttackRegistry.GetNormalAttack("Sky Attack"),
            })
        },
        {
            "Mewtwo", new Pokemon("Mewtwo", PokemonType.Psychic, 106, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Psychic"),
                AttackRegistry.GetNormalAttack("Hypnosis"),
                AttackRegistry.GetNormalAttack("Aura Sphere"),
                AttackRegistry.GetNormalAttack("Psystrike"),
            })
        },
        {
            "Mew", new Pokemon("Mew", PokemonType.Bug, 100, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Psychic"),
                AttackRegistry.GetNormalAttack("Hypnosis"),
                AttackRegistry.GetNormalAttack("Thunder Wave"),
                AttackRegistry.GetNormalAttack("Ancient Power"),
            })
        },
        {
            "Dragonair", new Pokemon("Dragonair", PokemonType.Dragon, 61, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Dragon Rage"),
                AttackRegistry.GetNormalAttack("Thunder Wave"),
                AttackRegistry.GetNormalAttack("Aqua Tail"),
                AttackRegistry.GetNormalAttack("Slam"),
            })
        },
        {
            "Dragonite", new Pokemon("Dragonite", PokemonType.Dragon, 91, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Dragon Rush"),
                AttackRegistry.GetNormalAttack("Thunder Wave"),
                AttackRegistry.GetNormalAttack("Fire Punch"),
                AttackRegistry.GetNormalAttack("Hurricane"),
            })
        },
        {
            "Geodude", new Pokemon("Geodude", PokemonType.Rock, 40, new List<NormalAttack>
            {
                AttackRegistry.GetNormalAttack("Rock Throw"),
                AttackRegistry.GetNormalAttack("Magnitude"),
                AttackRegistry.GetNormalAttack("Sand Attack"),
                AttackRegistry.GetNormalAttack("Rock Blast"),
            })
        },
    };

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
        Pokemon p = PokemonTemplates[name];
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
        return PokemonTemplates.Values.ToList();
    }

    /// <summary>
    /// Retorna una lista de tuplas donde cada una es el nombre y tipo de un Pokémon del registro.
    /// </summary>
    /// <returns>
    /// Lista de (Nombre, Tipo).
    /// </returns>
    public static List<(string Name, PokemonType Type)> GetPokemonNamesAndTypes()
    {
        return PokemonTemplates.Values.Select(p => (p.Name, p.Type)).ToList();
    }
}
