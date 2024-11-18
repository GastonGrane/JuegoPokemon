// -----------------------------------------------------------------------
// <copyright file="IBot.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace Library.Facade.Discord;

/// <summary>
/// La interfaz del Bot de Discord para usar con inyección de dependencias.
/// </summary>
public interface IBot
{
    /// <summary>
    /// Inicia el bot.
    /// </summary>
    /// <param name="services">El proveedor de servicios.</param>
    /// <returns><see cref="Task"/> para esperar a la inicialización del bot.</returns>
    Task StartAsync(ServiceProvider services);

    /// <summary>
    /// Para el bot.
    /// </summary>
    /// <returns><see cref="Task"/> para esperar a parar el bot.</returns>
    Task StopAsync();
}
