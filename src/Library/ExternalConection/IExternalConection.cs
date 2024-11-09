// -----------------------------------------------------------------------
// <copyright file="IPrinter.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Representa la comunicación a un servicio externo.
///
/// Permite imprimir texto, y pedirlo al usuario una selección.
/// </summary>
public interface IExternalConection
{
    /// <summary>
    /// Imprime la lista provista en el servicio.
    /// </summary>
    /// <param name="list">La lista a imprimir.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="list"/> es null.
    /// </exception>
    public void PrintList(List<Pokemon> list);

    /// <summary>
    /// Imprime la string provista en el servicio.
    /// </summary>
    /// <param name="str">La string a imprimir.</param>
    public void PrintString(string str);

    /// <summary>
    /// Imprime la string provista en el servicio, y luego le pide al
    /// usuario que ingrese un int.
    ///
    /// Si el usuario no ingresa un int, esta función deberá
    /// reintentar hasta que el dato ingresado sea un int.
    /// </summary>
    /// <param name="str">La string a imprimir.</param>
    /// <returns>El número ingresado por el usuario.</returns>
    public int PrintStringAndReceiveInt(string str);

    /// <summary>
    /// Imprime la lista de ataques provista en el servicio.
    /// </summary>
    /// <param name="ataques">La lista de <see cref="Attack"/>s a imprimir.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="ataques"/> es null.
    /// </exception>
    public void PrintListAtaque(List<Attack> ataques);

    /// <summary>
    /// Nota de Guzmán: No tengo ni la más pálida idea del propósito de esto.
    /// </summary>
    /// <param name="str">Ni idea.</param>
    /// <returns>Tampoco sé.</returns>
    public int SelectAtaque(string str);
    
    public void selecYourPokemon(Player player, List<Pokemon> Pokemons);
    public double AvailableLifePokemon(Pokemon active);
}
