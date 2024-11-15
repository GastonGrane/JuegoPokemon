using Library.GameLogic.Effects;

namespace Library.GameLogic.Utilities;

public class AleatoriedadPrograma : IProbability
{

    /// <summary>
    /// .
    /// </summary>
    public int LimInf { get; set; }
    
    /// <summary>
    /// .
    /// </summary>
    public int LimSupe { get; set; }
    
    /// <summary>
    /// .
    /// </summary>
    public int ProcentajeProbabilidad { get; set; }
    
    public bool CalcularSioNo(int porcentajedeprob)
    {
        int numero = new Random().Next(1, 101);

        this.ProcentajeProbabilidad = porcentajedeprob;

        return numero <= ProcentajeProbabilidad;
    }

    public int CalcularNumero(int liminferior, int limsuperior)
    {
        int numeroprobabilidad = 0;

        numeroprobabilidad = new Random().Next(liminferior, limsuperior);

        return numeroprobabilidad;
    }
}