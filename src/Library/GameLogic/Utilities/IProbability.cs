// -----------------------------------------------------------------------
// <copyright file="IProbability.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Utilities;

/// <summary>
/// Define la utiliziacion de la probabilidad que vayamos a utiliziar en nuestro codigo. Eligiendo entre un metodo que nos retorna
/// una bool para el critico o un int para especificar un numero de turnos.
/// </summary>
public interface IProbability
{
    /// <summary>
    /// Esta logica nos ayuda a resolver el porcentaje de probabilidad de un ataque.
    /// </summary>
    /// <returns>
    /// Nos devuelve si el pokemon pudo dar un ataque critico.
    /// </returns>
    /// <param name="porcentaje"> Porcentaje de probabilidad de retornar un booleano.</param>
    public bool Chance(int porcentaje);

    /// <summary>
    /// Esta logica nos da el numero de turnos que el efecto perdurara.
    /// </summary>
    /// <returns>
    /// Nos retorna el numero de turnos.
    /// </returns>
    /// <param name="liminferior"> Minimo numero que podria tocar. </param>
    /// <param name="limsuperior"> Maximo numero que podria tocar. </param>
    public int Number(int liminferior, int limsuperior);
}