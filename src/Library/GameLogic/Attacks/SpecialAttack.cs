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
public class SpecialAttack : NormalAttack
{
    private readonly IEffect effect;

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
        this.AmountUnusedTurn = 2; // Inicia con disponibilidad inmediata.
    }

    /// <summary>
    /// Constructor que copia los valores de una instancia de la clase <see cref="SpecialAttack"/>.
    /// </summary>
    /// <param name="attack">El ataque a copiar.</param>
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
    /// <returns>Un <see cref="AttackResult"/> con el daño infligido y el estado del ataque.</returns>
    public new AttackResult Use(Pokemon? target)
    {
        if (!this.Available)
        {
            return new AttackResult(AttackStatus.NotAvailable, 0);
        }

        ArgumentNullException.ThrowIfNull(target, nameof(target));

        // Calcular daño basado en ventaja.
        double multiplier = this.Type.Advantage(target.Type);
        int damage = (int)(this.Damage * multiplier);
        target.Damage(damage);

        // Aplicar efecto si el Pokémon objetivo no tiene un efecto activo.
        if (target.ActiveEffect == null)
        {
            target.ApplyEffect(this.effect);
            this.Available = false;
            this.AmountUnusedTurn = 0;
            return new AttackResult(AttackStatus.EffectApplied, damage);
        }

        // Si no aplica el efecto, igual se realiza el ataque.
        this.Available = false;
        this.AmountUnusedTurn = 0;
        return new AttackResult(AttackStatus.NoEffect, damage);
    }

    /// <summary>
    /// Actualiza el número de turnos que el ataque no ha estado disponible y lo habilita tras dos turnos.
    /// </summary>
    public override void UpdateTurn()
    {
        if (!this.Available)
        {
            this.AmountUnusedTurn += 1;
            if (this.AmountUnusedTurn >= 2)
            {
                this.Available = true;
            }
        }
    }
}
