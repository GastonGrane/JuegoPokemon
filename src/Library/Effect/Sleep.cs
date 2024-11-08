namespace Library
{
    /// <summary>
    /// Representa un efecto de sueño que puede ser aplicado a un Pokémon.
    /// Este efecto impide que el Pokémon pueda atacar durante un número determinado de turnos.
    /// </summary>
    public class Sleep : IEffect
    {
        /// <summary>
        /// Cantidad de turnos restantes durante los cuales el efecto de sueño estará activo.
        /// </summary>
        private int _turnsRemaining;

        /// <summary>
        /// Indica si el efecto de sueño ha expirado y ya no debe aplicarse.
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// Referencia al Pokémon que tiene el efecto de sueño aplicado.
        /// </summary>
        public Pokemon Pokemon { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia del efecto de sueño con la duración especificada y el Pokémon afectado.
        /// </summary>
        /// <param name="duration">La duración del efecto de sueño en turnos.</param>
        /// <param name="pokemon">El Pokémon al cual se aplicará el efecto de sueño.</param>
        public Sleep(int duration, Pokemon pokemon)
        {
            _turnsRemaining = duration;
            IsExpired = false;
            Pokemon = pokemon;
        }

        /// <summary>
        /// Actualiza el efecto de sueño en el Pokémon objetivo, reduciendo los turnos restantes.
        /// Cuando el efecto ha durado el número especificado de turnos, se elimina.
        /// </summary>
        /// <param name="target">El Pokémon al que se le aplicará el efecto de sueño.</param>
        public void UpdateEffect(Pokemon target)
        {
            if (_turnsRemaining > 0)
            {
                _turnsRemaining--;
            }
            else
            {
                RemoveEffect(Pokemon);
            }
        }

        /// <summary>
        /// Elimina el efecto de sueño del Pokémon, marcándolo como expirado.
        /// </summary>
        /// <param name="target">El Pokémon del que se removerá el efecto.</param>
        public void RemoveEffect(Pokemon target)
        {
            IsExpired = true;
        }
    }
}
