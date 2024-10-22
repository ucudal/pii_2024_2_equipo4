namespace Library;

public class TipoVeneno: ITipo
{
    public string Nombre { get; } = "Veneno";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoBicho or TipoPsiquico or TipoTierra or TipoLucha or TipoPlanta)
        {
            return 2.0;  // Veneno es débil contra Bicho, Psíquico, Tierra, Lucha y planta.
        }
        
        if (tipoAtaque is TipoVeneno)
        {
            return 0.5;  // Veneno es fuerte contra veneno.
        }
        
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}