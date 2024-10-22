namespace Library;

public class TipoAgua : ITipo
{
    public string Nombre { get; } = "Agua";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoElectrico or TipoPlanta)
        {
            return 2.0;  // Agua es débil contra Planta.
        }

        if (tipoAtaque is TipoFuego or TipoFuego or TipoLucha)
        {
            return 0.5;  // Agua es fuerte contra Fuego.
        }
        
        

        return 1.0;  // Neutral por defecto.
    }
}