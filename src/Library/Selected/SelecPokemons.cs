// -----------------------------------------------------------------------
// <copyright file="SelecPokemons.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Nota de Guzmán: No sé qué es esto.
/// </summary>
public static class SelectPokemons
{
    private static List<Pokemon> list = [];

    /// <summary>
    /// Nota de Guzmán: No sé qué es esto.
    /// </summary>
    /// <param name="player">Un jugador.</param>
    /// <param name="pokemons">Algunos Pokemon.</param>
    /// <param name="printer">Un printer.</param>
    /// <exception cref="ArgumentNullException">
    /// Si algún parámetro es <c>null</c>.
    /// </exception>
    public static void SelectYourPokemon(Player player, List<Pokemon> pokemons, IPrinter printer)
    {
        ArgumentNullException.ThrowIfNull(pokemons, nameof(pokemons));
        ArgumentNullException.ThrowIfNull(printer, nameof(printer));
        while (list.Count < 6)
        {
            int num = printer.PrintStringAndReceiveInt(
                $"{player} digite el número del Pokemon que desea seleccionar");
            Pokemon pokSelected = pokemons[num - 1];
            if (pokemons.Contains(pokSelected))
            {
                printer.PrintString("Ya cuentas con ese Pokemons en tu lista");
            }
            else
            {
                list.Add(pokSelected);
                printer.PrintString($"{player} se ha agregado a {pokSelected} a su lista de pokemones");
            }
        }
    }
}
