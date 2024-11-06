namespace Library;
/// <summary>
/// Crea instancias de los distintos pokemons. 
/// </summary>
public class Pokemon
{
    /// <summary>
    /// El nombre del Pokemon. Esto es visible al usuario y sirve para diferencia los distintos Pokemons en la lista de cada jugador
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Se determina de qué tipo será este pokemon. Lo cual posteriormente será evaluado al momento de ser atacado.
    /// </summary>
    public PokemonType Type { get; }
    /// <summary>
    /// Se almacena el valor actual de salud del pokemon en un campo privado.
    /// </summary>
    private double _health;
    /// <summary>
    /// Propiedad de solo lectura que representa la salud máxima del pokemon.
    /// </summary>
    public double MaxHealth { get; }
    /// <summary>
    /// Propiedad que obtiene y establece la salud actual del pokemon.
    /// La salud se ajusta automáticamente para que esté dentro del rango de 0 a <see cref="MaxHealth"/>:
    /// - Si el valor excede al de <paramref name="MaxHealth">, se establece el valor correspondiente al de <paramref name="MaxHealth">.
    /// - Si el valor es menor que 0, se establece en 0.
    /// - De lo contrario, se asigna el valor directamente.
    /// </summary>
    public double Health
    {
        get { return _health; }
        private set
        {
            if (value > MaxHealth && MaxHealth != 0)
            {
                _health = MaxHealth;
            }
            else if (value < 0)
            {
                _health = 0;
            }
            else
            {
                _health = value;
            }
        }
    }
    /// <summary>
    /// Se crea la lista donde se estableceran los distintos ataques con los que contará el pokemon.
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
/// El método recibe un int correspondiente al indice del ataque que desea utilizar dentro de la <see cref="Attacks "/>.
/// </summary>
/// <param name="attackIdx"></param> Corresponde al valor del indice del ataque al cual se quiere acceder.
/// <returns></returns>
/// <exception cref="InvalidOperationException"></exception>
/// Lanzada si el Pokémon no tiene ataques disponibles.
/// <exception cref="ArgumentOutOfRangeException"></exception>
/// Lanzada si el índice <paramref name="attackIdx"/> está fuera del rango permitido (0 a <see cref="Attacks.Count"/> - 1).
    private Attack GetAttack(int attackIdx)
    {
        if (Attacks.Count == 0)
        {
            throw new InvalidOperationException("Un pokemon sin ataques no puede atacar");
        }

        if (attackIdx >= Attacks.Count || attackIdx < 0)
        {
            throw new ArgumentOutOfRangeException($"El índice del ataque no está entre 0..{Attacks.Count}");
        }
        return Attacks[attackIdx];
    }
    /// <summary>
    /// El método recibe un string correspondiente al nombre del ataque que se encuentra dentro de la lista <see cref="Attacks"/>.
    /// </summary>
    /// <param name="attackName"></param> Nombre del ataque al cual se quiere acceder.
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    /// Lanzada si el Pokémon no tiene ataques disponibles.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el nombre <paramref name="attackName"/> no se encuentra en la lista de ataques.
    /// </exception>
    private Attack GetAttack(string attackName)
    {
        if (Attacks.Count == 0)
        {
            throw new InvalidOperationException("Un pokemon sin ataques no puede atacar");
        }

        // FIXME: Esto debería comparar así nomás, o se tendría que normalizar acá, o antes?
        Attack? attack = Attacks.Find(attack => attack.Name == attackName);
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
        double damage = (attack.Damage * multiplier);
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
    public void Attack(Pokemon target, int attackIdx)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackIdx);
        Attack(target, attack);
    }

    /// <summary>
    /// Realiza un ataque sobre el Pokémon objetivo utilizando el nombre del ataque especificado.
    /// </summary>
    /// <param name="target">El Pokémon objetivo al que se le aplicará el ataque.</param>
    /// <param name="attackName">El nombre del ataque que se usará para realizar el daño.</param>
    /// <exception cref="ArgumentNullException">
    /// Lanzada si el Pokémon objetivo <paramref name="target"/> es <c>null</c>.
    /// </exception>
    public void Attack(Pokemon target, string attackName)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackName);
        Attack(target, attack);
    }
    /// <summary>
    /// Restaura la salud del Pokémon a un valor especificado.
    /// </summary>
    /// <param name="health">La cantidad de salud a la que se restaurará el Pokémon.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanzada si el valor de salud <paramref name="health"/> es menor que 0.
    /// </exception>
    public void Curar(int health)
    {
        if (health < 0)
        {
            throw new ArgumentOutOfRangeException("No se puede curar con un valor negativo.");
        }
        this.Health = health;
    }
}