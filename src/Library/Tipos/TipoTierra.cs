namespace Library;

public class TipoTierra : ITipo
{
    public string Nombre { get; } = "Tierra";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoAgua or TipoHielo or TipoPlanta or TipoRoca or TipoVeneno)
        {
            return 2.0; // 
        }
       
        if (tipoAtaque is TipoElectrico) 
        {
                return 0.5; // Aire tiene ventaja sobre Fuego.
        }
            
        return 1.0; // son neutrales 
                    
            
        }

    }
