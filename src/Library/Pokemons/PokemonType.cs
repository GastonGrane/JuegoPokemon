// -----------------------------------------------------------------------
// <copyright file="PokemonType.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Enumera los diferentes tipos de Pokemon, cada uno con una cierta ventaja y desventaja sobre otro tipo.
/// </summary>
public enum PokemonType
{
    /// <summary>
    /// El tipo normal.
    /// </summary>
    Normal,

    /// <summary>
    /// El tipo Fire.
    /// </summary>
    Fire,

    /// <summary>
    /// El tipo Water.
    /// </summary>
    Water,

    /// <summary>
    /// El tipo Electric.
    /// </summary>
    Electric,

    /// <summary>
    /// El tipo Grass.
    /// </summary>
    Grass,

    /// <summary>
    /// El tipo Ice.
    /// </summary>
    Ice,

    /// <summary>
    /// El tipo Fighting.
    /// </summary>
    Fighting,

    /// <summary>
    /// El tipo Poison.
    /// </summary>
    Poison,

    /// <summary>
    /// El tipo Ground.
    /// </summary>
    Ground,

    /// <summary>
    /// El tipo Flying.
    /// </summary>
    Flying,

    /// <summary>
    /// El tipo Psychic.
    /// </summary>
    Psychic,

    /// <summary>
    /// El tipo Bug.
    /// </summary>
    Bug,

    /// <summary>
    /// El tipo Rock.
    /// </summary>
    Rock,

    /// <summary>
    /// El tipo Ghost.
    /// </summary>
    Ghost,

    /// <summary>
    /// El tipo Dragon.
    /// </summary>
    Dragon,
}

/// <summary>
/// Provee los metodos para calcular la efectividad de los tipos de los Pokemons en la batalla.
/// </summary>
public static class Calculate
{
    // FIXME: Este método actualmente asume que si el elemento defensor no está
    // listado en las ventajas del atacante, el atacante debe ser normal
    // contre ese elemento, pero podría ser valioso que sea explícito cuales
    // son normales, y si no está explicitado en ninguna lista retornar -1

    /// <summary>
    /// Este determina la ventaja del Pokemon atacante, sobre el Pokemon atacado.
    /// </summary>
    /// <remarks>
    /// Si el tipo <paramref name="defender"/> no está explícitamente mencionado como "strong",
    /// "weak" o "immune" en la tabla del tipo <paramref name="attacker"/>, se considera un
    /// multiplicador de 1.0 (neutral).
    /// </remarks>
    /// <param name="attacker">El tipo del ataque utilizado.</param>
    /// <param name="defender">El tipo del Pokemon atacado.</param>
    /// <returns>
    /// Un double que representa la efectividad:
    /// <item>2.0 si <paramref name="attacker"/> es fuerte contra <paramref name="defender"/></item>
    /// <item>0.5 si <paramref name="attacker"/> es debil contra <paramref name="defender"/></item>
    /// <item>0.0 si <paramref name="attacker"/> no tiene efecto en <paramref name="defender"/></item>
    /// <item>1.0 si no hay ventaja entre ambos tipos</item>
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Lanza esta excepcion si <paramref name="attacker"/> es un tipo que no tiene ventajas explicitadas.
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
                    PokemonType.Bug,
                    PokemonType.Psychic,
                    PokemonType.Ground,
                    PokemonType.Fighting,
                    PokemonType.Grass
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

        if (strong.Contains(defender))
        {
            return 2.0;
        }

        if (weak.Contains(defender))
        {
            return 0.5;
        }

        if (immune.Contains(defender))
        {
            return 0.0;
        }

        return 1.0;
    }
}
