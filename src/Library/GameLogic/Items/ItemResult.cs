// -----------------------------------------------------------------------
// <copyright file="ItemResult.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Items;

/// <summary>
/// Representa el resultado del uso de un ítem en el juego, indicando su estado y el efecto aplicado al objetivo.
/// </summary>
public class ItemResult
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ItemResult"/> con el estado especificado del ítem.
    /// </summary>
    /// <param name="itemStatus">El estado del ítem que representa el resultado de su uso, como <see cref="ItemStatus.Revive"/>, <see cref="ItemStatus.SuperPotion"/>, o <see cref="ItemStatus.TotalCure"/>.</param>
    public ItemResult(ItemStatus itemStatus)
    {
        this.ItemStatus = itemStatus;
    }

    /// <summary>
    /// Indica el estado del ítem que se utilizó en el juego.
    /// </summary>
    public ItemStatus ItemStatus { get; }
}