namespace Library;

public class TipoHielo: ITipo
{
    public string Nombre { get; } = "Hielo";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoFuego or TipoRoca or TipoLucha)
        {
            return 2.0;  // Hielo es débil contra Fuego, roca y lucha.
        }
        
        if (tipoAtaque is TipoHielo)
        {
            return 0.5;  // Hielo es fuerte contra hielo.
        }
        
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}