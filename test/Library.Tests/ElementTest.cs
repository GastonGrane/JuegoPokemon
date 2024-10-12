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
        foreach (var v1 in Enum.GetValues<Element>())
        {
            foreach (var v2 in Enum.GetValues<Element>())
            {
                Assert.That(v1.Advantage(v2), Is.AnyOf([0.0, 0.5, 1.0, 2.0]));
                Assert.That(v1.Advantage(v2), Is.AnyOf([0.0, 0.5, 1.0, 2.0]));
            }
        }

    }
}
