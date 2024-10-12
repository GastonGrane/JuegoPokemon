namespace Library;

public interface IPokemon
{
    string Name { get; set; }
    Element Element { get; set; }
    double Health { get; set; }
    double MaxHealth { get; set; }
    List<Attack> Attacks { get; set; }

    public void AttackToPokemon(string attackName, IPokemon target)
    {
        Element defender = target.Element;
        Element attacker = this.Element;

        Attack? attack = this.Attacks.Find(attack => attack.Name == attackName);
        if (attack == null)
        {
            return;
        }


        double multiplier = Calculate.Advantage(attacker, defender);
        double damage = (attack.Damage * multiplier);
        target.Health -= damage;
        if (target.Health < 0)
        {
            target.Health = 0;
        }
    }
}
