// -----------------------------------------------------------------------
// <copyright file="SelectPokemonsTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Tests;

/// <summary>
/// Testeando el seleccionar un pokemon para nuestra lista personal.
/// </summary>
public class SelectPokemonsTest
{
    /// <summary>
    /// Testeando que pueda seleccionar un pokemon en especifico para añadir a mis lista de pokemons.
    /// </summary>
    [Test]
    public void CanSelectPokemon()
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

        Player player1 = new Player("Gaston", pokemon);

        // No entiendo el funcionamiento de Select, quiero poder instanciarla para luego hacer un test sobre ella, 
        // seleccionando un pokemon para que se meta en mi lista de pokemones
    }
}