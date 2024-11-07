// -----------------------------------------------------------------------
// <copyright file="SuperPotions.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Items;

/// <summary>
/// Representa una super poción que cura a un Pokémon específico, restaurando una cantidad significativa de su salud.
/// </summary>
public class SuperPotions : IItem
{
    /// <summary>
    /// Aplica el efecto de la super poción en el Pokémon especificado, restaurando 70 puntos de salud.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará la super poción.</param>
    public void Use(Pokemon pokemon)
    {
        pokemon.Curar(70);
    }
}