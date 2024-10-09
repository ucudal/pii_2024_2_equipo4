namespace Library;

public class TipoAgua : ITipo
{
    public string Nombre { get; } = "Agua";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoTierra)
        {
            return 0.5;  // Agua es débil contra Planta.
        }

        if (tipoAtaque is TipoFuego)
        {
            return 2.0;  // Agua es fuerte contra Fuego.
        }

        if (tipoAtaque is TipoTierra)
        {
            return 1.25;  // Agua tiene ventaja sobre Tierra.
        }

        return 1.0;  // Neutral por defecto.
    }
}