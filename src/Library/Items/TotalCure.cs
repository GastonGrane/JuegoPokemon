namespace Library.Items;

public class TotalCure : IItem
{
    public void Use(Pokemon pokemon, Player player)
    {
        if(player.Pokemons.Contains(pokemon))
        {
            
        }
        else
        {
            PrintConsole.printString("Debde de Sanar un pokemon de su equipo");
        }
    }
}