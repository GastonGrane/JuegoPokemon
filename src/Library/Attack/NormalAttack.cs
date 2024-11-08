// -----------------------------------------------------------------------
// <copyright file="NormalAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Representa un tipo especifico de ataque en el juego, NormalAttack a diferencia de SpecialAttack no va a utilizar efectos.
/// </summary>
/// <remarks>
/// Esta clase nos da instancias de Attack, cada uno con sus caracteristicas unica,
/// Estas instancias predefinidas las creamos para utilziarlas como un movimiento en las batallas.
/// </remarks>
public class NormalAttack : Attack
{
    /// <summary>
    /// El constructor de una nueva instancia de la clase <see cref="NormalAttack"/>.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de danio que genera.</param>
    /// <param name="type">El <see cref="PokemonType"/> que va a definir el elemento del ataque.</param>
    /// <remarks>
    /// Este constructor lo utilizamos internamente para crear las caracteristicas de cada ataque.
    /// </remarks>
    public NormalAttack(string name, int damage, PokemonType type)
        : base(name, damage, type)
    {
    }
}