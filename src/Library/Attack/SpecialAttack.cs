// -----------------------------------------------------------------------
// <copyright file="SpecialAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Todos los derechos reservados.
// -----------------------------------------------------------------------

using Library.Effect;

namespace Library;

// FIXME: Por ahora, este código no implementa ataques especiales ni define los efectos aplicados

/// <summary>
/// Representa un ataque especial que, además de causar daño, también inflige un estado en el Pokémon objetivo,
/// dependiendo del tipo de ataque que se utilice. Una vez que el ataque acierta, el estado se aplica
/// con un 100% de precisión.
/// </summary>
public class SpecialAttack : Attack
{
    private PokemonType attackType;
    private IEffect Effect;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SpecialAttack"/>.
    /// </summary>
    public SpecialAttack(string name, int damage, PokemonType attackType, int precision)
        : base(name, damage, attackType, precision)
    {
        this.attackType = attackType;
        this.Effect = Effect;
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SpecialAttack"/>, copiando los valores
    /// de otra instancia de <see cref="SpecialAttack"/>.
    /// </summary>
    /// <param name="attack">Instancia de ataque especial a copiar.</param>
    /// <exception cref="ArgumentNullException">Se lanza si el parámetro <paramref name="attack"/> es <c>null</c>.</exception>
    public SpecialAttack(SpecialAttack attack)
        : base(attack)
    {
    }

    private static readonly Random Random = new Random();

    /// <summary>
    /// Aplica el daño y el efecto especial al Pokémon objetivo. Si el Pokémon objetivo no tiene un efecto
    /// activo, se le aplica el efecto de este ataque.
    /// </summary>
    /// <param name="target">El Pokémon objetivo que recibirá el efecto especial.</param>
    /// <exception cref="ArgumentNullException">Se lanza si el Pokémon objetivo es <c>null</c>.</exception>
    public override void Use(Pokemon target)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        double multiplier = attackType.Advantage(target.Type);
        double damage = this.Damage * multiplier;
        target.Damage((int)damage);

        if (target.ActiveEffect == null)
        {
            target.ApplyEffect(this.Effect);
        }
    }
}
