// -----------------------------------------------------------------------
// <copyright file="PlayerTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic;
using Library.GameLogic.Attacks;
using Library.GameLogic.Effects;
using Library.GameLogic.Entities;
using Library.GameLogic.Players;

namespace Library.Tests.GameLogic;

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
            Player p = new Player("Gaston", null);
#pragma warning restore CS8625
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el player sin lista de pokemons no tiro una excepcion");
    }

    /// <summary>
    /// Testea que Player se cree con el nombre y su lista de Pokmemon correcta.
    /// </summary>
    [Test]
    public void PlayerConParametrosCorrectorFunciona()
    {
        List<Pokemon> l = new List<Pokemon>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
        };

        string name = "Axel";
        Player p = new Player(name, l);

        Assert.That(p.Name, Is.EqualTo(name));
        for (int i = 0; i < l.Count; ++i)
        {
            Assert.That(l[i], Is.EqualTo(p.Pokemons[i]));
        }
    }

    /// <summary>
    /// Testea que Player no puede ser construido con 0 pokemones.
    /// </summary>
    [Test]
    public void PlayerListaDePokemonsVaciaFalla()
    {
        bool exceptionThrown = false;
        try
        {
            Player p = new Player("Gaston", []);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el player con lista de pokemones vacía debería tirar una excepción");
    }

    /// <summary>
    /// Testea que Player no puede ser construido con >6 pokemones.
    /// </summary>
    [Test]
    public void PlayerListaDePokemonsMuchosFalla()
    {
        bool exceptionThrown = false;
        try
        {
            Player p = new Player("Gaston", [
                PokemonRegistry.GetPokemon("Pikachu"),
                PokemonRegistry.GetPokemon("Bulbasaur"),
                PokemonRegistry.GetPokemon("Charmander"),
                PokemonRegistry.GetPokemon("Squirtle"),
                PokemonRegistry.GetPokemon("Moltres"),
                PokemonRegistry.GetPokemon("Mewtwo"),
                PokemonRegistry.GetPokemon("Mew"),
            ]);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Crear el player con lista de demasiados pokemones debería tirar una excepción");
    }

    /// <summary>
    /// Testea que de una excepcion si creamos un player sin nombre o nombre null.
    /// </summary>
    [Test]
    public void PlayerSinNombreONullFalla()
    {
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
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
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
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
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
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

    /// <summary>
    /// Testea que se puede cambiar de pokemon activo correctamente por índice.
    /// </summary>
    [Test]
    public void PlayerPuedeCambiarDePokemonActivoPorIndice()
    {
        Pokemon pikachu = PokemonRegistry.GetPokemon("Pikachu");
        Pokemon charmander = PokemonRegistry.GetPokemon("Charmander");
        List<Pokemon> pok = new()
        {
            pikachu,
            charmander,
        };

        Player p = new("Sharon", pok);

        Assert.That(p.ActivePokemon, Is.EqualTo(pikachu));
        Assert.That(p.ChangePokemon(1), Is.True);
        Assert.That(p.ActivePokemon, Is.EqualTo(charmander));
    }

    /// <summary>
    /// Testea que se puede cambiar de pokemon activo correctamente por nombre.
    /// </summary>
    [Test]
    public void PlayerPuedeCambiarDePokemonActivoPorNombre()
    {
        Pokemon pikachu = PokemonRegistry.GetPokemon("Pikachu");
        Pokemon charmander = PokemonRegistry.GetPokemon("Charmander");
        List<Pokemon> pok = new()
        {
            pikachu,
            charmander,
        };

        Player p = new("Sharon", pok);

        Assert.That(p.ActivePokemon, Is.EqualTo(pikachu));
        Assert.That(p.ChangePokemon("Charmander"), Is.True);
        Assert.That(p.ActivePokemon, Is.EqualTo(charmander));
    }

    /// <summary>
    /// Testea que no se puede cambiar de pokemon activo con índice fuera de rango.
    /// </summary>
    [Test]
    public void PlayerNoPuedeCambiarDePokemonActivoPorIndiceIncorrecto()
    {
        Pokemon pikachu = PokemonRegistry.GetPokemon("Pikachu");
        Pokemon charmander = PokemonRegistry.GetPokemon("Charmander");
        List<Pokemon> pok = new()
        {
            pikachu,
            charmander,
        };

        Player p = new("Sharon", pok);

        Assert.That(p.ActivePokemon, Is.EqualTo(pikachu));
        Assert.Throws<ArgumentOutOfRangeException>(() => p.ChangePokemon(7));
        Assert.That(p.ActivePokemon, Is.EqualTo(pikachu));
    }

    /// <summary>
    /// Testea que no se puede cambiar de pokemon activo con nombre no en la lista.
    /// </summary>
    [Test]
    public void PlayerNoPuedeCambiarDePokemonActivoPorNombreIncorrecto()
    {
        Pokemon pikachu = PokemonRegistry.GetPokemon("Pikachu");
        Pokemon charmander = PokemonRegistry.GetPokemon("Charmander");
        List<Pokemon> pok = new()
        {
            pikachu,
            charmander,
        };

        Player p = new("Sharon", pok);

        Assert.That(p.ActivePokemon, Is.EqualTo(pikachu));
        Assert.That(p.ChangePokemon("Squirtle"), Is.False);
        Assert.That(p.ActivePokemon, Is.EqualTo(pikachu));
    }

    /// <summary>
    /// Testea que la probabilida de victoria de un jugador con todo es 100.
    /// </summary>
    [Test]
    public void PlayerConTodoTieneProbabilidadDeVictoria100()
    {
        Player p = new Player(
                "Axel",
                new()
                {
                    PokemonRegistry.GetPokemon("Pikachu"),
                    PokemonRegistry.GetPokemon("Squirtle"),
                    PokemonRegistry.GetPokemon("Bulbasaur"),
                    PokemonRegistry.GetPokemon("Raichu"),
                    PokemonRegistry.GetPokemon("Ivysaur"),
                    PokemonRegistry.GetPokemon("Wartortle"),
                });

        Assert.That(p.ProbabilidadDeVictoria(), Is.EqualTo(100));
    }

    /// <summary>
    /// Testea que la probabilida de victoria de un jugador con todo es 100.
    /// </summary>
    [Test]
    public void PlayerSinNadaTienePuntaje0()
    {
        Pokemon mew = PokemonRegistry.GetPokemon("Mew");
        Poison poison = new Poison();
        Player player = new Player(
                "Gastón",
                new()
                {
                    mew,
                });

        // Uso todas los items
        player.ApplyItem(mew, "Super Potion");
        player.ApplyItem(mew, "Super Potion");
        player.ApplyItem(mew, "Super Potion");
        player.ApplyItem(mew, "Super Potion");

        // Debe tener un efecto para usar total cure
        mew.ApplyEffect(poison);
        player.ApplyItem(mew, "Total Cure");
        mew.ApplyEffect(poison);
        player.ApplyItem(mew, "Total Cure");

        // Lo dejo con un efecto para sacar esos 10 puntos.
        mew.ApplyEffect(poison);

        // Lo mato, revivo y mato de nuevo
        mew.Damage(1000);
        player.ApplyItem(mew, "Revive");
        mew.Damage(1000);

        Assert.That(player.ProbabilidadDeVictoria(), Is.EqualTo(0));
    }

    /// <summary>
    /// Testea que la probabilida de victoria de un jugador con menos Pokemon, pero todo demás normal, es lo correcto.
    /// </summary>
    [Test]
    public void PlayerConMenosPokemonYPokemonDañadoTieneMenosPuntaje()
    {
        // squirtle tiene una vida redonda.
        Pokemon squirtle = PokemonRegistry.GetPokemon("Squirtle");
        Player p = new Player(
                "Sharon",
                new()
                {
                    PokemonRegistry.GetPokemon("Pikachu"),
                    squirtle,
                    PokemonRegistry.GetPokemon("Bulbasaur"),
                });

        squirtle.Damage(22);

        Assert.That(p.ProbabilidadDeVictoria(), Is.EqualTo(65));
    }

    /// <summary>
    /// Testea que la probabilida de victoria de un jugador que haya usado sus items es menor.
    /// </summary>
    [Test]
    public void PlayerConMenosItemsTieneMenosPuntaje()
    {
        Pokemon squirtle = PokemonRegistry.GetPokemon("Squirtle");
        Player p = new Player(
                "Guzmán",
                new()
                {
                    PokemonRegistry.GetPokemon("Pikachu"),
                    PokemonRegistry.GetPokemon("Raichu"),
                    squirtle,
                    PokemonRegistry.GetPokemon("Bulbasaur"),
                    PokemonRegistry.GetPokemon("Ivysaur"),
                    PokemonRegistry.GetPokemon("Venusaur"),
                });

        p.ApplyItem(squirtle, "Super Potion");
        p.ApplyItem(squirtle, "Super Potion");

        Assert.That(p.ProbabilidadDeVictoria(), Is.EqualTo(91));
    }
}
