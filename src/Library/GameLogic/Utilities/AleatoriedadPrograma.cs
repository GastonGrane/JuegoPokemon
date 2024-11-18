using Library.GameLogic.Effects;

namespace Library.GameLogic.Utilities;

/// <summary>
/// Clase que utilizamos para generar los numeros aleatorios en el programa principal, utilizando Random.
/// </summary>
/// <remarks>
/// Todas las clases que utilizan esto cumplen con el principio DIP debido a que pasan de depender de la clase <see cref="Random"/>
/// a depender de esta que es mas abstracta y permite cambiar como funciona la adquisicion denumeros aleatorios.
/// </remarks>
public class AleatoriedadPrograma : IProbability
{
    /// <inheritdoc/>
    public bool CalcularSioNo(int porcentajedeprob)
    {
        int numero = new Random().Next(1, 101);

        return numero <= porcentajedeprob;
    }

    /// <inheritdoc/>
    public int CalcularNumero(int liminferior, int limsuperior)
    {
        return new Random().Next(liminferior, limsuperior);
    }
}