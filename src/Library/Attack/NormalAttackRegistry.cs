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
        { "Aqua Jet", new NormalAttack("Aqua Jet", 40, PokemonType.Water) },
        { "Bullet Seed", new NormalAttack("Bullet Seed", 25, PokemonType.Grass) },
        { "Blaze Kick", new NormalAttack("Blaze Kick", 85, PokemonType.Fire) },
        { "Fusion Bolt", new NormalAttack("Fusion Bolt", 100, PokemonType.Electric) },
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
