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
/// La clase <see cref="Attack"/> sirve como base para varios tipos de ataques especificos.
/// ESta clase utiliza SRP "Single Responsibility Principle" al encapsular exclusivamente los atributos de un ataque
/// sin la logica correspondiente. Cumple también con el principio de OCP "Open-Closed Principle", ya que permite
/// la extensión a través de subclases como <see cref="NormalAttack"/> o <see cref="SpecialAttack"/> sin necesidad de
/// modificar el código base.
/// E implementa el patrón GRASP de "Polimorfismo", ya que se espera que las subclases concreten comportamientos específicos.
/// Estas instancias predefinidas las creamos para utilziarlas como un movimiento en las batallas.
/// </remarks>
public abstract class Attack
{
    /// <summary>
    /// Crea un <see cref="Attack"/> con los parámetros provistos.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de danio que genera.</param>
    /// <param name="type">El <see cref="PokemonType"/> que va a definir el elemento del ataque.</param>
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
