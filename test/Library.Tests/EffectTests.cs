// -----------------------------------------------------------------------
// <copyright file="EffectTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Effect;

namespace Library.Tests;

/// <summary>
/// Tests que prueban el correcto uncionamiento de los efectos del codigo.
/// </summary>
[TestFixture]
public class PokemonEffectTests
{
    private Pokemon pokemon;

    /// <summary>
    /// Creo poquemon que usare en los Test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.pokemon = new Pokemon("Pikachu", PokemonType.Electric, 100, new List<Attack>());
    }

    /// <summary>
    /// Verifica que el efecto de veneno disminuya la salud en un 5% cada turno.
    /// </summary>
    [Test]
    public void PoisonEffectShouldExpireWhenHealing()
    {
        var poisonEffect = new Poison();
        this.pokemon.ApplyEffect(poisonEffect);

        for (int i = 0; i < 3; i++)
        {
            this.pokemon.UpdateEffect();
        }

        this.pokemon.RemoveEffect();
        Assert.That(this.pokemon.Health, Is.EqualTo(86.74).Within(1));
        Assert.IsTrue(poisonEffect.IsExpired);
        Assert.IsNull(this.pokemon.ActiveEffect);
    }

    /// <summary>
    /// Verifica que el efecto de quemadura disminuya la salud en un 10% cada turno.
    /// </summary>
    [Test]
    public void BurnEffectShouldExpireWhenHealing()
    {
        var burnEffect = new Burn();
        this.pokemon.ApplyEffect(burnEffect);

        for (int i = 0; i < 3; i++)
        {
            this.pokemon.UpdateEffect();
        }

        this.pokemon.RemoveEffect();
        Assert.That(this.pokemon.Health, Is.EqualTo(72.9).Within(1));
        Assert.IsTrue(burnEffect.IsExpired);
        Assert.IsNull(this.pokemon.ActiveEffect);
    }

    /// <summary>
    /// Verifica que el efecto de sueño impida atacar durante 3 turnos y expire después de esos turnos.
    /// </summary>
    [Test]
    public void SleepEffectShouldExpireAfterThreeTurns()
    {
        var sleepEffect = new Sleep(3);
        this.pokemon.ApplyEffect(sleepEffect);

        for (int i = 0; i < 3; i++)
        {
            this.pokemon.UpdateEffect();
            Assert.IsFalse(this.pokemon.CanAttack);
        }

        this.pokemon.UpdateEffect();
        Assert.IsTrue(sleepEffect.IsExpired);
        Assert.IsNull(this.pokemon.ActiveEffect);
    }

    /// <summary>
    /// Verifica que el efecto de parálisis permita atacar y no atacar al menos una vez cada uno,
    /// y que el efecto expire al removerlo explícitamente.
    /// </summary>
    [Test]
    public void ParalysisEffectShouldAllowAtLeastOneAttackAndOneBlock()
    {
        var paralysisEffect = new Paralysis();
        this.pokemon.ApplyEffect(paralysisEffect);

        int canAttackCount = 0;
        int cannotAttackCount = 0;

        while (canAttackCount == 0 || cannotAttackCount == 0)
        {
            this.pokemon.UpdateEffect();
            if (this.pokemon.CanAttack)
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
        this.pokemon.RemoveEffect();
        Assert.IsTrue(
            paralysisEffect.IsExpired,
            "El efecto de parálisis debería estar expirado después de removerlo.");
        Assert.IsNull(
            this.pokemon.ActiveEffect,
            "No debería haber ningún efecto activo en el Pokémon después de removerlo.");
    }
}