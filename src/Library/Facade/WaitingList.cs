// -----------------------------------------------------------------------
// <copyright file="WaitingList.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.GameLogic.Entities;
using Library.GameLogic.Players;

namespace Library.Facade;

/// <summary>
/// La lista de espera de jugadores para entrar a una partida.
/// </summary>
public class WaitingList
{
    private static WaitingList? instance;

    private readonly List<Player> waitingList;

    private WaitingList()
    {
        this.waitingList = new();
    }

    /// <summary>
    /// El singleton de la lista de espera.
    /// </summary>
    public static WaitingList Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WaitingList();
            }

            return instance;
        }
    }

    /// <summary>
    /// Busca si existe un jugador cuyo nombre sea <paramref name="name"/>.
    /// </summary>
    /// <param name="name">El nombre del usuario que se busca.</param>
    /// <returns><c>true</c> si hay un usuario con ese nombre en la lista de espera, sino <c>false</c>.</returns>
    public bool ContainsPlayer(string name)
    {
        return this.waitingList.Any(p => p.Name == name);
    }

    /// <summary>
    /// Añade un un jugador.
    /// </summary>
    /// <param name="name">El nombre del jugador.</param>
    /// <param name="pokemon">Los pokemon del jugador.</param>
    public void AddPlayer(string name, List<Pokemon> pokemon)
    {
        this.waitingList.Add(new Player(name, pokemon));
    }
}
