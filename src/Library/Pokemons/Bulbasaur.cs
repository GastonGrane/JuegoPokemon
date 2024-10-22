namespace Library;

public class Bulbasaur : Pokemon
{
    public Bulbasaur() : base("Bulbasaur", PokemonType.Fire, 100, new List<Attack>() { NormalAttack.BulletSeed })
    {
    }
}
