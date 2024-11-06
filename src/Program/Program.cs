// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library;

namespace Program
{
    /// <summary>
    /// Clase principal que ejecuta el programa para crear y mostrar una lista de Pokémon en la consola.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Punto de entrada principal del programa.
        /// </summary>
        /// <param name="args">Argumentos de la línea de comandos.</param>
        public static void Main(string[] args)
        {
            PrintConsole printConsole = new PrintConsole();

            Pokemon pokemon1 = new Pokemon(
                "Pikachu",
                PokemonType.Electric,
                100,
                new List<Attack> { NormalAttack.FusionBolt });

            Pokemon pokemon2 = new Pokemon(
                "Bulbasaur",
                    PokemonType.Fire,
                    100,
                    new List<Attack> { NormalAttack.BulletSeed });

            Pokemon pokemon3 = new Pokemon(
                "Charmander",
                    PokemonType.Fire,
                    100,
                    new List<Attack> { NormalAttack.BlazeKick });

            Pokemon pokemon4 = new Pokemon(
                "Squirtle",
                    PokemonType.Water,
                    100,
                    new List<Attack> { NormalAttack.AquaJet });

            List<Pokemon> pokemons = new List<Pokemon>
            {
                pokemon1,
                pokemon2,
                pokemon3,
                pokemon4,
            };

            printConsole.PrintList(pokemons);
        }
    }
}
