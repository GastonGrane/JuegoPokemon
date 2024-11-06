namespace Library;

/// <summary>
/// Representa una clase base abstracta para atacar en el juego, nos da las propiedades esenciales que definen las caracteristicas de cada ataque
/// </summary>
/// <remarks>
/// La clase <see cref="Attack"/> sirve como base para varios tipos de ataques especificos , 
/// tal como <see cref="NormalAttack"/>. Cada uno deellos tiene un nombre, danio y
/// <see cref="PokemonType"/> que influencia en la efectividad del ataque conforme al tipo del contrincantre.
/// </remarks>
public abstract class Attack
{
    /// <summary>
    /// Retorna el nombre del ataque
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Retorna el valor de danio del ataque
    /// </summary>
    public int Damage { get; }

    /// <summary>
    /// Retorna el tipo de ataque, que va a determinar si es eficaz el ataque
    /// </summary>
    /// <value> Un <see cref="PokemonType"/> representa el tipo elemental del ataque
    /// </value>
    public PokemonType Type { get; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Attack"/>
    /// </summary>
    /// <param name="name">Nombre del ataque</param>
    /// <param name="damage">EL danio del ataque que puede generar</param>
    /// <param name="type">El tipo de ataque, que afecta los enfrentamientos de tipos distintos</param>
    protected Attack(string name, int damage, PokemonType type)
    {
        this.Name = name;
        this.Damage = damage;
        this.Type = type;
    }
}