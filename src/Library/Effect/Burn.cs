// -----------------------------------------------------------------------
// <copyright file="Burn.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Effect;

/// <summary>
/// Representa un efecto de quemadura que puede ser aplicado a un Pokémon.
/// Este efecto causa daño al Pokémon objetivo cada turno mientras está activo.
/// </summary>
/// <remarks>
/// Esta clase cumple con SRP "Single Responsibility Principle" ya que tiene una unica responsabilidad, manejar la
/// logica del efecto Burn.
/// </remarks>
public class Burn : IEffect
{
    /// <summary>
    /// Inicializa una nueva instancia del efecto de quemadura en el Pokémon especificado y lo marca como activo.
    /// </summary>
    public Burn()
    {
        this.IsExpired = false;
    }

    /// <summary>
    /// Indica si el efecto de quemadura ha expirado y ya no debe aplicarse.
    /// </summary>
    public bool IsExpired { get; private set; }

    /// <summary>
    /// Aplica el daño de quemadura al Pokémon objetivo, reduciendo su salud en un 10% de su salud actual.
    /// </summary>
    /// <param name="target">El Pokémon al que se le aplicará el daño por quemadura.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="target"/> es <c>null</c>.</exception>
    public void UpdateEffect(Pokemon target)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "El Pokémon objetivo no puede ser null.");
        }

        target.Damage((int)(target.MaxHealth * 0.10));
    }

    /// <summary>
    /// Elimina el efecto de quemadura del Pokémon, marcándolo como expirado.
    /// </summary>
    /// <param name="target">El Pokémon del que se removerá el efecto.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="target"/> es <c>null</c>.</exception>
    public void RemoveEffect(Pokemon target)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "El Pokémon objetivo no puede ser null.");
        }

        this.IsExpired = true;
    }
}
