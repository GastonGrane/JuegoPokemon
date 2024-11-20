// -----------------------------------------------------------------------
// <copyright file="PlayerTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic;
using Library.GameLogic.Attacks;
using Library.GameLogic.Players;

namespace Library.Tests;

/// <summary>
/// Test de Player.
/// </summary>
public class PlayerTest
{
    /// <summary>
    /// Testea Player con lista de pokemones null.
    /// </summary>
    [Test]
    public void PlayerListaDePokemonsNullFalla()
    {
        bool exceptionThrown = false;
        try
        {
#pragma warning disable CS8625 // se le pasa null a propósito
            Player unused = new Player("Gaston", null);
#pragma warning restore CS8625
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el player sin lista de pokemons no tiro una excepcion");
    }

    /// <summary>
    /// Testea que de una excepcion si creamos un player sin nombre o nombre null.
    /// </summary>
    [Test]
    public void PlayerSinNombreONullFalla()
    {
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };
        List<Pokemon?> pokemon = new List<Pokemon?>();

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        Pokemon p2 = new Pokemon("pokemon2", PokemonType.Bug, 100, attacks);
        Pokemon p3 = new Pokemon("pokemon3", PokemonType.Bug, 100, attacks);
        Pokemon p4 = new Pokemon("pokemon4", PokemonType.Bug, 100, attacks);
        Pokemon p5 = new Pokemon("pokemon5", PokemonType.Bug, 100, attacks);
        Pokemon p6 = new Pokemon("pokemon6", PokemonType.Bug, 100, attacks);

        pokemon.Add(p1);
        pokemon.Add(p2);
        pokemon.Add(p3);
        pokemon.Add(p4);
        pokemon.Add(p5);
        pokemon.Add(p6);

        bool exceptionThrown = false;
        try
        {
            Player unused = new Player(string.Empty, pokemon);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el player sin nombre no tiro una excepcion");
    }

    /// <summary>
    /// Testea que se lanza una excepción si creamos un player sin pokémons.
    /// </summary>
    [Test]
    public void PlayerSinPokemonsFalla()
    {
        var ex = Assert.Throws<ArgumentNullException>(() =>
        {
            List<Pokemon?>? pokemones = null;
            Player unused = new Player("Gaston", pokemones);
        });

        Assert.That(ex.ParamName, Is.EqualTo("Un jugador no puede tener una lista de pokemons null"), "El parámetro de la excepción no coincide.");
    }

    /// <summary>
    /// Testea que ocurra una excepcion si player ataca a null.
    /// </summary>
    [Test]
    public void PlayerAtacaANingunJugadorFalla()
    {
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };
        List<Pokemon?> pokemon = new List<Pokemon?>();

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        Pokemon p2 = new Pokemon("pokemon2", PokemonType.Bug, 100, attacks);
        Pokemon p3 = new Pokemon("pokemon3", PokemonType.Bug, 100, attacks);
        Pokemon p4 = new Pokemon("pokemon4", PokemonType.Bug, 100, attacks);
        Pokemon p5 = new Pokemon("pokemon5", PokemonType.Bug, 100, attacks);
        Pokemon p6 = new Pokemon("pokemon6", PokemonType.Bug, 100, attacks);

        pokemon.Add(p1);
        pokemon.Add(p2);
        pokemon.Add(p3);
        pokemon.Add(p4);
        pokemon.Add(p5);
        pokemon.Add(p6);

        bool exceptionThrown = false;
        try
        {
            Player p = new Player("Gaston", pokemon);
#pragma warning disable CS8625 // se le pasa null a propósito
            p.Attack(null, "Blaze Kick");
#pragma warning restore CS8625
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Atacar a un jugador null no tiro una excepcion");
    }

    /// <summary>
    /// Testea que ocurra correctamente la implementacion de **AllAreDead**.
    /// </summary>
    [Test]
    public void PlayerSeQuedaSinPokemonVivosTerminaElJuego()
    {
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            NormalAttackRegistry.GetNormalAttack("Aqua Jet"),
            NormalAttackRegistry.GetNormalAttack("Blaze Kick"),
            NormalAttackRegistry.GetNormalAttack("Bullet Seed"),
        };
        List<Pokemon?> pokemon = new List<Pokemon?>();

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 0, attacks);
        Pokemon p2 = new Pokemon("pokemon2", PokemonType.Bug, 0, attacks);
        Pokemon p3 = new Pokemon("pokemon3", PokemonType.Bug, 0, attacks);
        Pokemon p4 = new Pokemon("pokemon4", PokemonType.Bug, 0, attacks);
        Pokemon p5 = new Pokemon("pokemon5", PokemonType.Bug, 0, attacks);
        Pokemon p6 = new Pokemon("pokemon6", PokemonType.Bug, 0, attacks);

        pokemon.Add(p1);
        pokemon.Add(p2);
        pokemon.Add(p3);
        pokemon.Add(p4);
        pokemon.Add(p5);
        pokemon.Add(p6);

        Player player2 = new Player("Guzman", pokemon);

        Assert.True(player2.AllAreDead());
    }
}
