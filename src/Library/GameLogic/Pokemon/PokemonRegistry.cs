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
                NormalAttackRegistry.GetNormalAttack("Thunder Shock"),
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
                SpecialAttackRegistry.GetSpecialAttack("Thunder Wave"),
                SpecialAttackRegistry.GetSpecialAttack("Thunderbolt"),
            })
        },
        {
            "Bulbasaur", new Pokemon("Bulbasaur", PokemonType.Grass, 45, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Tackle"),
                NormalAttackRegistry.GetNormalAttack("Vine Whip"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
            })
        },
        {
            "Ivysaur", new Pokemon("Ivysaur", PokemonType.Grass, 60, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Vine Whip"),
                NormalAttackRegistry.GetNormalAttack("Razor Leaf"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
            })
        },
        {
            "Venusaur", new Pokemon("Venusaur", PokemonType.Grass, 80, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Razor Leaf"),
                NormalAttackRegistry.GetNormalAttack("Solar Beam"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                NormalAttackRegistry.GetNormalAttack("Petal Dance"),
            })
        },
        {
            "Charmander", new Pokemon("Charmander", PokemonType.Fire, 39, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Scratch"),
                NormalAttackRegistry.GetNormalAttack("Ember"),
                SpecialAttackRegistry.GetSpecialAttack("Fire Spin"),
                NormalAttackRegistry.GetNormalAttack("Slash"),
            })
        },
        {
            "Charmeleon", new Pokemon("Charmeleon", PokemonType.Fire, 58, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Slash"),
                NormalAttackRegistry.GetNormalAttack("Flamethrower"),
                SpecialAttackRegistry.GetSpecialAttack("Fire Spin"),
                NormalAttackRegistry.GetNormalAttack("Dragon Rage"),
            })
        },
        {
            "Charizard", new Pokemon("Charizard", PokemonType.Fire, 78, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Air Slash"),
                NormalAttackRegistry.GetNormalAttack("Flamethrower"),
                SpecialAttackRegistry.GetSpecialAttack("Fire Spin"),
                NormalAttackRegistry.GetNormalAttack("Fire Blast"),
            })
        },
        {
            "Squirtle", new Pokemon("Squirtle", PokemonType.Water, 44, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Tackle"),
                NormalAttackRegistry.GetNormalAttack("Water Gun"),
                NormalAttackRegistry.GetNormalAttack("Bubble"),
                NormalAttackRegistry.GetNormalAttack("Bite"),
            })
        },
        {
            "Wartortle", new Pokemon("Wartortle", PokemonType.Water, 59, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Water Gun"),
                NormalAttackRegistry.GetNormalAttack("Bite"),
                NormalAttackRegistry.GetNormalAttack("Water Pulse"),
                NormalAttackRegistry.GetNormalAttack("Aqua Tail"),
            })
        },
        {
            "Blastoise", new Pokemon("Blastoise", PokemonType.Water, 79, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Water Gun"),
                NormalAttackRegistry.GetNormalAttack("Hydro Pump"),
                NormalAttackRegistry.GetNormalAttack("Ice Beam"),
                NormalAttackRegistry.GetNormalAttack("Flash Cannon"),
            })
        },
        {
            "Caterpie", new Pokemon("Caterpie", PokemonType.Bug, 45, new List<NormalAttack>
            {
            NormalAttackRegistry.GetNormalAttack("Tackle"),
            NormalAttackRegistry.GetNormalAttack("Bug Bite"),
            NormalAttackRegistry.GetNormalAttack("String Shot"),
            SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
            })
        },
        {
            "Metapod", new Pokemon("Metapod", PokemonType.Bug, 50, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Tackle"),
                NormalAttackRegistry.GetNormalAttack("Bug Bite"),
                NormalAttackRegistry.GetNormalAttack("Harden"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
            })
        },
        {
            "Butterfree", new Pokemon("Butterfree", PokemonType.Bug, 60, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Air Slash"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
                NormalAttackRegistry.GetNormalAttack("Bug Buzz"),
            })
        },
        {
            "Weedle", new Pokemon("Weedle", PokemonType.Bug, 40, new List<NormalAttack>
            {
                SpecialAttackRegistry.GetSpecialAttack("Poison Sting"),
                NormalAttackRegistry.GetNormalAttack("Bug Bite"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
                NormalAttackRegistry.GetNormalAttack("String Shot"),
            })
        },
        {
            "Kakuna", new Pokemon("Kakuna", PokemonType.Bug, 45, new List<NormalAttack>
            {
                SpecialAttackRegistry.GetSpecialAttack("Poison Sting"),
                NormalAttackRegistry.GetNormalAttack("Bug Bite"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
                NormalAttackRegistry.GetNormalAttack("Harden"),
            })
        },
        {
            "Beedrill", new Pokemon("Beedrill", PokemonType.Bug, 65, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Twineedle"),
                NormalAttackRegistry.GetNormalAttack("Poison Jab"),
                SpecialAttackRegistry.GetSpecialAttack("Toxic"),
                NormalAttackRegistry.GetNormalAttack("Pin Missile"),
            })
        },
        {
            "Pidgey", new Pokemon("Pidgey", PokemonType.Bug, 40, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Tackle"),
                NormalAttackRegistry.GetNormalAttack("Gust"),
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
                NormalAttackRegistry.GetNormalAttack("Wing Attack"),
            })
        },
        {
            "Pidgeotto", new Pokemon("Pidgeotto", PokemonType.Bug, 63, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Wing Attack"),
                NormalAttackRegistry.GetNormalAttack("Air Slash"),
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
                NormalAttackRegistry.GetNormalAttack("Aerial Ace"),
            })
        },
        {
            "Pidgeot", new Pokemon("Pidgeot", PokemonType.Bug, 83, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Air Slash"),
                NormalAttackRegistry.GetNormalAttack("Hurricane"),
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
                NormalAttackRegistry.GetNormalAttack("Sky Attack"),
            })
        },
        {
            "Rattata", new Pokemon("Rattata", PokemonType.Normal, 30, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Tackle"),
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
                NormalAttackRegistry.GetNormalAttack("Bite"),
                NormalAttackRegistry.GetNormalAttack("Hyper Fang"),
            })
        },
        {
            "Raticate", new Pokemon("Raticate", PokemonType.Normal, 55, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
                NormalAttackRegistry.GetNormalAttack("Hyper Fang"),
                NormalAttackRegistry.GetNormalAttack("Super Fang"),
                NormalAttackRegistry.GetNormalAttack("Double-Edge"),
            })
        },
        {
            "Spearow", new Pokemon("Spearow", PokemonType.Flying, 40, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Peck"),
                NormalAttackRegistry.GetNormalAttack("Fury Attack"),
                NormalAttackRegistry.GetNormalAttack("Aerial Ace"),
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
            })
        },
        {
            "Fearow", new Pokemon("Fearow", PokemonType.Flying, 65, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Drill Peck"),
                NormalAttackRegistry.GetNormalAttack("Aerial Ace"),
                NormalAttackRegistry.GetNormalAttack("Sky Attack"),
                NormalAttackRegistry.GetNormalAttack("Quick Attack"),
            })
        },
        {
            "Ekans", new Pokemon("Ekans", PokemonType.Poison, 35, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Wrap"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Sting"),
                SpecialAttackRegistry.GetSpecialAttack("Toxic"),
                NormalAttackRegistry.GetNormalAttack("Bite"),
            })
        },
        {
            "Arbok", new Pokemon("Arbok", PokemonType.Poison, 60, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Poison Fang"),
                NormalAttackRegistry.GetNormalAttack("Crunch"),
                SpecialAttackRegistry.GetSpecialAttack("Toxic"),
                NormalAttackRegistry.GetNormalAttack("Gunk Shot"),
            })
        },
        {
            "Raichu", new Pokemon("Raichu", PokemonType.Electric, 60, new List<NormalAttack>
            {
                SpecialAttackRegistry.GetSpecialAttack("Thunderbolt"),
                NormalAttackRegistry.GetNormalAttack("Thunder"),
                SpecialAttackRegistry.GetSpecialAttack("Thunder Wave"),
                NormalAttackRegistry.GetNormalAttack("Iron Tail"),
            })
        },
        {
            "Jigglypuff", new Pokemon("Jigglypuff", PokemonType.Normal, 115, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Pound"),
                SpecialAttackRegistry.GetSpecialAttack("Sing"),
                NormalAttackRegistry.GetNormalAttack("Body Slam"),
                NormalAttackRegistry.GetNormalAttack("Double Slap"),
            })
        },
        {
            "Wigglytuff", new Pokemon("Wigglytuff", PokemonType.Normal, 140, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Double Slap"),
                NormalAttackRegistry.GetNormalAttack("Body Slam"),
                SpecialAttackRegistry.GetSpecialAttack("Sing"),
                NormalAttackRegistry.GetNormalAttack("Hyper Voice"),
            })
        },
        {
            "Zubat", new Pokemon("Zubat", PokemonType.Poison, 40, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Wing Attack"),
                SpecialAttackRegistry.GetSpecialAttack("Supersonic"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Fang"),
                NormalAttackRegistry.GetNormalAttack("Air Cutter"),
            })
        },
        {
            "Golbat", new Pokemon("Golbat", PokemonType.Poison, 75, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Air Slash"),
                SpecialAttackRegistry.GetSpecialAttack("Toxic"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Fang"),
                NormalAttackRegistry.GetNormalAttack("Cross Poison"),
            })
        },
        {
            "Oddish", new Pokemon("Oddish", PokemonType.Grass, 45, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Absorb"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
                NormalAttackRegistry.GetNormalAttack("Razor Leaf"),
            })
        },
        {
            "Gloom", new Pokemon("Gloom", PokemonType.Poison, 60, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Petal Dance"),
                SpecialAttackRegistry.GetSpecialAttack("Stun Spore"),
                SpecialAttackRegistry.GetSpecialAttack("Acid"),
                NormalAttackRegistry.GetNormalAttack("Mega Drain"),
            })
        },
        {
            "Vileplume", new Pokemon("Vileplume", PokemonType.Poison, 75, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Petal Blizzard"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                SpecialAttackRegistry.GetSpecialAttack("Sludge Bomb"),
                NormalAttackRegistry.GetNormalAttack("Solar Beam"),
            })
        },
        {
            "Paras", new Pokemon("Paras", PokemonType.Bug, 35, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Scratch"),
                SpecialAttackRegistry.GetSpecialAttack("Spore"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
                NormalAttackRegistry.GetNormalAttack("Fury Cutter"),
            })
        },
        {
            "Parasect", new Pokemon("Parasect", PokemonType.Bug, 60, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("X-Scissor"),
                SpecialAttackRegistry.GetSpecialAttack("Spore"),
                SpecialAttackRegistry.GetSpecialAttack("Cross Poison"),
                NormalAttackRegistry.GetNormalAttack("Giga Drain"),
            })
        },
        {
            "Venonat", new Pokemon("Venonat", PokemonType.Bug, 60, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Confusion"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Fang"),
                NormalAttackRegistry.GetNormalAttack("Signal Beam"),
            })
        },
        {
            "Venomoth", new Pokemon("Venomoth", PokemonType.Bug, 70, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Bug Buzz"),
                SpecialAttackRegistry.GetSpecialAttack("Sleep Powder"),
                SpecialAttackRegistry.GetSpecialAttack("Poison Powder"),
                NormalAttackRegistry.GetNormalAttack("Psychic"),
            })
        },
        {
            "Diglett", new Pokemon("Diglett", PokemonType.Ground, 10, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Dig"),
                NormalAttackRegistry.GetNormalAttack("Scratch"),
                NormalAttackRegistry.GetNormalAttack("Sand Attack"),
                NormalAttackRegistry.GetNormalAttack("Mud Slap"),
            })
        },
        {
            "Dugtrio", new Pokemon("Dugtrio", PokemonType.Ground, 35, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Earthquake"),
                NormalAttackRegistry.GetNormalAttack("Earth Power"),
                NormalAttackRegistry.GetNormalAttack("Sand Tomb"),
                NormalAttackRegistry.GetNormalAttack("Slash"),
            })
        },
        {
            "Meowth", new Pokemon("Meowth", PokemonType.Normal, 40, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Scratch"),
                NormalAttackRegistry.GetNormalAttack("Pay Day"),
                SpecialAttackRegistry.GetSpecialAttack("Screech"),
                NormalAttackRegistry.GetNormalAttack("Fury Swipes"),
            })
        },
        {
            "Snorlax", new Pokemon("Snorlax", PokemonType.Normal, 160, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Body Slam"),
                SpecialAttackRegistry.GetSpecialAttack("Yawn"),
                NormalAttackRegistry.GetNormalAttack("Giga Impact"),
                NormalAttackRegistry.GetNormalAttack("Crunch"),
            })
        },
        {
            "Articuno", new Pokemon("Articuno", PokemonType.Ice, 90, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Ice Beam"),
                SpecialAttackRegistry.GetSpecialAttack("Freeze-Dry"),
                NormalAttackRegistry.GetNormalAttack("Hurricane"),
                SpecialAttackRegistry.GetSpecialAttack("Blizzard"),
            })
        },
        {
            "Zapdos", new Pokemon("Zapdos", PokemonType.Electric, 90, new List<NormalAttack>
            {
                SpecialAttackRegistry.GetSpecialAttack("Thunder"),
                SpecialAttackRegistry.GetSpecialAttack("Thunder Wave"),
                NormalAttackRegistry.GetNormalAttack("Drill Peck"),
                SpecialAttackRegistry.GetSpecialAttack("Thunderbolt"),
            })
        },
        {
            "Moltres", new Pokemon("Moltres", PokemonType.Fire, 90, new List<NormalAttack>
            {
                SpecialAttackRegistry.GetSpecialAttack("Fire Blast"),
                SpecialAttackRegistry.GetSpecialAttack("Heat Wave"),
                NormalAttackRegistry.GetNormalAttack("Hurricane"),
                NormalAttackRegistry.GetNormalAttack("Sky Attack"),
            })
        },
        {
            "Mewtwo", new Pokemon("Mewtwo", PokemonType.Psychic, 106, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Psychic"),
                SpecialAttackRegistry.GetSpecialAttack("Hypnosis"),
                NormalAttackRegistry.GetNormalAttack("Aura Sphere"),
                SpecialAttackRegistry.GetSpecialAttack("Psystrike"),
            })
        },
        {
            "Mew", new Pokemon("Mew", PokemonType.Bug, 100, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Psychic"),
                SpecialAttackRegistry.GetSpecialAttack("Hypnosis"),
                SpecialAttackRegistry.GetSpecialAttack("Thunder Wave"),
                NormalAttackRegistry.GetNormalAttack("Ancient Power"),
            })
        },
        {
            "Dragonair", new Pokemon("Dragonair", PokemonType.Dragon, 61, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Dragon Rage"),
                SpecialAttackRegistry.GetSpecialAttack("Thunder Wave"),
                NormalAttackRegistry.GetNormalAttack("Aqua Tail"),
                NormalAttackRegistry.GetNormalAttack("Slam"),
            })
        },
        {
            "Dragonite", new Pokemon("Dragonite", PokemonType.Dragon, 91, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Dragon Rush"),
                SpecialAttackRegistry.GetSpecialAttack("Thunder Wave"),
                SpecialAttackRegistry.GetSpecialAttack("Fire Punch"),
                NormalAttackRegistry.GetNormalAttack("Hurricane"),
            })
        },
        {
            "Geodude", new Pokemon("Geodude", PokemonType.Rock, 40, new List<NormalAttack>
            {
                NormalAttackRegistry.GetNormalAttack("Rock Throw"),
                NormalAttackRegistry.GetNormalAttack("Magnitude"),
                NormalAttackRegistry.GetNormalAttack("Sand Attack"),
                NormalAttackRegistry.GetNormalAttack("Rock Blast"),
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
