namespace Library.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {

    }

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
