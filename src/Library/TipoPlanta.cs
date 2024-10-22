namespace Library;

public class TipoPlanta:ITipo
{
    public string Nombre { get; } = "Planta";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoBicho or TipoFuego or TipoHielo or TipoVeneno or TipoVolador)
        {
            return 2.0; // Aire es débil contra Tierra.
        }
        
        if (tipoAtaque is TipoAgua or TipoElectrico or TipoPlanta or TipoTierra)
        {
                return 0.5; // Aire tiene ventaja sobre Fuego.
        }
           
        return 1.0; // son neutrales 
                    
            
        }

    }
