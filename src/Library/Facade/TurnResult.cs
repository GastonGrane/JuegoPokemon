// -----------------------------------------------------------------------
// <copyright file="TurnResult.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Attacks;
using Library.GameLogic.Items;

namespace Library.Facade;

/// <summary>
/// Representa el resultado del uso de un ítem en el juego, indicando su estado y el efecto aplicado al objetivo.
/// </summary>
public class TurnResult
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase con el estado especificado del ítem.
    /// </summary>
    /// <param name="itemStatus">El estado del ítem que representa el resultado de su uso, como <see cref="ItemStatus.Revive"/>, <see cref="ItemStatus.SuperPotion"/>, o <see cref="ItemStatus.TotalCure"/>.</param>
    public TurnResult(ItemStatus itemStatus)
    {
        this.ItemStatus = itemStatus;
    }

    /// <summary>
    /// Constructor para definir el estado del juego si se atacó en este turno.
    /// </summary>
    /// <param name="attackStatus">El estado del ataque realizado, como crítico, normal o fallido.</param>
    /// <param name="damage">El daño causado por el ataque en este turno.</param>
    public TurnResult(AttackStatus attackStatus, int damage)
    {
        this.Damage = damage;
        this.AttackStatus = attackStatus;
    }

    /// <summary>
    /// Indica el estado del ítem que se utilizó en el juego.
    /// </summary>
    public ItemStatus ItemStatus { get; }

    /// <summary>
    /// Indica el numero de Daño que se utilizó en el juego.
    /// </summary>
    public int Damage { get; set; }

    /// <summary>
    /// Indica el estado del ataque que se realizó en el juego.
    /// </summary>
    public AttackStatus AttackStatus { get; }
}
