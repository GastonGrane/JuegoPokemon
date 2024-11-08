namespace Library;

public interface IExternalConection
{
    public void printList(List<Pokemon> list);
    public void printString(string str);
    public int printStringAndReceiveInt(string str);
    public void PrintListAtaque(List<Attack> ataques);
    public int SelectAtaque(string str);
    public void selecYourPokemon(Player player, List<Pokemon> Pokemons);
    public void availableAttack(Player active, Player other, int turno);

}