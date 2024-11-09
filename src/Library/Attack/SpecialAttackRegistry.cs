// -----------------------------------------------------------------------
// <copyright file="SpecialAttackRegistry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Clase estática con una colección de ataques especiales pre-definidos.
/// </summary>
/// <remarks>
/// Se podría decir que es una implementación de <see href="https://refactoring.guru/design-patterns/prototype">Prototype</see>.
/// </remarks>
public static class SpecialAttackRegistry
{
    private static readonly Dictionary<string, SpecialAttack> SpecialAttacks = new()
    {
        { "Acid", new SpecialAttack("Acid",  55, PokemonType.Poison) },
        { "Blizzard", new SpecialAttack("Blizzard",  110, PokemonType.Ice) },
        { "Cross Poison", new SpecialAttack("Cross Poison",  70, PokemonType.Poison) },
        { "Fire Blast", new SpecialAttack("Fire Blast",  110, PokemonType.Fire) },
        { "Fire Punch", new SpecialAttack("Fire Punch",  75, PokemonType.Fire) },
        { "Fire Spin", new SpecialAttack("Fire Spin", 35, PokemonType.Fire) },
        { "Freeze-Dry", new SpecialAttack("Freeze-Dry",  70, PokemonType.Ice) },
        { "Heat Wave", new SpecialAttack("Heat Wave",  95, PokemonType.Fire) },
        { "Hyper Voice", new SpecialAttack("Hyper Voice",  90, PokemonType.Normal) },
        { "Hypnosis", new SpecialAttack("Hypnosis",  0, PokemonType.Psychic) },
        { "Poison Fang", new SpecialAttack("Poison Fang",  50, PokemonType.Poison) },
        { "Poison Powder", new SpecialAttack("Poison Powder",  0, PokemonType.Poison) },
        { "Psystrike", new SpecialAttack("Psystrike",  100, PokemonType.Psychic) },
        { "Sand Attack", new SpecialAttack("Sand Attack",  0, PokemonType.Ground) },
        { "Sand Tomb", new SpecialAttack("Sand Tomb",  65, PokemonType.Ground) },
        { "Screech", new SpecialAttack("Screech",  0, PokemonType.Normal) },
        { "Sing", new SpecialAttack("Sing",  0, PokemonType.Normal) },
        { "Sleep Powder", new SpecialAttack("Sleep Powder",  0, PokemonType.Grass) },
        { "Sludge Bomb", new SpecialAttack("Sludge Bomb",  85, PokemonType.Poison) },
        { "Spore", new SpecialAttack("Spore",  0, PokemonType.Grass) },
        { "Stun Spore", new SpecialAttack("Stun Spore",  0, PokemonType.Grass) },
        { "Supersonic", new SpecialAttack("Supersonic",  0, PokemonType.Normal) },
        { "Thunderbolt", new SpecialAttack("Thunderbolt",  90, PokemonType.Electric) },
        { "Thunder", new SpecialAttack("Thunder",  110, PokemonType.Electric) },
        { "Thunder Wave", new SpecialAttack("Thunder Wave",  0, PokemonType.Electric) },
        { "Toxic", new SpecialAttack("Toxic", 0, PokemonType.Poison) },
        { "Yawn", new SpecialAttack("Yawn",  0, PokemonType.Normal) },
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
