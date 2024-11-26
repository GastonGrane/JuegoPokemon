// -----------------------------------------------------------------------
// <copyright file="PokemonTypeTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Entities;

namespace Library.Tests.GameLogic;

/// <summary>
/// Tests de la clase <see cref="PokemonType"/>.
/// </summary>
internal sealed class PokemonTypeTests
{
    /// <summary>
    /// Testea que todos los valores de <see cref="PokemonType"/> tengan un
    /// valor correcto de ventaja sobre todos los valores
    /// de <see cref="PokemonType"/>.
    /// </summary>
    [Test]
    public void AllCombinationsOfElementsAreValid()
    {
        foreach (var v1 in Enum.GetValues<PokemonType>())
        {
            foreach (var v2 in Enum.GetValues<PokemonType>())
            {
                Assert.That(v1.Advantage(v2), Is.AnyOf([0.0, 0.5, 1.0, 2.0]), $"{v1} no tuvo ventaja sobre {v2}");
            }
        }
    }

    /// <summary>
    /// Si se pide la ventaja de un valor invailido hay una excepcion.
    /// </summary>
    [Test]
    public void InvalidElementThrowsException()
    {
        PokemonType val1 = (PokemonType)100;
        PokemonType val2 = PokemonType.Dragon;

        bool exceprionThrown = false;
        try
        {
            val1.Advantage(val2);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceprionThrown = true;
        }

        Assert.True(exceprionThrown, "No hubo excepcion al calcular la ventaja de valor invalido");
    }
}
