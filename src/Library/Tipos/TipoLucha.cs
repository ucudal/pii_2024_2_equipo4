namespace Library;


public class TipoLucha:ITipo
    {
        public string Nombre { get; } = "Lucha";

        public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
        {
            if (tipoAtaque is TipoPsiquico or TipoVolador or TipoBicho or TipoRoca )
            {
                return 2.0; 
            }
            
            return 1.0; // son neutrales 
                    
            
        }

    }

