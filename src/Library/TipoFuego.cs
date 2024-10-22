namespace Library;

public class TipoFuego : ITipo
{
    public string Nombre { get; } = "Fuego";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoAgua or TipoRoca or TipoTierra)
        {
            return 2.0;  // Fuego es débil contra Agua.
        }
        
        if (tipoAtaque is TipoBicho or TipoFuego or TipoPlanta)
        {
            return 0.5;  // Fuego tiene una ligera ventaja sobre Tierra.
        }
        
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}