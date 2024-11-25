// -----------------------------------------------------------------------
// <copyright file="CommandHelper.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Discord.Commands;
using Discord.WebSocket;

namespace Library.Facade.Discord.Commands;

/// <summary>
/// Métodos de utilidad para comandos.
/// </summary>
public static class CommandHelper
{
    /// <summary>
    /// Retorna el nombre visual del usuario en el servidor.
    /// </summary>
    /// <param name="context">El socket de comunicación.</param>
    /// <param name="name">El nombre del usuario (puede ser el del servidor o el del usuario mismo).</param>
    /// <returns>El nombre del usuario visible en el servidor.</returns>
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
    /// Retorna una referencia al usuario del servidor con un nombre dado.
    /// </summary>
    /// <param name="context">El socket de comunicación.</param>
    /// <param name="name">El nombre del usuario que se quiere.</param>
    /// <returns>La instancia que se refiere a este usuario.</returns>
    public static SocketGuildUser? GetUser(
        SocketCommandContext context,
        string? name)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (name == null)
        {
            return null;
        }

        foreach (SocketGuildUser user in context.Guild.Users)
        {
            if (user.Username == name
                || user.DisplayName == name
                || user.Nickname == name
                || user.GlobalName == name)
            {
                return user;
            }
        }

        return null;
    }
}
