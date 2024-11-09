// -----------------------------------------------------------------------
// <copyright file="PokemonRegistry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Colección de Pokémon pre-definidos.
/// </summary>
/// <remarks>
/// Se podría decir que es una implementación de <see href="https://refactoring.guru/design-patterns/prototype">Prototype</see>.
/// </remarks>
public static class PokemonRegistry
{
    private static readonly Dictionary<string, Pokemon> PokemonTemplates = new()
    {
        // href="/pokedex/pikachu"
        { "Pikachu", new Pokemon("Pikachu", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/bulbasaur"
        { "Bulbasaur", new Pokemon("Bulbasaur", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/ivysaur"
        { "Ivysaur", new Pokemon("Ivysaur", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/venusaur"
        { "Venusaur", new Pokemon("Venusaur", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/charmander"
        { "Charmander", new Pokemon("Charmander", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/charmeleon"
        { "Charmeleon", new Pokemon("Charmeleon", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/charizard"
        { "Charizard", new Pokemon("Charizard", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/squirtle"
        { "Squirtle", new Pokemon("Squirtle", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/wartortle"
        { "Wartortle", new Pokemon("Wartortle", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/blastoise"
        { "Blastoise", new Pokemon("Blastoise", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/caterpie"
        { "Caterpie", new Pokemon("Caterpie", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/metapod"
        { "Metapod", new Pokemon("Metapod", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/butterfree"
        { "Butterfree", new Pokemon("Butterfree", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/weedle"
        { "Weedle", new Pokemon("Weedle", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/kakuna"
        { "Kakuna", new Pokemon("Kakuna", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/beedrill"
        { "Beedrill", new Pokemon("Beedrill", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/pidgey"
        { "Pidgey", new Pokemon("Pidgey", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/pidgeotto"
        { "Pidgeotto", new Pokemon("Pidgeotto", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/pidgeot"
        { "Pidgeot", new Pokemon("Pidgeot", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/rattata"
        { "Rattata", new Pokemon("Rattata", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/raticate"
        { "Raticate", new Pokemon("Raticate", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/spearow"
        { "Spearow", new Pokemon("Spearow", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/fearow"
        { "Fearow", new Pokemon("Fearow", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/ekans"
        { "Ekans", new Pokemon("Ekans", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/arbok"
        { "Arbok", new Pokemon("Arbok", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/raichu"
        { "Raichu", new Pokemon("Raichu", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/jigglypuff"
        { "Jigglypuff", new Pokemon("Jigglypuff", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/wigglytuff"
        { "Wigglytuff", new Pokemon("Wigglytuff", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/zubat"
        { "Zubat", new Pokemon("Zubat", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/golbat"
        { "Golbat", new Pokemon("Golbat", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/oddish"
        { "Oddish", new Pokemon("Oddish", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/gloom"
        { "Gloom", new Pokemon("Gloom", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/vileplume"
        { "Vileplume", new Pokemon("Vileplume", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/paras"
        { "Paras", new Pokemon("Paras", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/parasect"
        { "Parasect", new Pokemon("Parasect", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/venonat"
        { "Venonat", new Pokemon("Venonat", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/venomoth"
        { "Venomoth", new Pokemon("Venomoth", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/diglett"
        { "Diglett", new Pokemon("Diglett", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/dugtrio"
        { "Dugtrio", new Pokemon("Dugtrio", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/meowth"
        { "Meowth", new Pokemon("Meowth", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/snorlax"
        { "Snorlax", new Pokemon("Snorlax", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/articuno"
        { "Articuno", new Pokemon("Articuno", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/zapdos"
        { "Zapdos", new Pokemon("Zapdos", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/moltres"
        { "Moltres", new Pokemon("Moltres", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/mewtwo"
        { "Mewtwo", new Pokemon("Mewtwo", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/mew"
        { "Mew", new Pokemon("Mew", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/dragonair"
        { "Dragonair", new Pokemon("Dragonair", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/dragonite"
        { "Dragonite", new Pokemon("Dragonite", PokemonType.Bug, 0, new List<Attack> { }) },

            // href="/pokedex/geodude"
        { "Geodude", new Pokemon("Geodude", PokemonType.Bug, 0, new List<Attack> { }) },
    };

    /// <summary>
    /// Retorna una copia del Pokémon cuyo nombre es <paramref name="name"/>, si se encuentra en el registro.
    /// </summary>
    /// <param name="name">El nombre del <see cref="Pokemon"/></param>
    /// <exception cref="KeyNotFoundException">
    /// Si el Pokémon no está en el registro.
    /// </exception>
    public static Pokemon GetPokemon(string name)
    {
        return PokemonTemplates[name];
    }
}
