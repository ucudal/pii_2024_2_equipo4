namespace Library;

public class TipoElectrico : ITipo
{
    public string Nombre { get; } = "Electrico";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoTierra)
        {
            return 2.0; // 
        }
       
        if (tipoAtaque is TipoVolador) 
        {
            return 0.5; // Aire tiene ventaja sobre Fuego.
        }

        if (tipoAtaque is TipoElectrico)
        {
            return 0.0;
        }
        
        return 1.0; // son neutrales 
                    
            
    }

}