// -----------------------------------------------------------------------
// <copyright file="SpecialAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Effects;

namespace Library.GameLogic.Attacks;

/// <summary>
/// Representa un ataque especial que, además de causar daño, también inflige un estado en el Pokémon objetivo,
/// dependiendo del tipo de ataque que se utilice. Una vez que el ataque acierta, el estado se aplica
/// con un 100% de precisión.
/// </summary>
public class SpecialAttack : Attack
{
    private IEffect effect;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SpecialAttack"/>.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de daño que realiza.</param>
    /// <param name="attackType">El <see cref="PokemonType"/> del ataque.</param>
    /// <param name="precision">La precisión del ataque (1-100).</param>
    /// <param name="effect">El efecto del ataque.</param>
    public SpecialAttack(string name, int damage, PokemonType attackType, int precision, IEffect effect)
        : base(name, damage, attackType, precision)
    {
        this.effect = effect;
    }

    /// <summary>
    /// Constructor que copia los valores de una instancia de la clase <see cref="SpecialAttack"/>.
    /// </summary>
    /// <param name="attack">El ataque a copiar.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="attack"/> es <c>null</c>.
    /// </exception>
    public SpecialAttack(SpecialAttack attack)
        : base(attack)
    {
        this.effect = attack.effect;
    }

    /// <summary>
    /// Aplica el daño y el efecto especial al Pokémon objetivo. Si el Pokémon objetivo no tiene un efecto
    /// activo, se le aplica el efecto de este ataque.
    /// </summary>
    /// <param name="target">El Pokémon objetivo que recibirá el efecto especial.</param>
    /// <exception cref="ArgumentNullException">Se lanza si el Pokémon objetivo es <c>null</c>.</exception>
    public override void Use(Pokemon target)
    {
        ArgumentNullException.ThrowIfNull(target, nameof(target));

        double multiplier = this.Type.Advantage(target.Type);
        int damage = (int)(this.Damage * multiplier);
        target.Damage(damage);

        if (target.ActiveEffect == null)
        {
            target.ApplyEffect(this.effect);
        }
    }
}
