namespace Library
{
    /// <summary>
    /// Representa un efecto de parálisis que puede ser aplicado a un Pokémon.
    /// Este efecto impide que el Pokémon objetivo ataque en algunos turnos mientras está activo.
    /// </summary>
    public class Paralysis : IEffect
    {
        /// <summary>
        /// Generador de números aleatorios para determinar si el Pokémon puede atacar.
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Referencia al Pokémon que tiene el efecto de parálisis aplicado.
        /// </summary>
        public Pokemon Pokemon { get; set; }

        /// <summary>
        /// Indica si el efecto de parálisis ha expirado y ya no debe aplicarse.
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia del efecto de parálisis con el estado activo en el Pokémon especificado.
        /// </summary>
        /// <param name="pokemon">El Pokémon al cual se aplicará el efecto de parálisis.</param>
        public Paralysis(Pokemon pokemon)
        {
            IsExpired = false;
            Pokemon = pokemon;
        }

        /// <summary>
        /// Actualiza el efecto de parálisis en el Pokémon objetivo.
        /// Determina aleatoriamente si el Pokémon puede atacar, con una probabilidad del 50%.
        /// </summary>
        /// <param name="target">El Pokémon al que se le aplicará el efecto de parálisis.</param>
        public void UpdateEffect(Pokemon target)
        {
            // Determina aleatoriamente si el Pokémon puede atacar
            target.CanAttack = random.Next(2) == 1; // 50% probabilidad de atacar o no
        }

        /// <summary>
        /// Elimina el efecto de parálisis del Pokémon, marcándolo como expirado y restaurando su capacidad de atacar.
        /// </summary>
        /// <param name="target">El Pokémon del que se removerá el efecto.</param>
        public void RemoveEffect(Pokemon target)
        {
            IsExpired = true;
            target.CanAttack = true; // Restaura la capacidad de atacar
        }
    }
}