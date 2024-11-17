using Library.GameLogic;
using Library.GameLogic.Players;

namespace Library.Facade;

/// <summary>
/// Clase estática responsable de manejar e imprimir los estados de los ataques e ítems utilizados durante el juego.
/// </summary>
public static class GameState
{
    /// <summary>
    /// Imprime el estado actual del ataque y del ítem utilizado durante el turno, y limpia los estados después de imprimirlos.
    /// </summary>
    /// <param name="connection">La conexión externa utilizada para imprimir los mensajes.</param>
    /// <param name="attacker">El jugador que realizó el ataque, si corresponde.</param>
    /// <param name="defender">El Pokémon activo del jugador defensor.</param>
    public static void PrintStatuses(IExternalConnection connection, Player attacker, Player defender)
    {
        /// <summary>
        ///  Imprimir estado de Ataque.
        /// </summary>
        switch (CommunicationUser.attackStatus)
        {
            case AttackStatus.CriticalHit:
                int criticalDamage = CalculateDamage(attacker, defender, true);
                connection.PrintString($"¡Golpe crítico! {attacker.ActivePokemon.Name} atacó a {defender.ActivePokemon.Name}, causando {criticalDamage} de daño. Vida restante: {defender.ActivePokemon.Health}/{defender.ActivePokemon.MaxHealth}.");
                CommunicationUser.attackStatus = AttackStatus.Empty;
                break;

            case AttackStatus.NormalAttack:
                int normalDamage = CalculateDamage(attacker, defender, false);
                connection.PrintString($"{attacker.ActivePokemon.Name} atacó a {defender.ActivePokemon.Name}, causando {normalDamage} de daño. Vida restante: {defender.ActivePokemon.Health}/{defender.ActivePokemon.MaxHealth}.");
                CommunicationUser.attackStatus = AttackStatus.Empty;
                break;

            case AttackStatus.EffectApplied:
                connection.PrintString($"{attacker.ActivePokemon.Name} aplicó un efecto especial a {defender.ActivePokemon.Name}. Vida restante: {defender.ActivePokemon.Health}/{defender.ActivePokemon.MaxHealth}.");
                CommunicationUser.attackStatus = AttackStatus.Empty;
                break;

            case AttackStatus.NoEffect:
                connection.PrintString($"El ataque de {attacker.ActivePokemon.Name} no tuvo efecto sobre {defender.ActivePokemon.Name}.");
                CommunicationUser.attackStatus = AttackStatus.Empty;
                break;

            case AttackStatus.HinderingEffect:
                connection.PrintString($"El ataque de {attacker.ActivePokemon.Name} fue bloqueado por un efecto en {defender.ActivePokemon.Name}.");
                CommunicationUser.attackStatus = AttackStatus.Empty;
                break;
        }
        /// <summary>
        ///  Imprimir estado del ítem.
        /// </summary>
        switch (CommunicationUser.itemStatus)
        {
            case ItemStatus.Revive:
                connection.PrintString($"{attacker.Name} usó Revive. {attacker.ActivePokemon.Name} fue revivido y ahora tiene {attacker.ActivePokemon.Health}/{attacker.ActivePokemon.MaxHealth} puntos de vida.");
                CommunicationUser.itemStatus = ItemStatus.Empty;
                break;

            case ItemStatus.SuperPotion:
                connection.PrintString($"{attacker.Name} usó Super Poción en {attacker.ActivePokemon.Name}. Vida actual: {attacker.ActivePokemon.Health}/{attacker.ActivePokemon.MaxHealth}.");
                CommunicationUser.itemStatus = ItemStatus.Empty;
                break;

            case ItemStatus.TotalCure:
                connection.PrintString($"{attacker.Name} usó Cura Total. {attacker.ActivePokemon.Name} ya no está afectado por efectos negativos.");
                CommunicationUser.itemStatus = ItemStatus.Empty;
                break;
        }
    }

    /// <summary>
    /// Calcula el daño realizado al objetivo en función del tipo de ataque.
    /// </summary>
    /// <param name="attacker">El jugador atacante.</param>
    /// <param name="defender">El jugador defensor.</param>
    /// <param name="isCritical">Indica si el daño fue un golpe crítico.</param>
    /// <returns>El daño calculado.</returns>
    public static int CalculateDamage(Player attacker, Player defender, bool isCritical)
    {
        double multiplier = attacker.ActivePokemon.Type.Advantage(defender.ActivePokemon.Type);

        int baseDamage = attacker.ActivePokemon.Attacks[0].Damage;

        int damage;
        if (isCritical)
        {
            damage = (int)((baseDamage * multiplier) * 0.20);
        }
        else
        {
            damage = (int)(baseDamage * multiplier);
        }

        return damage;
    }
}
