using Library.Items;

namespace Library.Tests;

/// <summary>
/// Testeamos los Items.
/// </summary>
public class ItemsTest
{
    /// <summary>
    /// Testeamos si el metodo Revive, lo revive con el 50 de HP.
    /// </summary>
    [Test]
    public void CanRevive()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackLibrary.AquaJet,
            NormalAttackLibrary.BlazeKick,
            NormalAttackLibrary.BulletSeed,
        };
        List<Pokemon> pokemon = new List<Pokemon>();

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 0, attacks);
        pokemon.Add(p1);

        // Revive no tendria que ser static??
        Revive revive = new Revive();
        revive.Use(p1);

        Assert.That(p1.Health, Is.EqualTo(50));
    }

    /// <summary>
    /// Testeamos que falle el hecho de que pasemos como parametro algo null.
    /// </summary>
    [Test]
    public void PasarUnParametroNullFalla()
    {
        List<Attack> attacks = new List<Attack>
        {
            NormalAttackLibrary.AquaJet,
            NormalAttackLibrary.BlazeKick,
            NormalAttackLibrary.BulletSeed,
        };
        List<Pokemon> pokemon = new List<Pokemon>();

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 0, attacks);
        pokemon.Add(p1);

        // Revive no tendria que ser static??
        Revive revive = new Revive();
        revive.Use(p1);

        Assert.That(p1.Health, Is.EqualTo(50));

        bool exceptionThrown = false;
        try
        {
            revive.Use(null);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        Assert.True(exceptionThrown, "Curar a un pokemon inexistente no tiro una excepcion");
    }
}