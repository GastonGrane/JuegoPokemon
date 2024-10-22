namespace Library;

public interface IPokemon
{
    string Name { get; set; }
    PokemonType Type { get; set; }
    double Health { get; set; }
    double MaxHealth { get; set; }
    List<Attack> Attacks { get; set; }

    public bool Attack(IPokemon target, string attackName)
    {
        // FIXME: Esto está mal, tendría que ser el elemento del ataque, pero la vida es muy corta para deliberar sobre los detalles
        PokemonType defender = target.Type;
        PokemonType attacker = this.Type;

        Attack? attack = this.Attacks.Find(attack => attack.Name == attackName);
        if (attack == null)
        {
            return false;
        }

        double multiplier = attacker.Advantage(defender);
        double damage = (attack.Damage * multiplier);
        target.Health -= damage;
        if (target.Health < 0)
        {
            target.Health = 0;
        }
        return true;
    }
}
