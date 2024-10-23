namespace Library;

public class Pikachu : Pokemon
{
    public Pikachu() : base("Pikachu", PokemonType.Electric, 100, new List<Attack>() { NormalAttack.FusionBolt })
    {
    }
}
