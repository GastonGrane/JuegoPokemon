// -----------------------------------------------------------------------
// <copyright file="ConsolePrinter.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Globalization;

namespace Library;

/// <summary>
/// Un <see cref="IExternalConnection"/> que imprime/toma entrada de la consola.
/// </summary>
/// <remarks>
/// Cumple con SRP "Single Responsability Principle", ya que su unica responsabilidad es manejar la interaccion con la consola.
/// Cumple con LSP "Liskov Substitution Principle" ya que al implementar el contrato de la interfaz, se puede utilizar en cualquier lugar
/// que se utilize la interfaz, mantienendo el comportamiento esperado.
/// Cumple con DIP "Dependency Inversion Principle" debido a que clases de alto nivel dependen de la
/// interfaz IExternalConnection en lugar de depender de ConsoleConnection directamente. Esto permite que las clases de alto nivel
/// puedan funcionar sin estar acopladas a una implementación concreta.
/// </remarks>
public class ConsoleConnection : IExternalConnection
{
    /// <inheritdoc/>
    public void PrintWelcome(Player p1, Player p2)
    {
        Console.WriteLine("-------------------");
        Console.WriteLine(" COMIENZA EL JUEGO ");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Bienvenidos {p1.Name} y {p2.Name}");
    }

    /// <inheritdoc/>
    public void PrintPlayerWon(Player p1, Player p2)
    {
        Console.WriteLine($"El ganador de la partida es {p1.Name}");
    }

    /// <inheritdoc/>
    public void PrintTurnHeading(Player player)
    {
        Console.WriteLine($"Turno de {player}");
    }

    /// <inheritdoc/>
    public int ShowMenuAndReceiveInput(string selectionText, string[] inputs)
    {
        while (true)
        {
            Console.WriteLine(selectionText);
            int idx = 1;
            foreach (string line in inputs)
            {
                Console.WriteLine($"{idx}: {line}");
                idx++;
            }

            string input = Console.ReadLine()!;
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida, se esperaba un número entre 1 y 2");
            }

            if (selection != -1)
            {
                if (selection >= 1 && selection <= inputs.Length)
                {
                    return selection;
                }
                Console.WriteLine($"Valor inválido ingresado. Se esperaba un valor entre 1-{inputs.Length}");
                continue;
            }

            for (int i = 0; i < inputs.Length; ++i)
            {
                string line = inputs[i];
                // FIXME(Guzmán): Sensible o no a mayús.?
                if (input == line)
                {
                    return i;
                }
            }
            Console.WriteLine("Valor inválido ingresado, se esperaba un item del menú");
            continue;
        }
    }


    /// <inheritdoc/>
    public string? ShowAttacksAndRecieveInput(Pokemon p)
    {
        ReadOnlyCollection<Attack> attacks = p.Attacks;
        while (true)
        {
            Console.WriteLine("Seleccione un ataque");

            Console.WriteLine("0: Volver al menú anterior");
            int idx = 1;
            // FIXME(Guzmán): Esto sería algo como p.AttackAvailable, pero no está hecho eso.
            foreach (Attack attack in attacks)
            {
                Console.WriteLine($"{idx}: {attack.Name} ({attack.Type})");
                idx++;
            }

            string input = Console.ReadLine()!;
            int selection = -1;
            CultureInfo culture = new CultureInfo("en_US");
            try
            {
                selection = int.Parse(input, culture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida, se esperaba un número entre 1 y 2");
            }

            if (selection == 0) return null;

            if (selection != -1)
            {
                if (selection >= 1 && selection <= attacks.Count)
                {
                    return attacks[selection - 1].Name;
                }
                Console.WriteLine($"Valor inválido ingresado. Se esperaba un valor entre 1-{attacks.Count}");
                continue;
            }

            for (int i = 0; i < attacks.Count; ++i)
            {
                Attack attack = attacks[i];
                // FIXME(Guzmán): Sensible o no a mayús.?
                if (attack.Name == input)
                {
                    return input;
                }
            }
            Console.WriteLine("Valor inválido ingresado, se esperaba un item del menú");
            continue;
        }
    }
}
