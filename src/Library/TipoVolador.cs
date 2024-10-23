namespace Library;

public class TipoVolador : ITipo
{
    public string Nombre { get; } = "Volador";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoElectrico || tipoAtaque is TipoHielo || tipoAtaque is TipoRoca)
        {
            return 2.0; //El tipo volador es debil contra estos tipos
        }

        if (tipoAtaque is TipoBicho || tipoAtaque is TipoLucha || tipoAtaque is TipoPlanta || tipoAtaque is TipoTierra)
        {
            return 0.5; //El tipo volador es fuerte contra estos tipos
        }

        return 1.0; //Daño natural
    }
}