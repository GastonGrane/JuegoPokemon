namespace Library;

public abstract class Attack
{
    public string Name { get; }
    public int Damage { get; }
    public PokemonType Type { get; }

    protected Attack(string name, int damage, PokemonType type)
    {
        this.Name = name;
        this.Damage = damage;
        this.Type = type;
    }
}
