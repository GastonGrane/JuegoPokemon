// -----------------------------------------------------------------------
// <copyright file="Pokemon.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using Library.GameLogic.Attacks;
using Library.GameLogic.Effects;

namespace Library.GameLogic.Pokemon;

/// <summary>
/// Representa una instancia de un Pokémon, con atributos específicos y ataques disponibles.
/// </summary>
/// <remarks>
/// En esta clase podemos notar el encapsulamiento, donde **Health** y las lista de ataques **Attacks** estan
/// protegidas. Las clases proporcionan un acceso a estos solo a traves de propiedas o metodos, esto ayuda a controlar
/// la validacion de los mismos.
/// Además, se puede ver DIP (Dependency Inversion Principle), ya que esta clase depende de la clase abstracta "Attack", y no de ninguna implementación
/// concreta, así permitiendo que sea más reutilizable, ya que al agregar tipos de ataques nuevos, estos funcionarán sin modificar esta clase.
/// </remarks>
public class Pokemon
{
    /// <summary>
    /// Generador de random que ayuda a determinar la precision del ataque y si el mismo es critico o no.
    /// </summary>
    // Nota de Guzmán: Habría que mockear esto? Sí. Lo voy a hacer? No.
    private static readonly Random Random = new Random();

    /// <summary>
    /// El valor actual de salud del pokemon.
    ///
    /// El acceso a este valor será controlado por la propiedad <see cref="Health"/>.
    /// </summary>
    private int health;

    /// <summary>
    /// Lista de los distintos ataques con los que cuenta el pokemon.
    ///
    /// El acceso a este valor será controlado por la propiedad <see cref="Attacks"/>.
    /// </summary>
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
        this.CanAttack = true;
    }

    /// <summary>
    /// Crea una copia del Pokémon, conservando sus atributos pero sin copiar su estado actual.
    /// </summary>
    /// <param name="pokemon">El Pokémon a clonar.</param>
    /// <exception cref="ArgumentNullException">
    /// Si <paramref name="pokemon"/> es <c>null</c>.
    /// </exception>
    /// <remarks>
    /// No copia el efecto, porque la idea es no copiar su estado actual.
    /// </remarks>
    public Pokemon(Pokemon pokemon)
    {
        ArgumentNullException.ThrowIfNull(pokemon, nameof(pokemon));

        this.Name = pokemon.Name;
        this.Type = pokemon.Type;
        this.Health = pokemon.Health;
        this.MaxHealth = pokemon.Health;
        this.attacks = pokemon.attacks;
        this.ActiveEffect = null;
        this.CanAttack = true;
    }

    /// <summary>
    /// Efecto activo que afecta al Pokémon, como veneno, parálisis, etc.
    /// </summary>
    public IEffect? ActiveEffect { get; private set; }

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
    public int Health
    {
        get
        {
            return this.health;
        }

        private set
        {
            if (value > this.MaxHealth && this.MaxHealth != 0)
            {
                this.health = this.MaxHealth;
            }
            else if (value < 0)
            {
                this.health = 0;
            }
            else
            {
                this.health = value;
            }
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
    /// <returns>Un <see cref="AttackResult"/> que contiene información sobre el resultado del ataque, incluyendo el daño causado y el estado del ataque.</returns>
    public AttackResult? Attack(Pokemon target, string attackName)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackName);
        AttackResult? attackResult = this.Attack(target, attack);
        return attackResult;
    }

    /// <summary>
    /// Suma un valor a la salud actual del Pokémon.
    /// </summary>
    /// <param name="amount">Cantidad de salud a añadir.</param>
    public void Heal(int amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount, nameof(amount));
        this.Health += amount;
    }

    /// <summary>
    /// Aplica daño al Pokémon, reduciendo su salud. El daño mínimo permitido es 0.
    /// </summary>
    /// <param name="damage">Cantidad de daño a aplicar. Debe ser mayor a 0.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Si <paramref name="damage"/> es menor a 0.
    /// </exception>
    public void Damage(int damage)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(damage, 0, nameof(damage));

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
    /// <param name="target">Pokémon objetivo al que se le aplicará el ataque.</param>
    /// <param name="attack">El ataque que se usará para realizar el daño.</param>
    /// <returns>
    /// <c>true</c> si la precision del ataque fue exitoso y el daño fue aplicado al Pokémon objetivo;
    /// <c>false</c> si el ataque falló.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el ataque especificado no se encuentra dentro de la lista <see cref="Attacks"/> del Pokémon que ataca.
    /// </exception>
    private AttackResult? Attack(Pokemon target, Attack attack)
    {
        if (!this.Attacks.Contains(attack))
        {
            throw new ArgumentOutOfRangeException($"Este pokemon no tiene el ataque {attack.Name}");
        }

        if (!this.CanAttack)
        {
            return new AttackResult(AttackStatus.HinderingEffect, 0);
        }

        if (Random.Next(100) < attack.Precision)
        {
           AttackResult? attackResult = attack.Use(target);
           return attackResult;
        }

        this.UpdateEffect();
        return new AttackResult(AttackStatus.Miss, 0);
    }

    /// <summary>
    /// Retorna el ataque correspondiente al nombre especificado.
    /// </summary>
    /// <param name="attackName">
    /// El nombre del ataque al cual se quiere acceder.
    /// </param>
    /// <returns>El ataque correspondiente al nombre provisto.</returns>
    /// <exception cref="InvalidOperationException">
    /// Lanzada si el Pokémon no tiene ataques disponibles.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si <paramref name="attackName"/> no es el nombre de ningún ataque.
    /// </exception>
    private Attack GetAttack(string attackName)
    {
        // FIXME (Gaton): Este if me parece innecesario, ya que no se pueden crear pokemons sin ataques
        if (this.Attacks.Count == 0)
        {
            throw new InvalidOperationException("Un pokemon sin ataques no puede atacar");
        }

        Attack attack;
        try
        {
            attack = this.Attacks.First(attack1 => attack1.Name == attackName);
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
    /// <param name="attackIdx">
    /// Índice del ataque en la lista de ataques.
    /// </param>
    /// <returns>El ataque correspondiente al índice provisto.</returns>
    /// <exception cref="InvalidOperationException">
    /// Lanzada si el Pokémon no tiene ataques disponibles.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el índice <paramref name="attackIdx"/> está fuera del rango permitido (0-(cant. ataques - 1)).
    /// </exception>
    private Attack GetAttack(int attackIdx)
    {
        // FIXME (Gaston): Este if me parece innecesario, ya que no se pueden crear pokemons sin ataques
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
