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
        { "Fire Spin", new SpecialAttack("Fire Spin", 35, PokemonType.Fire) },
        { "Poison Powder", new SpecialAttack("Poison Powder", 0, PokemonType.Poison) },
        { "Sing", new SpecialAttack("Sing", 0, PokemonType.Normal) },
        { "Sleep Powder", new SpecialAttack("Sleep Powder", 0, PokemonType.Grass) },
        { "Thunder Wave", new SpecialAttack("Thunder Wave", 0, PokemonType.Electric) },
        { "Toxic", new SpecialAttack("Toxic", 0, PokemonType.Poison) },
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
