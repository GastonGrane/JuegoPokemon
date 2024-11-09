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
        { "Aerial Ace", new NormalAttack("Aerial Ace", 60, PokemonType.Flying) },
        { "Air Slash", new NormalAttack("Air Slash", 75, PokemonType.Flying) },
        { "Aqua Jet", new NormalAttack("Aqua Jet", 40, PokemonType.Water) },
        { "Aqua Tail", new NormalAttack("Aqua Tail", 90, PokemonType.Water) },
        { "Bite", new NormalAttack("Bite", 60, PokemonType.Normal) },
        { "Blaze Kick", new NormalAttack("Blaze Kick", 85, PokemonType.Fire) },
        { "Body Slam", new NormalAttack("Body Slam", 85, PokemonType.Normal) },
        { "Bubble", new NormalAttack("Bubble", 40, PokemonType.Water) },
        { "Bug Bite", new NormalAttack("Bug Bite", 60, PokemonType.Bug) },
        { "Bug Buzz", new NormalAttack("Bug Buzz", 90, PokemonType.Bug) },
        { "Bullet Seed", new NormalAttack("Bullet Seed", 25, PokemonType.Grass) },
        { "Crunch", new NormalAttack("Crunch", 80, PokemonType.Normal) },
        { "Double-Edge", new NormalAttack("Double-Edge", 120, PokemonType.Normal) },
        { "Double Slap", new NormalAttack("Double Slap", 15, PokemonType.Normal) },
        { "Dragon Rage", new NormalAttack("Dragon Rage", 65, PokemonType.Dragon) },
        { "Drill Peck", new NormalAttack("Drill Peck", 80, PokemonType.Flying) },
        { "Ember", new NormalAttack("Ember", 40, PokemonType.Fire) },
        { "Fire Blast", new NormalAttack("Fire Blast", 110, PokemonType.Fire) },
        { "Flamethrower", new NormalAttack("Flamethrower", 90, PokemonType.Fire) },
        { "Flash Cannon", new NormalAttack("Flash Cannon", 80, PokemonType.Normal) },
        { "Fury Attack", new NormalAttack("Fury Attack", 15, PokemonType.Normal) },
        { "Fusion Bolt", new NormalAttack("Fusion Bolt", 100, PokemonType.Electric) },
        { "Gunk Shot", new NormalAttack("Gunk Shot", 120, PokemonType.Poison) },
        { "Gust", new NormalAttack("Gust", 40, PokemonType.Flying) },
        { "Harden", new NormalAttack("Harden", 0, PokemonType.Normal) },
        { "Hurricane", new NormalAttack("Hurricane", 110, PokemonType.Flying) },
        { "Hydro Pump", new NormalAttack("Hydro Pump", 110, PokemonType.Water) },
        { "Hyper Fang", new NormalAttack("Hyper Fang", 80, PokemonType.Normal) },
        { "Ice Beam", new NormalAttack("Ice Beam", 90, PokemonType.Ice) },
        { "Iron Tail", new NormalAttack("Iron Tail", 100, PokemonType.Normal) },
        { "Peck", new NormalAttack("Peck", 35, PokemonType.Flying) },
        { "Petal Dance", new NormalAttack("Petal Dance", 120, PokemonType.Grass) },
        { "Pin Missile", new NormalAttack("Pin Missile", 25, PokemonType.Bug) },
        { "Poison Fang", new NormalAttack("Poison Fang", 50, PokemonType.Poison) },
        { "Poison Jab", new NormalAttack("Poison Jab", 80, PokemonType.Poison) },
        { "Poison Sting", new NormalAttack("Poison Sting", 15, PokemonType.Poison) },
        { "Pound", new NormalAttack("Pound", 40, PokemonType.Normal) },
        { "Quick Attack", new NormalAttack("Quick Attack", 40, PokemonType.Normal) },
        { "Razor Leaf", new NormalAttack("Razor Leaf", 55, PokemonType.Grass) },
        { "Scratch", new NormalAttack("Scratch", 40, PokemonType.Normal) },
        { "Sky Attack", new NormalAttack("Sky Attack", 140, PokemonType.Flying) },
        { "Slash", new NormalAttack("Slash", 70, PokemonType.Normal) },
        { "Solar Beam", new NormalAttack("Solar Beam", 120, PokemonType.Grass) },
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
