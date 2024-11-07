// -----------------------------------------------------------------------
// <copyright file="SpecialAttack.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

public enum SpecialType
{
    None,
}

public class SpecialAttack : Attack
{
    private SpecialType SpecialAttackType { get; }

    public SpecialAttack(string name, int damage, PokemonType attackType, SpecialType specialType)
        : base(name, damage, attackType)
    {
        this.SpecialAttackType = specialType;
    }
}
