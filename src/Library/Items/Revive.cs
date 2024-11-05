namespace Library.Items;

public class Revive : IItem
{
    public void Use(Pokemon pokemon, Player player)
    {
        if(player.Pokemons.Contains(pokemon))
        {
            if (pokemon.Health == 0)
            {
                pokemon.Curar(50);
            }
            else
            {
                PrintConsole.printString("No puede revivir un Pokemon con vida");
            }
        }
        else
        {
            PrintConsole.printString("Debde de Curar un pokemon de su equipo");
        }
    }
}