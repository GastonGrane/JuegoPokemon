// -----------------------------------------------------------------------
// <copyright file="NormalAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
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
    private static readonly Random Random = new Random();

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="NormalAttack"/>.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de danio que genera.</param>
    /// <param name="type">El <see cref="PokemonType"/> que va a definir el elemento del ataque.</param>
    /// <param name="precision">La precision del ataque (1-100).</param>
    /// <exception cref="ArgumentNullException">
    /// Lanzado si <paramref name="name"/> es <c>null</c>.
    /// </exception>
    /// <remarks>
    /// Este constructor lo utilizamos internamente para crear las caracteristicas de cada ataque.
    /// </remarks>
    public NormalAttack(string name, int damage, PokemonType type, int precision)
        : base(name, damage, type, precision)
    {
        ArgumentNullException.ThrowIfNull(name, "Un ataque no se puede inicializar con un nombre null.");
        ArgumentOutOfRangeException.ThrowIfNegative(damage, "El daño no puede ser negativo.");
    }

    /// <summary>
    /// Constructor que copia los valores de una instancia de la clase <see cref="NormalAttack"/>.
    /// </summary>
    /// <param name="attack">El ataque a copiar.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="attack"/> es <c>null</c>.
    /// </exception>
    public NormalAttack(NormalAttack attack)
        : base(attack)
    {
    }

    /// <summary>
    /// Aplica el ataque normal al Pokémon objetivo, calculando el daño con base en la ventaja de tipo.
    /// </summary>
    /// <param name="target">El Pokémon objetivo que recibirá el daño.</param>
    /// <exception cref="ArgumentNullException">Lanzado si el Pokémon objetivo es <c>null</c>.</exception>
    public override void Use(Pokemon target)
    {
        ArgumentNullException.ThrowIfNull(target, nameof(target));

        double multiplier = this.Type.Advantage(target.Type);
        int damage = (int)(this.Damage * multiplier);
        target.Damage(damage);

        if (Random.Next(10) < 1)
        {
            target.Damage((damage * 20) / 100);
        }
    }
}
