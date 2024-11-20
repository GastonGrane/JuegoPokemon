// -----------------------------------------------------------------------
// <copyright file="ItemStatus.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Items;

/// <summary>
/// Representa los posibles estados que pueden resultar del uso de un ítem en el juego.
/// </summary>
public enum ItemStatus
{
    /// <summary>
    /// Se utilizó un ítem para revivir a un Pokémon.
    /// </summary>
    Revive,

    /// <summary>
    /// Se utilizó una poción para restaurar la salud de un Pokémon.
    /// </summary>
    SuperPotion,

    /// <summary>
    /// Se utilizó un ítem para eliminar los efectos de estado negativos en un Pokémon.
    /// </summary>
    TotalCure,

    /// <summary>
    /// Se coloca vacio para esperar el siguiente turno a informar.
    /// </summary>
    Empty,
}