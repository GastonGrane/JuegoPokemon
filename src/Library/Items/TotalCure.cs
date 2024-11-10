// -----------------------------------------------------------------------
// <copyright file="TotalCure.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Items;

/// <summary>
/// Representa un objeto que puede eliminar todos los efectos de estado negativos de un Pokémon.
/// Al usar este objeto en un Pokémon, se eliminan todos los efectos de estado aplicados a él.
/// </summary>
public class TotalCure : IItem
{
    /// <summary>
    /// Constructor establece nombre para ser imprimido al Player.
    /// </summary>
    public TotalCure()
    {
    }

    /// <summary>
    /// Nombre de el efecto.
    /// </summary>
    public string Name { get { return "Total Cure"; } }

    /// <summary>
    /// Usa el objeto de cura total en el Pokémon especificado, eliminando cualquier efecto de estado activo.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará la cura total.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="pokemon"/> es <c>null</c>.</exception>
    public void Use(Pokemon pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));
        if (pokemon.ActiveEffect == null)
        {
            throw new InvalidOperationException("El Pokémon no tiene ningún efecto activo.");
        }

        pokemon.RemoveEffect();
    }
}
