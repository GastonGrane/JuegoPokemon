using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Tests
{
    [TestFixture]
    public class PokemonEffectTests
    {
        private Pokemon _pokemon;

        [SetUp]
        public void Setup()
        {
            _pokemon = new Pokemon("Pikachu", PokemonType.Electric, 100, new List<Attack>());
        }

        /// <summary>
        /// Verifica que el efecto de veneno disminuya la salud en un 5% cada turno y expire cuando se intente curar al Pokémon.
        /// </summary>
        [Test]
        public void PoisonEffect_ShouldExpireWhenHealing()
        {
            var poisonEffect = new Poison(_pokemon);
            _pokemon.ApplyEffect(poisonEffect);

            for (int i = 0; i < 3; i++)
            {
                _pokemon.UpdateEffect();
            }

            _pokemon.RemoveEffect();
            Assert.AreEqual(86.74, _pokemon.Health, 1);
            Assert.IsTrue(poisonEffect.IsExpired);
            Assert.IsNull(_pokemon.ActiveEffect); 
        }

        /// <summary>
        /// Verifica que el efecto de quemadura disminuya la salud en un 10% cada turno y expire cuando se intente curar al Pokémon.
        /// </summary>
        [Test]
        public void BurnEffect_ShouldExpireWhenHealing()
        {
            var burnEffect = new Burn(_pokemon);
            _pokemon.ApplyEffect(burnEffect);

            for (int i = 0; i < 3; i++)
            {
                _pokemon.UpdateEffect();
            }

            _pokemon.RemoveEffect();
            Assert.AreEqual(_pokemon.Health, 72.9, 1);
            Assert.IsTrue(burnEffect.IsExpired);
            Assert.IsNull(_pokemon.ActiveEffect);
        }

        /// <summary>
        /// Verifica que el efecto de sueño impida atacar durante 3 turnos y expire después de esos turnos.
        /// </summary>
        [Test]
        public void SleepEffect_ShouldExpireAfterThreeTurns()
        {
            var sleepEffect = new Sleep(3, _pokemon);
            _pokemon.ApplyEffect(sleepEffect);

            for (int i = 0; i < 3; i++)
            {
                _pokemon.UpdateEffect();
                Assert.IsFalse(_pokemon.CanAttack);
            }

            _pokemon.UpdateEffect(); 
            Assert.IsTrue(sleepEffect.IsExpired);
            Assert.IsNull(_pokemon.ActiveEffect); 
        }

        /// <summary>
        /// Verifica que el efecto de parálisis permita atacar aproximadamente el 50% de las veces y expire al removerlo explícitamente.
        /// </summary>
        [Test]
        public void ParalysisEffect_ShouldAllowAttackApproximatelyHalfTheTime()
        {
            var paralysisEffect = new Paralysis(_pokemon);
            _pokemon.ApplyEffect(paralysisEffect);

            int canAttackCount = 0;
            int cannotAttackCount = 0;

            for (int i = 0; i < 100; i++) 
            {
                _pokemon.UpdateEffect();
                if (_pokemon.CanAttack)
                    canAttackCount++;
                else
                    cannotAttackCount++;
            }

            Assert.AreEqual(50, canAttackCount, 10); 
            Assert.AreEqual(50, cannotAttackCount, 10);

            _pokemon.RemoveEffect();

            Assert.IsTrue(paralysisEffect.IsExpired);
            Assert.IsNull(_pokemon.ActiveEffect);
        }
    }
        
}

