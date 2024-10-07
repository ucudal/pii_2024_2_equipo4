namespace DefaultNamespace;


public class TipoTierra : ITipo
{
    public string Nombre { get; } = "Tierra";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoFuego)
        {
            return 0.5;  // Tierra es débil contra Fuego.
        }

        if (tipoAtaque is TipoAgua)
        {
            return 2.0;  // Tierra es fuerte contra Agua.
        }

        if (tipoAtaque is TipoAire)
        {
            return 1.25;  // Tierra tiene una ligera ventaja sobre Aire.
        }

        return 1.0;  // Neutral por defecto.
    }
}