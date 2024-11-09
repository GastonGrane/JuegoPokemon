// -----------------------------------------------------------------------
// <copyright file="NormalAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Todos los derechos reservados.
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Representa un ataque básico en el juego. A diferencia de <see cref="SpecialAttack"/>, 
/// <see cref="NormalAttack"/> no utiliza efectos y solo inflige daño directo al Pokémon objetivo.
/// </summary>
/// <remarks>
/// Las instancias de esta clase representan ataques normales que pueden ser usados en batallas.
/// Cada ataque tiene características únicas predefinidas para ser utilizados como movimientos en combate.
/// </remarks>
public class NormalAttack : Attack
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="NormalAttack"/>.
    /// </summary>
    public NormalAttack(string name, int damage, PokemonType type, int precision)
        : base(name, damage, type, precision)
    {
        ArgumentNullException.ThrowIfNull(name, "Un ataque no se puede inicializar con un nombre null.");
        ArgumentOutOfRangeException.ThrowIfNegative(damage, "El daño no puede ser negativo.");
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="NormalAttack"/> copiando los valores
    /// de otra instancia de <see cref="NormalAttack"/>.
    /// </summary>
    /// <param name="attack">El ataque a copiar.</param>
    /// <exception cref="ArgumentNullException">Lanzado si <paramref name="attack"/> es <c>null</c>.</exception>
    public NormalAttack(NormalAttack attack)
        : base(attack)
    {
    }
    private static readonly Random Random = new Random();


    /// <summary>
    /// Aplica el ataque normal al Pokémon objetivo, calculando el daño con base en la ventaja de tipo.
    /// </summary>
    /// <param name="target">El Pokémon objetivo que recibirá el daño.</param>
    /// <exception cref="ArgumentNullException">Lanzado si el Pokémon objetivo es <c>null</c>.</exception>
    public override void Use(Pokemon target)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "El objetivo del ataque no puede ser null.");
        }

        double multiplier = Type.Advantage(target.Type);
        double damage = this.Damage * multiplier;
        target.Damage((int)damage);

        if (Random.Next(10) < 1)
        {
            target.Damage((damage * 20) / 100);
        }
    }
}
