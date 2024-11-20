// -----------------------------------------------------------------------
// <copyright file="AttackStatus.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Attacks;

/// <summary>
/// Representa los posibles estados que pueden resultar de un ataque en el juego.
/// </summary>
public enum AttackStatus
{
    /// <summary>
    /// El ataque realizado fue un golpe crítico.
    /// </summary>
    CriticalHit,

    /// <summary>
    /// El ataque realizado fue exitoso, con un daño normal.
    /// </summary>
    NormalAttack,

    /// <summary>
    /// El ataque aplicó un efecto especial al objetivo.
    /// </summary>
    EffectApplied,

    /// <summary>
    /// El ataque no tuvo efecto en el objetivo.
    /// </summary>
    NoEffect,

    /// <summary>
    /// El ataque fue bloqueado por un efecto o condición.
    /// </summary>
    HinderingEffect,

    /// <summary>
    /// Se coloca cuando la precision no fue buena.
    /// </summary>
    Miss,

    /// <summary>
    /// Se coloca cuando no se puede usar ese ataque.
    /// </summary>
    NotAvailable,

    /// <summary>
    /// Se coloca vacio para esperar el siguiente turno a informar.
    /// </summary>
    Empty,
}