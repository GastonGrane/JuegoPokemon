// -----------------------------------------------------------------------
// <copyright file="Paralysis.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Security.Cryptography;

namespace Library.Effect;

/// <summary>
/// Representa un efecto de parálisis que puede ser aplicado a un Pokémon.
/// Este efecto impide que el Pokémon objetivo ataque en algunos turnos mientras está activo.
/// </summary>
/// <remarks>
/// Esta clase cumple con SRP "Single Responsibility Principle" ya que tiene una unica responsabilidad, manejar la
/// logica del efecto Paralysis.
/// </remarks>
public class Paralysis : IEffect
{
    /// <summary>
    /// Generador de números aleatorios seguro para determinar si el Pokémon puede atacar.
    /// </summary>
    private readonly RandomNumberGenerator random = RandomNumberGenerator.Create();

    /// <summary>
    /// Inicializa una nueva instancia del efecto de parálisis con el estado activo.
    /// </summary>
    public Paralysis()
    {
        this.IsExpired = false;
    }

    /// <summary>
    /// Indica si el efecto de parálisis ha expirado y ya no debe aplicarse.
    /// </summary>
    public bool IsExpired { get; private set; }

    /// <summary>
    /// Actualiza el efecto de parálisis en el Pokémon objetivo.
    /// Determina aleatoriamente si el Pokémon puede atacar, con una probabilidad del 50%.
    /// </summary>
    /// <param name="target">El Pokémon al que se le aplicará el efecto de parálisis.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="target"/> es <c>null</c>.</exception>
    public void UpdateEffect(Pokemon target)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "El Pokémon objetivo no puede ser null.");
        }

        byte[] randomByte = new byte[1];
        this.random.GetBytes(randomByte);
        target.CanAttack = (randomByte[0] % 2) == 1; // 50% probabilidad de atacar o no
    }

    /// <summary>
    /// Elimina el efecto de parálisis del Pokémon, marcándolo como expirado y restaurando su capacidad de atacar.
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
