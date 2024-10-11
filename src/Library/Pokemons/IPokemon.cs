namespace DefaultNamespace;

public interface IPokemon
{
    public string Name { get; set; }
    public IElement Element;
    public int Health;
    public int MaxHealth;
    public Attacks[] attacks;
    
    void Attack(IPokemon target, Attacks ataq);
}