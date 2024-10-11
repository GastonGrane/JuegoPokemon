namespace DefaultNamespace
{
    public interface IPokemon
    {
        string Name { get; set; }
        Element Element { get; set; }
        double Health { get; set; }
        double MaxHealth { get; set; }
        List<Attack> Attacks { get; set; }
        
        void AttackToPokemon(Attack attackName, IPokemon target);
    }
}
