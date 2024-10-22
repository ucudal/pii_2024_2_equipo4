namespace Library;

public class TipoNormal: ITipo
{
    public string Nombre { get; } = "Normal";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoLucha)
        {
            return 2.0;  // Normal es débil contra Lucha.
        }
        
        if (tipoAtaque is TipoFantasma)
        {
            return 0;  // Normal inmune contra Fantasma.
        }
        
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}