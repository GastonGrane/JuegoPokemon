using Library;

namespace Program;

class Program
{
    public static void Main(string[] args)
    {
        Pokemon pokemon1 = new Bulbasaur();
        Pokemon pokemon2 = new Pikachu();
        Pokemon pokemon3 = new Squirtle();
        List <Pokemon> Pokemons = new List<Pokemon>();
        Pokemons.Add(pokemon1);
        Pokemons.Add(pokemon2);
        Pokemons.Add(pokemon3);
        PrintConsole.printList(Pokemons);
    }
}


//Game game = Game.createGame([]);
//game.Play();