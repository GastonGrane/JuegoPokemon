// -----------------------------------------------------------------------
// <copyright file="AttackRegistry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Effects;
using Library.GameLogic.Entities;
using Library.GameLogic.Utilities;

namespace Library.GameLogic.Attacks;

/// <summary>
/// Clase estática con una colección de ataques normales pre-definidos.
/// </summary>
/// <remarks>
/// Se podría decir que es una implementación de <see href="https://refactoring.guru/design-patterns/prototype">Prototype</see>.
/// Esto es porque esta clase permite conseguir un objeto de la clase NormalAttack sin conocer su estructura, a través de el nombre del objeto, clonando un prototipo pre-definido.
/// </remarks>
public class AttackRegistry
{
    private static AttackRegistry? instance;

    private Dictionary<string, NormalAttack> normalAttacks;

    private AttackRegistry(Dictionary<string, NormalAttack> normalAttacks)
    {
        this.normalAttacks = normalAttacks;
    }

    /// <summary>
    /// El singleton del registro.
    /// </summary>
    /// <remarks>
    /// Si la instancia no está inicializada, se inicializa con <see cref="InitSingleton()"/>.
    /// </remarks>
    public static AttackRegistry Instance
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
    /// Reinicia el valor del singleton.
    /// </summary>
    public static void ResetSingleton()
    {
        instance = null;
    }

    /// <summary>
    /// Inicializa <see cref="Instance"/> con los ataques predefinidos.
    /// </summary>
    /// <remarks>
    /// Todos los ataques utilizan una instancia de <see cref="SystemRandom"/>.
    /// Si es necesario cambiar esto utilice <see cref="InitSingleton(IProbability)"/>.
    /// </remarks>
    public static void InitSingleton()
    {
        InitSingleton(new SystemRandom());
    }

    /// <summary>
    /// Inicializa <see cref="Instance"/> con los ataques predefinidos.
    /// </summary>
    /// <param name="criticalGen">El generador para ataques críticos de todos los ataques.</param>
    public static void InitSingleton(IProbability criticalGen)
    {
        Dictionary<string, NormalAttack> normalAttacks = new();
        void AddNormal(string name, int damage, PokemonType type, int precision)
        {
            normalAttacks.Add(name, new NormalAttack(name, damage, type, precision, criticalGen));
        }

        void AddSpecial<T>(string name, int damage, PokemonType type, int precision)
            where T : IEffect, new()
        {
            normalAttacks.Add(name, new SpecialAttack(name, damage, type, precision, new T(), criticalGen));
        }

        // Nota de Guzmán: Estos ataques no son todos de Gen-1, y la mayoría tampoco corresponderían acá. Sin embargo, quiero entregar, así que acá van.
        // Lo que sí, son todos ataques reales, sacados de Pokémon.
        AddNormal("Absorb", 40, PokemonType.Grass, 100);
        AddNormal("Aerial Ace", 60, PokemonType.Flying, 100);
        AddNormal("Air Cutter", 55, PokemonType.Flying, 95);
        AddNormal("Air Slash", 75, PokemonType.Flying, 95);
        AddNormal("Ancient Power", 60, PokemonType.Rock, 100);
        AddNormal("Aqua Jet", 40, PokemonType.Water, 100);
        AddNormal("Aqua Tail", 90, PokemonType.Water, 90);
        AddNormal("Aura Sphere", 80, PokemonType.Fighting, 100);
        AddNormal("Bite", 60, PokemonType.Normal, 100);
        AddNormal("Blaze Kick", 85, PokemonType.Fire, 90);
        AddNormal("Body Slam", 85, PokemonType.Normal, 100);
        AddNormal("Bubble", 40, PokemonType.Water, 100);
        AddNormal("Bug Bite", 60, PokemonType.Bug, 100);
        AddNormal("Bug Buzz", 90, PokemonType.Bug, 100);
        AddNormal("Bullet Seed", 25, PokemonType.Grass, 100);
        AddNormal("Confusion", 50, PokemonType.Psychic, 100);
        AddNormal("Crunch", 80, PokemonType.Normal, 100);
        AddNormal("Dig", 80, PokemonType.Ground, 100);
        AddNormal("Double-Edge", 120, PokemonType.Normal, 100);
        AddNormal("Double Slap", 35, PokemonType.Normal, 85);
        AddNormal("Dragon Rage", 40, PokemonType.Dragon, 100);
        AddNormal("Dragon Rush", 100, PokemonType.Dragon, 75);
        AddNormal("Drill Peck", 80, PokemonType.Flying, 100);
        AddNormal("Earth Power", 90, PokemonType.Ground, 100);
        AddNormal("Earthquake", 100, PokemonType.Ground, 100);
        AddNormal("Ember", 40, PokemonType.Fire, 100);
        AddNormal("Flamethrower", 90, PokemonType.Fire, 100);
        AddNormal("Flash Cannon", 80, PokemonType.Normal, 100);
        AddNormal("Fury Attack", 30, PokemonType.Normal, 85);
        AddNormal("Fury Cutter", 40, PokemonType.Bug, 95);
        AddNormal("Fury Swipes", 54, PokemonType.Normal, 80);
        AddNormal("Fusion Bolt", 100, PokemonType.Electric, 100);
        AddNormal("Giga Drain", 75, PokemonType.Grass, 100);
        AddNormal("Giga Impact", 150, PokemonType.Normal, 90);
        AddNormal("Gunk Shot", 120, PokemonType.Poison, 80);
        AddNormal("Gust", 40, PokemonType.Flying, 100);
        AddNormal("Harden", 0, PokemonType.Normal, 100);
        AddNormal("Hurricane", 110, PokemonType.Flying, 70);
        AddNormal("Hydro Pump", 110, PokemonType.Water, 80);
        AddNormal("Hyper Fang", 80, PokemonType.Normal, 90);
        AddNormal("Hyper Voice", 90, PokemonType.Normal, 100);
        AddNormal("Ice Beam", 90, PokemonType.Ice, 100);
        AddNormal("Iron Tail", 100, PokemonType.Normal, 75);
        AddNormal("Magnitude", 70, PokemonType.Ground, 100);
        AddNormal("Mega Drain", 40, PokemonType.Grass, 100);
        AddNormal("Mud Slap", 45, PokemonType.Ground, 100);
        AddNormal("Pay Day", 40, PokemonType.Normal, 100);
        AddNormal("Peck", 35, PokemonType.Flying, 100);
        AddNormal("Petal Blizzard", 90, PokemonType.Grass, 100);
        AddNormal("Petal Dance", 70, PokemonType.Grass, 100);
        AddNormal("Pin Missile", 25, PokemonType.Bug, 95);
        AddNormal("Poison Jab", 80, PokemonType.Poison, 100);
        AddNormal("Pound", 40, PokemonType.Normal, 100);
        AddNormal("Psychic", 90, PokemonType.Psychic, 100);
        AddNormal("Quick Attack", 40, PokemonType.Normal, 100);
        AddNormal("Razor Leaf", 55, PokemonType.Grass, 95);
        AddNormal("Rock Blast", 75, PokemonType.Rock, 90);
        AddNormal("Rock Throw", 50, PokemonType.Rock, 90);
        AddNormal("Sand Attack", 0, PokemonType.Ground, 100);
        AddNormal("Sand Tomb", 65, PokemonType.Ground, 85);
        AddNormal("Scratch", 40, PokemonType.Normal, 100);
        AddNormal("Signal Beam", 75, PokemonType.Bug, 100);
        AddNormal("Sky Attack", 140, PokemonType.Flying, 90);
        AddNormal("Slam", 80, PokemonType.Normal, 75);
        AddNormal("Slash", 70, PokemonType.Normal, 100);
        AddNormal("Solar Beam", 120, PokemonType.Grass, 100);
        AddNormal("String Shot", 0, PokemonType.Bug, 95);
        AddNormal("Super Fang", 100, PokemonType.Normal, 90);
        AddNormal("Tackle", 40, PokemonType.Normal, 100);
        AddNormal("Thunder Shock", 40, PokemonType.Electric, 100);
        AddNormal("Twineedle", 25, PokemonType.Bug, 100);
        AddNormal("Vine Whip", 45, PokemonType.Grass, 100);
        AddNormal("Water Gun", 40, PokemonType.Water, 100);
        AddNormal("Water Pulse", 60, PokemonType.Water, 100);
        AddNormal("Wing Attack", 60, PokemonType.Flying, 100);
        AddNormal("Wrap", 15, PokemonType.Normal, 90);
        AddNormal("X-Scissor", 80, PokemonType.Bug, 100);

        AddSpecial<Poison>("Acid", 55, PokemonType.Poison, 100);
        AddSpecial<Paralysis>("Blizzard", 110, PokemonType.Ice, 70);
        AddSpecial<Poison>("Cross Poison", 70, PokemonType.Poison, 100);
        AddSpecial<Burn>("Fire Blast", 110, PokemonType.Fire, 85);
        AddSpecial<Burn>("Fire Punch", 75, PokemonType.Fire, 100);
        AddSpecial<Burn>("Fire Spin", 35, PokemonType.Fire, 85);
        AddSpecial<Burn>("Freeze-Dry", 70, PokemonType.Ice, 100);
        AddSpecial<Burn>("Heat Wave", 95, PokemonType.Fire, 90);
        AddSpecial<Sleep>("Hypnosis", 0, PokemonType.Psychic, 60);
        AddSpecial<Poison>("Poison Fang", 50, PokemonType.Poison, 100);
        AddSpecial<Poison>("Poison Powder", 0, PokemonType.Poison, 75);
        AddSpecial<Poison>("Poison Sting", 15, PokemonType.Poison, 100);
        AddSpecial<Sleep>("Psystrike", 10, PokemonType.Psychic, 100);
        AddSpecial<Paralysis>("Screech", 0, PokemonType.Normal, 85);
        AddSpecial<Sleep>("Sing", 0, PokemonType.Normal, 55);
        AddSpecial<Sleep>("Sleep Powder", 0, PokemonType.Grass, 75);
        AddSpecial<Poison>("Sludge Bomb", 85, PokemonType.Poison, 100);
        AddSpecial<Sleep>("Spore", 0, PokemonType.Grass, 100);
        AddSpecial<Paralysis>("Stun Spore", 0, PokemonType.Grass, 75);
        AddSpecial<Paralysis>("Supersonic", 0, PokemonType.Normal, 55);
        AddSpecial<Paralysis>("Thunderbolt", 90, PokemonType.Electric, 100);
        AddSpecial<Paralysis>("Thunder", 110, PokemonType.Electric, 70);
        AddSpecial<Paralysis>("Thunder Wave", 0, PokemonType.Electric, 90);
        AddSpecial<Poison>("Toxic", 0, PokemonType.Poison, 90);
        AddSpecial<Sleep>("Yawn", 0, PokemonType.Normal, 100);

        instance = new(normalAttacks);
    }

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
        NormalAttack a = Instance.normalAttacks[name];
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
        return Instance.normalAttacks.Values.Select(p => (p.Name, p.Type)).ToList();
    }
}
