// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Facade;
using Library.GameLogic.Entities;
using Library.Facade.Discord;

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
            ConsoleApp();
            // DiscordBot().GetAwaiter().GetResult();
        }

        private static void ConsoleApp()
        {
            List<Pokemon> pokemons = new List<Pokemon>
            {
                PokemonRegistry.GetPokemon("Pikachu"),
                PokemonRegistry.GetPokemon("Bulbasaur"),
                PokemonRegistry.GetPokemon("Charmander"),
                PokemonRegistry.GetPokemon("Squirtle"),
            };
            IExternalConnection connection = new ConsoleConnection();
            Game game = Game.CreateGame(pokemons, connection);
            game.PlayGameTurn();
        }

        private static async Task DiscordBot()
        {
            await BotLoader.LoadAsync();
        }
    }
}
