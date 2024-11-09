// -----------------------------------------------------------------------
// <copyright file="NormalAttackTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Tests;

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
        Attack colaDragon = new NormalAttack("Cola Dragon", 15, PokemonType.Dragon);

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
            NormalAttack attack = new NormalAttack(null, 13, PokemonType.Bug);
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
            Attack lanzaRoca = new NormalAttack("Lanza Roca", -13, PokemonType.Bug);
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
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);

        Pokemon p11 = new Pokemon("pokemon", PokemonType.Water, 100, attacks);

        p1.Attack(p11, "Aqua Jet");
        Assert.That(p11.Health, Is.EqualTo(80));
    }
}
