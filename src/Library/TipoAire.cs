namespace Library;

public class TipoAire : ITipo
{
    public string Nombre { get; } = "Aire";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoTierra)
        {
            return 0.5;  // Aire es débil contra Tierra.
        }

        if (tipoAtaque is TipoFuego)
        {
            return 1.5;  // Aire tiene ventaja sobre Fuego.
        }

        if (tipoAtaque is TipoAgua)
        {
            return 1.0;  // Aire es neutral contra Agua.
        }

        return 1.0;  // Neutral por defecto si no es ninguno de los anteriores.
    }
}