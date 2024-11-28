using Library.GameLogic.Attacks;
using Library.GameLogic.Entities;
using Library.GameLogic.Players;

namespace Library.Tests.GameLogic;

[TestFixture]
public class defensaTest
{
    [Test]
    public void ProbabilidadDeGanar()
    {
        List<NormalAttack> attacks = new List<NormalAttack>
        {
            AttackRegistry.GetNormalAttack("Aqua Jet"),
            AttackRegistry.GetNormalAttack("Blaze Kick"),
            AttackRegistry.GetNormalAttack("Bullet Seed"),
            AttackRegistry.GetNormalAttack("Toxic"),
        };
        List<Pokemon> pokemon = new List<Pokemon>();

        Pokemon p1 = new Pokemon("pokemon", PokemonType.Bug, 0, attacks);
        Pokemon p2 = new Pokemon("pokemon2", PokemonType.Bug, 10, attacks); // 10
        Pokemon p3 = new Pokemon("pokemon3", PokemonType.Bug, 20, attacks); // 20
        Pokemon p4 = new Pokemon("pokemon4", PokemonType.Bug, 40, attacks); // 30
        Pokemon p5 = new Pokemon("pokemon5", PokemonType.Bug, 10, attacks); // 40
        Pokemon p6 = new Pokemon("pokemon6", PokemonType.Bug, 0, attacks);

        pokemon.Add(p1);
        pokemon.Add(p2);
        pokemon.Add(p3);
        pokemon.Add(p4);
        pokemon.Add(p5);
        pokemon.Add(p6);

        Player player1 = new Player("Guzman", pokemon);
        Player player2 = new Player("Sharon", pokemon); // se utiliza un ataque para que el pokemon este afectado
        player2.ApplyItem(p5, "Super Potion"); // es decir que ya no son 7 items sino 6 (6*30/7 = 25)
        player1.Attack(player2, "Toxic"); // no se suman 10 porq esta afectado.
        Assert.IsTrue(player2.ProbabilidadDeGanar() == 65);
    }
}