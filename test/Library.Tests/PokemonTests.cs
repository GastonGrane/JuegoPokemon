namespace Library.Tests;

public class PokemonTests
{
    [Test]
    public void PokemonConMuchosAtaquesFalla()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttack.AquaJet,
            NormalAttack.BlazeKick,
            NormalAttack.BulletSeed,
            NormalAttack.FusionBolt,
            new NormalAttack("extra", 100, PokemonType.Bug),
        };
        
        bool exceptionThrown = false;
        try
        {
            Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionThrown = true;
        }
        Assert.True(exceptionThrown, "Crear el pokemon con demasiados ataques no tiro una excepcion");
    }

    [Test]
    public void PokemonCon3AtaquesSePuede()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttack.AquaJet,
            NormalAttack.BlazeKick,
            NormalAttack.BulletSeed,
        };

        Pokemon p = new Pokemon("pokemon", PokemonType.Bug, 100, attacks);
        Assert.That(p.Name, Is.EqualTo("pokemon"));
        Assert.That(p.Type, Is.EqualTo(PokemonType.Bug));
        Assert.That(p.Name, Is.EqualTo("pokemon"));

    }
}