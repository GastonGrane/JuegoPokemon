// -----------------------------------------------------------------------
// <copyright file="Item.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameLogic.Items;

/// <summary>
/// Define la funcionalidad básica para un objeto que se puede utilizar en un Pokémon.
/// </summary>
/// /// <remarks>
/// La clase abstracta <see cref="Item"/> permite que distintos ítems puedan ser aplicados a un Pokémon de manera polimórfica.
/// Esto permite lograr un bajo acomplamiento al crear varios items, y que sus funcionalidades sean independientes de los Pokémon.
/// Esto nos ayuda el dia de mañana no generar un error, o no uno tan grande, gracias a que si ocurre un cambio, en los requisitos de los Items, ocurrirá en
/// esta superclase o una subclase, o en el caso que sea dependiente el problema seria unicamente en su uso de esta clase, esto haciendolo
/// más felxible a la hora de añadir o modificar items o sus funcionalidades.
/// Este diseño sigue DIP (Dependency Inversion Principle), ya que permite que
/// otras clases interactúen con objetos de tipo <see cref="Item"/> sin depender de
/// implementaciones específicas. También sigue OCP (Open-Closed Principle), permitiendo
/// que nuevos ítems se añadan sin modificar el código existente de otras clases o la interfaz.
/// </remarks>
public abstract class Item
{
    /// <summary>
    /// Constructor base para los Items.
    /// </summary>
    /// <param name="name"> El nombre del Item. </param>
    protected Item(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// El nombre del item.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Aplica el efecto del objeto en el Pokémon especificado.
    /// </summary>
    /// <param name="pokemon">El Pokémon en el que se usará el objeto.</param>
    /// /// <exception cref="ArgumentNullException">
    /// Si <paramref name="pokemon"/> es null.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Si <paramref name="pokemon"/> cuando no es posible utilizar el Item en ese Pokemon.
    /// </exception>
    public abstract void Use(Pokemon pokemon);
}
