// -----------------------------------------------------------------------
// <copyright file="ItemTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Effect;
using Library.Items;

namespace Library.Tests
{
    /// <summary>
    /// Contiene pruebas para la clase <see cref="TotalCure"/> que verifica su funcionalidad
    /// en la eliminación de efectos activos de estado en un Pokémon.
    /// </summary>
    [TestFixture]
    public class ItemTest
    {
        /// <summary>
        /// Instancia de Pokémon utilizada en las pruebas.
        /// </summary>
        private Pokemon? pokemon;

        /// <summary>
        /// Instancia de <see cref="TotalCure"/> utilizada en las pruebas.
        /// </summary>
        private TotalCure totalCure;

        /// <summary>
        /// Configura el entorno de prueba inicializando un Pokémon y el objeto <see cref="TotalCure"/>
        /// antes de cada prueba individual.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.pokemon = new Pokemon("Pikachu", PokemonType.Electric, 100, new List<Attack>());
            this.totalCure = new TotalCure();
        }

        /// <summary>
        /// Verifica que <see cref="TotalCure.Use(Pokemon)"/> elimine correctamente un efecto activo
        /// de estado en el Pokémon cuando existe un efecto activo.
        /// </summary>
        [Test]
        public void UseRemovesActiveEffectSuccessfully()
        {
            // Arrange
            var poisonEffect = new Poison();
            this.pokemon.ApplyEffect(poisonEffect);

            // Act
            this.totalCure.Use(this.pokemon);

            // Assert
            Assert.IsNull(this.pokemon.ActiveEffect, "TotalCure debería haber eliminado el efecto activo.");
        }

        /// <summary>
        /// Verifica que <see cref="TotalCure.Use(Pokemon)"/> lance una excepción
        /// <see cref="InvalidOperationException"/> si se intenta utilizar cuando el Pokémon
        /// no tiene efectos activos de estado.
        /// </summary>
        [Test]
        public void UseThrowsInvalidOperationExceptionWhenNoActiveEffect()
        {
            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => this.totalCure.Use(this.pokemon),
                "Usar TotalCure en un Pokémon sin efecto activo debería lanzar InvalidOperationException.");
        }
    }
}