// -----------------------------------------------------------------------
// <copyright file="NormalAttackLibrary.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Clase estática con una colección de ataques normales pre-definidos.
/// </summary>
public static class NormalAttackLibrary
{
    /// <summary>
    /// Aqua Jet (water).
    /// </summary>
    public static readonly NormalAttack AquaJet = new NormalAttack("Aqua Jet", 40, PokemonType.Water, 100);

    /// <summary>
    /// Bullet Seed (Grass).
    /// </summary>
    public static readonly NormalAttack BulletSeed = new NormalAttack("Bullet Seed", 25, PokemonType.Grass, 100);

    /// <summary>
    /// Blaze Kick (Fire).
    /// </summary>
    public static readonly NormalAttack BlazeKick = new NormalAttack("Blaze Kick", 85, PokemonType.Fire, 100);

    /// <summary>
    /// Fusion Bolt (Electric).
    /// </summary>
    public static readonly NormalAttack FusionBolt = new NormalAttack("Fusion Bolt", 100, PokemonType.Electric, 100);
}
