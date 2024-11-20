// -----------------------------------------------------------------------
// <copyright file="EffectTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic;
using Library.GameLogic.Effects;
using Library.GameLogic.Pokemon;

namespace Library.Tests.GameLogic;

/// <summary>
/// Tests que prueban el correcto uncionamiento de los efectos del codigo.
/// </summary>
internal sealed class EffectTests
{
    /// <summary>
    /// Verifica que el efecto de veneno disminuya la salud en un 5% cada turno.
    /// </summary>
    [Test]
    public void PoisonEffectShouldExpireWhenHealing()
    {
        var pokemon = PokemonRegistry.GetPokemon("Pikachu");
        var poisonEffect = new Poison();
        pokemon.ApplyEffect(poisonEffect);

        for (int i = 0; i < 3; i++)
        {
            pokemon.UpdateEffect();
        }

        pokemon.RemoveEffect();

        // MaxHealth = 35
        // 35*0.05 = 1.75 ~ 1
        // 35 - 1 - 1 - 1 = 32
        Assert.That(pokemon.Health, Is.EqualTo(32));
        Assert.IsTrue(poisonEffect.IsExpired);
        Assert.IsNull(pokemon.ActiveEffect);
    }

    /// <summary>
    /// Verifica que el efecto de quemadura disminuya la salud en un 10% cada turno.
    /// </summary>
    [Test]
    public void BurnEffectShouldExpireWhenHealing()
    {
        var pokemon = PokemonRegistry.GetPokemon("Pikachu");
        var burnEffect = new Burn();
        pokemon.ApplyEffect(burnEffect);

        for (int i = 0; i < 3; i++)
        {
            pokemon.UpdateEffect();
        }

        pokemon.RemoveEffect();

        // MaxHealth = 35
        // 35*0.1 = 3.5 ~ 3
        // 35 - 3 - 3 - 3 = 24
        Assert.That(pokemon.Health, Is.EqualTo(26));
        Assert.IsTrue(burnEffect.IsExpired);
        Assert.IsNull(pokemon.ActiveEffect);
    }

    /// <summary>
    /// Verifica que el efecto de sueño impida atacar durante 3 turnos y expire después de esos turnos.
    /// </summary>
    [Test]
    public void SleepEffectShouldExpireAfterThreeTurns()
    {
        var pokemon = PokemonRegistry.GetPokemon("Pikachu");
        var sleepEffect = new Sleep(3);
        pokemon.ApplyEffect(sleepEffect);

        for (int i = 0; i < 3; i++)
        {
            pokemon.UpdateEffect();
            Assert.IsFalse(pokemon.CanAttack);
        }

        pokemon.UpdateEffect();
        Assert.IsTrue(sleepEffect.IsExpired);
        Assert.IsNull(pokemon.ActiveEffect);
    }

    /// <summary>
    /// Verifica que el efecto de parálisis permita atacar y no atacar al menos una vez cada uno,
    /// y que el efecto expire al removerlo explícitamente.
    /// </summary>
    [Test]
    public void ParalysisEffectShouldAllowAtLeastOneAttackAndOneBlock()
    {
        var pokemon = PokemonRegistry.GetPokemon("Pikachu");
        var paralysisEffect = new Paralysis();
        pokemon.ApplyEffect(paralysisEffect);

        int canAttackCount = 0;
        int cannotAttackCount = 0;

        while (canAttackCount == 0 || cannotAttackCount == 0)
        {
            pokemon.UpdateEffect();
            if (pokemon.CanAttack)
            {
                canAttackCount++;
            }
            else
            {
                cannotAttackCount++;
            }
        }

        Assert.IsTrue(
            canAttackCount >= 1 && cannotAttackCount >= 1,
            "Debe permitir al menos un ataque y bloquear al menos uno.");
        pokemon.RemoveEffect();
        Assert.IsTrue(
            paralysisEffect.IsExpired,
            "El efecto de parálisis debería estar expirado después de removerlo.");
        Assert.IsNull(
            pokemon.ActiveEffect,
            "No debería haber ningún efecto activo en el Pokémon después de removerlo.");
    }
}
