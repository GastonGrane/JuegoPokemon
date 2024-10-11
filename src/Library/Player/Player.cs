namespace DefaultNamespace
{
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

        public void ChangePokemon(string newPokemon)
        {
            IPokemon? pokemon = this.Pokemons.Find(pokemon => pokemon.Name == newPokemon);
            if (pokemon != null)
            {
                ActivePokemon = pokemon;
            }
            else
            {
                return;
            }
        }
    }
}