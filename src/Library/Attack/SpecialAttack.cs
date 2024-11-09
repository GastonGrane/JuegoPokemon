// -----------------------------------------------------------------------
// <copyright file="SpecialAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Effect;

namespace Library
{
    /// <summary>
    /// Representa un ataque especial que, además de causar daño,
    /// aplica un efecto en el Pokémon objetivo. El efecto depende del tipo de ataque.
    /// Una vez que el ataque impacta, el efecto se aplica al Pokémon objetivo,
    /// con una precisión del 100% para la aplicación del efecto.
    /// </summary>
    /// <remarks>
    /// Inicializa una nueva instancia de la clase <see cref="SpecialAttack"/>.
    /// </remarks>
    /// <param name="name">El nombre del ataque especial.</param>
    /// <param name="damage">La cantidad de daño que realiza el ataque.</param>
    /// <param name="attackType">El tipo del ataque (<see cref="PokemonType"/>).</param>
    /// <param name="effect">El efecto especial que se aplicará al Pokémon objetivo.</param>
    public class SpecialAttack(string name, int damage, PokemonType attackType, IEffect effect) : Attack(name, damage, attackType)
    {
        /// <summary>
        /// Obtiene el efecto especial que se aplica al Pokémon objetivo.
        /// </summary>
        private IEffect Effect { get; set; } = effect;

        /// <summary>
        /// Aplica el efecto especial al Pokémon objetivo si no tiene un efecto activo.
        /// </summary>
        /// <param name="target">El Pokémon objetivo que recibirá el efecto especial.</param>
        /// <exception cref="ArgumentNullException">Se lanza si el Pokémon objetivo es <c>null</c>.</exception>
        public void Do(Pokemon target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target), "El Pokémon objetivo no puede ser null.");
            }

            if (target.ActiveEffect == null)
            {
                target.ApplyEffect(this.Effect);
            }
        }
    }
}
