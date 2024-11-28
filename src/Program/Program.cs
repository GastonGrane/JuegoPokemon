// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Facade;
using Library.Facade.Discord;
using Library.GameLogic.Entities;
using Library.GameLogic.Players;

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

                Player p1 = new Player(
                    "Axel",
                    new List<Pokemon>
                    {
                        PokemonRegistry.GetPokemon("Pikachu"), PokemonRegistry.GetPokemon("Ivysaur"),
                        PokemonRegistry.GetPokemon("Metapod"), PokemonRegistry.GetPokemon("Charmander"),
                    });
                Player p2 = new Player(
                    "Sharon",
                    new List<Pokemon>
                    {
                        PokemonRegistry.GetPokemon("Mewtwo"), PokemonRegistry.GetPokemon("Golbat"),
                        PokemonRegistry.GetPokemon("Charmeleon"), PokemonRegistry.GetPokemon("Oddish"),
                    });

                IExternalConnection connection = new ConsoleConnection();
                Game game = new Game(p1, p2, connection);
                game.Play();
            }
        }
    }
