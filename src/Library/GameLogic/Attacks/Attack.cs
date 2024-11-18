// -----------------------------------------------------------------------
// <copyright file="Attack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Effects;

namespace Library.GameLogic.Attacks;

/// <summary>
/// Clase base abstracta que representa un ataque en el juego, proporcionando propiedades esenciales
/// que definen las características de cada ataque.
/// </summary>
/// <remarks>
/// La clase <see cref="Attack"/> sirve como base para varios tipos de ataques especificos.
/// Esta clase cumple con LSP (Liskov Subsititution Principle) debido a que en los objetos de las subclases creadas a partir
/// de esta se va a generar el mismo comportamiento que en la superclase, así logrando la posibilidad de poder utilizar los objetos de las subclases
/// donde se usan los objetos de la superclase, y logrando comportamiento coherente.
/// Cumple también con OCP "Open-Closed Principle", ya que permite
/// la extensión a través de subclases como <see cref="NormalAttack"/> o <see cref="SpecialAttack"/> sin necesidad de
/// modificar el código base.
/// Finalmente, implementa el patrón GRASP de "Polimorfismo", ya que se espera que las subclases concreten comportamientos específicos.
/// Estas instancias predefinidas las creamos para utilziarlas como un movimiento en las batallas.
/// </remarks>
public abstract class Attack
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Attack"/> con los parámetros especificados.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de daño que causa el ataque.</param>
    /// <param name="type">El tipo de ataque (<see cref="PokemonType"/>), que determina su efectividad.</param>
    /// <param name="precision">La precision del ataque (1-100).</param>
    protected Attack(string name, int damage, PokemonType type, int precision)
    {
        this.Name = name;
        this.Damage = damage;
        this.Type = type;
        this.Precision = precision;
    }

    /// <summary>
    /// Crea un <see cref="Attack"/> copiando los valores del ataque provisto.
    /// </summary>
    /// <param name="attack">El ataque a copiar.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="attack"/> es <c>null</c>.
    /// </exception>
    protected Attack(Attack attack)
    {
        ArgumentNullException.ThrowIfNull(attack, nameof(attack));
        this.Name = attack.Name;
        this.Damage = attack.Damage;
        this.Type = attack.Type;
        this.Precision = attack.Precision;
    }

    /// <summary>
    /// Obtiene el nombre del ataque.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Obtiene el valor de daño del ataque.
    /// </summary>
    public int Damage { get; }

    /// <summary>
    /// Obtiene el tipo de ataque, que determina la efectividad del ataque contra diferentes tipos de Pokémon.
    /// </summary>
    public PokemonType Type { get; }

    /// <summary>
    /// Obtiene la precisión del ataque, representada como un porcentaje entre 1 y 100.
    /// </summary>
    public int Precision { get; }

    /// <summary>
    /// Aplica el ataque a un Pokémon objetivo. Debe ser implementado por clases derivadas.
    /// </summary>
    /// <param name="target"> El Pokémon objetivo al que se aplicará el ataque.</param>
    public abstract void Use(Pokemon target);

    /// <summary>
    /// Aplica el ataque a un Pokémon objetivo. Debe ser implementado por clases derivadas.
    /// </summary>
    /// <param name="target"> El Pokémon objetivo que recibirá el daño. </param>
    /// <param name="random"> El tipo de aleatoriedad que queremos utilizar. </param>
    public abstract void Use(Pokemon target, IProbability probabildiad);
}
