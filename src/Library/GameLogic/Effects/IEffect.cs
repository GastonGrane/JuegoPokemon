// -----------------------------------------------------------------------
// <copyright file="IEffect.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Effects;

/// <summary>
/// Define una interfaz para los efectos que se pueden aplicar a un Pokémon.
/// Los efectos pueden actualizarse en cada turno, eliminarse y expirar.
/// </summary>
/// <remarks>
/// Implementa el principio ISP (Interface Segregation Principle) al proporcionar una interfaz específica
/// para los efectos, la cual todos ecesitan utilizar
/// Aplica el patrón GRASP de "Polimorfismo" al permitir que cada tipo de efecto defina su propio
/// comportamiento, cumple así con el el principio "Open-Closed Principle" al facilitar la extensión de su funcionalidad, mediante la implementación de la misma.
/// </remarks>
public interface IEffect
{
    /// <summary>
    /// Indica si el efecto ha expirado y debería ser eliminado del Pokémon.
    /// </summary>
    bool IsExpired { get; }

    /// <summary>
    /// Actualiza el estado del efecto en cada turno.
    /// </summary>
    /// <param name="target">El Pokémon al que se aplica el efecto.</param>
    void UpdateEffect(Pokemon.Pokemon target);

    /// <summary>
    /// Elimina el efecto del Pokémon, restaurando cualquier cambio aplicado por el efecto.
    /// </summary>
    /// <param name="target">El Pokémon del que se elimina el efecto.</param>
    void RemoveEffect(Pokemon.Pokemon target);
}
