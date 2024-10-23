namespace Library;

public class TipoBicho : ITipo
{
    public string Nombre { get; } = "Bicho";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoFuego || tipoAtaque is TipoRoca || tipoAtaque is TipoVolador || tipoAtaque is TipoVeneno)
        {
            return 2.0; //Tipo Bicho es debil contra los tipos Fuego, Roca, Volador y Veneno
        }

        if (tipoAtaque is TipoLucha || tipoAtaque is TipoPlanta || tipoAtaque is TipoTierra)
        {
            return 0.5; //Tipo Bicho es fuerte contra los tipos Lucha, Planta y Tierra
        }

        return 1.0; //Daño natural
    }
}