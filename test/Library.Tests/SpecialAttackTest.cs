using Library.Effect;

namespace Library.Tests
{
    public class SpecialAttackTest
    {
        /// <summary>
        /// Verifica que el ataque especial golpee al objetivo y aplique el efecto, repitiendo hasta que tenga éxito.
        /// </summary>
        [Test]
        public void SpecialAttack_AppliesEffect_AfterSuccessfulHit()
        {
            var paralysisEffect = new Paralysis();
            var specialAttack = new SpecialAttack("Trueno", 10, PokemonType.Electric, 100, paralysisEffect); // 50% de precisión
            var target = new Pokemon("Pikachu", PokemonType.Water, 50, new List<Attack> { specialAttack });
            specialAttack.Use(target);
            Assert.NotNull(target.ActiveEffect);
            Assert.IsInstanceOf<Paralysis>(target.ActiveEffect);
            Assert.Less(target.Health, 50); // Verifica que el daño haya sido aplicado
        }

        /// <summary>
        /// Verifica que un ataque especial no reemplace el efecto activo si el Pokémon objetivo ya tiene uno.
        /// </summary>
        [Test]
        public void SpecialAttack_DoesNotOverrideEffect_AfterSuccessfulHit()
        {
            var initialEffect = new Poison();
            var paralysisEffect = new Paralysis();
            var specialAttack1 = new SpecialAttack("Trueno", 10, PokemonType.Electric, 100, initialEffect);
            var specialAttack2 = new SpecialAttack("Trueno", 10, PokemonType.Electric, 100, paralysisEffect);
            var target = new Pokemon("Bulbasaur", PokemonType.Grass, 50, new List<Attack> { specialAttack2 });
            specialAttack1.Use(target);
            specialAttack2.Use(target);
            Assert.AreEqual(initialEffect, target.ActiveEffect); // Verifica que el efecto inicial no haya cambiado
            Assert.Less(target.Health, 50); // Verifica que el daño haya sido aplicado
        }
    }
}
