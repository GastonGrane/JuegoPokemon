// -----------------------------------------------------------------------
// <copyright file="ConsolePrinter.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

public class ConsolePrinter : IPrinter
{
    public void PrintList(List<Pokemon> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1} : {list[i].Name}");
        }
    }

    public void PrintString(string str)
    {
        Console.WriteLine(str);
    }

    public int PrintStringAndReceiveInt(string str)
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
        int eleccion = this.PrintStringAndReceiveInt(str);
        bool control = true;

        while (control)
        {
            return eleccion;
            control = false;
        }

        return eleccion - 1; // Ajustar índice para la lista
    }
}
