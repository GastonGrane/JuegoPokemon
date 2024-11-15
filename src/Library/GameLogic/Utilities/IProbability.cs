namespace Library.GameLogic.Effects;

/// <summary>
/// DAS.
/// </summary>
public interface IProbability
{
    /// <summary>
    /// .
    /// </summary>
    int LimInf { get; }
    
    /// <summary>
    /// .
    /// </summary>
    int LimSupe { get; }
    
    /// <summary>
    /// .
    /// </summary>
    int ProcentajeProbabilidad { get; }
    
    /// <summary>
    /// ASD.
    /// </summary>
    /// <returns>
    /// asfas.
    /// </returns>
    public bool CalcularSioNo(int porcentaje);

    /// <summary>
    /// AFS.
    /// </summary>
    /// <returns>
    /// asd.
    /// </returns>
    public int CalcularNumero(int a, int b);
}