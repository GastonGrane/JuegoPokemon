// -----------------------------------------------------------------------
// <copyright file="SpecialAttackTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Effect;

namespace Library.Tests;

/// <summary>
/// Tests para la clase SpecialAttack.
/// </summary>
public class SpecialAttackTest
{
    /// <summary>
    /// Verifica que el ataque especial golpee al objetivo y aplique el efecto, repitiendo hasta que tenga éxito.
    /// </summary>
    [Test]
    public void SpecialAttackAppliesEffectAfterSuccessfulHit()
    {
        SpecialAttack specialAttack = new("Trueno", 10, PokemonType.Electric, 100, new Paralysis());
        Pokemon target = new Pokemon("Pikachu", PokemonType.Water, 50, new List<Attack> { specialAttack });

        specialAttack.Use(target);
        Assert.NotNull(target.ActiveEffect);
        Assert.IsInstanceOf<Paralysis>(target.ActiveEffect);
        Assert.That(target.Health, Is.LessThan(50)); // Verifica que el daño haya sido aplicado
    }

    /// <summary>
    /// Verifica que un ataque especial no reemplace el efecto activo si el Pokémon objetivo ya tiene uno.
    /// </summary>
    [Test]
    public void SpecialAttackDoesNotOverrideEffectAfterSuccessfulHit()
    {
        Poison initialEffect = new Poison();
        SpecialAttack poisonSpecialAttack = new SpecialAttack("Spit", 10, PokemonType.Poison, 100, initialEffect);
        SpecialAttack paralysisSpecialAttack = new SpecialAttack("Thunder", 10, PokemonType.Electric, 100, new Paralysis());
        Pokemon target = new Pokemon("Bulbasaur", PokemonType.Grass, 50, new List<Attack> { });

        poisonSpecialAttack.Use(target);
        paralysisSpecialAttack.Use(target);
        Assert.That(initialEffect, Is.EqualTo(target.ActiveEffect)); // Verifica que el efecto inicial no haya cambiado
        Assert.That(target.Health, Is.LessThan(50)); // Verifica que el daño haya sido aplicado
    }
}
