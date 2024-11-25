// -----------------------------------------------------------------------
// <copyright file="ConsoleConnectionTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.Facade;
using Library.GameLogic.Entities;
using Library.GameLogic.Players;

namespace Library.Tests.Facade;

/// <summary>
/// Tests de la conexión a consola.
/// </summary>
internal sealed class ConsoleConnectionTest
{
    private TextWriter oldOut;
    private TextReader oldIn;
    private StringWriter consoleOutput;
    private ConsoleConnection conn;

    /// <summary>
    /// Crea una instancia del test, redireccionando la consola.
    /// </summary>
    public ConsoleConnectionTest()
    {
        this.ConsoleConnectionSetUp();
    }

    /// <summary>
    /// Guarda la entrada y salida previas de la consola, e inicia la salida de la consola con la salida <see cref="consoleOutput"/>.
    /// </summary>
    [SetUp]
    public void ConsoleConnectionSetUp()
    {
        this.conn = new();
        this.consoleOutput = new();
        this.oldOut = Console.Out;
        this.oldIn = Console.In;
        Console.SetOut(this.consoleOutput);
    }

    /// <summary>
    /// Restaura la entrada y salida previas de la consola.
    /// </summary>
    [TearDown]
    public void ConsoleConnectionTearDown()
    {
        Console.SetOut(this.oldOut);
        Console.SetIn(this.oldIn);
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.PrintWelcome(Player, Player)"/> imprime correctamente.
    /// </summary>
    [Test]
    public void PrintsWelcome()
    {
        string p1Name = "Gaston";
        string p2Name = "Axel";
        Player p1 = new Player(p1Name, new() { PokemonRegistry.GetPokemon("Pikachu") });
        Player p2 = new Player(p2Name, new() { PokemonRegistry.GetPokemon("Squirtle") });

        this.conn.PrintWelcome(p1, p2);

        this.consoleOutput.Flush();
        string output = this.consoleOutput.ToString();
        Assert.That(output, Does.Contain($"Bienvenidos {p1.Name} y {p2.Name}"));
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.PrintPlayerWon(Player, Player)"/> imprime correctamente.
    /// </summary>
    [Test]
    public void PrintsPlayerWon()
    {
        string p1Name = "Gaston";
        string p2Name = "Axel";
        Player p1 = new Player(p1Name, new() { PokemonRegistry.GetPokemon("Pikachu") });
        Player p2 = new Player(p2Name, new() { PokemonRegistry.GetPokemon("Squirtle") });

        this.conn.PrintPlayerWon(p1, p2);
        this.conn.PrintPlayerWon(p2, p1);
        this.consoleOutput.Flush();
        string output = this.consoleOutput.ToString();

        Assert.That(output, Does.Contain($"El ganador de la partida es {p1.Name}"));
        Assert.That(output, Does.Contain($"El ganador de la partida es {p2.Name}"));
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.PrintTurnHeading(Player)"/> imprime correctamente.
    /// </summary>
    [Test]
    public void PrintsTurnHeading()
    {
        string p1Name = "Gaston";
        string p2Name = "Axel";
        Player p1 = new Player(p1Name, new() { PokemonRegistry.GetPokemon("Pikachu") });
        Player p2 = new Player(p2Name, new() { PokemonRegistry.GetPokemon("Squirtle") });

        this.conn.PrintTurnHeading(p1);
        this.conn.PrintTurnHeading(p2);
        this.consoleOutput.Flush();
        string output = this.consoleOutput.ToString();

        Assert.That(output, Does.Contain($"Turno de {p1.Name}"));
        Assert.That(output, Does.Contain($"Turno de {p2.Name}"));
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.ReportAttackResult(int, Player, Player)"/> imprime correctamente.
    /// </summary>
    [Test]
    public void ReportAttackWorks()
    {
        string p1Name = "Gaston";
        string p2Name = "Axel";
        Player p1 = new Player(p1Name, new() { PokemonRegistry.GetPokemon("Pikachu") });
        Player p2 = new Player(p2Name, new() { PokemonRegistry.GetPokemon("Squirtle") });

        int oldHP = p1.ActivePokemon.Health;
        p1.Attack(p2, "Quick Attack");
        this.conn.ReportAttackResult(oldHP, p1, p2);
        this.consoleOutput.Flush();
        string output = this.consoleOutput.ToString();

        Pokemon pok1 = p1.ActivePokemon;
        Pokemon pok2 = p2.ActivePokemon;
        int diff = oldHP - pok2.Health;
        Assert.That(output, Does.Contain($"{pok1.Name} atacó a {pok2.Name}, haciéndole {diff} de daño, y dejándolo en {pok2.Health}/{pok2.MaxHealth}"));
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.ShowMenuAndReceiveInput(string, System.Collections.ObjectModel.ReadOnlyCollection{string})"/> con una entrada correcta de índice funciona.
    /// </summary>
    [Test]
    public void ShowMenuWithCorrectInputIndexWorks()
    {
        List<string> options = new() { "Axel", "Gaston", "Sharon", "Guzman" };
        StringReader input = new("1\n");
        string headerString = "Seleccione un nombre: ";
        Console.SetIn(input);

        int result = this.conn.ShowMenuAndReceiveInput(headerString, options.AsReadOnly());
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(0));
        Assert.That(output, Does.Contain(headerString));
        Assert.That(output, Does.Not.Contain($"Número inválido ingresado. Se esperaba un valor entre 1 y {options.Count}"));
        Assert.That(output, Does.Contain("1: Axel"));
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.ShowMenuAndReceiveInput(string, System.Collections.ObjectModel.ReadOnlyCollection{string})"/> con una entrada incorrecta de índice no funciona, y luego reintenta hasta encontrar entrada válida.
    /// </summary>
    [Test]
    public void ShowMenuWithIncorrectInputIndexRetriesAndThenWorks()
    {
        List<string> options = new() { "Axel", "Gaston", "Sharon", "Guzman" };
        StringReader input = new("7\n5\n-1\n1\n");
        string headerString = "Seleccione un nombre: ";
        Console.SetIn(input);

        int result = this.conn.ShowMenuAndReceiveInput(headerString, options.AsReadOnly());
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(0));
        Assert.That(output, Does.Contain(headerString));
        Assert.That(output, Does.Contain($"Número inválido ingresado. Se esperaba un valor entre 1 y {options.Count}"));
        Assert.That(output, Does.Contain("1: Axel"));
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.ShowMenuAndReceiveInput(string, System.Collections.ObjectModel.ReadOnlyCollection{string})"/> con una entrada correcta de texto funciona.
    /// </summary>
    [Test]
    public void ShowMenuWithCorrectInputTextWorks()
    {
        List<string> options = new() { "Axel", "Gaston", "Sharon", "Guzman" };
        StringReader input = new("Axel\n");
        string headerString = "Seleccione un nombre: ";
        Console.SetIn(input);

        int result = this.conn.ShowMenuAndReceiveInput(headerString, options.AsReadOnly());
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(0));
        Assert.That(output, Does.Contain(headerString));
        Assert.That(output, Does.Not.Contain("Valor inválido ingresado, se esperaba un item del menú"));
        Assert.That(output, Does.Contain("1: Axel"));
    }

    /// <summary>
    /// Verifica que <see cref="ConsoleConnection.ShowMenuAndReceiveInput(string, System.Collections.ObjectModel.ReadOnlyCollection{string})"/> con una entrada incorrecta de texto no funciona, y luego reintenta hasta encontrar entrada válida.
    /// </summary>
    [Test]
    public void ShowMenuWithIncorrectInputTextRetriesAndThenWorks()
    {
        List<string> options = new() { "Axel", "Gaston", "Sharon", "Guzman" };
        StringReader input = new("Seba\nMartín\n-1\nGaston\n");
        string headerString = "Seleccione un nombre: ";
        Console.SetIn(input);

        int result = this.conn.ShowMenuAndReceiveInput(headerString, options.AsReadOnly());
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(1));
        Assert.That(output, Does.Contain(headerString));
        Assert.That(output, Does.Contain("Valor inválido ingresado, se esperaba un item del menú"));
        Assert.That(output, Does.Contain("2: Gaston"));
    }
}