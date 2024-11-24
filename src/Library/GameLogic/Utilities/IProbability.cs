// -----------------------------------------------------------------------
// <copyright file="IProbability.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Utilities;

/// <summary>
/// Una interfaz que representa una fuente de aleatoriedad.
/// Eligiendo entre un metodo que nos retorna <c>true</c> con cierta
/// probabilidad, y otro que retorna un numero aleatorio en un rango definido.
/// </summary>
public interface IProbability
{
    /// <summary>
    /// Este método que resuelve un porcentaje de probabilidad.
    /// </summary>
    /// <returns>
    /// Nos devuelve <c>true</c> con <paramref name="porcentaje"/> de probabilidad.
    /// </returns>
    /// <param name="porcentaje">Porcentaje de probabilidad de retornar un booleano.</param>
    public bool Chance(int porcentaje);

    /// <summary>
    /// Este método da un numero aleatorio entre un limite inferior y el limite superior.
    /// </summary>
    /// <returns>
    /// Un número aleatorio entre <paramref name="liminferior"/> y <paramref name="limsuperior"/>.
    /// Incluye el límite inferior pero no el superior.
    /// </returns>
    /// <param name="liminferior">Minimo numero que podria tocar.</param>
    /// <param name="limsuperior">Maximo numero que podria tocar.</param>
    public int Number(int liminferior, int limsuperior);
}
