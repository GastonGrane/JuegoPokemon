// -----------------------------------------------------------------------
// <copyright file="IPrinter.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Representa la comunicación a un servicio externo.
/// Permite imprimir texto, y pedirlo al usuario una selección.
/// </summary>
/// <remarks>
/// Esta interfaz cumple con OCP "Open-Closed Principle" si se neccesita cambiar como se imprime la informcacio, se puede
/// crear nuevas implementacion sin modificar la interzas original.
/// Tambien cumple con DIP "Dependency Inversion Principle" al abstraer la funcionalidad de la impresion y permitir que
/// las clases de alto nivel (como la interaccion con el usuario) dependan de la interfaz en lugar de depender de una
/// implemntacion contreta. Esto nos da en el codigo una mayor flexibilidad y descaoplamiento.
/// La interfaz aplica multiples metodos, sin embargo estan todos relacionados con la impresdion, lo que
/// mantiene una alta cohesion en la misma.
/// La interfaz cumple tambien con SRP "Single Responsability Principle" ya que encapsula el tema de "Comunicarse con el
/// usuario", y esta al tener solo un unico proposito tambien tiene solo una razon de cambio, que querramos cambiar como
/// se habla con el usuario, y gracias a esto generamos un bajo acomplamiento.
/// </remarks>
public interface IPrinter
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
}
