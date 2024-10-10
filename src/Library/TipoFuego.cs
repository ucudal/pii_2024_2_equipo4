namespace Library;

public class TipoFuego : ITipo
{
    public string Nombre { get; } = "Fuego";

    public double CalcularAtaqueEfectivo(ITipo tipoAtaque)
    {
        if (tipoAtaque is TipoAgua or TipoAire)
        {
            return 1.5;  // Fuego es débil contra Agua.
        }

        if (tipoAtaque is TipoTierra)
        {
            return 0.5;  // Fuego tiene una ligera ventaja sobre Tierra.
        }
        // Valor por defecto si el tipo no es uno de los anteriores
        return 1.0;  // Neutral si no se cumple ninguna de las condiciones anteriores.
    }
}