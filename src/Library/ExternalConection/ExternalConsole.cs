// -----------------------------------------------------------------------
// <copyright file="ConsolePrinter.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Un IPrinter que imprime/toma entrada de la consola.
/// </summary>
public class ExternalConsole : IExternalConection
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
    /// <summary>
    /// El jugador selecciona los Pokemons que integraran su lista de Pokemons.
    /// </summary>
    /// <param name="player"></param>Jugador que seleccionara los Pokemons.
    /// <param name="Pokemons"></param>Lista de las opciones de Pokemons con los que cuenta el juego.
    public void SelecYourPokemon(Player player, List<Pokemon> Pokemons)
    {
        List<Pokemon> list = new List<Pokemon>();
        PrintList(Pokemons);
        while (list.Count < 6)
        {
            int num = PrintStringAndReceiveInt(
                $"{player} digite el número del Pokemon que desea seleccionar");
            Pokemon pokSelected = Pokemons[num - 1];
            if (list.Contains(pokSelected))
            {
                PrintString("Ya cuentas con ese Pokemon en tu lista");
            }
            else
            {
                list.Add(pokSelected);
                PrintString($"{pokSelected.Name} se ha agregado a la lista de {player}");
            }
        }
    }
    /// <summary>
    /// Retorna la vida actual del pokemon activo.
    /// </summary>
    /// <param name="active"></param>Pokemon con el que se encuentra juagndo el PLayer en ese turno.
    /// <returns></returns>
    public double AvailableLifePokemon(Pokemon active)
    {
        double life = active.Health;
        return life;
    }
    /// <summary>
    /// Muestra las vidas de los POkemones activos de ambos jugadores.
    /// </summary>
    /// <param name="active"></param>Pokemon activo del jugador correspondiente al turno actual.
    /// <param name="otherActive"></param>Pokemon activo del otro jugador.
    public void showLifeActivePokemons(Pokemon active, Pokemon otherActive)
    {
        double lifeActive = AvailableLifePokemon(active);
        double lifeOtherActive = AvailableLifePokemon(active);
        PrintString($"Tu Pokemon:{active.Name} tine una vida de {lifeActive}/100.");
        PrintString($"Tu adversario:{otherActive.Name} tine una vida de {lifeOtherActive}/100.");
    }
}