// -----------------------------------------------------------------------
// <copyright file="PokemonTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Attacks;
using Library.GameLogic.Entities;

namespace Library.Tests.GameLogic;

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
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
            AttackRegistry.GetNormalAttack("Fusion Bolt"),
            AttackRegistry.GetNormalAttack("Sky Attack"),
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
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
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
        List<NormalAttack> attacks = new List<NormalAttack>();

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
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
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
    /// Testea que ocurra una excepcion si Pomeon ata con un indice de ataque inecistente.
    /// </summary>
    [Test]
    public void PokemonAtacaConUnAtaqueInexisteIndiceFalla()
    {
        List<NormalAttack> attacks = new List<NormalAttack>()
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
        };

        bool exceptionThrown = false;
        try
        {
            Pokemon p = new Pokemon("Pokemon", PokemonType.Dragon, 100, attacks);
            Pokemon p2 = new Pokemon("Pokemon", PokemonType.Ghost, 100, attacks);
            p.Attack(p2, 4);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Atacar con el ataque inexistente de un pokemon no genero una excepcion");
    }

    /// <summary>
    /// Testea que funcione si un Pokemon ataca con un indice de ataque valido.
    /// </summary>
    [Test]
    public void PokemonAtacaConUnAtacaIndiceValidoFunciona()
    {
        List<NormalAttack> attacks = new List<NormalAttack>()
        {
            AttackRegistry.GetNormalAttack("Mega Drain"),
            AttackRegistry.GetNormalAttack("Poison Jab"),
            AttackRegistry.GetNormalAttack("Hurricane"),
        };

        Pokemon p = new Pokemon("Pokemon", PokemonType.Dragon, 100, attacks);
        Pokemon p2 = new Pokemon("Pokemon", PokemonType.Ghost, 100, attacks);

        p.Attack(p2, 0);
        Assert.That(p2.Health, Is.LessThan(100));

        p.Attack(p2, 1);
        Assert.That(p2.Health, Is.EqualTo(0));
    }

    /// <summary>
    /// Testea que ocurra un error si Pokemon se Cura con numeros negativos.
    /// </summary>
    [Test]
    public void PokemonSeCuraNegativoFalla()
    {
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
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
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
        };

        Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        Pokemon p2 = new Pokemon("pokemon2", PokemonType.Dragon, 100, attacks);
        p.Attack(p2, "Aqua Jet");
        p2.Heal(150);

        Assert.That(p2.Health, Is.EqualTo(100));
    }
}
