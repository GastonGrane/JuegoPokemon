// -----------------------------------------------------------------------
// <copyright file="Revive.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Items;

/// <summary>
/// Representa un objeto de revivir que restaura parcialmente la salud de un Pokémon debilitado.
/// </summary>
public class Revive : IItem
{
    /// <summary>
    /// Constructor establece nombre para ser imprimido al Player.
    /// </summary>
    /// <param name="name"></param>
    public Revive()
    {
        this.Name = "Revive";
    }

    /// <summary>
    /// Nombre de el efecto.
    /// </summary>
    /// <param name="name"></param>
    public string Name { get; }

    /// <summary>
    /// Aplica el efecto del objeto Revive en el Pokémon especificado, restaurando 50 puntos de salud.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará el Revive.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="pokemon"/> es null.
    /// </exception>
    public void Use(Pokemon pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));
        pokemon.Heal(50);
    }
}
