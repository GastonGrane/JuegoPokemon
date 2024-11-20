// -----------------------------------------------------------------------
// <copyright file="NormalAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Pokemon;

namespace Library.GameLogic.Attacks;

/// <summary>
/// Representa un ataque básico en el juego. A diferencia de <see cref="SpecialAttack"/>.
/// </summary>
/// <remarks>
/// Esta clase cumple con SRP, al abarcar la funcionalidad de un único tipo de ataque, aquellos que únicamente producen daño.
/// La clase <see cref="NormalAttack"/> permite crear instancias de ataques predefinidos para ser utilizados
/// en las batallas, y se beneficia del "Polimorfismo" del patrón GRASP al heredar de la clase base <see cref="NormalAttack"/>.
/// </remarks>
public class NormalAttack
{
    private static readonly Random Random = new Random();

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="NormalAttack"/>.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de daño que genera.</param>
    /// <param name="type">El <see cref="PokemonType"/> que va a definir el elemento del ataque.</param>
    /// <param name="precision">La precision del ataque (1-100).</param>
    /// <exception cref="ArgumentNullException">
    /// Lanzado si <paramref name="name"/> es <c>null</c>.
    /// </exception>
    /// <remarks>
    /// Este constructor lo utilizamos internamente para crear las caracteristicas de cada ataque.
    /// </remarks>
    public NormalAttack(string name, int damage, PokemonType type, int precision)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        ArgumentOutOfRangeException.ThrowIfNegative(damage, nameof(damage));
        this.Name = name;
        this.Damage = damage;
        this.Type = type;
        this.Precision = precision;
        this.Available = true;
    }

    /// <summary>
    /// Crea un <see cref="NormalAttack"/> copiando los valores del ataque provisto.
    /// </summary>
    /// <param name="attack">El ataque a copiar.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="attack"/> es <c>null</c>.
    /// </exception>
    public NormalAttack(NormalAttack attack)
    {
        ArgumentNullException.ThrowIfNull(attack, nameof(attack));
        this.Name = attack.Name;
        this.Damage = attack.Damage;
        this.Type = attack.Type;
        this.Precision = attack.Precision;
        this.Available = true;
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
    /// Disponibilidad del ataque en el turno que se está jugando.
    /// </summary>
    public bool Available { get; protected set; }

    /// <summary>
    /// Cantidad de turnos en los que el ataque no se ha encontrado disponible.
    /// </summary>
    public int AmountUnusedTurn { get; protected set; }

    /// <summary>
    /// Aplica el ataque normal al Pokémon objetivo, calculando el daño con base en la ventaja de tipo.
    /// </summary>
    /// <param name="target">El Pokémon objetivo que recibirá el daño.</param>
    /// <returns>Un <see cref="AttackResult"/> con el daño causado y el estado del ataque.</returns>
    public AttackResult Use(Pokemon.Pokemon target)
    {
        ArgumentNullException.ThrowIfNull(target, nameof(target));

        double multiplier = this.Type.Advantage(target.Type);
        int damage = (int)(this.Damage * multiplier);
        target.Damage(damage);

        if (Random.Next(10) < 1)
        {
            int criticalDamage = (damage * 20) / 100;
            target.Damage(criticalDamage);
            return new AttackResult(AttackStatus.CriticalHit, criticalDamage);
        }

        return new AttackResult(AttackStatus.NormalAttack, damage);
    }

    /// <summary>
    /// Esta función se llama una vez finalizado el turno del juego y lo que hace es actualizar todo lo que deba actualizarse en cada turno.
    /// </summary>
    public virtual void UpdateTurn()
    {
    }
}
