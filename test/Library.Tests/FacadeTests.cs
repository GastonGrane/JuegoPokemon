// -----------------------------------------------------------------------
// <copyright file="FacadeTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using Library.Facade;
using Library.GameLogic.Entities;
using Library.GameLogic.Players;

namespace Library.Tests.Facade;

#pragma warning disable SA1402 // Esta ocurre por definir el mock y los tests acá. está bien ignorarlo porque esta clase es únicamente para este archivo y nada más.

/// <summary>
/// Tests de la fachada.
/// </summary>
internal sealed class FacadeTests
{
    /// <summary>
    /// Test de la bienvenida al usuario.
    /// </summary>
    [Test]
    public void TestWelcome()
    {
        ConnectionMock mock = new();
        Game game = Game.CreateGame(PokemonRegistry.GetAllPokemon(), mock);
        game.ShowWelcome();
        Assert.True(mock.PrintWelcomeCalled, "Welcome was not called");
    }

    /// <summary>
    /// Test de la bienvenida al usuario.
    /// </summary>
    [Test]
    public void TestPlayTurn()
    {
        ConnectionMock mock = new();
        Game game = Game.CreateGame(PokemonRegistry.GetAllPokemon(), mock);
        game.ShowWelcome();
        Assert.True(mock.PrintWelcomeCalled, "Welcome was not called");

        game.PlayGameTurn();
        Assert.True(mock.PrintTurnHeadingCalled, "Turn heading was not called");
        Assert.True(mock.ReportAttackResultCalled, "Report attack result was not called");
        Assert.True(mock.PrintPlayerWonCalled, "Print player won was not called");
    }
}

/// <summary>
/// Clase para testear la fachada. Sirve como mock de la conexión externa.
/// </summary>
internal sealed class ConnectionMock : IExternalConnection
{
    /// <summary>
    /// Si el método PrintPlayerWon se llamó.
    /// </summary>
    public bool PrintPlayerWonCalled { get; private set; }

    /// <summary>
    /// Si el método PrintString se llamó.
    /// </summary>
    public bool PrintStringCalled { get; private set; }

    /// <summary>
    /// Si el método PrintTurnHeading se llamó.
    /// </summary>
    public bool PrintTurnHeadingCalled { get; private set; }

    /// <summary>
    /// Si el método PrintWelcome se llamó.
    /// </summary>
    public bool PrintWelcomeCalled { get; private set; }

    /// <summary>
    /// Si el método ReportAttackResult se llamó.
    /// </summary>
    public bool ReportAttackResultCalled { get; private set; }

    /// <summary>
    /// Si el método ShowAttacksAndRecieveInput se llamó.
    /// </summary>
    public bool ShowAttacksAndRecieveInputCalled { get; private set; }

    /// <summary>
    /// Si el método ShowChangePokemonMenu se llamó.
    /// </summary>
    public bool ShowChangePokemonMenuCalled { get; private set; }

    /// <summary>
    /// Si el método ShowMenuAndReceiveInput se llamó.
    /// </summary>
    public bool ShowMenuAndReceiveInputCalled { get; private set; }

    /// <inheritdoc/>
    public void PrintPlayerWon(Player p1, Player p2)
    {
        this.PrintPlayerWonCalled = true;
    }

    /// <inheritdoc/>
    public void PrintString(string str)
    {
        this.PrintStringCalled = true;
    }

    /// <inheritdoc/>
    public void PrintTurnHeading(Player player)
    {
        this.PrintTurnHeadingCalled = true;
    }

    /// <inheritdoc/>
    public void PrintWelcome(Player p1, Player p2)
    {
        this.PrintWelcomeCalled = true;
    }

    /// <inheritdoc/>
    public void ReportAttackResult(int oldHP, Player attacker, Player defender)
    {
        this.ReportAttackResultCalled = true;
    }

    /// <inheritdoc/>
    public string? ShowAttacksAndRecieveInput(Pokemon pokemon)
    {
        this.ShowAttacksAndRecieveInputCalled = true;

        return "Quick Attack"; // el primer ataque
    }

    /// <inheritdoc/>
    public int ShowChangePokemonMenu(Player player)
    {
        this.ShowChangePokemonMenuCalled = true;

        return 1;
    }

    /// <inheritdoc/>
    public int ShowMenuAndReceiveInput(string selectionText, ReadOnlyCollection<string> options)
    {
        this.ShowMenuAndReceiveInputCalled = true;

        return 1; // que ataque
    }
}
