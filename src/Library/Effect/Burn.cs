using System.Diagnostics;

namespace Library
{
    /// <summary>
    /// Representa un efecto de quemadura que puede ser aplicado a un Pokémon.
    /// Este efecto causa daño al Pokémon objetivo cada turno mientras está activo.
    /// </summary>
    public class Burn : IEffect
    {
        /// <summary>
        /// Indica si el efecto de quemadura ha expirado y ya no debe aplicarse.
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia del efecto de quemadura en el Pokémon especificado y lo marca como activo.
        /// </summary>
        /// <param name="pokemon">El Pokémon al cual se aplicará el efecto de quemadura.</param>
        public Burn(Pokemon pokemon)
        {
            IsExpired = false;
        }

        /// <summary>
        /// Aplica el daño de quemadura al Pokémon objetivo, reduciendo su salud en un 10% de su salud actual.
        /// </summary>
        /// <param name="target">El Pokémon al que se le aplicará el daño por quemadura.</param>
        public void UpdateEffect(Pokemon target)
        {
            // Aplica el daño de quemadura cada turno
            target.Damage((int)(target.Health * 0.10));
        }

        /// <summary>
        /// Elimina el efecto de quemadura del Pokémon, marcándolo como expirado.
        /// </summary>
        /// <param name="target">El Pokémon del que se removerá el efecto.</param>
        public void RemoveEffect(Pokemon target)
        {
            IsExpired = true;
        }
    }
}