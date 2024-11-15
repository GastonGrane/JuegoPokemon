// -----------------------------------------------------------------------
// <copyright file="Sleep.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Effects;

/// <summary>
/// Representa un efecto de sueño que puede ser aplicado a un Pokémon.
/// Este efecto impide que el Pokémon pueda atacar durante un número determinado de turnos.
/// </summary>
/// <remarks>
/// Esta clase cumple con SRP "Single Responsibility Principle" ya que tiene una unica responsabilidad, manejar la
/// logica del efecto Sleep.
/// </remarks>
public class Sleep : IEffect
{
    /// <summary>
    /// Cantidad de turnos restantes durante los cuales el efecto de sueño estará activo.
    /// </summary>
    private int turnsRemaining;
    
    public Sleep()
    {
        this.turnsRemaining = new Random().Next(1, 5);
        this.IsExpired = false;
    }
    
    /// <summary>
    /// Inicializa una nueva instancia del efecto de sueño con una duración aleatoria entre 1 y 4 turnos.
    /// </summary>
    public Sleep(IProbability rondasdormido)
    {
        this.turnsRemaining = rondasdormido.CalcularNumero(1, 5);
        this.IsExpired = false;
    }

    /// <summary>
    /// Inicializa una nueva instancia del efecto de sueño con la duración especificada.
    /// </summary>
    /// <param name="duration">La duración del efecto de sueño en turnos.</param>
    public Sleep(int duration)
    {
        this.turnsRemaining = duration;
        this.IsExpired = false;
    }

    /// <summary>
    /// Indica si el efecto de sueño ha expirado y ya no debe aplicarse.
    /// </summary>
    public bool IsExpired { get; private set; }

    /// <summary>
    /// Actualiza el efecto de sueño en el Pokémon objetivo, reduciendo los turnos restantes.
    /// Cuando el efecto ha durado el número especificado de turnos, se elimina.
    /// </summary>
    /// <param name="target">El Pokémon al que se le aplicará el efecto de sueño.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="target"/> es <c>null</c>.</exception>
    public void UpdateEffect(Pokemon target)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "El Pokémon objetivo no puede ser null.");
        }

        if (this.turnsRemaining > 0)
        {
            this.turnsRemaining--;
            target.CanAttack = false; // El Pokémon no puede atacar mientras está dormido
        }
        else
        {
            this.RemoveEffect(target);
        }
    }

    /// <summary>
    /// Elimina el efecto de sueño del Pokémon, marcándolo como expirado.
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
        target.CanAttack = true; // Restaura la capacidad de atacar
    }
}
