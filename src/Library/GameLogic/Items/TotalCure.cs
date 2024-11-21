// -----------------------------------------------------------------------
// <copyright file="TotalCure.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Entities;

namespace Library.GameLogic.Items;

/// <summary>
/// Representa un objeto que puede eliminar todos los efectos de estado negativos de un Pokémon.
/// Al usar este objeto en un Pokémon, se eliminan todos los efectos de estado aplicados a él.
/// </summary>
/// <remarks>
/// La clase <see cref="TotalCure"/> implementa la clase <see cref="Item"/> y define el comportamiento específico
/// de un ítem que elimina todos los efectos de estado negativos de un Pokémon.
/// Esta clase también cumple con LSP, al cumplir con el contrato de la interfaz, al únicamente aplicar el efecto necesario en el Pokémon.
/// Esta implementación también muestra el uso de excepciones para asegurar que el objeto se utilice correctamente.
/// </remarks>
public class TotalCure : Item
{
    /// <summary>
    /// Constructor establece nombre para ser imprimido al Player.
    /// </summary>
    public TotalCure()
        : base("Total Cure")
    {
    }

    /// <summary>
    /// Usa el objeto de cura total en el Pokémon especificado, eliminando cualquier efecto de estado activo.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará la cura total.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="pokemon"/> es <c>null</c>.</exception>
    public override void Use(Pokemon pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));
        if (pokemon.ActiveEffect == null)
        {
            throw new InvalidOperationException("El Pokémon no tiene ningún efecto activo.");
        }

        pokemon.RemoveEffect();
    }
}
