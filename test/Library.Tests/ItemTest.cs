// -----------------------------------------------------------------------
// <copyright file="ItemTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Effect;
using Library.Items;

namespace Library.Tests;

/// <summary>
/// Test de los Item.
/// </summary>
internal sealed class ItemTest
{
    /// <summary>
    /// Testea si el metodo Revive, lo revive con el 50 de HP.
    /// </summary>
    [Test]
    public void CanRevive()
    {
        // MaxHealth > 50
        Pokemon p = PokemonRegistry.GetPokemon("Dragonite");
        p.Damage(1000);

        Revive revive = new Revive();
        revive.Use(p);

        Assert.That(p.Health, Is.EqualTo(50));
    }

    // FIXME: Hacer un test de revivir a un Pokémon vivo.

    /// <summary>
    /// Testea que falle el hecho de que pasemos como parametro algo null.
    /// </summary>
    [Test]
    public void PasarUnParametroNullFalla()
    {
        Revive revive = new Revive();
        bool exceptionThrown = false;
        try
        {
#pragma warning disable CS8625 // se le pasa null a propósito
            revive.Use(null);
#pragma warning restore CS8625
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Curar a un pokemon inexistente no tiro una excepcion");
    }

    /// <summary>
    /// Verifica que <see cref="TotalCure.Use(Pokemon)"/> elimine correctamente un efecto activo
    /// de estado en el Pokémon cuando existe un efecto activo.
    /// </summary>
    [Test]
    public void UseRemovesActiveEffectSuccessfully()
    {
        var p = PokemonRegistry.GetPokemon("Pikachu");
        var totalCure = new TotalCure();

        // Arrange
        var poisonEffect = new Poison();
        p.ApplyEffect(poisonEffect);

        // Act
        totalCure.Use(p);

        // Assert
        Assert.IsNull(p.ActiveEffect, "TotalCure debería haber eliminado el efecto activo.");
    }

    /// <summary>
    /// Verifica que <see cref="TotalCure.Use(Pokemon)"/> lance una excepción
    /// <see cref="InvalidOperationException"/> si se intenta utilizar cuando el Pokémon
    /// no tiene efectos activos de estado.
    /// </summary>
    [Test]
    public void UseThrowsInvalidOperationExceptionWhenNoActiveEffect()
    {
        var p = PokemonRegistry.GetPokemon("Pikachu");
        var totalCure = new TotalCure();

        Assert.Throws<InvalidOperationException>(
            () => totalCure.Use(p),
            "Usar TotalCure en un Pokémon sin efecto activo debería lanzar InvalidOperationException.");
    }
}
