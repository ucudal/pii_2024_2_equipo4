namespace DefaultNamespace;


public class TipoFuego : ITipo
{
    public string Nombre { get; } = "Fuego";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoAgua or TipoAire)
        {
            return 0.5;  // Fuego es débil contra Agua.
        }

        if (tipoAtaque is TipoTierra)
        {
            return 1.25;  // Fuego tiene una ligera ventaja sobre Tierra.
        }
        
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}