namespace DefaultNamespace;

public enum Element
{
    Fire,
    Water,
    Grass,
    Electric,
}

public class Calculate
{
    public static double Advantage(Element attacker, Element defender)
    {
        if (attacker == Element.Fire && defender == Element.Water)
        {
            return 2.0;
        }
        else if (attacker == Element.Water && defender == Element.Electric)
        {
            return 2.0;
        }
        else if (attacker == Element.Electric && defender == Element.Grass)
        {
            return 2.0;
        }
        else if (attacker == Element.Grass && defender == Element.Fire)
        {
            return 2.0;
        }
        else if (attacker == Element.Water && defender == Element.Fire)
        {
            return 0.5;
        }
        else if (attacker == Element.Electric && defender == Element.Water)
        {
            return 0.5;
        }
        else if (attacker == Element.Grass && defender == Element.Electric)
        {
            return 0.5;
        }
        else if (attacker == Element.Fire && defender == Element.Grass)
        {
            return 0.5;
        }
        else
        {
            return 0;
        }
    }
}
