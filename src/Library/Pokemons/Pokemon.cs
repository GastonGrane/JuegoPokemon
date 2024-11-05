using System.Linq.Expressions;

namespace Library;

public abstract class Pokemon
{
    public string Name { get; set; }
    public PokemonType Type { get; }
    private double _health;
    public double Health
    {
        get { return _health; }
        set
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
    public double MaxHealth { get; }
    public List<Attack> Attacks { get; }

    protected Pokemon(string name, PokemonType type, int maxHealth, List<Attack> attacks)
    {
        this.Name = name;
        this.Type = type;
        this.Health = maxHealth;
        this.MaxHealth = maxHealth;
        this.Attacks = attacks;
    }

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

    public void Attack(Pokemon target, int attackIdx)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackIdx);
        Attack(target, attack);
    }


    public void Attack(Pokemon target, string attackName)
    {
        ArgumentNullException.ThrowIfNull(target, "No se puede atacar un pokemon que es null");
        Attack attack = this.GetAttack(attackName);
        Attack(target, attack);
    }

    public void Curar(int health)
    {
        try
        {
            if (health < 0)
            {
                throw new NegativeHealthException("No se puede curar con un valor negativo.");
            }
        }
        catch
        {
            
        }

        this.Health = health;
    }

    public class NegativeHealthException : Exception
    {
        public NegativeHealthException(string message) : base(message)
        {
            //
        }
    }
}