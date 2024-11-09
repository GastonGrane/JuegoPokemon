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
    /// <summary>
    /// El diccionario entre nombre de Pokemon y Pokemon. Lo devuelto al usuario será una copia de un elemento de este diccionario.
    /// </summary>
    /// <remarks>
    /// Estos son los primero 40 y algo, y algunos al final que quería poner porque eran piola.
    /// </remarks>
    // FIXME: Faltan los ataques
    private static readonly Dictionary<string, Pokemon> PokemonTemplates = new()
    {
        { "Pikachu", new Pokemon("Pikachu", PokemonType.Electric, 35, new List<Attack> { }) },

        { "Bulbasaur", new Pokemon("Bulbasaur", PokemonType.Grass, 45, new List<Attack> { }) },

        { "Ivysaur", new Pokemon("Ivysaur", PokemonType.Grass, 60, new List<Attack> { }) },

        { "Venusaur", new Pokemon("Venusaur", PokemonType.Grass, 80, new List<Attack> { }) },

        { "Charmander", new Pokemon("Charmander", PokemonType.Fire, 39, new List<Attack> { }) },

        { "Charmeleon", new Pokemon("Charmeleon", PokemonType.Fire, 58, new List<Attack> { }) },

        { "Charizard", new Pokemon("Charizard", PokemonType.Fire, 78, new List<Attack> { }) },

        { "Squirtle", new Pokemon("Squirtle", PokemonType.Water, 44, new List<Attack> { }) },

        { "Wartortle", new Pokemon("Wartortle", PokemonType.Water, 59, new List<Attack> { }) },

        { "Blastoise", new Pokemon("Blastoise", PokemonType.Water, 79, new List<Attack> { }) },

        { "Caterpie", new Pokemon("Caterpie", PokemonType.Bug, 45, new List<Attack> { }) },

        { "Metapod", new Pokemon("Metapod", PokemonType.Bug, 50, new List<Attack> { }) },

        { "Butterfree", new Pokemon("Butterfree", PokemonType.Bug, 60, new List<Attack> { }) },

        { "Weedle", new Pokemon("Weedle", PokemonType.Bug, 40, new List<Attack> { }) },

        { "Kakuna", new Pokemon("Kakuna", PokemonType.Bug, 45, new List<Attack> { }) },

        { "Beedrill", new Pokemon("Beedrill", PokemonType.Bug, 65, new List<Attack> { }) },

        { "Pidgey", new Pokemon("Pidgey", PokemonType.Bug, 40, new List<Attack> { }) },

        { "Pidgeotto", new Pokemon("Pidgeotto", PokemonType.Bug, 63, new List<Attack> { }) },

        { "Pidgeot", new Pokemon("Pidgeot", PokemonType.Bug, 83, new List<Attack> { }) },

        { "Rattata", new Pokemon("Rattata", PokemonType.Normal, 30, new List<Attack> { }) },

        { "Raticate", new Pokemon("Raticate", PokemonType.Normal, 55, new List<Attack> { }) },

        { "Spearow", new Pokemon("Spearow", PokemonType.Flying, 40, new List<Attack> { }) },

        { "Fearow", new Pokemon("Fearow", PokemonType.Flying, 65, new List<Attack> { }) },

        { "Ekans", new Pokemon("Ekans", PokemonType.Poison, 35, new List<Attack> { }) },

        { "Arbok", new Pokemon("Arbok", PokemonType.Poison, 60, new List<Attack> { }) },

        { "Raichu", new Pokemon("Raichu", PokemonType.Electric, 60, new List<Attack> { }) },

        { "Jigglypuff", new Pokemon("Jigglypuff", PokemonType.Normal, 115, new List<Attack> { }) },

        { "Wigglytuff", new Pokemon("Wigglytuff", PokemonType.Normal, 140, new List<Attack> { }) },

        { "Zubat", new Pokemon("Zubat", PokemonType.Poison, 40, new List<Attack> { }) },

        { "Golbat", new Pokemon("Golbat", PokemonType.Poison, 75, new List<Attack> { }) },

        { "Oddish", new Pokemon("Oddish", PokemonType.Grass, 45, new List<Attack> { }) },

        { "Gloom", new Pokemon("Gloom", PokemonType.Poison, 60, new List<Attack> { }) },

        { "Vileplume", new Pokemon("Vileplume", PokemonType.Poison, 75, new List<Attack> { }) },

        { "Paras", new Pokemon("Paras", PokemonType.Bug, 35, new List<Attack> { }) },

        { "Parasect", new Pokemon("Parasect", PokemonType.Bug, 60, new List<Attack> { }) },

        { "Venonat", new Pokemon("Venonat", PokemonType.Bug, 60, new List<Attack> { }) },

        { "Venomoth", new Pokemon("Venomoth", PokemonType.Bug, 70, new List<Attack> { }) },

        { "Diglett", new Pokemon("Diglett", PokemonType.Ground, 10, new List<Attack> { }) },

        { "Dugtrio", new Pokemon("Dugtrio", PokemonType.Ground, 35, new List<Attack> { }) },

        { "Meowth", new Pokemon("Meowth", PokemonType.Normal, 40, new List<Attack> { }) },

        { "Snorlax", new Pokemon("Snorlax", PokemonType.Normal, 160, new List<Attack> { }) },

        { "Articuno", new Pokemon("Articuno", PokemonType.Ice, 90, new List<Attack> { }) },

        { "Zapdos", new Pokemon("Zapdos", PokemonType.Electric, 90, new List<Attack> { }) },

        { "Moltres", new Pokemon("Moltres", PokemonType.Fire, 90, new List<Attack> { }) },

        { "Mewtwo", new Pokemon("Mewtwo", PokemonType.Psychic, 106, new List<Attack> { }) },

        { "Mew", new Pokemon("Mew", PokemonType.Bug, 100, new List<Attack> { }) },

        { "Dragonair", new Pokemon("Dragonair", PokemonType.Dragon, 61, new List<Attack> { }) },

        { "Dragonite", new Pokemon("Dragonite", PokemonType.Dragon, 91, new List<Attack> { }) },

        { "Geodude", new Pokemon("Geodude", PokemonType.Rock, 40, new List<Attack> { }) },
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
