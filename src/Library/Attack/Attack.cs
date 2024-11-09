// -----------------------------------------------------------------------
// <copyright file="Attack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Todos los derechos reservados.
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
    /// <param name="precision">La precisión del ataque, en un rango de 1 a 100.</param>
    protected Attack(string name, int damage, PokemonType type, int precision)
    {
        this.Name = name;
        this.Damage = damage;
        this.Type = type;
        this.Precision = precision;
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Attack"/> copiando los valores del ataque proporcionado.
    /// </summary>
    /// <param name="attack">El ataque a copiar.</param>
    /// <exception cref="ArgumentNullException">Se lanza si el ataque proporcionado es <c>null</c>.</exception>
    protected Attack(Attack attack)
    {
        if (attack == null) throw new ArgumentNullException(nameof(attack), "El ataque no puede ser null.");
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
    /// <param name="target">El Pokémon objetivo al que se aplicará el ataque.</param>
    public abstract void Use(Pokemon target);
}
