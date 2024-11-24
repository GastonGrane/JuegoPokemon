// -----------------------------------------------------------------------
// <copyright file="SystemRandom.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Effects;

namespace Library.GameLogic.Utilities;

/// <summary>
/// Implementación de <see cref="IProbability"/> que genera números aleatorios, utilizando <see cref="Random"/>.
/// </summary>
/// <remarks>
/// Todas las clases que utilizan esto cumplen con el principio DIP debido a que pasan de depender de la clase concreta <see cref="Random"/>
/// a depender de esta abstracción que permite cambiar cómo funciona la adquisición de números aleatorios.
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
