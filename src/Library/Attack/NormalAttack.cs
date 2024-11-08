namespace Library;

/// <summary>
/// Representa un tipo especifico de ataque en el juego, NormalAttack a diferencia de SpecialAttack no va a utilizar efectos
/// </summary>
/// <remarks>
/// Esta clase nos da instancias de Attack, cada uno con sus caracteristicas unica,
/// Estas instancias predefinidas las creamos para utilziarlas como un movimiento en las batallas
/// </remarks>
public class NormalAttack : Attack
{
    public static readonly NormalAttack AquaJet = new NormalAttack("Aqua Jet", 40, PokemonType.Water);

    public static readonly NormalAttack BulletSeed = new NormalAttack("Bullet Seed", 25, PokemonType.Grass);

    public static readonly NormalAttack BlazeKick = new NormalAttack("Blaze Kick", 85, PokemonType.Fire);

    public static readonly NormalAttack FusionBolt = new NormalAttack("Fusion Bolt", 100, PokemonType.Electric);

    /// <summary>
    /// El constructor de una nueva instancia de la clase <see cref="NormalAttack"/>
    /// </summary>
    /// <param name="name">El nombre del ataque</param>
    /// <param name="damage">La cantidad de danio que genera</param>
    /// <param name="type">El <see cref="PokemonType"/> que va a definir el elemento del ataque
    /// </param>
    /// <remarks>
    /// Este constructor lo utilizamos internamente para crear las caracteristicas de cada ataque
    /// </remarks>
    public NormalAttack(string name, int damage, PokemonType type) : base(name, damage, type)
    {
    }
}
