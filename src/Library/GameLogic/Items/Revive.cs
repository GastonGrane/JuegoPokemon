// -----------------------------------------------------------------------
// <copyright file="Revive.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Items;

/// <summary>
/// Representa un objeto de revivir que restaura parcialmente la salud de un Pokémon debilitado.
/// </summary>
/// <remarks>
/// La clase <see cref="Revive"/> implementa la interfaz <see cref="IItem"/> y define el comportamiento específico
/// del ítem "Revive", cumpliendo con LSP.
/// </remarks>
public class Revive : IItem
{
    /// <summary>
    /// Constructor establece nombre para ser imprimido al Player.
    /// </summary>
    public Revive()
    {
    }

    /// <summary>
    /// Nombre de el efecto.
    /// </summary>
    public string Name
    {
        get { return "Revive"; }
    }

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
