// -----------------------------------------------------------------------
// <copyright file="Bot.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library.GameLogic.Entities;
using Library.GameLogic.Players;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Library.Facade.Discord;

/// <summary>
/// Esta clase implementa el bot de Discord.
/// </summary>
public class Bot : IBot, IDisposable
{
    private readonly ILogger<Bot> logger;
    private readonly IConfiguration configuration;
    private readonly DiscordSocketClient client;
    private ServiceProvider? serviceProvider;

    /// <summary>
    /// Crea una instancia del bot.
    /// </summary>
    /// <param name="logger">El logger que utilizará el bot.</param>
    /// <param name="configuration">La configuración del bot. Principalmente para el token.</param>
    public Bot(ILogger<Bot> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;

        DiscordSocketConfig config = new()
        {
            AlwaysDownloadUsers = true,
            GatewayIntents =
                GatewayIntents.AllUnprivileged
                | GatewayIntents.MessageContent,
        };

        this.client = new DiscordSocketClient(config);
    }

    /// <inheritdoc/>
    public async Task StartAsync(ServiceProvider services)
    {
        string discordToken = this.configuration["DiscordToken"] ?? throw new MissingFieldException("Falta el token");

        this.logger.LogInformation("Iniciando el bot con token {Token}", discordToken);

        this.serviceProvider = services;

        await this.client.LoginAsync(TokenType.Bot, discordToken).ConfigureAwait(false);
        await this.client.StartAsync().ConfigureAwait(false);

        this.client.MessageReceived += this.HandleCommandAsync;
    }

    /// <inheritdoc/>
    public async Task StopAsync()
    {
        this.logger.LogInformation("Finalizando");
        await this.client.LogoutAsync().ConfigureAwait(false);
        await this.client.StopAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Called when disposing of the class.
    /// </summary>
    /// <param name="dispose">Whether to dispose of managed resources.</param>
    protected virtual void Dispose(bool dispose)
    {
        if (dispose)
        {
            this.client.Dispose();
        }
    }

    /// <summary>
    /// Acepta un comando y llama al método correspondiente.
    /// </summary>
    /// <param name="socketMessage">El mensaje recibido.</param>
    /// <returns>Un <see cref="Task"/> representando que se terminó el handling del mensaje.</returns>
    private async Task HandleCommandAsync(SocketMessage socketMessage)
    {
        if (socketMessage is not SocketUserMessage userMessage || userMessage.Author.IsBot)
        {
            return;
        }

        if (socketMessage.Channel is IDMChannel)
        {
            return;
        }

        int position = 0;
        bool messageIsCommand = userMessage.HasCharPrefix('!', ref position);

        if (!messageIsCommand)
        {
            return;
        }

        SocketCommandContext commandContext = new SocketCommandContext(this.client, userMessage);

        CultureInfo culture = new CultureInfo("en_US");
        switch (userMessage.Content.ToLower(culture).Split(' ')[0])
        {
            case "!join":
                await BotCommands.AddToWaitingList(commandContext);
                break;

            case "!list":
                await BotCommands.DisplayWaitingList(commandContext);
                break;
        }
    }
}
