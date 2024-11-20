// -----------------------------------------------------------------------
// <copyright file="IProbability.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Utilities;

/// <summary>
/// Define la utiliziacion de la probabilidad que vayamos a utiliziar en nuestro codigo. Eligiendo entre un metodo que nos retorna
/// <c>true</c> con cierta probabilidad, y otro que retorna un numero aleatorio en un rango definido.
/// </summary>
public interface IProbability
{
    /// <summary>
    /// Esta logica nos ayuda a resolver un porcentaje de probabilidad.
    /// </summary>
    /// <returns>
    /// Nos devuelve <c>true</c> con <paramref name="porcentaje"/> de probabilidad.
    /// </returns>
    /// <param name="porcentaje"> Porcentaje de probabilidad de retornar un booleano.</param>
    public bool Chance(int porcentaje);

    /// <summary>
    /// Esta logica nos da un numero entre un limite inferior y el limite superior.
    /// </summary>
    /// <returns>
    /// Nos retorna el numero.
    /// </returns>
    /// <param name="liminferior"> Minimo numero que podria tocar. </param>
    /// <param name="limsuperior"> Maximo numero que podria tocar. </param>
    public int Number(int liminferior, int limsuperior);
}