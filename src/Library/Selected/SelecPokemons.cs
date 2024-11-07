// -----------------------------------------------------------------------
// <copyright file="SelecPokemons.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

public static class SelecPokemons
{
    private static List<Pokemon> list = [];

    public static void SelecYourPokemon(Player player, List<Pokemon> pokemons, IPrinter printer)
    {
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
