// -----------------------------------------------------------------------
// <copyright file="Poison.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Effect;

/// <summary>
/// Representa un efecto de veneno que puede ser aplicado a un Pokémon.
/// Este efecto causa daño al Pokémon objetivo cada turno mientras está activo.
/// </summary>
/// /// <remarks>
/// Esta clase cumple con SRP "Single Responsibility Principle" ya que tiene una unica responsabilidad, manejar la
/// logica del efecto Burn, e implementa la interfaz <see cref="IEffect"/>, respetando el "Open-Closed Principle" al
/// facilitar la adición de nuevos efectos sin modificar la lógica de la interfaz base.
/// </remarks>
public class Poison : IEffect
{
    /// <summary>
    /// Inicializa una nueva instancia del efecto de veneno y lo marca como activo.
    /// </summary>
    public Poison()
    {
        this.IsExpired = false;
    }

    /// <summary>
    /// Indica si el efecto de veneno ha expirado y ya no debe aplicarse.
    /// </summary>
    public bool IsExpired { get; private set; }

    /// <summary>
    /// Aplica el daño de veneno al Pokémon objetivo, reduciendo su salud en un 5% de su salud actual.
    /// </summary>
    /// <param name="target">El Pokémon al que se le aplicará el daño por veneno.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="target"/> es <c>null</c>.</exception>
    public void UpdateEffect(Pokemon target)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "El Pokémon objetivo no puede ser null.");
        }

        target.Damage((int)(target.Health * 0.05));
    }

    /// <summary>
    /// Elimina el efecto de veneno del Pokémon.
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
