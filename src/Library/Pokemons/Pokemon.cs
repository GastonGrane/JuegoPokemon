// -----------------------------------------------------------------------
// <copyright file="Pokemon.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Crea instancias de los distintos pokemons.
/// </summary>
public class Pokemon
{
    /// <summary>
    /// El nombre del Pokemon. Esto es visible al usuario y sirve para diferenciar a los distintos pokemones en su lista.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Determina de qué tipo será este pokemon. Esto afecta las ventajas al momento de recibir ataques.
    /// </summary>
    public PokemonType Type { get; }

    /// <summary>
    /// Se almacena el valor actual de salud del pokemon en un campo privado.
    /// </summary>
    private double health;

    /// <summary>
    /// Propiedad de solo lectura que representa la salud máxima del pokemon.
    /// </summary>
    public double MaxHealth { get; }

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
    /// Lista donde se establecerán los distintos ataques con los que contará el pokemon.
    /// </summary>
    public List<Attack> Attacks { get; }

    public Pokemon(string name, PokemonType type, int maxHealth, List<Attack> attacks)
    {
        this.Name = name;
        this.Type = type;
        this.Health = maxHealth;
        this.MaxHealth = maxHealth;
        this.Attacks = attacks;
    }

    /// <summary>
    /// Esta funcion retorna el ataque correspondiente al valor que recibe como parámetro.
    /// </summary>
    /// <param name="attackIdx">
    /// Corresponde al valor del indice del ataque al cual se quiere acceder.
    /// </param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    /// Lanzada si el Pokémon no tiene ataques disponibles.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el índice <paramref name="attackIdx"/> está fuera del rango permitido (0 a <see cref="Attacks.Count"/> - 1).
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
        if (this.Attacks.Count == 0)
        {
            throw new InvalidOperationException("Un pokemon sin ataques no puede atacar");
        }

        // FIXME: Esto debería comparar así nomás, o se tendría que normalizar acá, o antes?
        Attack? attack = this.Attacks.Find(attack => attack.Name == attackName);
        if (attack == null)
        {
            throw new ArgumentOutOfRangeException($"El nombre de ataque no se encuentra en la lista de ataques");
        }

        return attack;
    }

    /// <summary>
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el ataque especificado.
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

        PokemonType attacker = attack.Type;
        PokemonType defender = target.Type;

        double multiplier = attacker.Advantage(defender);
        double damage = attack.Damage * multiplier;
        target.Health -= damage;
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
    /// Lanzada si el índice <paramref name="attackIdx"/> está fuera del rango permitido (0 a <see cref="Attacks.Count"/> - 1).
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
    public void Curar(int health)
    {
        if (health < 0)
        {
            throw new ArgumentOutOfRangeException("No se puede curar con un valor negativo.");
        }

        this.Health += health;
    }
}
