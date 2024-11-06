namespace Library;

public interface IPrint
{
    public void printList(List<Pokemon> list);
    public void printString(string str);
    public int printStringAndReceiveInt(string str);
    public void PrintListAtaque(List<Attack> ataques);
    public int SelectAtaque(string str);

}