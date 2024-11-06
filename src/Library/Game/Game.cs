namespace Library;

public class Game
{
    private Player PlayerOne;
    private Player PlayerTwo;
    // FIXME: Esto es para suprimir las advertencias por no utilizar atributos de instancia en algunos métodos. Cuando se añada una "Message Gateway" esto se podría ir, porque se irían las advertencias para estos métodos.
    private int tmp;

    private Game(Player p1, Player p2)
    {
        this.PlayerOne = p1;
        this.PlayerTwo = p2;
    }

    public static Game createGame(List<Pokemon> Pokemon)
    {
        // Por ahora es hard-coded, porque es más importante jugar al juego, y no ver el proceso de crearlo
        Player p1 = new Player("Axel", new List<Pokemon>());
        Player p2 = new Player("Sharon", new List<Pokemon>());
        return new Game(p1, p2);
    }

    private void AttackPlayer(Player active, Player other)
    {
        tmp++;
        while (true)
        {
            Console.WriteLine("Ingrese el nombre del ataque para utilizar:");
            var attacks = active.ActivePokemon.Attacks;
            for (int i = 0; i < attacks.Count; ++i)
            {
                var attack = attacks[i];
                // Console.WriteLine($"{i + 1} - {attack.Name}");
                Console.WriteLine($"- {attack.Name}");
            }
            string attackName = Console.ReadLine()!;
            Console.WriteLine();

            // Esto es sucio, sí, pero no quiero hacer que Attack devuelva la vida o algo porque la verdad que es tarde y no tengo ganas
            // Es más, esto tendría que ser actualizado para ataques especiales, pero bueno
            double oldHP = other.ActivePokemon.Health;
            try
            {
                active.Attack(other, attackName);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("El nombre de ataque fue inválido, intente de nuevo");
                continue;
            }
            double newHP = other.ActivePokemon.Health;
            Console.WriteLine($"{active.ActivePokemon.Name} atacó a {other.ActivePokemon.Name}, haciéndole {oldHP - newHP} de daño, y dejándolo en {newHP}/{other.ActivePokemon.MaxHealth}");
            break;
        }
    }

    private void PlayTurn(Player active, Player other)
    {
        Console.WriteLine($"{active.Name} es su turno de jugar");
        int selection;
        while (true)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Cambiar de Pokemon");
            Console.WriteLine();

            string input = Console.ReadLine()!;
            Console.WriteLine();

            try
            {
                selection = int.Parse(input!);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida, se esperaba un número entre 1 y 2");
            }
        }
        switch (selection)
        {
            case 1:
                AttackPlayer(active, other);
                break;
            case 2:
                ChangePokemon(active);
                break;
        }
    }

    private void PlayTurnP1()
    {
        PlayTurn(PlayerOne, PlayerTwo);
    }

    private void PlayTurnP2()
    {
        PlayTurn(PlayerTwo, PlayerOne);
    }

    private void ChangePokemon(Player p)
    {
        tmp++;
        while (true)
        {
            Console.WriteLine("Ingrese el nombre del Pokemon para utilizar");
            for (int i = 0; i < p.Pokemons.Count; ++i)
            {
                var pokemon = p.Pokemons[i];
                // Console.WriteLine($"{i + 1} - {pokemon.Name}");
                Console.WriteLine($"- {pokemon.Name}");
            }
            string input = Console.ReadLine()!;
            if (!p.ChangePokemon(input))
            {
                Console.WriteLine("El nombre que ha ingresado no pertenece a ningún Pokemon suyo, intente de nuevo");
            }
            else
            {
                break;
            }
        }
    }

    private bool CheckDead(Player p)
    {
        if (p.IsDead())
        {
            return true;
        }

        if (p.ActivePokemon.Health == 0)
        {
            Console.WriteLine($"{p}, su Pokemon ha muerto, elija otro Pokemon para continuar el juego");
            ChangePokemon(p);
            return false;
        }

        return false;
    }

    public void Play()
    {
        Console.WriteLine("-------------------");
        Console.WriteLine(" COMIENZA EL JUEGO ");
        Console.WriteLine("-------------------");

        bool InGame = true;
        while (InGame)
        {
            // FIXME: Tengo entendido que Pokemon permite que ambos jugadores hagan movidas, y luego se selecciona quién ataca primero por su velocidad. Acá se juego siempre primero el turno del jugador uno, o hay otra manera de selección?
            PlayTurnP1();
            if (CheckDead(PlayerTwo))
            {
                Console.WriteLine($"{PlayerTwo.Name} todos sus Pokemon han muerto, y ha perdido. Pua pua");
                break;
            }
            PlayTurnP2();
            if (CheckDead(PlayerOne))
            {
                Console.WriteLine($"{PlayerOne.Name} todos sus Pokemon han muerto, y ha perdido. Pua pua");
                break;
            }
        }
    }
}
