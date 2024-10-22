namespace Library;

public class Player
{
    public string Name;
    public List<Pokemon> Pokemons;
    public Pokemon ActivePokemon;

    public Player(string name, List<Pokemon> pokemons)
    {
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
        this.ActivePokemon.Attack(other.ActivePokemon, attackName);
    }

    public bool IsDead()
    {
        return Pokemons.All(p => p.Health == 0);
    }
}
