namespace DefaultNamespace;

public class Pikachu : IPokemon
{
    public string Name;
    public IElement Element;
    public int Health;
    public int MaxHealth;
    private readonly object IElement;
    public Attacks[] attacks;

    public  Pikachu()
    {
        this.Name = "Pikachu";
        this.IElement = typeof(Electrico);
        this.Health = 100;
        this.MaxHealth = 10;
    }

    public void Attack(IPokemon target)
    {
        Attack = 
    }
}