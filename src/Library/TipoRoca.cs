namespace Library;

public class TipoRoca:ITipo
{
    public string Nombre { get; } = "Roca";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoAgua || tipoAtaque is TipoLucha || tipoAtaque is TipoPlanta || tipoAtaque is TipoTierra)
        {
            return 2.0;
        }

        if (tipoAtaque is TipoFuego || tipoAtaque is TipoNormal || tipoAtaque is TipoVeneno ||
            tipoAtaque is TipoVolador)
        {
            return 0.5;
        }
    }
}