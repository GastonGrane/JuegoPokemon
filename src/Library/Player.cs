namespace Library;

public class Player
{
    public string Name;
    public List<IPokemon> Pokemons;
    public IPokemon ActivePokemon;

    public Player(string name, List<IPokemon> pokemons)
    {
        this.Name = name;
        this.Pokemons = pokemons;
        this.ActivePokemon = pokemons[0];
    }

    public bool ChangePokemon(string newPokemon)
    {
        IPokemon? pokemon = this.Pokemons.Find(pokemon => pokemon.Name == newPokemon);

        if (pokemon != null)
        {
            ActivePokemon = pokemon;
            return true;
        }

        return false;
    }

    public bool Attack(Player other, string attackName)
    {
        return this.ActivePokemon.Attack(other.ActivePokemon, attackName);
    }

    public bool IsDead()
    {
        return Pokemons.All(p => p.Health == 0);
    }
}
