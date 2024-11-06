using Library;

namespace Program
{
    /// <summary>
    /// Clase principal que ejecuta el programa para crear y mostrar una lista de Pokémon en la consola.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Punto de entrada principal del programa.
        /// </summary>
        /// <param name="args">Argumentos de la línea de comandos.</param>
        public static void Main(string[] args)
        {
            PrintConsole printConsole = new PrintConsole();

            /// <summary>
            /// Crea una instancia de Pikachu, un Pokémon de tipo Eléctrico, con 100 puntos de vida
            /// y el ataque FusionBolt.
            /// </summary>
            Pokemon pokemon1 = new Pokemon("Pikachu", PokemonType.Electric, 100,
                new List<Attack> { NormalAttack.FusionBolt });

            /// <summary>
            /// Crea una instancia de Bulbasaur, un Pokémon de tipo Fuego, con 100 puntos de vida
            /// y el ataque BulletSeed.
            /// </summary>
            Pokemon pokemon2 = new Pokemon("Bulbasaur", PokemonType.Fire, 100,
                new List<Attack> { NormalAttack.BulletSeed });

            /// <summary>
            /// Crea una instancia de Charmander, un Pokémon de tipo Fuego, con 100 puntos de vida
            /// y el ataque BlazeKick.
            /// </summary>
            Pokemon pokemon3 = new Pokemon("Charmander", PokemonType.Fire, 100,
                new List<Attack> { NormalAttack.BlazeKick });

            /// <summary>
            /// Crea una instancia de Squirtle, un Pokémon de tipo Agua, con 100 puntos de vida
            /// y el ataque AquaJet.
            /// </summary>
            Pokemon pokemon4 = new Pokemon("Squirtle", PokemonType.Water, 100,
                new List<Attack> { NormalAttack.AquaJet });

            /// <summary>
            /// Lista de Pokémon creados para ser mostrados en la consola.
            /// </summary>
            List<Pokemon> Pokemons = new List<Pokemon>
            {
                pokemon1,
                pokemon2,
                pokemon3,
                pokemon4
            };

            /// <summary>
            /// Imprime la lista de Pokémon en la consola usando el método printList de la clase PrintConsole.
            /// </summary>
            printConsole.printList(Pokemons);
        }
    }
}
