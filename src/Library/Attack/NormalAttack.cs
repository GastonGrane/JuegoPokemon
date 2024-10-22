namespace Library;

public class NormalAttack : Attack
{
    public static NormalAttack AquaJet = new NormalAttack("Aqua Jet", 40, PokemonType.Water);

    public static NormalAttack BulletSeed = new NormalAttack("Bullet Seed", 25, PokemonType.Grass);

    public static NormalAttack BlazeKick = new NormalAttack("Blaze Kick", 85, PokemonType.Fire);

    public static NormalAttack FusionBolt = new NormalAttack("Fusion Bolt", 100, PokemonType.Electric);

    public NormalAttack(string name, int damage, PokemonType type) : base(name, damage, type) { }
}
