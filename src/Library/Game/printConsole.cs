namespace Library;

public static class PrintConsole
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
}