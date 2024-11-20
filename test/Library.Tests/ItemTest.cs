// -----------------------------------------------------------------------
// <copyright file="ItemTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic;
using Library.GameLogic.Effects;
using Library.GameLogic.Items;

namespace Library.Tests.GameLogic;

/// <summary>
/// Test de los Item.
/// </summary>
internal sealed class ItemTest
{
    /// <summary>
    /// Testea si el metodo Revive, lo revive con el 50% de su HP.
    /// </summary>
    [Test]
    public void CanRevive()
    {
        // La vida de Bulbasaur es de 45 al inicializarse (maxHealth)
        Pokemon p = PokemonRegistry.GetPokemon("Bulbasaur");
        p.Damage(100);

        Revive revive = new Revive();
        revive.Use(p);
        Assert.That(p.Health, Is.EqualTo(22));
    }

    /// <summary>
    /// Testea que no se pueda utilizar con pokemones que se encuentren vivos.
    /// </summary>
    [Test]
    public void CantReviveALivePokemon()
    {
        // La vida de Bulbasaur es de 45 al inicializarse (maxHealth)
        Pokemon p = PokemonRegistry.GetPokemon("Bulbasaur");
        p.Damage(20);
        Assert.That(p.Health, Is.GreaterThan(0));

        Revive revive = new Revive();
        var ex = Assert.Throws<InvalidOperationException>(() => revive.Use(p));
        Assert.That(ex.Message, Is.EqualTo($"El Pokémon {p.Name} ya está vivo y no puede ser revivido."));
    }

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
