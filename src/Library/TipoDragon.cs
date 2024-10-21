namespace Library;

public class TipoDragon : ITipo
{
    public string Nombre { get; } = "Dragón";
    
    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoDragon or TipoHielo)
        {
            return 1.5;  // Dragón es débil contra Dragón y Hielo.
        }

        if (tipoAtaque is TipoAgua or TipoFuego or TipoElectrico or TipoPlanta)
        {
            return 0.5;  // Fuego tiene una ligera ventaja sobre Agua, Fuego, ELéctrico y Planta.
        }
        // Valor por defecto si el tipo no es uno de los anteriores
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}