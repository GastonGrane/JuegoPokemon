// -----------------------------------------------------------------------
// <copyright file="Helper.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library.Facade.Discord;

/// <summary>
/// Métodos de utilidad para discord.
/// </summary>
public static class Helper
{
    /// <summary>
    /// Retorna el nombre del usuario visible en el servidor.
    /// </summary>
    /// <param name="context">El contexto del comando.</param>
    /// <param name="name">Nombre en caso de no encontrar uno válido. Es ignorado al ser null.</param>
    /// <returns>
    /// El nombre del usuario visible (no el nombre de la cuenta).
    /// </returns>
    public static string GetDisplayName(
        SocketCommandContext context,
        string? name = null)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (name == null)
        {
            name = context.Message.Author.Username;
        }

        foreach (SocketGuildUser user in context.Guild.Users)
        {
            if (user.Username == name
                || user.DisplayName == name
                || user.Nickname == name
                || user.GlobalName == name)
            {
                return user.DisplayName;
            }
        }

        return name;
    }

    /// <summary>
    /// Espera a recibir (al menos) un mensaje por mensaje directo del usuario.
    /// </summary>
    /// <param name="dmChannel">El canal con el usuario.</param>
    /// <param name="lastMessage">El mensaje a partir del cual esperar.</param>
    /// <returns>
    /// Un <see cref="Task"/> que espera hasta recibir mensajes por el canal.
    /// </returns>
    public static async Task<List<IUserMessage>> ReceiveDM(IDMChannel dmChannel, IMessage lastMessage)
    {
        ArgumentNullException.ThrowIfNull(dmChannel);

        while (true)
        {
            var messages = await dmChannel.GetMessagesAsync(lastMessage, Direction.After).FlattenAsync();
            if (messages == null || !messages.Any())
            {
                await Task.Delay(100);
                continue;
            }

            return messages.Select(m => m as IUserMessage).ToList();
        }
    }
}
