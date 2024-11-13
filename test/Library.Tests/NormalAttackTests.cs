// -----------------------------------------------------------------------
// <copyright file="NormalAttackTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic;
using Library.GameLogic.Attacks;

namespace Library.Tests.GameLogic;

/// <summary>
/// Test de los metodos de NormalAttack.
/// </summary>
public class NormalAttackTests
{
    /// <summary>
    /// Testea el constructor de NormalAttack.
    /// </summary>
    [Test]
    public void CanNormalAttack()
    {
        Attack colaDragon = new NormalAttack("Cola Dragon", 15, PokemonType.Dragon, 100);

        Assert.That(colaDragon.Name, Is.EqualTo("Cola Dragon"), "El nombre no se inicio correctoamente");
        Assert.That(colaDragon.Damage, Is.EqualTo(15), "El daño no se incio correctamente");
        Assert.That(colaDragon.Type, Is.EqualTo(PokemonType.Dragon), "El tipo del ataque no se inicio bien");
    }

    /// <summary>
    /// Testea que ocurra una excepcion si el parametro nombre es null.
    /// </summary>
    [Test]
    public void NormalAttackDevuelveExcepcionSiNombreEsEsNull()
    {
        bool exceptionThrown = false;
        try
        {
#pragma warning disable CS8625 // se le pasa null a propósito
            NormalAttack attack = new NormalAttack(null, 13, PokemonType.Bug, 100);
#pragma warning restore CS8625
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear un NormalAttack con nombre null no tiro una excepcion");
    }

    /// <summary>
    /// Testea que ocurra una excepcion si el damage es negativo.
    /// </summary>
    [Test]
    public void NormalAttackDevuelveExcepcionSiElDamageEsNegativo()
    {
        bool exceptionThrown = false;
        try
        {
            Attack lanzaRoca = new NormalAttack("Lanza Roca", -13, PokemonType.Bug, 100);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear un NormalAttack con un damage negativo no tiro una excepcion");
    }

    /// <summary>
    /// Testea si NormalAttack realmente hace el daño que tendria que hacer.
    /// </summary>
    [Test]
    public void NormalAttackCanAttack()
    {
        var p1 = PokemonRegistry.GetPokemon("Squirtle");
        var p2 = PokemonRegistry.GetPokemon("Bulbasaur");

        p1.Attack(p2, "Water Gun");
        Assert.That(p1.Health, Is.EqualTo(p1.MaxHealth));
        Assert.That(p2.Health, Is.LessThan(p2.MaxHealth));
    }
}
