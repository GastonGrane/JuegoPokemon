using System.ComponentModel.Design;

namespace Library.Items;

public class SuperPotions : IItem
{
    public void Use(Pokemon pokemon, Player player)
    {
        if(player.Pokemons.Contains(pokemon))
        {
            pokemon.Curar(70);
        }
        else
        {
            PrintConsole.printString("Debde de Curar un pokemon de su equipo");
        }
    }
}