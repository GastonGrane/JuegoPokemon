// -----------------------------------------------------------------------
// <copyright file="NormalAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Pokemon;

namespace Library.GameLogic.Attacks;

/// <summary>
/// Representa un ataque básico en el juego. A diferencia de <see cref="SpecialAttack"/>.
/// </summary>
public class NormalAttack : Attack
{
    private static readonly Random Random = new Random();

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="NormalAttack"/>.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de daño que genera.</param>
    /// <param name="type">El <see cref="PokemonType"/> que define el elemento del ataque.</param>
    /// <param name="precision">La precisión del ataque (1-100).</param>
    public NormalAttack(string name, int damage, PokemonType type, int precision)
        : base(name, damage, type, precision)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        ArgumentOutOfRangeException.ThrowIfNegative(damage, nameof(damage));
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
        ArgumentNullException.ThrowIfNull(attack.Name, "Un Ataque no se puede inicializar con nombre null");
        ArgumentOutOfRangeException.ThrowIfNegative(attack.Damage, "El daño no puede ser negativo");
    }

    /// <summary>
    /// Aplica el ataque normal al Pokémon objetivo, calculando el daño con base en la ventaja de tipo.
    /// </summary>
    /// <param name="target">El Pokémon objetivo que recibirá el daño.</param>
    /// <returns>Un <see cref="AttackResult"/> con el daño causado y el estado del ataque.</returns>
    public override AttackResult Use(Pokemon.Pokemon target)
    {
        ArgumentNullException.ThrowIfNull(target, nameof(target));

        double multiplier = this.Type.Advantage(target.Type);
        int damage = (int)(this.Damage * multiplier);
        target.Damage(damage);

        if (Random.Next(10) < 1)
        {
            int criticalDamage = (damage * 20) / 100;
            target.Damage(criticalDamage);
            return new AttackResult(AttackStatus.CriticalHit, criticalDamage);
        }

        return new AttackResult(AttackStatus.NormalAttack, damage);
    }
}
