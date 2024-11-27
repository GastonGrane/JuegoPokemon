// -----------------------------------------------------------------------
// <copyright file="Revive.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Entities;

namespace Library.GameLogic.Items;

/// <summary>
/// Representa un objeto de revivir que restaura parcialmente la salud de un Pokémon debilitado.
/// </summary>
/// <remarks>
/// La clase <see cref="Revive"/> implementa la clase <see cref="Item"/> y define el comportamiento específico
/// del ítem "Revive", cumpliendo con LSP.
/// </remarks>
public class Revive : Item
{
    /// <summary>
    /// Constructor establece nombre para ser imprimido al Player.
    /// </summary>
    public Revive()
        : base("Revive")
    {
    }

    /// <summary>
    /// Aplica el efecto del objeto Revive en el Pokémon especificado, restaurando 50 porciento de su salud inicial.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará el Revive.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="pokemon"/> es null.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Si <paramref name="pokemon"/> está vivo.
    /// </exception>
    public override void Use(Pokemon pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));
        if (pokemon.Health != 0)
        {
            throw new InvalidOperationException($"El Pokémon {pokemon.Name} ya está vivo y no puede ser revivido.");
        }

        int cincPor = (pokemon.MaxHealth * 50) / 100;
        pokemon.Heal(cincPor);
    }
}
