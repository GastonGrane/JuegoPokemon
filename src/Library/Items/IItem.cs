// -----------------------------------------------------------------------
// <copyright file="IItem.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.Items;

/// <summary>
/// Define la funcionalidad básica para un objeto que se puede utilizar en un Pokémon.
/// </summary>
/// /// <remarks>
/// La interfaz <see cref="IItem"/> permite que distintos ítems, puedan ser aplicados a un Pokémon de manera polimórfica
/// y utilizamos bajo acomplamiento al crear varios items pero que todos dependan de esta interfaz.
/// Este diseño sigue DIP el "Dependency Inversion Principle", ya que permite que
/// otras clases interactúen con objetos de tipo <see cref="IItem"/> sin depender de
/// implementaciones específicas. También sigue OCP el "Open-Close Principle", permitiendo
/// que nuevos ítems se añadan sin modificar el código existente.
/// </remarks>
public interface IItem
{
    /// <summary>
    /// Aplica el efecto del objeto en el Pokémon especificado.
    /// </summary>
    /// <param name="pokemon">El Pokémon en el que se usará el objeto.</param>
    public void Use(Pokemon pokemon);
}
