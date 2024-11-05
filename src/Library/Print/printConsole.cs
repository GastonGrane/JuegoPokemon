namespace Library;

public class PrintConsole : IPrint
{
    public static void printList(List<Pokemon> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1} : {list[i].Name}");
        }
    }

    public static void printString(string str)
    {
        Console.WriteLine(str);
    }

    public static int printStringAndReceiveInt(string str)
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
    public static void PrintListAtaque(List<Attack> ataques)
    {
        Console.WriteLine("Ataques disponibles:");
        for (int i = 0; i < ataques.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ataques[i].Name} (Daño: {ataques[i].Damage})");
        }
        Console.WriteLine();
    }

    public static int SelectAtaque(string str)
    {
   
        int eleccion = printStringAndReceiveInt(str);
        bool control =true;

        while (control)
        {
            return eleccion;
            control = false;
        }

        return eleccion - 1; // Ajustar índice para la lista
    }
}