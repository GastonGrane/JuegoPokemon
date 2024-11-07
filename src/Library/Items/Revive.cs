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
    /// Aplica el efecto del objeto Revive en el Pokémon especificado, restaurando 50 puntos de salud.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará el Revive.</param>
    public void Use(Pokemon pokemon)
    {
        pokemon.Curar(50);
    }
}