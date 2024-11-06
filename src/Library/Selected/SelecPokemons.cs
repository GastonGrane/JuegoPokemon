namespace Library;

public static class SelecPokemons
{
    private static List<Pokemon> list = [];

    public static void selecYourPokemon(Player player, List<Pokemon> Pokemons, IPrint print)
    {
        while (list.Count < 6)
        {
            int num = print.PrintStringAndReceiveInt(
                $"{player} digite el número del Pokemon que desea seleccionar");
            Pokemon pokSelected = Pokemons[num - 1];
            if (Pokemons.Contains(pokSelected))
            {
                print.PrintString("Ya cuentas con ese Pokemons en tu lista");
            }
            else
            {
                list.Add(pokSelected);
                print.PrintString($"{player} se ha agregado a {pokSelected} a su lista de pokemones");
            }
        }
    }
}
