// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Entities;

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
            List<Pokemon> pokemons = new List<Pokemon>
            {
                PokemonRegistry.GetPokemon("Pikachu"),
                PokemonRegistry.GetPokemon("Bulbasaur"),
                PokemonRegistry.GetPokemon("Charmander"),
                PokemonRegistry.GetPokemon("Squirtle"),
            };

            Console.WriteLine(PokemonRegistry.GetPokemon("Pikachu").Name);
        }
    }
}
