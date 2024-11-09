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
/// </remarks>
public static class NormalAttackRegistry
{
    private static readonly Dictionary<string, NormalAttack> NormalAttacks = new()
    {
        { "Absorb", new NormalAttack("Absorb",  40, PokemonType.Grass) },
        { "Aerial Ace", new NormalAttack("Aerial Ace", 60, PokemonType.Flying) },
        { "Air Cutter", new NormalAttack("Air Cutter",  55, PokemonType.Flying) },
        { "Air Slash", new NormalAttack("Air Slash", 75, PokemonType.Flying) },
        { "Ancient Power", new NormalAttack("Ancient Power",  60, PokemonType.Rock) },
        { "Aqua Jet", new NormalAttack("Aqua Jet", 40, PokemonType.Water) },
        { "Aqua Tail", new NormalAttack("Aqua Tail", 90, PokemonType.Water) },
        { "Aura Sphere", new NormalAttack("Aura Sphere",  80, PokemonType.Fighting) },
        { "Bite", new NormalAttack("Bite", 60, PokemonType.Normal) },
        { "Blaze Kick", new NormalAttack("Blaze Kick", 85, PokemonType.Fire) },
        { "Body Slam", new NormalAttack("Body Slam", 85, PokemonType.Normal) },
        { "Bubble", new NormalAttack("Bubble", 40, PokemonType.Water) },
        { "Bug Bite", new NormalAttack("Bug Bite", 60, PokemonType.Bug) },
        { "Bug Buzz", new NormalAttack("Bug Buzz", 90, PokemonType.Bug) },
        { "Bullet Seed", new NormalAttack("Bullet Seed", 25, PokemonType.Grass) },
        { "Confusion", new NormalAttack("Confusion",  50, PokemonType.Psychic) },
        { "Cross Poison", new NormalAttack("Cross Poison",  70, PokemonType.Poison) },
        { "Crunch", new NormalAttack("Crunch", 80, PokemonType.Normal) },
        { "Dig", new NormalAttack("Dig",  60, PokemonType.Ground) },
        { "Double-Edge", new NormalAttack("Double-Edge", 120, PokemonType.Normal) },
        { "Double Slap", new NormalAttack("Double Slap",  35, PokemonType.Normal) },
        { "Dragon Rage", new NormalAttack("Dragon Rage", 65, PokemonType.Dragon) },
        { "Dragon Rush", new NormalAttack("Dragon Rush",  100, PokemonType.Dragon) },
        { "Drill Peck", new NormalAttack("Drill Peck",  80, PokemonType.Flying) },
        { "Earth Power", new NormalAttack("Earth Power",  90, PokemonType.Ground) },
        { "Earthquake", new NormalAttack("Earthquake",  100, PokemonType.Ground) },
        { "Ember", new NormalAttack("Ember", 40, PokemonType.Fire) },
        { "Fire Blast", new NormalAttack("Fire Blast", 110, PokemonType.Fire) },
        { "Flamethrower", new NormalAttack("Flamethrower", 90, PokemonType.Fire) },
        { "Flash Cannon", new NormalAttack("Flash Cannon", 80, PokemonType.Normal) },
        { "Fury Attack", new NormalAttack("Fury Attack", 15, PokemonType.Normal) },
        { "Fury Cutter", new NormalAttack("Fury Cutter",  45, PokemonType.Bug) },
        { "Fury Swipes", new NormalAttack("Fury Swipes",  54, PokemonType.Normal) },
        { "Fusion Bolt", new NormalAttack("Fusion Bolt", 100, PokemonType.Electric) },
        { "Giga Drain", new NormalAttack("Giga Drain",  75, PokemonType.Grass) },
        { "Giga Impact", new NormalAttack("Giga Impact",  150, PokemonType.Normal) },
        { "Gunk Shot", new NormalAttack("Gunk Shot", 120, PokemonType.Poison) },
        { "Gust", new NormalAttack("Gust", 40, PokemonType.Flying) },
        { "Harden", new NormalAttack("Harden", 0, PokemonType.Normal) },
        { "Hurricane", new NormalAttack("Hurricane",  110, PokemonType.Flying) },
        { "Hydro Pump", new NormalAttack("Hydro Pump", 110, PokemonType.Water) },
        { "Hyper Fang", new NormalAttack("Hyper Fang", 80, PokemonType.Normal) },
        { "Ice Beam", new NormalAttack("Ice Beam",  90, PokemonType.Ice) },
        { "Iron Tail", new NormalAttack("Iron Tail", 100, PokemonType.Normal) },
        { "Magnitude", new NormalAttack("Magnitude",  70, PokemonType.Ground) },
        { "Mega Drain", new NormalAttack("Mega Drain",  65, PokemonType.Grass) },
        { "Mud Slap", new NormalAttack("Mud Slap",  45, PokemonType.Ground) },
        { "Pay Day", new NormalAttack("Pay Day",  40, PokemonType.Normal) },
        { "Peck", new NormalAttack("Peck", 35, PokemonType.Flying) },
        { "Petal Blizzard", new NormalAttack("Petal Blizzard",  90, PokemonType.Grass) },
        { "Petal Dance", new NormalAttack("Petal Dance",  70, PokemonType.Grass) },
        { "Pin Missile", new NormalAttack("Pin Missile", 25, PokemonType.Bug) },
        { "Poison Fang", new NormalAttack("Poison Fang", 50, PokemonType.Poison) },
        { "Poison Jab", new NormalAttack("Poison Jab", 80, PokemonType.Poison) },
        { "Poison Sting", new NormalAttack("Poison Sting", 15, PokemonType.Poison) },
        { "Pound", new NormalAttack("Pound", 40, PokemonType.Normal) },
        { "Psychic", new NormalAttack("Psychic",  90, PokemonType.Psychic) },
        { "Quick Attack", new NormalAttack("Quick Attack", 40, PokemonType.Normal) },
        { "Razor Leaf", new NormalAttack("Razor Leaf",  55, PokemonType.Grass) },
        { "Rock Blast", new NormalAttack("Rock Blast",  75, PokemonType.Rock) },
        { "Rock Throw", new NormalAttack("Rock Throw",  50, PokemonType.Rock) },
        { "Scratch", new NormalAttack("Scratch",  40, PokemonType.Normal) },
        { "Signal Beam", new NormalAttack("Signal Beam",  75, PokemonType.Bug) },
        { "Sky Attack", new NormalAttack("Sky Attack", 140, PokemonType.Flying) },
        { "Slam", new NormalAttack("Slam",  80, PokemonType.Normal) },
        { "Slash", new NormalAttack("Slash",  70, PokemonType.Normal) },
        { "Solar Beam", new NormalAttack("Solar Beam",  120, PokemonType.Grass) },
        { "String Shot", new NormalAttack("String Shot", 0, PokemonType.Bug) },
        { "Super Fang", new NormalAttack("Super Fang", 100, PokemonType.Normal) },
        { "Tackle", new NormalAttack("Tackle", 40, PokemonType.Normal) },
        { "Thunderbolt", new NormalAttack("Thunderbolt", 90, PokemonType.Electric) },
        { "Thunder", new NormalAttack("Thunder", 110, PokemonType.Electric) },
        { "Thunder Shock", new NormalAttack("Thunder Shock", 40, PokemonType.Electric) },
        { "Twineedle", new NormalAttack("Twineedle", 25, PokemonType.Bug) },
        { "Vine Whip", new NormalAttack("Vine Whip", 45, PokemonType.Grass) },
        { "Water Gun", new NormalAttack("Water Gun", 40, PokemonType.Water) },
        { "Water Pulse", new NormalAttack("Water Pulse", 60, PokemonType.Water) },
        { "Wing Attack", new NormalAttack("Wing Attack", 60, PokemonType.Flying) },
        { "Wrap", new NormalAttack("Wrap", 15, PokemonType.Normal) },
        { "X-Scissor", new NormalAttack("X-Scissor",  80, PokemonType.Bug) },
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
