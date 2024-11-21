// -----------------------------------------------------------------------
// <copyright file="IExternalConnection.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;

using Library.GameLogic.Entities;
using Library.GameLogic.Players;

namespace Library.Facade;

/// <summary>
/// Representa la comunicación a un servicio externo.
/// Permite imprimir texto, y pedirlo al usuario una selección.
/// </summary>
/// <remarks>
/// Esta interfaz cumple con OCP "Open-Closed Principle" si se neccesita cambiar como se imprime la informcacio, se puede
/// crear nuevas implementacion sin modificar la interzas original.
/// Tambien cumple con DIP "Dependency Inversion Principle" al abstraer la funcionalidad de la impresion y permitir que
/// las clases de alto nivel (como la interacción con el usuario) dependan de la interfaz en lugar de depender de una
/// implemntacion contreta. Esto nos da en el codigo una mayor flexibilidad y descaoplamiento.
/// La interfaz aplica multiples metodos, sin embargo estan todos relacionados con la impresdion, lo que
/// mantiene una alta cohesion en la misma.
/// La interfaz cumple tambien con SRP "Single Responsability Principle" ya que encapsula el tema de "Comunicarse con el
/// usuario", y esta al tener solo un unico proposito tambien tiene solo una razon de cambio, que querramos cambiar como
/// se habla con el usuario, y gracias a esto generamos un bajo acomplamiento.
/// Por supuesto, esta interfaz también hace uso de LSP, ya que una implementación debe cumplir con el contrato de la interfaz,
/// y una vez esto se logra esta implementación se puede utilizar donde sea que se necesita esta interfaz, logrando más flexibilidad.
/// </remarks>
public interface IExternalConnection
{
    /// <summary>
    /// Imprime la string pasada al servicio.
    /// </summary>
    /// <param name="str">La string a imprimir.</param>
    public void PrintString(string str);

    /// <summary>
    /// Imprime el mensaje de bienvenida a ambos usuarios.
    /// </summary>
    /// <param name="p1">El primer jugador.</param>
    /// <param name="p2">El segundo jugador.</param>
    public void PrintWelcome(Player p1, Player p2);

    /// <summary>
    /// Imprime el mensaje de victoria para el primer jugador. Además, debería indicar que terminó la partida, y hacer algo al respecto.
    /// </summary>
    /// <param name="p1">El jugador ganador.</param>
    /// <param name="p2">El jugador perdedor.</param>
    public void PrintPlayerWon(Player p1, Player p2);

    /// <summary>
    /// Imprime la indicación del comienzo del turno del jugador 1.
    /// </summary>
    /// <param name="player">El jugador cuyo turno es.</param>
    public void PrintTurnHeading(Player player);

    /// <summary>
    /// Le imprime las opciones recibidas, y le permite eligir una opción al usuario mediante un número o el nombre de la opción.
    /// Si la opción ingresada fue inválida, este método deberá reintentar hasta lograr una entrada correcta.
    /// </summary>
    /// <param name="selectionText">El texto a mostrar para contextualizar las opciones. El texto se muestra antes de las mismas.</param>
    /// <param name="options">Los elementos que se pueden elegir del menú.</param>
    /// <returns>
    /// El índice, relativo al array <paramref name="options"/> de la opción elegida.
    /// </returns>
    public int ShowMenuAndReceiveInput(string selectionText, ReadOnlyCollection<string> options);

    /// <summary>
    /// Le imprime la lista de ataques del pokemon recibido, y le permite eligir una opción al usuario mediante un número o el nombre del ataque.
    /// Si la opción ingresada fue inválida, este método deberá reintentar hasta lograr una entrada correcta.
    /// </summary>
    /// <param name="pokemon">El pokemon cuyos ataques se elegirán.</param>
    /// <returns>
    /// El nombre del ataque que eligió el usuario, o <c>null</c> si el usuario se arrepintió y quiso volver atrás.
    /// </returns>
    public string? ShowAttacksAndRecieveInput(Pokemon pokemon);

    /// <summary>
    /// Le muestra al usuario la lista de Pokemon, y le permite elegir uno. Además, le indica una opción para arrepentirse y no cambiar de Pokémon.
    /// </summary>
    /// <param name="player">El jugador que quiere cambiar de Pokemon.</param>
    /// <returns>
    /// El índice en la lista de Pokemon del Pokemon que se eligió. <c>0</c>indica que el usuario quiere volver.
    /// </returns>
    public int ShowChangePokemonMenu(Player player);

    /// <summary>
    /// Le muestra al usuario el resultado que tuvo su ataque.
    /// </summary>
    /// <param name="oldHP">La vida del pokemon de <paramref name="defender"/> antes de ser atacado.</param>
    /// <param name="attacker">El jugador que atacó.</param>
    /// <param name="defender">El jugador que fue atacado.</param>
    public void ReportAttackResult(int oldHP, Player attacker, Player defender);
}
