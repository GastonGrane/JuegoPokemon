// -----------------------------------------------------------------------
// <copyright file="ElementTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Tests;

internal sealed class Tests
{
    [Test]
    public void AllCombinationsOfElementsAreValid()
    {
        foreach (var v1 in Enum.GetValues<PokemonType>())
        {
            foreach (var v2 in Enum.GetValues<PokemonType>())
            {
                Assert.That(v1.Advantage(v2), Is.AnyOf([0.0, 0.5, 1.0, 2.0]), $"{v1} no tuve ventaja sobre {v2}");
            }
        }
    }
}
