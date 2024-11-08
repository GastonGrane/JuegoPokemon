namespace Library
{
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
        private double _health;

        /// <summary>
        /// Representa un efecto activo que afecta al Pokémon, como veneno, paralización, etc.
        /// </summary>
        public IEffect ActiveEffect;

        /// <summary>
        /// Indica si el Pokémon puede atacar en su turno.
        /// </summary>
        public bool CanAttack { get; set; }

        /// <summary>
        /// Propiedad de solo lectura que representa la salud máxima del pokemon.
        /// </summary>
        public double MaxHealth { get; }

        /// <summary>
        /// Propiedad que obtiene y establece la salud actual del pokemon.
        /// La settear la vida se ajusta automáticamente para que esté dentro del rango de 0 a <see cref="MaxHealth"/>:
        /// - Si el valor excede al de <paramref name="MaxHealth"/>, se establece el valor correspondiente al de <paramref name="MaxHealth"/>.
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
        /// Esta función retorna el ataque correspondiente al string que recibe como parámetro.
        /// </summary>
        /// <param name="attackName">
        /// Nombre del ataque al cual se quiere acceder.
        /// </param>
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
        /// <exception cref="InvalidOperationException">
        /// Lanzada si el Pokémon no tiene ataques disponibles.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Lanzada si el índice <paramref name="attackIdx"/> está fuera del rango permitido (0 a <see cref="Attacks.Count"/> - 1).
        /// </exception>
        public void Attack(Pokemon target, int attackIdx)
        {
            if (this.CanAttack == true)
            {
                ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
                Attack attack = this.GetAttack(attackIdx);
                Attack(target, attack);
            }
            UpdateEffect();
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
            if (this.CanAttack == true)
            {
                ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
                Attack attack = this.GetAttack(attackName);
                Attack(target, attack);
            }
           UpdateEffect();
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
            if (health < 0)
            {
                throw new ArgumentOutOfRangeException("No se puede curar con un valor negativo.");
            }

            this.Health += health;
        }

        /// <summary>
        /// Inflige daño al Pokémon, reduciendo su salud en la cantidad especificada.
        /// </summary>
        /// <param name="health">Cantidad de salud a restar al Pokémon.</param>
        /// <exception cref="ArgumentOutOfRangeException">Lanzada si el valor recibido <paramref name="health"/> es negativo.</exception>
        public void Damage(int health)
        {
            if (health < 0)
            {
                throw new ArgumentOutOfRangeException("No se puede Dañar con un valor negativo.");
            }

            this.Health -= health;
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
            if (ActiveEffect != null)
            {
                throw new InvalidOperationException("El Pokémon ya tiene un efecto activo. No se puede aplicar otro efecto hasta que el actual expire.");
            }
            else
            {
                ActiveEffect = effect;
            }
        }

        /// <summary>
        /// Actualiza el efecto activo del Pokémon en cada turno. Si el efecto ha expirado, lo elimina.
        /// </summary>
        public void UpdateEffect()
        {
            ActiveEffect?.UpdateEffect(this);

            if (ActiveEffect != null && ActiveEffect.IsExpired)
            {
                RemoveEffect();
            }
        }

        /// <summary>
        /// Elimina el efecto activo del Pokémon, si existe.
        /// </summary>
        public void RemoveEffect()
        {
            ActiveEffect?.RemoveEffect(this);
            ActiveEffect = null;
        }
    }
}
