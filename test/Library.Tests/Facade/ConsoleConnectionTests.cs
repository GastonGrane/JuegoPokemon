// -----------------------------------------------------------------------
// <copyright file="ConsoleConnectionTests.cs" company="Universidad Católica del Uruguay">
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
internal sealed class ConsoleConnectionTests
{
    private TextWriter oldOut;
    private TextReader oldIn;
    private StringWriter consoleOutput;
    private ConsoleConnection conn;

    /// <summary>
    /// Crea una instancia del test, redireccionando la consola.
    /// </summary>
    public ConsoleConnectionTests()
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
    /// Verifica que el método PrintString imprima correctamente el texto proporcionado en la consola.
    /// </summary>
    [Test]
    public void CanPrintString()
    {
        this.conn.PrintString("hola");
        this.consoleOutput.Flush();
        string output = this.consoleOutput.ToString();

        Assert.That(output, Does.Contain("hola"));
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

    /// <summary>
    /// Verifica que el método ShowAttacksAndRecieveInput permita seleccionar un ataque correctamente
    /// cuando se proporciona una entrada válida.
    /// </summary>
    [Test]
    public void ShowAttackWithCorrectAttack()
    {
        Pokemon p = PokemonRegistry.GetPokemon("Pikachu");
        StringReader input = new("Thunder Shock\n Quick Attack");
        Console.SetIn(input);

        string? result = this.conn.ShowAttacksAndRecieveInput(p);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo("Thunder Shock"));
        Assert.That(output, Does.Contain("Seleccione un ataque"));
        Assert.That(output, Does.Contain("1: Thunder Shock (Electric)"));
    }

    /// <summary>
    /// Verifica que el método ShowAttacksAndRecieveInput maneje entradas de índice incorrectas,
    /// muestre mensajes de error y permita al usuario reintentar hasta seleccionar correctamente.
    /// </summary>
    [Test]
    public void ShowAttacksWithIncorrectInputIndexRetriesAndThenWorks()
    {
        Pokemon bulbasaur = PokemonRegistry.GetPokemon("Bulbasaur");
        StringReader input = new("5\n-1\n1\n"); // Secuencia: incorrect -> incorrecto -> correcto.
        Console.SetIn(input);

        string? result = this.conn.ShowAttacksAndRecieveInput(bulbasaur);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo("Tackle"));
        Assert.That(output, Does.Contain("1: Tackle (Normal)"));
        Assert.That(output, Does.Contain($"Valor inválido ingresado. Se esperaba un valor entre 1-{bulbasaur.AvailableAttacks.Count}"));
        Assert.That(output, Does.Contain("Valor inválido ingresado, se esperaba un item del menú"));
    }

    /// <summary>
    /// Verifica que el método ShowAttacksAndRecieveInput maneje entradas de texto incorrectas,
    /// muestre mensajes de error y permita al usuario reintentar hasta seleccionar correctamente.
    /// </summary>
    [Test]
    public void ShowAttacksWithIncorrectInputTextRetriesAndThenWorks()
    {
        Pokemon pikachu = PokemonRegistry.GetPokemon("Pikachu");
        StringReader input = new("InvalidAttack\nAnotherInvalid\nThunderbolt\n"); // Secuencia: incorrecto -> incorrecto -> correcto.
        Console.SetIn(input);

        string? result = this.conn.ShowAttacksAndRecieveInput(pikachu);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo("Thunderbolt"));
        Assert.That(output, Does.Contain("Seleccione un ataque"));
        Assert.That(output, Does.Contain("Valor inválido ingresado"));
    }

    /// <summary>
    /// Verifica que el método ShowAttacksAndRecieveInput funcione correctamente con un índice válido.
    /// </summary>
    [Test]
    public void ShowAttacksWithCorrectInputIndexWorks()
    {
        Pokemon pikachu = PokemonRegistry.GetPokemon("Pikachu"); // Asume un método o acceso al Pokémon ya definido en el proyecto.
        StringReader input = new("1\n");
        Console.SetIn(input);

        string? result = this.conn.ShowAttacksAndRecieveInput(pikachu);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo("Thunder Shock")); // Nombre del ataque esperado.
        Assert.That(output, Does.Contain("Seleccione un ataque"));
        Assert.That(output, Does.Contain("1: Thunder Shock (Electric)"));
        Assert.That(output, Does.Not.Contain("Valor inválido ingresado"));
    }

    /// <summary>
    /// Verifica que el método ShowAttacksAndRecieveInput devuelva null cuando el usuario selecciona "0"
    /// para volver al menú anterior.
    /// </summary>
    [Test]
    public void ShowAttacksWithInputZeroReturnsNull()
    {
        Pokemon squirtle = PokemonRegistry.GetPokemon("Squirtle");
        StringReader input = new("0\n");
        Console.SetIn(input);

        string? result = this.conn.ShowAttacksAndRecieveInput(squirtle);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.Null);
        Assert.That(output, Does.Contain("Seleccione un ataque"));
        Assert.That(output, Does.Contain("0: Volver al menú anterior"));
    }

    /// <summary>
    /// Verifica que el método ShowChangePokemonMenu permita seleccionar un Pokémon correctamente
    /// utilizando un índice válido.
    /// </summary>
    [Test]
    public void ShowChangePokemonMenuWithCorrectInputIndexWorks()
    {
        Player player = new Player("Axel", new List<Pokemon>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });
        StringReader input = new("1\n");
        Console.SetIn(input);

        int result = this.conn.ShowPokemonMenu(player);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(0)); // El índice 0 corresponde al primer Pokémon.
        Assert.That(output, Does.Contain("Seleccione un Pokémon"));
        Assert.That(output, Does.Contain("1: Pikachu (Electric)")); // Ajustar según el primer Pokémon del jugador.
        Assert.That(output, Does.Not.Contain("Valor inválido ingresado"));
    }

    /// <summary>
    /// Verifica que el método ShowChangePokemonMenu permita seleccionar un Pokémon correctamente
    /// utilizando su nombre como entrada.
    /// </summary>
    [Test]
    public void ShowChangePokemonMenuWithCorrectInputTextWorks()
    {
        Player player = new Player("Axel", new List<Pokemon>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });
        StringReader input = new("Pikachu\n");
        Console.SetIn(input);

        int result = this.conn.ShowPokemonMenu(player);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(0)); // El índice 0 corresponde a "Pikachu"
        Assert.That(output, Does.Contain("Seleccione un Pokémon"));
        Assert.That(output, Does.Not.Contain("Valor inválido ingresado"));
    }

    /// <summary>
    /// Verifica que el método ShowChangePokemonMenu maneje entradas de texto incorrectas,
    /// muestre mensajes de error y permita al usuario reintentar hasta seleccionar correctamente.
    /// </summary>
    [Test]
    public void ShowChangePokemonMenuWithIncorrectInputTextRetriesAndThenWorks()
    {
        Player player = new Player("Axel", new List<Pokemon>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });
        StringReader input = new("InvalidName\nAnotherInvalid\nArticuno\n"); // Secuencia: incorrecto -> incorrecto -> correcto.
        Console.SetIn(input);

        int result = this.conn.ShowPokemonMenu(player);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(2));
        Assert.That(output, Does.Contain("Seleccione un Pokémon"));
        Assert.That(output, Does.Contain("Valor inválido ingresado, se esperaba un item del menú"));
    }

    /// <summary>
    /// Verifica que el método ShowChangePokemonMenu devuelva -1 cuando el usuario selecciona "0"
    /// para volver al menú anterior.
    /// </summary>
    [Test]
    public void ShowChangePokemonMenuWithInputZeroReturnsMinusOne()
    {
        Player player = new Player("Axel", new List<Pokemon>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
            PokemonRegistry.GetPokemon("Mew"),
            PokemonRegistry.GetPokemon("Diglett"),
        });
        StringReader input = new("0\n");
        Console.SetIn(input);

        int result = this.conn.ShowPokemonMenu(player);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(-1)); // Retorno esperado para "volver al menú".
        Assert.That(output, Does.Contain("Seleccione un Pokémon"));
        Assert.That(output, Does.Contain("0: Volver al menú anterior"));
    }

    /// <summary>
    /// Verifica que el método ShowChangePokemonMenu maneje índices fuera de rango, muestre mensajes de error
    /// y permita al usuario reintentar hasta seleccionar correctamente.
    /// </summary>
    [Test]
    public void ShowChangePokemonMenuWithOutOfRangeIndexDisplaysErrorAndRetries()
    {
        Player player = new Player("Axel", new List<Pokemon>
        {
            PokemonRegistry.GetPokemon("Pikachu"),
            PokemonRegistry.GetPokemon("Squirtle"),
            PokemonRegistry.GetPokemon("Articuno"),
        });
        StringReader input = new("8\n2\n"); // Secuencia: fuera de rango -> correcto.
        Console.SetIn(input);

        int result = this.conn.ShowPokemonMenu(player);
        string output = this.consoleOutput.ToString();

        Assert.That(result, Is.EqualTo(1));
        Assert.That(output, Does.Contain($"Valor inválido ingresado. Se esperaba un valor entre 1-{player.Pokemons.Count}"));
        Assert.That(output, Does.Contain("1: Pikachu (Electric)"));
        Assert.That(output, Does.Contain("2: Squirtle (Water)"));
        Assert.That(output, Does.Contain("3: Articuno (Ice)"));
    }
}
