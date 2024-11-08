namespace Library;

public enum SpecialType
{
    None,
}

public class SpecialAttack : Attack
{
    SpecialType SpecialAttackType { get; }

    public SpecialAttack(string name, int damage, PokemonType attackType, SpecialType specialType, int precision) : base(name, damage, attackType, precision)
    {
        this.SpecialAttackType = specialType;
    }
}
