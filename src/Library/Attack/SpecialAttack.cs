namespace Library;

public enum SpecialType
{
}

public class SpecialAttack : Attack
{
    SpecialType SpecialAttackType { get; }

    public SpecialAttack(string name, int damage, PokemonType attackType, SpecialType specialType) : base(name, damage, attackType)
    {
        this.SpecialAttackType = specialType;
    }
}
