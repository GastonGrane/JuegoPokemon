namespace Library
{
    public interface IEffect
    {
        /// <summary>
        /// Actualiza el estado del efecto en cada turno.
        /// </summary>
        /// <param name="target">El Pokémon al que se aplica el efecto.</param>
        void UpdateEffect(Pokemon target);

        /// <summary>
        /// Elimina el efecto del Pokémon, restaurando cualquier cambio aplicado por el efecto.
        /// </summary>
        /// <param name="target">El Pokémon del que se elimina el efecto.</param>
        void RemoveEffect(Pokemon target);

        /// <summary>
        /// Indica si el efecto ha expirado y debería ser eliminado del Pokémon.
        /// </summary>
        bool IsExpired { get; }
    }
}