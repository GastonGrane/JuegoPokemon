// -----------------------------------------------------------------------
// <copyright file="SpecialAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

// FIXME: Por ahora esto no hace nada, ni hay ataques especiales, ni los efectos están definidos

/// <summary>
/// Un ataque especial. Este es un tipo de ataque que,
/// además de realizar daño, también inflige un estado sobre el Pokemon,
/// dependiendo de qué ataque fue utilizado.
///
/// Una vez que el ataque acierta, siempre se le infligirá el estado al Pokemon,
/// es decir, la precisión de la aplicación del estado es del 100%.
/// </summary>
public class SpecialAttack : Attack
{
    /// <summary>
    /// Crea un ataque especial.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de daño que realiza.</param>
    /// <param name="attackType">El <see cref="PokemonType"/> del ataque.</param>
    /// <param name="precision">La precisión del ataque (1-100).</param>
    public SpecialAttack(string name, int damage, PokemonType attackType, int precision) : base(name, damage, attackType, precision) { }
}
