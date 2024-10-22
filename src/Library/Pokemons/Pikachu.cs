namespace Library;

public class Pikachu : IPokemon
{
    public string Name { get; set; }
    public PokemonType Type { get; set; }
    public double Health { get; set; }
    public double MaxHealth { get; set; }
    public List<Attack> Attacks { get; set; }

    public Pikachu()
    {
        this.Name = "Pikachu";
        this.Type = PokemonType.Electric;
        this.Health = 100;
        this.MaxHealth = 100;
        this.Attacks = new List<Attack>()
            {
                new Attack("Trueno", 50)
            };
    }
}
