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
public class ItemTest
{
    /// <summary>
    /// Instancia de Pokémon utilizada en las pruebas.
    /// </summary>
    private Pokemon pokemon;

    /// <summary>
    /// Instancia de <see cref="TotalCure"/> utilizada en las pruebas.
    /// </summary>
    private TotalCure totalCure;

    /// <summary>
    /// Configura el entorno de prueba inicializando un Pokémon y el objeto <see cref="TotalCure"/>
    /// antes de cada prueba individual.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        List<Attack> ataque = new List<Attack>()
        {
            NormalAttackLibrary.BlazeKick,
        };
        this.pokemon = new Pokemon("Pikachu", PokemonType.Electric, 100, ataque);
        this.totalCure = new TotalCure();
    }

    /// <summary>
    /// Testea si el metodo Revive, lo revive con el 50 de HP.
    /// </summary>
    [Test]
    public void CanRevive()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackLibrary.AquaJet,
            NormalAttackLibrary.BlazeKick,
            NormalAttackLibrary.BulletSeed,
        };

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 0, attacks);

        // FIXME: Revive no tendria que ser static??
        Revive revive = new Revive();
        revive.Use(p1);

        Assert.That(p1.Health, Is.EqualTo(50));
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
        // Arrange
        var poisonEffect = new Poison();
        this.pokemon.ApplyEffect(poisonEffect);

        // Act
        this.totalCure.Use(this.pokemon);

        // Assert
        Assert.IsNull(this.pokemon.ActiveEffect, "TotalCure debería haber eliminado el efecto activo.");
    }

    /// <summary>
    /// Verifica que <see cref="TotalCure.Use(Pokemon)"/> lance una excepción
    /// <see cref="InvalidOperationException"/> si se intenta utilizar cuando el Pokémon
    /// no tiene efectos activos de estado.
    /// </summary>
    [Test]
    public void UseThrowsInvalidOperationExceptionWhenNoActiveEffect()
    {
        // Act & Assert
        Assert.Throws<InvalidOperationException>(
            () => this.totalCure.Use(this.pokemon),
            "Usar TotalCure en un Pokémon sin efecto activo debería lanzar InvalidOperationException.");
    }
}
