// -----------------------------------------------------------------------
// <copyright file="ConsolePrinter.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Un IPrinter que imprime/toma entrada de la consola.
/// </summary>
/// <remarks>
/// Cumple con SRP "Single Responsability Principle", ya que su unica responsabilidad es manejar la interaccion con la consola.
/// Cumple con LSP "Liskov Substitution Principlee" ya que cualquier clase que implemente IPrinter, como en este caso
/// ConsolePrinter, puede ser reemplazada por otra implementación sin alterar el comportamiento esperado.
/// Cumple con DIP "Dependency Inversion Principle" debido a que clases de alto nivel dependen de la
/// interfaz IPrinter en lugar de depender de ConsolePrinter directamente. Esto permite que las clases de alto nivel
/// puedan funcionar sin estar acopladas a una implementación concreta.
/// </remarks>
public class ConsolePrinter : IPrinter
{
    /// <summary>
    /// Imprime la lista provista en la consola.
    /// </summary>
    /// <param name="list">La lista a imprimir.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="list"/> es null.
    /// </exception>
    public void PrintList(List<Pokemon> list)
    {
        ArgumentNullException.ThrowIfNull(list, nameof(list));
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1} : {list[i].Name}");
        }
    }

    /// <summary>
    /// Imprime la string provista en la consola.
    /// </summary>
    /// <param name="str">La string a imprimir.</param>
    public void PrintString(string str)
    {
        Console.WriteLine(str);
    }

    /// <summary>
    /// Imprime la string provista en la consola, y luego le pide al
    /// usuario que ingrese un int.
    ///
    /// Si el usuario no ingresa un int, esta función deberá
    /// reintentar hasta que el dato ingresado sea un int.
    /// </summary>
    /// <param name="str">La string a imprimir.</param>
    /// <returns>El número ingresado por el usuario.</returns>
    public int PrintStringAndReceiveInt(string str)
    {
        int number;
        while (true)
        {
            Console.WriteLine(str);
            string input = Console.ReadLine()!;
            if (int.TryParse(input, out number))
            {
                return number;
            }

            Console.WriteLine("ERROR: Por favor, ingresa un número válido.");
        }
    }

    /// <summary>
    /// Imprime la lista de ataques provista en la consola.
    /// </summary>
    /// <param name="ataques">La lista de <see cref="Attack"/>s a imprimir.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="ataques"/> es null.
    /// </exception>
    public void PrintListAtaque(List<Attack> ataques)
    {
        ArgumentNullException.ThrowIfNull(ataques, nameof(ataques));
        Console.WriteLine("Ataques disponibles:");
        for (int i = 0; i < ataques.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ataques[i].Name} (Daño: {ataques[i].Damage})");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Nota de Guzmán: No tengo ni la más pálida idea del propósito de esto.
    /// </summary>
    /// <param name="str">Ni idea.</param>
    /// <returns>Tampoco sé.</returns>
    public int SelectAtaque(string str)
    {
        int eleccion = this.PrintStringAndReceiveInt(str);
        bool control = true;

        while (control)
        {
            control = false;
            return eleccion;
        }

        return eleccion - 1; // Ajustar índice para la lista
    }
}