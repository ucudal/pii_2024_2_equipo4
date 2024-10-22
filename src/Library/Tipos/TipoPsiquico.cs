namespace Library;

public class TipoPsiquico: ITipo
{
    public string Nombre { get; } = "Psiquico";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoLucha or TipoBicho or TipoFantasma)
        {
            return 2.0;  // Psiquico es débil contra Lucha, Bicho y Fantasma.
        }
        
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}