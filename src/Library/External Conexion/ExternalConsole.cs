namespace Library;

public class ExternalConsole : IExternalConection
{
    public void printList(List<Pokemon> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1} : {list[i].Name}");
        }
    }
    public void printString(string str)
    {
        Console.WriteLine(str);
    }

    public int printStringAndReceiveInt(string str)
    {
        int number;
        while (true)
        {
            Console.WriteLine(str);
            string input = Console.ReadLine();
            if (int.TryParse(input, out number))
            {
                return number;
            }

            Console.WriteLine("ERROR: Por favor, ingresa un número válido.");
        }
    }

    public void PrintListAtaque(List<Attack> ataques)
    {
        Console.WriteLine("Ataques disponibles:");
        for (int i = 0; i < ataques.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ataques[i].Name} (Daño: {ataques[i].Damage})");
        }

        Console.WriteLine();
    }

    public int SelectAtaque(string str)
    {
        int eleccion = printStringAndReceiveInt(str);
        return eleccion - 1; // Ajustar índice para la lista
    }

    public void selecYourPokemon(Player player, List<Pokemon> Pokemons)
    {
        List<Pokemon> list = new List<Pokemon>();
        printList(Pokemons);
        while (list.Count < 6)
        {
            int num = printStringAndReceiveInt(
                $"{player} digite el número del Pokemon que desea seleccionar");
            Pokemon pokSelected = Pokemons[num - 1];
            if (list.Contains(pokSelected))
            {
                printString("Ya cuentas con ese Pokemon en tu lista");
            }
            else
            {
                list.Add(pokSelected);
                printString($"{pokSelected.Name} se ha agregado a la lista de {player}");
            }
        }
    }

    public void availableAttack(Player active, Player other, int turno)
    {
        active.ActivePokemon.upDateAvailableAttacks();
            var avaiAttacks = active.ActivePokemon.AvailableAttacks;
            var LastAttacks = active.ActivePokemon.LastAttacksUsed;

            foreach (var tuple in LastAttacks)
            {
                int i = tuple.contador;
                if ((i + 2) == turno)
                {
                    active.ActivePokemon.LastAttacksUsed.Remove(tuple);
                }
            }
            
            Console.WriteLine("Ingrese el nombre del ataque para utilizar:");
            for (int i = 0; i < avaiAttacks.Count; ++i)
            {
                var attack = avaiAttacks[i];
                // Console.WriteLine($"{i + 1} - {attack.Name}");
                Console.WriteLine($"- {attack.Name}");

            }
            
            string attackName = Console.ReadLine()!;
            foreach (Attack attack in avaiAttacks)
            {
                if ((attack.Name == attackName) && (attack is SpecialAttack))
                {
                    active.ActivePokemon.LastAttacksUsed.Add((attack, turno));
                }
            }

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
            }

            double newHP = other.ActivePokemon.Health;
            Console.WriteLine(
                $"{active.ActivePokemon.Name} atacó a {other.ActivePokemon.Name}, haciéndole {oldHP - newHP} de daño, y dejándolo en {newHP}/{other.ActivePokemon.MaxHealth}");
    }
}
