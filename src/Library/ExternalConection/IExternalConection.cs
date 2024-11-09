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
    
    /// <summary>
    /// El jugador selecciona los Pokemons que integraran su lista de Pokemons.
    /// </summary>
    /// <param name="player"></param>Jugador que seleccionara los Pokemons.
    /// <param name="Pokemons"></param>Lista de las opciones de Pokemons con los que cuenta el juego.
    public void SelecYourPokemon(Player player, List<Pokemon> Pokemons);
    /// <summary>
    /// Retorna la vida actual del pokemon activo.
    /// </summary>
    /// <param name="active"></param>Pokemon con el que se encuentra juagndo el PLayer en ese turno.
    /// <returns></returns>
    public double AvailableLifePokemon(Pokemon active);
    /// <summary>
    /// Muestra las vidas de los POkemones activos de ambos jugadores.
    /// </summary>
    /// <param name="active"></param>Pokemon activo del jugador correspondiente al turno actual.
    /// <param name="otherActive"></param>Pokemon activo del otro jugador.
    public void showLifeActivePokemons(Pokemon active, Pokemon otherActive);
}
