// -----------------------------------------------------------------------
// <copyright file="SpecialAttackTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic;
using Library.GameLogic.Attacks;
using Library.GameLogic.Effects;

namespace Library.Tests.GameLogic;

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

        Pokemon target = PokemonRegistry.GetPokemon("Bulbasaur");

        specialAttack.Use(target);
        Assert.NotNull(target.ActiveEffect);
        Assert.IsInstanceOf<Paralysis>(target.ActiveEffect);
        Assert.That(target.Health, Is.LessThan(target.MaxHealth)); // Verifica que el daño haya sido aplicado
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

        Pokemon target = PokemonRegistry.GetPokemon("Bulbasaur");

        poisonSpecialAttack.Use(target);
        paralysisSpecialAttack.Use(target);
        Assert.That(initialEffect, Is.EqualTo(target.ActiveEffect)); // Verifica que el efecto inicial no haya cambiado
        Assert.That(target.Health, Is.LessThan(target.MaxHealth)); // Verifica que el daño haya sido aplicado
    }

    /// <summary>
    /// Testea que luego de utilizarse un ataque especial el mismo no este disponible durante dos turnos.
    /// </summary>
    [Test]
    public void UsingSpecialAttackAreDisabledForTwoTurns()
    {
        SpecialAttack specialAttack = new("Trueno", 10, PokemonType.Electric, 100, new Paralysis());
        Pokemon target = PokemonRegistry.GetPokemon("Bulbasaur");

        Assert.That(specialAttack.Available, Is.True, "El ataque especial debe estar disponible antes de utilizarse");

        specialAttack.Use(target);
        Assert.That(specialAttack.Available, Is.False, "El ataque especial no debe estar disponible después de utilizarse");

        specialAttack.UpdateTurn();
        Assert.That(specialAttack.Available, Is.False, "El ataque especial no debe estar disponible después de utilizarse");

        specialAttack.UpdateTurn();
        Assert.That(specialAttack.Available, Is.True, "El ataque especial debe estar disponible después de dos turnos");
    }

    /// <summary>
    /// Testea que luego de utilizarse un ataque especial el mismo no este disponible durante dos turnos.
    /// </summary>
    [Test]
    public void UnavailableSpecialAttackDoesNotDoDamage()
    {
        SpecialAttack specialAttack = new("Trueno", 10, PokemonType.Electric, 100, new Paralysis());
        Pokemon target = PokemonRegistry.GetPokemon("Bulbasaur");

        Assert.That(specialAttack.Available, Is.True, "El ataque especial debe estar disponible antes de utilizarse");

        int oldHP = target.Health;
        specialAttack.Use(target);
        Assert.That(specialAttack.Available, Is.False, "El ataque especial no debe estar disponible después de utilizarse");
        Assert.That(target.Health, Is.LessThan(oldHP), "El ataque especial no debe estar disponible después de utilizarse");

        oldHP = target.Health;
        specialAttack.Use(target);
        Assert.That(target.Health, Is.EqualTo(oldHP), "El ataque no debe restar vida si no está disponible");
    }
}
