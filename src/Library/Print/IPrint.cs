namespace Library;

public interface IPrint
{
    public static abstract void printList(List<Pokemon> list);
    public static abstract void printString(string str);
    public static abstract int printStringAndReceiveInt(string str);
    public static abstract void PrintListAtaque(List<Attack> ataques);
    public static abstract int SelectAtaque(string str);

}