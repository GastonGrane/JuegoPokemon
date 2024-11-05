namespace Library;

public enum PokemonType
{
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
}

public static class Calculate
{
    // FIXME: Este método actualmente asume que si el elemento defensor no está
    // listado en las ventajas del atacante, el atacante debe ser normal
    // contre ese elemento, pero podría ser valioso que sea explícito cuales
    // son normales, y si no está explicitado en ninguna lista retornar -1
    public static double Advantage(this PokemonType attacker, PokemonType defender)
    {
        PokemonType[] strong;
        PokemonType[] weak;
        PokemonType[] immune;
        switch (attacker)
        {
            case PokemonType.Water:
                strong = [PokemonType.Electric, PokemonType.Grass];
                weak = [PokemonType.Water, PokemonType.Fire, PokemonType.Ice];
                immune = [];
                break;
            case PokemonType.Bug:
                strong = [PokemonType.Fire, PokemonType.Rock, PokemonType.Flying, PokemonType.Poison];
                weak = [PokemonType.Fighting, PokemonType.Grass, PokemonType.Ground];
                immune = [];
                break;
            case PokemonType.Dragon:
                strong = [PokemonType.Dragon, PokemonType.Ice];
                weak = [PokemonType.Water, PokemonType.Electric, PokemonType.Fire, PokemonType.Grass];
                immune = [];
                break;
            case PokemonType.Electric:
                strong = [PokemonType.Ground];
                weak = [PokemonType.Flying];
                immune = [PokemonType.Electric];
                break;
            case PokemonType.Ghost:
                strong = [PokemonType.Ghost];
                weak = [PokemonType.Poison, PokemonType.Fighting, PokemonType.Normal];
                immune = [];
                break;
            case PokemonType.Fire:
                strong = [PokemonType.Water, PokemonType.Rock, PokemonType.Ground];
                weak = [PokemonType.Bug, PokemonType.Fire, PokemonType.Grass];
                immune = [];
                break;
            case PokemonType.Ice:
                strong = [PokemonType.Fire, PokemonType.Fighting, PokemonType.Rock];
                weak = [PokemonType.Ice];
                immune = [];
                break;
            case PokemonType.Fighting:
                strong = [PokemonType.Psychic, PokemonType.Flying, PokemonType.Bug, PokemonType.Rock];
                weak = [];
                immune = [];
                break;
            case PokemonType.Normal:
                strong = [PokemonType.Fighting];
                weak = [];
                immune = [PokemonType.Ghost];
                break;
            case PokemonType.Grass:
                strong = [PokemonType.Bug, PokemonType.Fire, PokemonType.Ice, PokemonType.Poison, PokemonType.Flying];
                weak = [PokemonType.Water, PokemonType.Electric, PokemonType.Grass, PokemonType.Ground];
                immune = [];
                break;
            case PokemonType.Psychic:
                strong = [PokemonType.Bug, PokemonType.Fighting, PokemonType.Ghost];
                weak = [];
                immune = [];
                break;
            case PokemonType.Rock:
                strong = [PokemonType.Water, PokemonType.Fighting, PokemonType.Grass, PokemonType.Ground];
                weak = [PokemonType.Fire, PokemonType.Normal, PokemonType.Poison, PokemonType.Flying];
                immune = [];
                break;
            case PokemonType.Ground:
                strong = [PokemonType.Water, PokemonType.Ice, PokemonType.Grass, PokemonType.Rock, PokemonType.Poison];
                weak = [PokemonType.Electric];
                immune = [];
                break;
            case PokemonType.Poison:
                strong = [PokemonType.Bug, PokemonType.Psychic, PokemonType.Ground, PokemonType.Fighting, PokemonType.Grass];
                weak = [PokemonType.Grass, PokemonType.Poison];
                immune = [];
                break;
            case PokemonType.Flying:
                strong = [PokemonType.Electric, PokemonType.Ice, PokemonType.Rock];
                weak = [PokemonType.Bug, PokemonType.Fighting, PokemonType.Grass, PokemonType.Ground];
                immune = [];
                break;
            default:
                throw new ArgumentOutOfRangeException($"El Elemento {attacker} no tiene ventajas");
        }

        if (strong.Contains(defender)) return 2.0;
        if (weak.Contains(defender)) return 0.5;
        if (immune.Contains(defender)) return 0.0;
        return 1.0;
    }
}
