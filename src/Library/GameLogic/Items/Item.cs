// -----------------------------------------------------------------------
// <copyright file="Item.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Items;

/// <summary>
/// Define la funcionalidad básica para un objeto que se puede utilizar en un Pokémon.
/// </summary>
/// <remarks>
/// La clase abstracta <see cref="Item"/> permite que distintos ítems puedan ser aplicados a un Pokémon de manera polimórfica.
/// Esto permite lograr un bajo acoplamiento al crear varios ítems, y que sus funcionalidades sean independientes de los Pokémon.
/// Este diseño sigue DIP (Dependency Inversion Principle), ya que permite que
/// otras clases interactúen con objetos de tipo <see cref="Item"/> sin depender de
/// implementaciones específicas. También sigue OCP (Open-Closed Principle), permitiendo
/// que nuevos ítems se añadan sin modificar el código existente de otras clases o la interfaz.
/// </remarks>
public abstract class Item
{
    /// <summary>
    /// Constructor base para los ítems.
    /// </summary>
    /// <param name="name">El nombre del ítem.</param>
    protected Item(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// El nombre del ítem.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Aplica el efecto del ítem en el Pokémon especificado.
    /// </summary>
    /// <param name="pokemon">El Pokémon en el que se usará el ítem.</param>
    /// <returns>El estado del ítem después de ser utilizado.</returns>
    public abstract ItemStatus Use(Pokemon.Pokemon pokemon);
}