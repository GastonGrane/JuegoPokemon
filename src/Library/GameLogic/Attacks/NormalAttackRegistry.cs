// -----------------------------------------------------------------------
// <copyright file="NormalAttackRegistry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Attacks;

/// <summary>
/// Clase estática con una colección de ataques normales pre-definidos.
/// </summary>
/// <remarks>
/// Se podría decir que es una implementación de <see href="https://refactoring.guru/design-patterns/prototype">Prototype</see>.
/// Esto es porque esta clase permite conseguir un objeto de la clase NormalAttack sin conocer su estructura, a través de el nombre del objeto, clonando un prototipo pre-definido.
/// </remarks>
public static class NormalAttackRegistry
{
    // Nota de Guzmán: Estos ataques no son todos de Gen-1, y la mayoría tampoco corresponderían acá. Sin embargo, quiero entregar, así que acá van.
    // Lo que sí, son todos ataques reales, sacados de Pokémon.
    private static readonly Dictionary<string, NormalAttack> NormalAttacks = new()
    {
        { "Absorb", new NormalAttack("Absorb",  40, PokemonType.Grass, 100, true) },
        { "Aerial Ace", new NormalAttack("Aerial Ace", 60, PokemonType.Flying, 100, true) },
        { "Air Cutter", new NormalAttack("Air Cutter",  55, PokemonType.Flying, 95, true) },
        { "Air Slash", new NormalAttack("Air Slash", 75, PokemonType.Flying, 95, true) },
        { "Ancient Power", new NormalAttack("Ancient Power",  60, PokemonType.Rock, 100, true) },
        { "Aqua Jet", new NormalAttack("Aqua Jet", 40, PokemonType.Water, 100, true) },
        { "Aqua Tail", new NormalAttack("Aqua Tail", 90, PokemonType.Water, 90, true) },
        { "Aura Sphere", new NormalAttack("Aura Sphere",  80, PokemonType.Fighting, 100, true) },
        { "Bite", new NormalAttack("Bite", 60, PokemonType.Normal, 100, true) },
        { "Blaze Kick", new NormalAttack("Blaze Kick", 85, PokemonType.Fire, 90, true) },
        { "Body Slam", new NormalAttack("Body Slam", 85, PokemonType.Normal, 100, true) },
        { "Bubble", new NormalAttack("Bubble", 40, PokemonType.Water, 100, true) },
        { "Bug Bite", new NormalAttack("Bug Bite", 60, PokemonType.Bug, 100, true) },
        { "Bug Buzz", new NormalAttack("Bug Buzz", 90, PokemonType.Bug, 100, true) },
        { "Bullet Seed", new NormalAttack("Bullet Seed", 25, PokemonType.Grass, 100, true) },
        { "Confusion", new NormalAttack("Confusion",  50, PokemonType.Psychic, 100, true) },
        { "Cross Poison", new NormalAttack("Cross Poison",  70, PokemonType.Poison, 100, true) },
        { "Crunch", new NormalAttack("Crunch", 80, PokemonType.Normal, 100, true) },
        { "Dig", new NormalAttack("Dig",  80, PokemonType.Ground, 100, true) },
        { "Double-Edge", new NormalAttack("Double-Edge", 120, PokemonType.Normal, 100, true) },
        { "Double Slap", new NormalAttack("Double Slap",  35, PokemonType.Normal, 85, true) },
        { "Dragon Rage", new NormalAttack("Dragon Rage", 40, PokemonType.Dragon, 100, true) },
        { "Dragon Rush", new NormalAttack("Dragon Rush",  100, PokemonType.Dragon, 75, true) },
        { "Drill Peck", new NormalAttack("Drill Peck",  80, PokemonType.Flying, 100, true) },
        { "Earth Power", new NormalAttack("Earth Power",  90, PokemonType.Ground, 100, true) },
        { "Earthquake", new NormalAttack("Earthquake",  100, PokemonType.Ground, 100, true) },
        { "Ember", new NormalAttack("Ember", 40, PokemonType.Fire, 100, true) },
        { "Fire Blast", new NormalAttack("Fire Blast", 110, PokemonType.Fire, 85, true) },
        { "Flamethrower", new NormalAttack("Flamethrower", 90, PokemonType.Fire, 100, true) },
        { "Flash Cannon", new NormalAttack("Flash Cannon", 80, PokemonType.Normal, 100, true) },
        { "Fury Attack", new NormalAttack("Fury Attack", 30, PokemonType.Normal, 85, true) },
        { "Fury Cutter", new NormalAttack("Fury Cutter",  40, PokemonType.Bug, 95, true) },
        { "Fury Swipes", new NormalAttack("Fury Swipes",  54, PokemonType.Normal, 80, true) },
        { "Fusion Bolt", new NormalAttack("Fusion Bolt", 100, PokemonType.Electric, 100, true) },
        { "Giga Drain", new NormalAttack("Giga Drain",  75, PokemonType.Grass, 100, true) },
        { "Giga Impact", new NormalAttack("Giga Impact",  150, PokemonType.Normal, 90, true) },
        { "Gunk Shot", new NormalAttack("Gunk Shot", 120, PokemonType.Poison, 80, true) },
        { "Gust", new NormalAttack("Gust", 40, PokemonType.Flying, 100, true) },
        { "Harden", new NormalAttack("Harden", 0, PokemonType.Normal, 100, true) },
        { "Hurricane", new NormalAttack("Hurricane",  110, PokemonType.Flying, 70, true) },
        { "Hydro Pump", new NormalAttack("Hydro Pump", 110, PokemonType.Water, 80, true) },
        { "Hyper Fang", new NormalAttack("Hyper Fang", 80, PokemonType.Normal, 90, true) },
        { "Hyper Voice", new NormalAttack("Hyper Voice",  90, PokemonType.Normal, 100, true) },
        { "Ice Beam", new NormalAttack("Ice Beam",  90, PokemonType.Ice, 100, true) },
        { "Iron Tail", new NormalAttack("Iron Tail", 100, PokemonType.Normal, 75, true) },
        { "Magnitude", new NormalAttack("Magnitude",  70, PokemonType.Ground, 100, true) },
        { "Mega Drain", new NormalAttack("Mega Drain",  40, PokemonType.Grass, 100, true) },
        { "Mud Slap", new NormalAttack("Mud Slap",  45, PokemonType.Ground, 100, true) },
        { "Pay Day", new NormalAttack("Pay Day",  40, PokemonType.Normal, 100, true) },
        { "Peck", new NormalAttack("Peck", 35, PokemonType.Flying, 100, true) },
        { "Petal Blizzard", new NormalAttack("Petal Blizzard",  90, PokemonType.Grass, 100, true) },
        { "Petal Dance", new NormalAttack("Petal Dance",  70, PokemonType.Grass, 100, true) },
        { "Pin Missile", new NormalAttack("Pin Missile", 25, PokemonType.Bug, 95, true) },
        { "Poison Fang", new NormalAttack("Poison Fang", 50, PokemonType.Poison, 100, true) },
        { "Poison Jab", new NormalAttack("Poison Jab", 80, PokemonType.Poison, 100, true) },
        { "Pound", new NormalAttack("Pound", 40, PokemonType.Normal, 100, true) },
        { "Psychic", new NormalAttack("Psychic",  90, PokemonType.Psychic, 100, true) },
        { "Quick Attack", new NormalAttack("Quick Attack", 40, PokemonType.Normal, 100, true) },
        { "Razor Leaf", new NormalAttack("Razor Leaf",  55, PokemonType.Grass, 95, true) },
        { "Rock Blast", new NormalAttack("Rock Blast",  75, PokemonType.Rock, 90, true) },
        { "Rock Throw", new NormalAttack("Rock Throw",  50, PokemonType.Rock, 90, true) },
        { "Sand Attack", new NormalAttack("Sand Attack",  0, PokemonType.Ground, 100, true) },
        { "Sand Tomb", new NormalAttack("Sand Tomb",  65, PokemonType.Ground, 85, true) },
        { "Scratch", new NormalAttack("Scratch",  40, PokemonType.Normal, 100, true) },
        { "Signal Beam", new NormalAttack("Signal Beam",  75, PokemonType.Bug, 100, true) },
        { "Sky Attack", new NormalAttack("Sky Attack", 140, PokemonType.Flying, 90, true) },
        { "Slam", new NormalAttack("Slam",  80, PokemonType.Normal, 75, true) },
        { "Slash", new NormalAttack("Slash",  70, PokemonType.Normal, 100, true) },
        { "Solar Beam", new NormalAttack("Solar Beam",  120, PokemonType.Grass, 100, true) },
        { "String Shot", new NormalAttack("String Shot", 0, PokemonType.Bug, 95, true) },
        { "Super Fang", new NormalAttack("Super Fang", 100, PokemonType.Normal, 90, true) },
        { "Tackle", new NormalAttack("Tackle", 40, PokemonType.Normal, 100, true) },
        { "Thunder", new NormalAttack("Thunder", 110, PokemonType.Electric, 70, true) },
        { "Thunder Shock", new NormalAttack("Thunder Shock", 40, PokemonType.Electric, 100, true) },
        { "Twineedle", new NormalAttack("Twineedle", 25, PokemonType.Bug, 100, true) },
        { "Vine Whip", new NormalAttack("Vine Whip", 45, PokemonType.Grass, 100, true) },
        { "Water Gun", new NormalAttack("Water Gun", 40, PokemonType.Water, 100, true) },
        { "Water Pulse", new NormalAttack("Water Pulse", 60, PokemonType.Water, 100, true) },
        { "Wing Attack", new NormalAttack("Wing Attack", 60, PokemonType.Flying, 100, true) },
        { "Wrap", new NormalAttack("Wrap", 15, PokemonType.Normal, 90, true) },
        { "X-Scissor", new NormalAttack("X-Scissor",  80, PokemonType.Bug, 100, true) },
    };

    /// <summary>
    /// Retorna una copia del <see cref="NormalAttack"/> cuyo nombre es <paramref name="name"/>, si se encuentra en el registro.
    /// </summary>
    /// <param name="name">El nombre del <see cref="NormalAttack"/>.</param>
    /// <exception cref="KeyNotFoundException">
    /// Si el <see cref="NormalAttack"/> no está en el registro.
    /// </exception>
    /// <returns>
    /// Una copia del <see cref="NormalAttack"/> cuyo nombre es <paramref name="name"/>.
    /// </returns>
    public static NormalAttack GetNormalAttack(string name)
    {
        NormalAttack a = NormalAttacks[name];
        return new(a);
    }

    /// <summary>
    /// Retorna una lista de tuplas donde cada una es el nombre y tipo de un ataque del registro.
    /// </summary>
    /// <returns>
    /// Lista de (Nombre, Tipo).
    /// </returns>
    public static List<(string Name, PokemonType Type)> GetAttackNamesAndTypes()
    {
        return NormalAttacks.Values.Select(p => (p.Name, p.Type)).ToList();
    }
}
