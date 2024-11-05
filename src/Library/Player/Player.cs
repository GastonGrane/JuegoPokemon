namespace Library;

public class Player
{
    public string Name { get; }
    public List<Pokemon> Pokemons { get; }
    public Pokemon ActivePokemon { get; private set; }

    public Player(string name, List<Pokemon> pokemons)
    {
        ArgumentNullException.ThrowIfNull(pokemons, "Un jugador no puede tener una lista de pokemons null");
        this.Name = name;
        this.Pokemons = pokemons;
        this.ActivePokemon = pokemons[0];
    }

    public bool ChangePokemon(string newPokemon)
    {
        Pokemon? pokemon = this.Pokemons.Find(pokemon => pokemon.Name == newPokemon);

        if (pokemon != null)
        {
            ActivePokemon = pokemon;
            return true;
        }

        return false;
    }

    public void Attack(Player other, string attackName)
    {
        ArgumentNullException.ThrowIfNull(other, "No se puede atacar un jugador que es null");
        this.ActivePokemon.Attack(other.ActivePokemon, attackName);
    }

    public bool IsDead()
    {
        return Pokemons.All(p => p.Health == 0);
    }
}
