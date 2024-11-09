// -----------------------------------------------------------------------
// Universidad Católica del Uruguay. Programación II. Todos los derechos reservados.
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using Library.Effect;

namespace Library;

/// <summary>
/// Representa una instancia de un Pokémon, con atributos específicos y ataques disponibles.
/// </summary>
public class Pokemon
{
    private static readonly Random Random = new Random();
    private double health;
    private List<Attack> attacks;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Pokemon"/> con los valores proporcionados.
    /// </summary>
    /// <param name="name">El nombre del Pokémon.</param>
    /// <param name="type">El tipo del Pokémon.</param>
    /// <param name="maxHealth">La salud máxima del Pokémon.</param>
    /// <param name="attacks">Lista de ataques disponibles para el Pokémon.</param>
    public Pokemon(string name, PokemonType type, int maxHealth, List<Attack> attacks)
    {
        ArgumentNullException.ThrowIfNull(attacks, nameof(attacks));
        ArgumentOutOfRangeException.ThrowIfZero(attacks.Count, nameof(attacks));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(attacks.Count, 4, nameof(attacks));

        this.Name = name;
        this.Type = type;
        this.Health = maxHealth;
        this.MaxHealth = maxHealth;
        this.attacks = attacks;
        this.ActiveEffect = null;
    }

    /// <summary>
    /// Crea una copia del Pokémon, conservando sus atributos pero sin copiar su estado actual.
    /// </summary>
    /// <param name="pokemon">El Pokémon a copiar.</param>
    public Pokemon(Pokemon pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));
        this.Name = pokemon.Name;
        this.Type = pokemon.Type;
        this.Health = pokemon.Health;
        this.MaxHealth = (int)pokemon.Health;
        this.attacks = pokemon.attacks;
        this.ActiveEffect = null;
    }

    /// <summary>
    /// Efecto activo que afecta al Pokémon, como veneno o parálisis.
    /// </summary>
    public IEffect? ActiveEffect { get; set; }

    /// <summary>
    /// Nombre del Pokémon.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Tipo del Pokémon, que afecta la efectividad de los ataques.
    /// </summary>
    public PokemonType Type { get; }

    /// <summary>
    /// Salud máxima del Pokémon.
    /// </summary>
    public int MaxHealth { get; }

    /// <summary>
    /// Indica si el Pokémon puede atacar en su turno.
    /// </summary>
    public bool CanAttack { get; set; }

    /// <summary>
    /// Salud actual del Pokémon.
    /// </summary>
    public double Health
    {
        get { return (int)this.health; }
        private set
        {
            if (value > this.MaxHealth && this.MaxHealth != 0)
                this.health = this.MaxHealth;
            else if (value < 0)
                this.health = 0;
            else
                this.health = value;
        }
    }

    /// <summary>
    /// Lista de ataques disponibles para el Pokémon.
    /// </summary>
    public ReadOnlyCollection<Attack> Attacks => this.attacks.AsReadOnly();

    /// <summary>
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el índice especificado.
    /// </summary>
    /// <param name="target">Pokémon objetivo del ataque.</param>
    /// <param name="attackIdx">Índice del ataque en la lista de ataques del Pokémon.</param>
    public void Attack(Pokemon target, int attackIdx)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackIdx);
        this.Attack(target, attack);
    }

    /// <summary>
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el nombre del ataque especificado.
    /// </summary>
    /// <param name="target">Pokémon objetivo del ataque.</param>
    /// <param name="attackName">Nombre del ataque a utilizar.</param>
    public void Attack(Pokemon target, string attackName)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackName);
        this.Attack(target, attack);
    }

    /// <summary>
    /// Suma un valor a la salud actual del Pokémon.
    /// </summary>
    /// <param name="health">Cantidad de salud a añadir.</param>
    public void Heal(int health)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(health, nameof(health));
        this.Health += health;
    }

    /// <summary>
    /// Aplica daño al Pokémon, reduciendo su salud. El daño mínimo permitido es 5.
    /// </summary>
    /// <param name="damage">Cantidad de daño a aplicar. Debe ser 5 o mayor.</param>
    public void Damage(double damage)
    {
        if (damage < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(damage), "El daño debe ser mayor a 5.");
        }

        this.Health -= damage;
    }

    /// <summary>
    /// Aplica un efecto al Pokémon si no tiene un efecto activo.
    /// </summary>
    /// <param name="effect">Efecto a aplicar.</param>
    public void ApplyEffect(IEffect effect)
    {
        if (this.ActiveEffect != null)
        {
            throw new InvalidOperationException(
                "El Pokémon ya tiene un efecto activo. No se puede aplicar otro efecto hasta que el actual expire.");
        }
        else
        {
            this.ActiveEffect = effect;
        }
    }

    /// <summary>
    /// Actualiza el efecto activo del Pokémon en cada turno y lo elimina si ha expirado.
    /// </summary>
    public void UpdateEffect()
    {
        this.ActiveEffect?.UpdateEffect(this);
        if (this.ActiveEffect != null && this.ActiveEffect.IsExpired)
        {
            this.RemoveEffect();
        }
    }

    /// <summary>
    /// Elimina el efecto activo del Pokémon, si existe.
    /// </summary>
    public void RemoveEffect()
    {
        this.ActiveEffect?.RemoveEffect(this);
        this.ActiveEffect = null;
    }

    /// <summary>
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el ataque especificado.
    /// </summary>
    /// <param name="target">Pokémon objetivo del ataque.</param>
    /// <param name="attack">Ataque a utilizar.</param>
    private bool Attack(Pokemon target, Attack attack)
    {
        if (!this.Attacks.Contains(attack))
        {
            throw new ArgumentOutOfRangeException($"Este pokemon no tiene el ataque {attack.Name}");
        }

        if (Random.Next(100) < attack.Precision)
        {
            attack.Use(this);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Retorna el ataque correspondiente al nombre especificado.
    /// </summary>
    /// <param name="attackName">Nombre del ataque.</param>
    private Attack GetAttack(string attackName)
    {
        if (this.Attacks.Count == 0)
        {
            throw new InvalidOperationException("Un pokemon sin ataques no puede atacar");
        }

        Attack attack;
        try
        {
            attack = this.Attacks.First(attack => attack.Name == attackName);
        }
        catch (InvalidOperationException)
        {
            throw new ArgumentOutOfRangeException(
                nameof(attackName),
                "El nombre de ataque no se encuentra en la lista de ataques");
        }

        return attack;
    }

    /// <summary>
    /// Retorna el ataque correspondiente al índice especificado.
    /// </summary>
    /// <param name="attackIdx">Índice del ataque.</param>
    private Attack GetAttack(int attackIdx)
    {
        if (this.Attacks.Count == 0)
        {
            throw new InvalidOperationException("Un pokemon sin ataques no puede atacar");
        }

        if (attackIdx >= this.Attacks.Count || attackIdx < 0)
        {
            throw new ArgumentOutOfRangeException($"El índice del ataque no está entre 0..{this.Attacks.Count}");
        }

        return this.Attacks[attackIdx];
    }
}
