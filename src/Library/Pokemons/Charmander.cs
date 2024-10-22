namespace Library;

public class Charmander : IPokemon
{
    public string Name { get; set; }
    public PokemonType Type { get; set; }
    public double Health { get; set; }
    public double MaxHealth { get; set; }
    public List<Attack> Attacks { get; set; }

    public Charmander()
    {
        this.Name = "Charmander";
        this.Type = PokemonType.Fire;
        this.Health = 100;
        this.MaxHealth = 100;
        this.Attacks = new List<Attack>()
            {
                NormalAttack.BlazeKick
            };
    }
}
