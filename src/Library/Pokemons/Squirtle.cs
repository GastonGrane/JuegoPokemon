namespace Library;

public class Squirtle : IPokemon
{
    public string Name { get; set; }
    public PokemonType Type { get; set; }
    public double Health { get; set; }
    public double MaxHealth { get; set; }
    public List<Attack> Attacks { get; set; }

    public Squirtle()
    {
        this.Name = "Squirtle";
        this.Type = PokemonType.Water;
        this.Health = 100;
        this.MaxHealth = 100;
        this.Attacks = new List<Attack>
            {
                NormalAttack.AquaJet,
            };
    }
}
