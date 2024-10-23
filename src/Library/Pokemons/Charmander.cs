namespace Library;

public class Charmander : Pokemon
{
    public Charmander() : base("Charmander", PokemonType.Fire, 100, new List<Attack>() { NormalAttack.BlazeKick })
    {
    }
}
