namespace Library;

/// <summary>
/// Enumera los diferentes tipos de Pokemon, cada uno con una cierta ventaja y desventaja sobre otro tipo
/// </summary>
public enum PokemonType
{
    /// <summary>
    /// Sin ventajas ni desvenjatas
    /// </summary>
    Normal,

    /// <summary>
    /// Fuerte contra **Grass**, debil contra **Water**
    /// </summary>
    Fire,

    /// <summary>
    /// Fuerte contra **Fire**, debil contra **Electric** y **Grass**
    /// </summary>
    Water,

    /// <summary>
    /// Fuerte contra **Water** y **Flying**, debil contra **Ground*
    /// </summary>
    Electric,

    /// <summary>
    /// Fuerte contra **Water** y **Ground**, debil contra **Fire**, **Flying** y **Bug**
    /// </summary>
    Grass,

    /// <summary>
    /// Fuerte contra **Dragon**, debil contra **Fire** y **Rock**
    /// </summary>
    Ice,

    /// <summary>
    /// Fuerte contra **Normal** y **Rock**, debil contra **Psychic** y **Flying**
    /// </summary>
    Fighting,

    /// <summary>
    /// Fuerte contra **Grass**, debil contra **Psychic**
    /// </summary>
    Poison,

    /// <summary>
    /// Fuerte contra **Electric**, debil contra **Water** y **Grass**
    /// </summary>
    Ground,

    /// <summary>
    /// Fuerte contra **Grass** y **Fighting**, debil contra **Electric** y **Rock**
    /// </summary>
    Flying,

    /// <summary>
    /// Fuerte contra **Fighting** y **Poison**, debil contra **Bug** y **Ghost**
    /// </summary>
    Psychic,

    /// <summary>
    /// Fuerte contra **Grass** y **Psychic**, debil contra **Fire**, **Flying** y **Rock**
    /// </summary>
    Bug,

    /// <summary>
    /// Fuerte contra **Fire**, debil contra **Water** y **Grass**
    /// </summary>
    Rock,

    /// <summary>
    /// Fuerte contra **Psychic**, inmune contra **Normal**
    /// </summary>
    Ghost,

    /// <summary>
    /// Fuerte contra **Dragon**, debil contra **Ice**
    /// </summary>
    Dragon,
}

/// <summary>
/// Provee los metodos para calcular la efectividad de los tipos de los Pokemons en la batalla
/// </summary>
public static class Calculate
{
    // FIXME: Este método actualmente asume que si el elemento defensor no está
    // listado en las ventajas del atacante, el atacante debe ser normal
    // contre ese elemento, pero podría ser valioso que sea explícito cuales
    // son normales, y si no está explicitado en ninguna lista retornar -1
    /// <summary>
    /// Este determina la ventaja del Pokemon atacante, sobre el Pokemon atacado
    /// </summary>
    /// <remarks>
    /// Si el tipo <paramref name="defender"/> no está explícitamente mencionado como "strong", 
    /// "weak" o "immune" en la tabla del tipo <paramref name="attacker"/>, se considera un
    /// multiplicador de 1.0 (neutral).
    /// Un multiplicador de -1 podría indicarse en futuras versiones si el
    /// tipo <paramref name="defender"/> no pertenece a ninguna categoría conocida. Logrando este asi una excepcion
    /// </remarks>
    /// <param name="attacker">El tipo del Pokemon atacante</param>
    /// <param name="defender">El tipo del Pokemon atacado</param>
    /// <returns>
    /// Un double que representa la efectividad:
    /// <item>2.0 si <paramref name="attacker"/> es fuerte contra <paramref name="defender"/></item>
    /// <item>0.5 si <paramref name="attacker"/> es debil contra <paramref name="defender"/></item>
    /// <item>0.0 si <paramref name="attacker"/> no tiene efecto en <paramref name="defender"/></item>
    /// <item>1.0 si no hay ventaja entre ambos tipos</item>
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanza esta excepcion si <paramref name="attacker"/> no es un tipo de Pokemon valido
    /// </exception>
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
                strong =
                [
                    PokemonType.Bug, PokemonType.Psychic, PokemonType.Ground, PokemonType.Fighting, PokemonType.Grass
                ];
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