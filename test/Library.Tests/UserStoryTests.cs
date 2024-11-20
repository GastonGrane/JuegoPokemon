// -----------------------------------------------------------------------
// <copyright file="UserStoryTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic;
using Library.GameLogic.Attacks;
using Library.GameLogic.Players;

namespace Library.Tests;

/// <summary>
/// Tests de las historias de usuario.
/// </summary>
internal sealed class UserStoryTests
{
    /// <summary>
    /// Test de la primera historia de usuario: se pueden elegir 6 Pokémon.
    /// </summary>
    [Test]
    public void UserStory1()
    {
        Assert.That(PokemonRegistry.GetPokemonNamesAndTypes().Count, Is.GreaterThan(6));
    }

    /// <summary>
    /// Test de la segunda historia de usuario: se pueden ver los ataques disponibles.
    /// </summary>
    [Test]
    public void UserStory2()
    {
        Player p = new Player("Axel", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });
        Assert.That(p.ActivePokemon, Is.Not.Null);
        Assert.That(p.ActivePokemon.Attacks, Is.Not.Null);
        Assert.That(p.ActivePokemon.Attacks, Is.Not.Empty);
    }

    /// <summary>
    /// Test de la tercera historia de usuario: se puede ver la HP de mis Pokemon y los de mi oponente.
    /// </summary>
    [Test]
    public void UserStory3()
    {
        Player p1 = new Player("Axel", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });

        Player p2 = new Player("Gastón", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Bulbasaur"),
            PokemonRegistry.GetPokemon("Metapod"),
            PokemonRegistry.GetPokemon("Dragonite"),
            PokemonRegistry.GetPokemon("Mewtwo"),
        });

        Assert.That(p1.ActivePokemon.Health, Is.GreaterThan(0));
        foreach (Pokemon? p in p1.Pokemons)
        {
            Assert.That(p.Health, Is.GreaterThan(0));
        }

        Assert.That(p2.ActivePokemon.Health, Is.GreaterThan(0));
        foreach (Pokemon? p in p2.Pokemons)
        {
            Assert.That(p.Health, Is.GreaterThan(0));
        }
    }

    /// <summary>
    /// Test de la cuarta historia de usuario: atacar y hacer daño basado en tipos.
    /// </summary>
    [Test]
    public void UserStory4()
    {
        Player p1 = new Player("Axel", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });

        Player p2 = new Player("Gastón", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Bulbasaur"),
            PokemonRegistry.GetPokemon("Metapod"),
            PokemonRegistry.GetPokemon("Dragonite"),
            PokemonRegistry.GetPokemon("Mewtwo"),
        });

        p1.Attack(p2, "Quick Attack");
        Assert.That(p2.ActivePokemon.Health, Is.LessThan(p2.ActivePokemon.MaxHealth));

        Assert.That(p2.ActivePokemon.Type.Advantage(p1.ActivePokemon.Type), Is.AnyOf([0.0, 1.0, 2.0, 0.5]));
        foreach (NormalAttack a in p2.ActivePokemon.Attacks)
        {
            Assert.That(a.Type.Advantage(p1.ActivePokemon.Type), Is.AnyOf([0.0, 1.0, 2.0, 0.5]));
        }
    }

    /// <summary>
    /// Test de la quinta historia de usuario: quiero saber que es mi turno.
    /// </summary>
    [Test]
    public void UserStory5()
    {
    }

    /// <summary>
    /// Test de la sexta historia de usuario: se gana cuando todos los pokemon de mi oponente mueren.
    /// </summary>
    [Test]
    public void UserStory6()
    {
        Player p1 = new Player("Axel", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });

        Player p2 = new Player("Gastón", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Bulbasaur"),
            PokemonRegistry.GetPokemon("Metapod"),
            PokemonRegistry.GetPokemon("Dragonite"),
            PokemonRegistry.GetPokemon("Mewtwo"),
        });

        for (int i = 0; i < 4; ++i)
        {
            p2.ChangePokemon(i);
            for (int j = 0; j < 10; ++j)
            {
                p1.Attack(p2, "Quick Attack");
            }
        }

        Assert.That(p2.AllAreDead(), Is.True);
    }

    /// <summary>
    /// Test de la séptima historia de usuario: se puede cambiar de Pokémon.
    /// </summary>
    [Test]
    public void UserStory7()
    {
        Player p1 = new Player("Axel", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });

        // Ya tengo el primer pokemon como el activo
        Assert.That(p1.ChangePokemon(0), Is.False);

        // Sí me puedo cambiar al segundo
        Assert.That(p1.ChangePokemon(1), Is.True);

        // Una vez que lo tengo, si intento cambiar a él de vuelta no puedo.
        Assert.That(p1.ChangePokemon(1), Is.False);
    }

    /// <summary>
    /// Test de la octava historia de usuario: se pueden usar items.
    /// </summary>
    [Test]
    public void UserStory8()
    {
        Player p1 = new Player("Axel", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });

        Player p2 = new Player("Gastón", new List<Pokemon?>
        {
            PokemonRegistry.GetPokemon("Dragonite"),
            PokemonRegistry.GetPokemon("Bulbasaur"),
            PokemonRegistry.GetPokemon("Metapod"),
            PokemonRegistry.GetPokemon("Mewtwo"),
        });

        p1.Attack(p2, "Quick Attack");
        p1.Attack(p2, "Quick Attack");
        p1.Attack(p2, "Quick Attack");

        Assert.That(p2.ActivePokemon.Health, Is.EqualTo(0));

        p2.ApplyItem(p2.ActivePokemon, "Revive");

        Assert.That(p2.ActivePokemon.Health, Is.EqualTo(50));
    }

    /// <summary>
    /// Test de la novena historia de usuario: me puedo unir a una lista y esperar por oponentes.
    /// </summary>
    [Test]
    public void UserStory9()
    {
    }

    /// <summary>
    /// Test de la décima historia de usuario: quiero ver la lista de jugador esperando por un oponente.
    /// </summary>
    [Test]
    public void UserStory10()
    {
    }

    /// <summary>
    /// Test de la décima primera historia de usuario: se puede iniciar una batalla con otro jugador en la cola.
    /// </summary>
    [Test]
    public void UserStory11()
    {
    }
}
