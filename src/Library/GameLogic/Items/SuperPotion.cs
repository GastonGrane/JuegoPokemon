// -----------------------------------------------------------------------
// <copyright file="SuperPotion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Items;

/// <summary>
/// Representa una super poción que cura a un Pokémon específico, restaurando una cantidad significativa de su salud.
/// </summary>
/// /// <remarks>
/// La clase <see cref="SuperPotion"/> implementa la clase <see cref="Item"/> y define el comportamiento específico
/// del ítem "Superpotion", cumpliendo con LSP.
/// </remarks>
public class SuperPotion : Item
{
    /// <summary>
    /// Constructor establece nombre para ser imprimido al Player.
    /// </summary>
    public SuperPotion()
        : base("Super Potion")
    {
    }

    /// <summary>
    /// Aplica el efecto de la super poción en el Pokémon especificado, restaurando 70 puntos de salud.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará la super poción.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="pokemon"/> es null.
    /// </exception>
    /// <returns>Un <see cref="ItemStatus"/> que indica el resultado del uso del ítem, en este caso, <see cref="ItemStatus.SuperPotion"/>.</returns>
    public override ItemStatus Use(Pokemon? pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));
        pokemon.Heal(70);
        return ItemStatus.SuperPotion;
    }
}
