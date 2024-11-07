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
public interface IPrinter
{

    /// <summary>
    /// Imprime la lista provista en el servicio
    /// </summary>
    /// <param name="list">La lista a imprimir.</param>
    public void PrintList(List<Pokemon> list);

    /// <summary>
    /// Imprime la string provista en el servicio
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
    public void PrintListAtaque(List<Attack> ataques);

    public int SelectAtaque(string str);
}
