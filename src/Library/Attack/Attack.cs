// -----------------------------------------------------------------------
// <copyright file="Attack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Clase base abstracta que representa un ataque en el juego, proporcionando propiedades esenciales
/// que definen las características de cada ataque.
/// </summary>
/// <remarks>
/// La clase <see cref="Attack"/> sirve como base para tipos específicos de ataques,
/// tales como <see cref="NormalAttack"/> y <see cref="SpecialAttack"/>.
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
    /// <param name="target">El Pokémon objetivo al que se aplicará el ataque.</param>
    public abstract void Use(Pokemon target);
}
