using System.Diagnostics;

namespace Library
{
    /// <summary>
    /// Representa un efecto de veneno que puede ser aplicado a un Pokémon.
    /// Este efecto causa daño al Pokémon objetivo cada turno mientras está activo.
    /// </summary>
    public class Poison : IEffect
    {
        /// <summary>
        /// Indica si el efecto de veneno ha expirado y ya no debe aplicarse.
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia del efecto de veneno en el Pokémon especificado y lo marca como activo.
        /// </summary>
        /// <param name="pokemon">El Pokémon al cual se aplicará el efecto de veneno.</param>
        public Poison(Pokemon pokemon)
        {
            IsExpired = false;
        }

        /// <summary>
        /// Aplica el daño de veneno al Pokémon objetivo, reduciendo su salud en un 5% de su salud actual.
        /// </summary>
        /// <param name="target">El Pokémon al que se le aplicará el daño por veneno.</param>
        public void UpdateEffect(Pokemon target)
        {
            // Aplica el daño de veneno cada turno
            target.Damage((int)(target.Health * 0.05));
        }

        /// <summary>
        /// Elimina el efecto de veneno del Pokémon.
        /// </summary>
        /// <param name="target">El Pokémon del que se removerá el efecto.</param>
        public void RemoveEffect(Pokemon target)
        {
            IsExpired = true;
        }
    }
}