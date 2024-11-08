using Library;

namespace Program;

class Program
{
    public static void Main(string[] args)
    {
        Pokemon pokemon1 = new Pokemon("Pikachu", PokemonType.Electric, 100,
            new List<Attack> { NormalAttack.FusionBolt });
        Pokemon pokemon2 = new Pokemon("Bulbasaur", PokemonType.Fire, 100,
            new List<Attack>() { NormalAttack.BulletSeed });
        Pokemon pokemon3 = new Pokemon("Charmander", PokemonType.Fire, 100,
            new List<Attack>() { NormalAttack.BlazeKick });
        Pokemon pokemon4 = new Pokemon("Squirtle", PokemonType.Water, 100,
            new List<Attack>() { NormalAttack.AquaJet, });
        List<Pokemon> Pokemons = new List<Pokemon>();
        Pokemons.Add(pokemon1);
        Pokemons.Add(pokemon2);
        Pokemons.Add(pokemon3);
        Pokemons.Add(pokemon4);
        //PrintConsole.printList(Pokemons);
    }
}


//Game game = Game.createGame([]);
//game.Play();