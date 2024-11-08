// -----------------------------------------------------------------------
// <copyright file="Attack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Representa una clase base abstracta para atacar en el juego, nos da las propiedades esenciales que definen las caracteristicas de cada ataque.
/// </summary>
/// <remarks>
/// La clase <see cref="Attack"/> sirve como base para varios tipos de ataques especificos,
/// tal como <see cref="NormalAttack"/>.
/// </remarks>
public abstract class Attack
{
    /// <summary>
    /// Crea un <see cref="Attack"/> con los parámetros provistos.
    /// </summary>
    protected Attack(string name, int damage, PokemonType type)
    {
        this.Name = name;
        this.Damage = damage;
        this.Type = type;
    }

    /// <summary>
    /// El nombre del ataque.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// El valor de daño del ataque.
    /// </summary>
    public int Damage { get; }

    /// <summary>
    /// Retorna el tipo de ataque, que va a determinar si es eficaz el ataque.
    /// </summary>
    /// <value>
    /// Un <see cref="PokemonType"/> representa el tipo elemental del ataque.
    /// </value>
    public PokemonType Type { get; }
}
