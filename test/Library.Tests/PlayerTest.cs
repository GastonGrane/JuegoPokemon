// -----------------------------------------------------------------------
// <copyright file="PlayerTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

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
            Player p = new Player("Gaston", null);
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
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackLibrary.AquaJet,
            NormalAttackLibrary.BlazeKick,
            NormalAttackLibrary.BulletSeed,
        };
        List<Pokemon> pokemon = new List<Pokemon>();

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
            Player p = new Player(string.Empty, pokemon);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el player sin nombre no tiro una excepcion");
    }

    /// <summary>
    /// Testea que de una excepcion si creamos un player sin pokemons.
    /// </summary>
    [Test]
    public void PlayerSinPokemonsFalla()
    {
        List<Pokemon> pokemones = new List<Pokemon>();

        bool exceptionThrown = false;
        try
        {
            Player p = new Player("Gaston", pokemones);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el player sin pokemons no tiro una excepcion");
    }

    /// <summary>
    /// Testea que ocurra una excepcion si player ataca a null.
    /// </summary>
    [Test]
    public void PlayerAtacaANingunJugadorFalla()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackLibrary.AquaJet,
            NormalAttackLibrary.BlazeKick,
            NormalAttackLibrary.BulletSeed,
        };
        List<Pokemon> pokemon = new List<Pokemon>();

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
            p.Attack(null, "Blaze Kick");
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
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackLibrary.AquaJet,
            NormalAttackLibrary.BlazeKick,
            NormalAttackLibrary.BulletSeed,
        };
        List<Pokemon> pokemon = new List<Pokemon>();

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