// -----------------------------------------------------------------------
// <copyright file="EffectTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Effects;
using Library.GameLogic.Entities;
using Library.GameLogic.Utilities;

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
    /// Verifica que el constructor Sleep(IProbability randomGen) inicialice correctamente los turnos restantes
    /// utilizando un generador de números aleatorios controlado.
    /// </summary>
    [Test]
    public void SleepConstructorWithSystemRandomGeneratesTurnsWithinRange()
    {
        // Crear una lista para almacenar múltiples instancias del efecto Sleep.
        List<int> generatedDurations = new List<int>();

        // Crear varias instancias de Sleep y registrar los turnos generados.
        // Repetimos varias veces para cubrir rangos.
        for (int i = 0; i < 100; i++)
        {
            Sleep sleepEffect = new Sleep(new SystemRandom());
            Assert.IsFalse(sleepEffect.IsExpired, "El efecto no debería estar expirado al ser creado.");
            generatedDurations.Add(sleepEffect.GetRemainingTurns()); // Método helper para obtener los turnos.
        }

        Assert.That(generatedDurations, Has.All.InRange(1, 4), "Todos los turnos generados deben estar entre 1 y 4.");
    }

    /// <summary>
    /// Verifica que el método UpdateEffect lance una excepción ArgumentNullException 
    /// cuando el parámetro target es null.
    /// </summary>
    [Test]
    public void UpdateEffectShouldThrowArgumentNullExceptionWhenTargetIsNull()
    {
        var effect1 = new Sleep();
        var effect2 = new Paralysis();
        var effect3 = new Burn();
        var effect4 = new Poison();

        // Verificar que se lance ArgumentNullException cuando target es null.
        var ex1 = Assert.Throws<ArgumentNullException>(() => effect1.UpdateEffect(null!));
        var ex2 = Assert.Throws<ArgumentNullException>(() => effect2.UpdateEffect(null!));
        var ex3 = Assert.Throws<ArgumentNullException>(() => effect3.UpdateEffect(null!));
        var ex4 = Assert.Throws<ArgumentNullException>(() => effect4.UpdateEffect(null!));

        Assert.That(ex1.ParamName, Is.EqualTo("target"));
        Assert.That(ex2.ParamName, Is.EqualTo("target"));
        Assert.That(ex3.ParamName, Is.EqualTo("target"));
        Assert.That(ex4.ParamName, Is.EqualTo("target"));
    }

    /// <summary>
    /// Verifica que el método RemoveEffect lance una excepción ArgumentNullException 
    /// cuando el parámetro target es null.
    /// </summary>
    [Test]
    public void RemoveEffectShouldThrowArgumentNullExceptionWhenTargetIsNull()
    {
        var effect1 = new Sleep();
        var effect2 = new Paralysis();
        var effect3 = new Burn();
        var effect4 = new Poison();

        // Verificar que se lance ArgumentNullException cuando target es null.
        var ex1 = Assert.Throws<ArgumentNullException>(() => effect1.RemoveEffect(null!));
        var ex2 = Assert.Throws<ArgumentNullException>(() => effect2.RemoveEffect(null!));
        var ex3 = Assert.Throws<ArgumentNullException>(() => effect3.RemoveEffect(null!));
        var ex4 = Assert.Throws<ArgumentNullException>(() => effect4.RemoveEffect(null!));

        Assert.That(ex1.ParamName, Is.EqualTo("target"));
        Assert.That(ex2.ParamName, Is.EqualTo("target"));
        Assert.That(ex3.ParamName, Is.EqualTo("target"));
        Assert.That(ex4.ParamName, Is.EqualTo("target"));
    }

    /// <summary>
    /// Verifica que el constructor de Paralysis(IProbability random), cuando se utiliza con SystemRandom, 
    /// implemente correctamente una probabilidad del 50% para permitir que el Pokémon afectado ataque.
    /// </summary>
    [Test]
    public void ParalysisConstructorWithSystemRandomShouldAllowAttackWith50PercentChance()
    {
        var paralysisEffect = new Paralysis(new SystemRandom());

        Pokemon pokemon = PokemonRegistry.GetPokemon("Pikachu");
        pokemon.ApplyEffect(paralysisEffect);

        // Ejecutar el efecto varias veces y cuenta cuántas veces el Pokémon puede atacar.
        int canAttackCount = 0;
        int cannotAttackCount = 0;

        // Repetimos varias veces para cubrir el 50% de probabilidad.
        for (int i = 0; i < 100; i++)
        {
            paralysisEffect.UpdateEffect(pokemon);
            if (pokemon.CanAttack)
            {
                canAttackCount++;
            }
            else
            {
                cannotAttackCount++;
            }
        }

        // Verificar que la probabilidad de ataque esté en torno al 50%.
        Assert.That(canAttackCount, Is.InRange(44, 56), "La probabilidad de atacar debería estar alrededor del 50%.");
        Assert.That(cannotAttackCount, Is.InRange(44, 56), "La probabilidad de no atacar debería estar alrededor del 50%.");
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
