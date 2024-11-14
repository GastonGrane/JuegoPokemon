using Library.GameLogic.Effects;

namespace Library.GameLogic.Utilities;

public class AleatoriedadPrograma : IProbability
{

    public int LimInf;
    public int LimSupe;
    public int ProcentajeProbabilidad;

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