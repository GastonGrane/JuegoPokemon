using System.Net;

namespace Library.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void CanCalculateElement()
    {
        object Advantage(object fire, object water)
        {
            return 2.0;
        }
        
        Element Fuego = Element.Fire;
        Element Agua = Element.Water;
        Assert.That(2.0, Is.EqualTo(Advantage(Fuego, Agua)));
    }
}