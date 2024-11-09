// -----------------------------------------------------------------------
// <copyright file="NormalAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

/// <summary>
/// Representa un tipo especifico de ataque en el juego, NormalAttack a diferencia de SpecialAttack no va a utilizar efectos.
/// </summary>
/// <remarks>
/// Esta clase nos da instancias de Attack, cada uno con sus caracteristicas unica cumplienod asi con SRP al
/// enfocarse unicmaneteen proporcionar ataques sin efectos.
/// La clase <see cref="NormalAttack"/> permite crear instancias de ataques predefinidos para ser utilizados
/// en las batallas, y se beneficia del "Polimorfismo" del patrón GRASP al heredar de la clase base <see cref="Attack"/>.
/// </remarks>
public class NormalAttack : Attack
{
    /// <summary>
    /// El constructor de una nueva instancia de la clase <see cref="NormalAttack"/>.
    /// </summary>
    /// <param name="name">El nombre del ataque.</param>
    /// <param name="damage">La cantidad de danio que genera.</param>
    /// <param name="type">El <see cref="PokemonType"/> que va a definir el elemento del ataque.</param>
    /// <param name="precision">La precision del ataque (1-100).</param>
    /// <remarks>
    /// Este constructor lo utilizamos internamente para crear las caracteristicas de cada ataque.
    /// </remarks>
    public NormalAttack(string name, int damage, PokemonType type, int precision)
        : base(name, damage, type, precision)
    {
        ArgumentNullException.ThrowIfNull(name, "Un Ataque no se puede inicializar con nombre null");
        ArgumentOutOfRangeException.ThrowIfNegative(damage, "El daño no puede ser negativo");
    }
}
