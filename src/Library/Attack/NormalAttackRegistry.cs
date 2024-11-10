// -----------------------------------------------------------------------
// <copyright file="NormalAttackRegistry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

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
        { "Absorb", new NormalAttack("Absorb",  40, PokemonType.Grass, 100) },
        { "Aerial Ace", new NormalAttack("Aerial Ace", 60, PokemonType.Flying, 100) },
        { "Air Cutter", new NormalAttack("Air Cutter",  55, PokemonType.Flying, 95) },
        { "Air Slash", new NormalAttack("Air Slash", 75, PokemonType.Flying, 95) },
        { "Ancient Power", new NormalAttack("Ancient Power",  60, PokemonType.Rock, 100) },
        { "Aqua Jet", new NormalAttack("Aqua Jet", 40, PokemonType.Water, 100) },
        { "Aqua Tail", new NormalAttack("Aqua Tail", 90, PokemonType.Water, 90) },
        { "Aura Sphere", new NormalAttack("Aura Sphere",  80, PokemonType.Fighting, 100) },
        { "Bite", new NormalAttack("Bite", 60, PokemonType.Normal, 100) },
        { "Blaze Kick", new NormalAttack("Blaze Kick", 85, PokemonType.Fire, 90) },
        { "Body Slam", new NormalAttack("Body Slam", 85, PokemonType.Normal, 100) },
        { "Bubble", new NormalAttack("Bubble", 40, PokemonType.Water, 100) },
        { "Bug Bite", new NormalAttack("Bug Bite", 60, PokemonType.Bug, 100) },
        { "Bug Buzz", new NormalAttack("Bug Buzz", 90, PokemonType.Bug, 100) },
        { "Bullet Seed", new NormalAttack("Bullet Seed", 25, PokemonType.Grass, 100) },
        { "Confusion", new NormalAttack("Confusion",  50, PokemonType.Psychic, 100) },
        { "Cross Poison", new NormalAttack("Cross Poison",  70, PokemonType.Poison, 100) },
        { "Crunch", new NormalAttack("Crunch", 80, PokemonType.Normal, 100) },
        { "Dig", new NormalAttack("Dig",  80, PokemonType.Ground, 100) },
        { "Double-Edge", new NormalAttack("Double-Edge", 120, PokemonType.Normal, 100) },
        { "Double Slap", new NormalAttack("Double Slap",  35, PokemonType.Normal, 85) },
        { "Dragon Rage", new NormalAttack("Dragon Rage", 40, PokemonType.Dragon, 100) },
        { "Dragon Rush", new NormalAttack("Dragon Rush",  100, PokemonType.Dragon, 75) },
        { "Drill Peck", new NormalAttack("Drill Peck",  80, PokemonType.Flying, 100) },
        { "Earth Power", new NormalAttack("Earth Power",  90, PokemonType.Ground, 100) },
        { "Earthquake", new NormalAttack("Earthquake",  100, PokemonType.Ground, 100) },
        { "Ember", new NormalAttack("Ember", 40, PokemonType.Fire, 100) },
        { "Fire Blast", new NormalAttack("Fire Blast", 110, PokemonType.Fire, 85) },
        { "Flamethrower", new NormalAttack("Flamethrower", 90, PokemonType.Fire, 100) },
        { "Flash Cannon", new NormalAttack("Flash Cannon", 80, PokemonType.Normal, 100) },
        { "Fury Attack", new NormalAttack("Fury Attack", 30, PokemonType.Normal, 85) },
        { "Fury Cutter", new NormalAttack("Fury Cutter",  40, PokemonType.Bug, 95) },
        { "Fury Swipes", new NormalAttack("Fury Swipes",  54, PokemonType.Normal, 80) },
        { "Fusion Bolt", new NormalAttack("Fusion Bolt", 100, PokemonType.Electric, 100) },
        { "Giga Drain", new NormalAttack("Giga Drain",  75, PokemonType.Grass, 100) },
        { "Giga Impact", new NormalAttack("Giga Impact",  150, PokemonType.Normal, 90) },
        { "Gunk Shot", new NormalAttack("Gunk Shot", 120, PokemonType.Poison, 80) },
        { "Gust", new NormalAttack("Gust", 40, PokemonType.Flying, 100) },
        { "Harden", new NormalAttack("Harden", 0, PokemonType.Normal, 100) },
        { "Hurricane", new NormalAttack("Hurricane",  110, PokemonType.Flying, 70) },
        { "Hydro Pump", new NormalAttack("Hydro Pump", 110, PokemonType.Water, 80) },
        { "Hyper Fang", new NormalAttack("Hyper Fang", 80, PokemonType.Normal, 90) },
        { "Ice Beam", new NormalAttack("Ice Beam",  90, PokemonType.Ice, 100) },
        { "Iron Tail", new NormalAttack("Iron Tail", 100, PokemonType.Normal, 75) },
        { "Magnitude", new NormalAttack("Magnitude",  70, PokemonType.Ground, 100) },
        { "Mega Drain", new NormalAttack("Mega Drain",  40, PokemonType.Grass, 100) },
        { "Mud Slap", new NormalAttack("Mud Slap",  45, PokemonType.Ground, 100) },
        { "Pay Day", new NormalAttack("Pay Day",  40, PokemonType.Normal, 100) },
        { "Peck", new NormalAttack("Peck", 35, PokemonType.Flying, 100) },
        { "Petal Blizzard", new NormalAttack("Petal Blizzard",  90, PokemonType.Grass, 100) },
        { "Petal Dance", new NormalAttack("Petal Dance",  70, PokemonType.Grass, 100) },
        { "Pin Missile", new NormalAttack("Pin Missile", 25, PokemonType.Bug, 95) },
        { "Poison Fang", new NormalAttack("Poison Fang", 50, PokemonType.Poison, 100) },
        { "Poison Jab", new NormalAttack("Poison Jab", 80, PokemonType.Poison, 100) },
        { "Pound", new NormalAttack("Pound", 40, PokemonType.Normal, 100) },
        { "Psychic", new NormalAttack("Psychic",  90, PokemonType.Psychic, 100) },
        { "Quick Attack", new NormalAttack("Quick Attack", 40, PokemonType.Normal, 100) },
        { "Razor Leaf", new NormalAttack("Razor Leaf",  55, PokemonType.Grass, 95) },
        { "Rock Blast", new NormalAttack("Rock Blast",  75, PokemonType.Rock, 90) },
        { "Rock Throw", new NormalAttack("Rock Throw",  50, PokemonType.Rock, 90) },
        { "Scratch", new NormalAttack("Scratch",  40, PokemonType.Normal, 100) },
        { "Signal Beam", new NormalAttack("Signal Beam",  75, PokemonType.Bug, 100) },
        { "Sky Attack", new NormalAttack("Sky Attack", 140, PokemonType.Flying, 90) },
        { "Slam", new NormalAttack("Slam",  80, PokemonType.Normal, 75) },
        { "Slash", new NormalAttack("Slash",  70, PokemonType.Normal, 100) },
        { "Solar Beam", new NormalAttack("Solar Beam",  120, PokemonType.Grass, 100) },
        { "String Shot", new NormalAttack("String Shot", 0, PokemonType.Bug, 95) },
        { "Super Fang", new NormalAttack("Super Fang", 100, PokemonType.Normal, 90) },
        { "Tackle", new NormalAttack("Tackle", 40, PokemonType.Normal, 100) },
        { "Thunder", new NormalAttack("Thunder", 110, PokemonType.Electric, 70) },
        { "Thunder Shock", new NormalAttack("Thunder Shock", 40, PokemonType.Electric, 100) },
        { "Twineedle", new NormalAttack("Twineedle", 25, PokemonType.Bug, 100) },
        { "Vine Whip", new NormalAttack("Vine Whip", 45, PokemonType.Grass, 100) },
        { "Water Gun", new NormalAttack("Water Gun", 40, PokemonType.Water, 100) },
        { "Water Pulse", new NormalAttack("Water Pulse", 60, PokemonType.Water, 100) },
        { "Wing Attack", new NormalAttack("Wing Attack", 60, PokemonType.Flying, 100) },
        { "Wrap", new NormalAttack("Wrap", 15, PokemonType.Normal, 90) },
        { "X-Scissor", new NormalAttack("X-Scissor",  80, PokemonType.Bug, 100) },
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
