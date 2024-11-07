namespace Library;

public static class SelecPokemons
{
    private static List<Pokemon> list = [];

    public static void selecYourPokemon(Player player, List<Pokemon> Pokemons, IPrint print)
    {
        print.printList(Pokemons);
        while (list.Count < 6)
        {
            int num = print.printStringAndReceiveInt(
                $"{player} digite el número del Pokemon que desea seleccionar");
            Pokemon pokSelected = Pokemons[num - 1];
            if (Pokemons.Contains(pokSelected))
            {
                print.printString("Ya cuentas con ese Pokemons en tu lista");
            }
            else
            {
                list.Add(pokSelected);
                print.printString($"{player} se ha agregado a {pokSelected} a su lista de pokemones");
            }
        }
    }
}