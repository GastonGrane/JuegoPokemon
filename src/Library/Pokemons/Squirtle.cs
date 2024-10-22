namespace Library;

public class Squirtle : Pokemon
{
    public Squirtle() : base("Squirtle", PokemonType.Water, 100, new List<Attack> { NormalAttack.AquaJet, })
    { }
}
