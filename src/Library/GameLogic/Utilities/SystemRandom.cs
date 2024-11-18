// -----------------------------------------------------------------------
// <copyright file="AleatoriedadPrograma.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Effects;

namespace Library.GameLogic.Utilities;

/// <summary>
/// Clase que utilizamos para generar los numeros aleatorios en el programa principal, utilizando Random.
/// </summary>
/// <remarks>
/// Todas las clases que utilizan esto cumplen con el principio DIP debido a que pasan de depender de la clase <see cref="Random"/>
/// a depender de esta que es mas abstracta y permite cambiar como funciona la adquisicion denumeros aleatorios.
/// </remarks>
public class SystemRandom : IProbability
{
    /// <inheritdoc/>
    public bool Chance(int porcentaje)
    {
        int numero = new Random().Next(1, 101);

        return numero <= porcentaje;
    }

    /// <inheritdoc/>
    public int Number(int liminferior, int limsuperior)
    {
        return new Random().Next(liminferior, limsuperior);
    }
}