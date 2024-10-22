namespace Library;

public class TipoFantasma:ITipo
{
    
        public string Nombre { get; } = "Fantasma";

        public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
        {
            if (tipoAtaque is TipoFantasma)
            {
                return 2.0;  // Fuego es débil contra Agua.
            }
        
            if (tipoAtaque is TipoVeneno or TipoLucha or TipoNormal)
            {
                return 0.5;  // Fuego tiene una ligera ventaja sobre Tierra.
            }
        
            return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
        }
    }
