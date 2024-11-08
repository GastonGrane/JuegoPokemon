// -----------------------------------------------------------------------
// <copyright file="AttackTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Tests;

/// <summary>
/// Testeamos los metodos de Attack
/// </summary>
public class AttackTest
{
    /// <summary>
    /// Testeamos si el NormalAttack realmente hace el daño que tendria que hacer
    /// </summary>
    [Test]
    public void NormalAttackCanAttack()
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

        List<Pokemon> pokemon0 = new List<Pokemon>();

        Pokemon p11 = new Pokemon("pokemon", PokemonType.Water, 100, attacks);
        Pokemon p22 = new Pokemon("pokemon2", PokemonType.Bug, 100, attacks);
        Pokemon p33 = new Pokemon("pokemon3", PokemonType.Bug, 100, attacks);
        Pokemon p44 = new Pokemon("pokemon4", PokemonType.Bug, 100, attacks);
        Pokemon p55 = new Pokemon("pokemon5", PokemonType.Bug, 100, attacks);
        Pokemon p66 = new Pokemon("pokemon6", PokemonType.Bug, 100, attacks);

        pokemon0.Add(p11);
        pokemon0.Add(p22);
        pokemon0.Add(p33);
        pokemon0.Add(p44);
        pokemon0.Add(p55);
        pokemon0.Add(p66);

        Player player1 = new Player("Gaston", pokemon0);
        Player player2 = new Player("Guzman", pokemon);

        player1.Attack(player2, "Aqua Jet");
        Assert.That(player2.ActivePokemon.Health, Is.EqualTo(60));
    }
}