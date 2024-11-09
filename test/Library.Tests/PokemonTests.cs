// -----------------------------------------------------------------------
// <copyright file="PokemonTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Tests;

/// <summary>
/// Test de Pokemon y sus metodos.
/// </summary>
public class PokemonTests
{
    /// <summary>
    /// Testea que ocurra una excepcion si Pokemon se crea con demasiados ataques.
    /// </summary>
    [Test]
    public void PokemonConMuchosAtaquesFalla()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
            NormalAttackRegistry.GetNormalAttack("Fusion Bolt"),
            NormalAttackRegistry.GetNormalAttack("Sky Attack"),
        };
        bool exceptionThrown = false;
        try
        {
            Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el pokemon con demasiados ataques no tiro una excepcion");
    }

    /// <summary>
    /// Testea que no ocurra una excepcion si Pokemon se crea con ataques menores a 4.
    /// </summary>
    [Test]
    public void PokemonCon3AtaquesSePuede()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };

        Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        Assert.That(p.Name, Is.EqualTo("pokemon"));
        Assert.That(p.Type, Is.EqualTo(PokemonType.Bug));
        Assert.That(p.Health, Is.EqualTo(100));
        Assert.That(p.Attacks.Count, Is.EqualTo(3));
    }

    /// <summary>
    /// Testea que ocurra una excepcion si Pokemon se crea sin ataques.
    /// </summary>
    [Test]
    public void PokemonSinAtaquesFalla()
    {
        List<Attack> attacks = new List<Attack>();

        bool exceptionThrown = false;
        try
        {
            Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el pokemon sin clases no tiro una excepcion");
    }

    /// <summary>
    /// Testea que ocurra una excepcion si Pokemon ataca con un Ataque inexistente.
    /// </summary>
    [Test]
    public void PokemonAtacaConUnAtaqueInexistenteFalla()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };
        bool exceptionThrown = false;
        try
        {
            Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
            Pokemon p2 = new Pokemon("pokemon", PokemonType.Fire, 100, attacks);
            p.Attack(p2, "extra");
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Atacar con el ataque inexistente de un pokemon no tiro una excepcion");
    }

    /// <summary>
    /// Testea que ocurra un error si Pokemon se Cura con numeros negativos.
    /// </summary>
    [Test]
    public void PokemonSeCuraNegativoFalla()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };
        bool exceptionThrown = false;
        try
        {
            Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
            p.Heal(-3);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Curarse negativamente no tiro una excepcion");
    }

    /// <summary>
    /// Testea que el pokemon no se cura de mas de su vida maxima, una vez inicializada con el pokemon.
    /// </summary>
    [Test]
    public void PokemonNoSeCuraDeMas()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };

        Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        Pokemon p2 = new Pokemon("pokemon2", PokemonType.Dragon, 100, attacks);
        p.Attack(p2, "Aqua Jet");
        p2.Heal(150);

        Assert.That(p2.Health, Is.EqualTo(100));
    }
}
