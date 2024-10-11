namespace DefaultNamespace
{
    public interface IPokemon
    {
        string Name { get; set; }
        Element Element { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        List<Attack> Attacks { get; set; }
        
        void Attack(IPokemon target, string attackName);
    }
}
