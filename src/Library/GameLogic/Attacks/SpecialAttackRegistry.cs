// -----------------------------------------------------------------------
// <copyright file="SpecialAttackRegistry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Effects;

namespace Library.GameLogic.Attacks;

/// <summary>
/// Clase estática con una colección de ataques especiales pre-definidos.
/// </summary>
/// <remarks>
/// Se podría decir que es una implementación de <see href="https://refactoring.guru/design-patterns/prototype">Prototype</see>.
/// Esto es porque esta clase permite conseguir un objeto de la clase SpecialAttack sin conocer su estructura, a través de el nombre del objeto, clonando un prototipo pre-definido.
/// </remarks>
public static class SpecialAttackRegistry
{
    private static readonly Dictionary<string, SpecialAttack> SpecialAttacks = new()
    {
        { "Acid", new SpecialAttack("Acid",  55, PokemonType.Poison, 100, new Poison(), true) },
        { "Blizzard", new SpecialAttack("Blizzard",  110, PokemonType.Ice, 70, new Paralysis(), true) },
        { "Cross Poison", new SpecialAttack("Cross Poison",  70, PokemonType.Poison, 100, new Poison(), true) },
        { "Fire Blast", new SpecialAttack("Fire Blast",  110, PokemonType.Fire, 85, new Burn(), true) },
        { "Fire Punch", new SpecialAttack("Fire Punch",  75, PokemonType.Fire, 100, new Burn(), true) },
        { "Fire Spin", new SpecialAttack("Fire Spin", 35, PokemonType.Fire, 85, new Burn(), true) },
        { "Freeze-Dry", new SpecialAttack("Freeze-Dry",  70, PokemonType.Ice, 100, new Burn(), true) },
        { "Heat Wave", new SpecialAttack("Heat Wave",  95, PokemonType.Fire, 90, new Burn(), true) },
        { "Hypnosis", new SpecialAttack("Hypnosis",  0, PokemonType.Psychic, 60, new Sleep(), true) },
        { "Poison Fang", new SpecialAttack("Poison Fang",  50, PokemonType.Poison, 100, new Poison(), true) },
        { "Poison Powder", new SpecialAttack("Poison Powder",  0, PokemonType.Poison, 75, new Poison(), true) },
        { "Poison Sting", new SpecialAttack("Poison Sting", 15, PokemonType.Poison, 100, new Poison(), true) },
        { "Psystrike", new SpecialAttack("Psystrike",  100, PokemonType.Psychic, 100, new Sleep(), true) },
        { "Screech", new SpecialAttack("Screech",  0, PokemonType.Normal, 85, new Paralysis(), true) },
        { "Sing", new SpecialAttack("Sing",  0, PokemonType.Normal, 55, new Sleep(), true) },
        { "Sleep Powder", new SpecialAttack("Sleep Powder",  0, PokemonType.Grass, 75, new Sleep(), true) },
        { "Sludge Bomb", new SpecialAttack("Sludge Bomb",  85, PokemonType.Poison, 100, new Poison(), true) },
        { "Spore", new SpecialAttack("Spore",  0, PokemonType.Grass, 100, new Sleep(), true) },
        { "Stun Spore", new SpecialAttack("Stun Spore",  0, PokemonType.Grass, 75, new Paralysis(), true) },
        { "Supersonic", new SpecialAttack("Supersonic",  0, PokemonType.Normal, 55, new Paralysis(), true) },
        { "Thunderbolt", new SpecialAttack("Thunderbolt",  90, PokemonType.Electric, 100, new Paralysis(), true) },
        { "Thunder", new SpecialAttack("Thunder",  110, PokemonType.Electric, 70, new Paralysis(), true) },
        { "Thunder Wave", new SpecialAttack("Thunder Wave",  0, PokemonType.Electric, 90, new Paralysis(), true) },
        { "Toxic", new SpecialAttack("Toxic", 0, PokemonType.Poison, 90, new Poison(), true) },
        { "Yawn", new SpecialAttack("Yawn",  0, PokemonType.Normal, 100, new Sleep(), true) },
    };

    /// <summary>
    /// Retorna una copia del <see cref="SpecialAttack"/> cuyo nombre es <paramref name="name"/>, si se encuentra en el registro.
    /// </summary>
    /// <param name="name">El nombre del <see cref="SpecialAttack"/>.</param>
    /// <exception cref="KeyNotFoundException">
    /// Si el <see cref="SpecialAttack"/> no está en el registro.
    /// </exception>
    /// <returns>
    /// Una copia del <see cref="SpecialAttack"/> cuyo nombre es <paramref name="name"/>.
    /// </returns>
    public static SpecialAttack GetSpecialAttack(string name)
    {
        SpecialAttack a = SpecialAttacks[name];
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
        return SpecialAttacks.Values.Select(p => (p.Name, p.Type)).ToList();
    }
}
