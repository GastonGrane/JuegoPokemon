// -----------------------------------------------------------------------
// <copyright file="Bot.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
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
    private readonly CommandService commands;
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
            /* | GatewayIntents.GuildMembers */
        };

        this.client = new DiscordSocketClient(config);
        this.commands = new CommandService();
    }

    /// <inheritdoc/>
    public async Task StartAsync(ServiceProvider services)
    {
        string discordToken = this.configuration["DiscordToken"] ?? throw new MissingFieldException("Falta el token");

        this.logger.LogInformation("Iniciando el con token {Token}", discordToken);

        this.serviceProvider = services;

        await this.commands.AddModulesAsync(Assembly.GetExecutingAssembly(), this.serviceProvider).ConfigureAwait(false);

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
            (this.commands as IDisposable).Dispose();
        }
    }

    private async Task HandleCommandAsync(SocketMessage arg)
    {
        if (arg is not SocketUserMessage message || message.Author.IsBot)
        {
            return;
        }

        int position = 0;
        bool messageIsCommand = message.HasCharPrefix('!', ref position);

        if (messageIsCommand)
        {
            await this.commands.ExecuteAsync(
                new SocketCommandContext(this.client, message),
                position,
                this.serviceProvider).ConfigureAwait(false);
        }
    }
}
