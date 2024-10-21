namespace Library;

public class TipoVeneno : ITipo
{
    public string Nombre { get; } = "Veneno";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoTierra or TipoBicho or TipoPsiquico or TipoLucha or TipoPlanta)
        {
            return 2.0; 
        }

        if (tipoAtaque is TipoVeneno or TipoPlanta)
        {
            return 0.5;  
        }

        return 1.0;  // Neutral por defecto.
    }
}