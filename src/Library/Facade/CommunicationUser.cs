namespace Library.GameLogic;

/// <summary>
/// Clase utilizada para manejar la comunicación de estado entre las acciones realizadas en el juego
/// y la interacción con el usuario, como ataques o el uso de ítems.
/// </summary>
public class CommunicationUser
{
    /// <summary>
    /// Indica el estado del ataque que se realizó en el juego.
    /// </summary>
    public static AttackStatus attackStatus;

    /// <summary>
    /// Indica el estado del ítem que se utilizó en el juego.
    /// </summary>
    public static ItemStatus itemStatus;
}

/// <summary>
/// Representa los posibles estados que pueden resultar de un ataque en el juego.
/// </summary>
public enum AttackStatus
{
    /// <summary>
    /// El ataque realizado fue un golpe crítico.
    /// </summary>
    CriticalHit,

    /// <summary>
    /// El ataque realizado fue exitoso, con un daño normal.
    /// </summary>
    NormalAttack,

    /// <summary>
    /// El ataque aplicó un efecto especial al objetivo.
    /// </summary>
    EffectApplied,

    /// <summary>
    /// El ataque no tuvo efecto en el objetivo.
    /// </summary>
    NoEffect,

    /// <summary>
    /// El ataque fue bloqueado por un efecto o condición.
    /// </summary>
    HinderingEffect,
    
    /// <summary>
    /// Se coloca vacio para esperar el siguiente turno a informar.
    /// </summary>
    Empty,
}

/// <summary>
/// Representa los posibles estados que pueden resultar del uso de un ítem en el juego.
/// </summary>
public enum ItemStatus
{
    /// <summary>
    /// Se utilizó un ítem para revivir a un Pokémon.
    /// </summary>
    Revive,

    /// <summary>
    /// Se utilizó una poción para restaurar la salud de un Pokémon.
    /// </summary>
    SuperPotion,

    /// <summary>
    /// Se utilizó un ítem para eliminar los efectos de estado negativos en un Pokémon.
    /// </summary>
    TotalCure,
    
    /// <summary>
    /// Se coloca vacio para esperar el siguiente turno a informar.
    /// </summary>
    Empty,
}