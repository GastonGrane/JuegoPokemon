// -----------------------------------------------------------------------
// <copyright file="FacadeTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace Library.Tests;

internal sealed class ConnectionMock : IExternalConnection
{
    public bool PrintPlayerWonCalled { get; private set; } = false;

    public bool PrintStringCalled { get; private set; } = false;

    public bool PrintTurnHeadingCalled { get; private set; } = false;

    public bool PrintWelcomeCalled { get; private set; } = false;

    public bool ReportAttackResultCalled { get; private set; } = false;

    public bool ShowAttacksAndRecieveInputCalled { get; private set; } = false;

    public bool ShowChangePokemonMenuCalled { get; private set; } = false;

    public bool ShowMenuAndReceiveInputCalled { get; private set; } = false;

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
