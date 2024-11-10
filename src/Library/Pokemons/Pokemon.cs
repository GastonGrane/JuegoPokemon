// -----------------------------------------------------------------------
// <copyright file="Pokemon.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using Library.Effect;

namespace Library;

/// <summary>
/// Crea instancias de los distintos pokemons.
/// En esta clase podemos notar el encapsulamiento, donde **Health** y las lista de ataques **Attacks** estan
/// protegidas. Las clases proporcionan un acceso a estos solo a traves de propiedas o metodos, esto ayuda a controlar
/// la validacion de los mismos.
/// </summary>
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
    private double health;

    /// <summary>
    /// Lista de los distintos ataques con los que cuenta el pokemon.
    ///
    /// El acceso a este valor será controlado por la propiedad <see cref="Attacks"/>.
    /// </summary>
    private List<Attack> attacks;

    /// <summary>
    /// Crea un pokemon con los valores provistos.
    ///
    /// El Pokemon empieza con su vida siendo su total.
    /// </summary>
    /// <param name="name">El nombre del Pokemon.</param>
    /// <param name="type">El tipo del Pokemon.</param>
    /// <param name="maxHealth">La vida máxima del Pokemon. Esta también será su vida inicial.</param>
    /// <param name="attacks">La lista de sus ataques.</param>
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
    /// Representa un efecto activo que afecta al Pokémon, como veneno, paralización, etc.
    /// </summary>
    public IEffect? ActiveEffect { get; set; }

    /// <summary>
    /// El nombre del Pokemon. Esto es visible al usuario y sirve para diferenciar a los distintos pokemones en su lista.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Determina de qué tipo será este pokemon. Esto afecta las ventajas al momento de recibir ataques.
    /// </summary>
    public PokemonType Type { get; }

    /// <summary>
    /// Propiedad de solo lectura que representa la salud máxima del pokemon.
    /// </summary>
    public double MaxHealth { get; }

    /// <summary>
    /// Indica si el Pokémon puede atacar en su turno.
    /// </summary>
    public bool CanAttack { get; set; }

    /// <summary>
    /// Propiedad que obtiene y establece la salud actual del pokemon.
    /// La settear la vida se ajusta automáticamente para que esté dentro del rango de 0 a <see cref="MaxHealth"/>:
    /// - Si el valor excede al de <see cref="MaxHealth"/>, se establece el valor correspondiente al de <see cref="MaxHealth"/>.
    /// - Si el valor es menor que 0, se establece en 0.
    /// - De lo contrario, se asigna el valor directamente.
    /// </summary>
    public double Health
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
    /// Lista de los distintos ataques con los que cuenta el pokemon.
    /// </summary>
    public ReadOnlyCollection<Attack> Attacks
    {
        get { return this.attacks.AsReadOnly(); }
    }

    /// <summary>
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el índice especificado para acceder al ataque.
    /// </summary>
    /// <param name="target">El Pokémon objetivo al que se le aplicará el ataque.</param>
    /// <param name="attackIdx">El índice del ataque en la lista de ataques del Pokémon.</param>
    /// <exception cref="ArgumentNullException">
    /// Lanzada si el Pokémon objetivo <paramref name="target"/> es <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Lanzada si el Pokémon no tiene ataques disponibles.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el índice <paramref name="attackIdx"/> está fuera del rango permitido ([0,(cant. ataques - 1)]).
    /// </exception>
    public void Attack(Pokemon target, int attackIdx)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackIdx);
        this.Attack(target, attack);
    }

    /// <summary>
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el nombre del ataque especificado.
    /// </summary>
    /// <param name="target">El Pokémon objetivo al que se le aplicará el ataque.</param>
    /// <param name="attackName">El nombre del ataque que se usará para realizar el daño.</param>
    /// <exception cref="ArgumentNullException">
    /// Lanzada si el Pokémon objetivo <paramref name="target"/> es <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Lanzada si el Pokémon no tiene ataques disponibles.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el nombre <paramref name="attackName"/> no se encuentra en la lista de ataques.
    /// </exception>
    public void Attack(Pokemon target, string attackName)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackName);
        this.Attack(target, attack);
    }

    /// <summary>
    /// Suma un valor especificado a la vida que ya tiene el pokemon.
    /// </summary>
    /// <param name="health">La cantidad de vida que se le suma a la vida actual del Pokémon.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el valor recibido <paramref name="health"/> es menor que 0.
    /// </exception>
    public void Heal(int health)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(health, nameof(health));

        this.Health += health;
    }

    /// <summary>
    /// Aplica daño al Pokémon, reduciendo su salud. El daño mínimo permitido es 5.
    /// Si el valor de daño es menor que 5, se lanzará una excepción.
    /// </summary>
    /// <param name="damage">La cantidad de daño a aplicar. Debe ser 5 o mayor.</param>
    /// <exception cref="ArgumentOutOfRangeException">Se lanza si el daño es menor que 5.</exception>
    public void Damage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage), "El daño debe ser mayor a 0.");
        }

        this.Health -= damage;
    }

    /// <summary>
    /// Aplica un efecto al Pokémon. Si ya existe un efecto activo, lanza una excepción y no se aplica el nuevo efecto.
    /// </summary>
    /// <param name="effect">El efecto que se intentará aplicar al Pokémon.</param>
    /// <exception cref="InvalidOperationException">
    /// Se lanza si el Pokémon ya tiene un efecto activo y se intenta aplicar un nuevo efecto antes de que el actual expire.
    /// </exception>
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
    /// Actualiza el efecto activo del Pokémon en cada turno. Si el efecto ha expirado, lo elimina.
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
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el ataque especificado, siempre y cuando pueda atacar.
    /// </summary>
    /// <param name="target">Pokémon objetivo al que se le aplicará el ataque.</param>
    /// <param name="attack">El ataque que se usará para realizar el daño.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el ataque especificado no se encuentra dentro de la lista <see cref="Attacks"/> del Pokémon que ataca.
    /// </exception>
    private void Attack(Pokemon target, Attack attack)
    {
        if (!this.Attacks.Contains(attack))
        {
            throw new ArgumentOutOfRangeException($"Este pokemon no tiene el ataque {attack.Name}");
        }

        if (Random.Next(100) < attack.Precision)
        {
            PokemonType attacker = attack.Type;
            PokemonType defender = target.Type;
            double multiplier = attacker.Advantage(defender);
            int damage = (int)(attack.Damage * multiplier);
            if (!this.CanAttack)
            {
                target.Health -= damage;

                // esto equivale al 10%
                if (Random.Next(10) < 1)
                {
                    target.Health -= (damage * 20) / 100;
                }

                this.UpdateEffect();
            }
        }
    }

    /// <summary>
    /// Esta función retorna el ataque correspondiente al string que recibe como parámetro.
    /// </summary>
    /// <param name="attackName">
    /// Nombre del ataque al cual se quiere acceder.
    /// </param>
    /// <returns>El ataque cuyo nombre es el nombre pasado.</returns>
    /// <exception cref="InvalidOperationException">
    /// Lanzada si el Pokémon no tiene ataques disponibles.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el nombre <paramref name="attackName"/> no se encuentra en la lista de ataques.
    /// </exception>
    private Attack GetAttack(string attackName)
    {
        // FIXME (Gaston): Este if me parece innecesario, ya que no se pueden crear pokemons sin ataques
        if (this.Attacks.Count == 0)
        {
            throw new InvalidOperationException("Un pokemon sin ataques no puede atacar");
        }

        // FIXME: Esto debería comparar así nomás, o se tendría que normalizar acá, o antes?
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
    /// Retorna el ataque correspondiente al valor que recibe como parámetro.
    /// </summary>
    /// <param name="attackIdx">
    /// Corresponde al valor del indice del ataque al cual se quiere acceder.
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