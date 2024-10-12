namespace DefaultNamespace;
{
public class Game
{
    public List<IPokemon> ListaPokemons;
    public bool InGame;
    public Player PlayerOne;
    public Player PlayerTwo;

    public Game(List<IPokemon> ListaPokemons)
    {
        this.ListaPokemons = ListaPokemons;
    }

    public void Play()
    {
        this.InGame = true;
        while (InGame == true)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(" COMIENZA EL JUEGO ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"{PlayerOne.Name} es tu turno de jugar\nSeleccione la opcion:\n1-ATACAR\n2-CAMBIAR DE POKEMON\n");
            int selecPOne = int.Parse(Console.ReadLine());
            if (selecPOne == 1)
            {
                PlayerOne.ActivePokemon.AttackToPokemon(PlayerOne.ActivePokemon.Attacks[0].Name, PlayerTwo.ActivePokemon);
                if (PlayerTwo.ActivePokemon.Health == 0)
                {
                    Console.WriteLine($"{PlayerTwo} su pokemon ha muerto, continua el juego con otro Pokemon");
                    PlayerOne.ChangePokemon();
                }
            }
            else if (selecPOne == 2)
            {
                Console.WriteLine("Inserte el nombre del poquemon que desea utilizar:\n");
                string newPokemon = Console.ReadLine();
                PlayerOne.ChangePokemon(newPokemon);
                IPokemon? pokemon = PlayerOne.Pokemons.Find(pokemon => pokemon.Name == newPokemon);
                if (pokemon != null)
                {
                    PlayerOne.ChangePokemon(pokemon.Name);
                }
                else
                {
                    Console.WriteLine("La opcion seleccionada no es correcta, ha perdido su turno"); 
                }
            }
            else
            {
                Console.WriteLine("La opcion seleccionada no es correcta, ha perdido su turno");
            }
            Console.WriteLine($"{PlayerTwo.Name} es tu turno de jugar\nSeleccione la opcion:\n1-ATACAR\n2-CAMBIAR DE POKEMON\n");
            int selecPTwo = int.Parse(Console.ReadLine());
            if (selecPTwo == 1)
            {
                PlayerTwo.ActivePokemon.AttackToPokemon(PlayerTwo.ActivePokemon.Attacks[0].Name, PlayerOne.ActivePokemon);
            }
            else if (selecPTwo == 2)
            {
                Console.WriteLine("Inserte el nombre del poquemon que desea utilizar:\n");
                string newPokemon = Console.ReadLine();
                IPokemon? pokemon = PlayerTwo.Pokemons.Find(pokemon => pokemon.Name == newPokemon);
                if (pokemon != null)
                {
                    PlayerTwo.ChangePokemon(pokemon.Name);
                }
                else
                {
                    Console.WriteLine("La opcion seleccionada no es correcta, ha perdido su turno"); 
                }
            }
            else
            {
                Console.WriteLine("La opcion seleccionada no es correcta, ha perdido su turno");
            }

            foreach
            {
                
            }
        }
    }

    public void EndGame()
    {
        
    }

    public void SelecPokemon()
    {
        
    }

    public void createPlayer(string nameOne, string nameTwo, List<IPokemon> pokemonsPlayerOne, List<IPokemon> pokemonsPlayerTwo)
    {
        PlayerOne = new Player(nameOne, pokemonsPlayerOne);
        PlayerTwo = new Player(nameTwo, pokemonsPlayerTwo);
    }

    public string PrintMenssage()
    {
        
    }
}