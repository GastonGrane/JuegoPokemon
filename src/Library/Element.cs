namespace Library;

public enum Element
{
    Fire,
    Water,
    Grass,
    Electric,
}

public static class Calculate
{
    public static double Advantage(this Element attacker, Element defender)
    {
        // FIXME: Hay manera más linda de hacer esto? Probablemente, pero ahora no quiero pensar
        // N.B: Esto está totalmente inventado, para la próxima entrega esta tabla será prevista
        switch (attacker)
        {
            case Element.Fire:
                switch (defender)
                {
                    case Element.Fire:
                        return 1.0;
                    case Element.Water:
                        return 0.5;
                    case Element.Grass:
                        return 2.0;
                    case Element.Electric:
                        return 1.0;
                }
                break;
            case Element.Water:
                switch (defender)
                {
                    case Element.Fire:
                        return 2.0;
                    case Element.Water:
                        return 1.0;
                    case Element.Grass:
                        return 1.0;
                    case Element.Electric:
                        return 0.5;
                }
                break;
            case Element.Grass:
                switch (defender)
                {
                    case Element.Fire:
                        return 0.5;
                    case Element.Water:
                        return 1.0;
                    case Element.Grass:
                        return 1.0;
                    case Element.Electric:
                        return 1.0;
                }
                break;
            case Element.Electric:
                switch (defender)
                {
                    case Element.Fire:
                        return 1.0;
                    case Element.Water:
                        return 2.0;
                    case Element.Grass:
                        return 2.0;
                    case Element.Electric:
                        return 1.0;
                }
                break;

        }
        return -1.0;
    }
}
