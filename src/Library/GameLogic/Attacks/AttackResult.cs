// -----------------------------------------------------------------------
// <copyright file="AttackResult.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Attacks;

/// <summary>
/// Representa el resultado de un ataque, incluyendo el daño causado y el estado del ataque.
/// </summary>
/// <remarks>
/// El constructor de AttackResult.
/// </remarks>
public class AttackResult(AttackStatus attackStatus, int damage)
{
    /// <summary>
    /// Indica el numero de Daño que se utilizó en el juego.
    /// </summary>
    public int Damage { get; set; } = damage;

    /// <summary>
    /// Indica el estado del ataque que se realizó en el juego.
    /// </summary>
    public AttackStatus AttackStatus { get; } = attackStatus;
}