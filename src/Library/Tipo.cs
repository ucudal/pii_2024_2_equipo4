namespace Library;

public class Tipo
{
    public string Nombre { get; }
    private Dictionary<string, double> efectividades;

    public Tipo(string nombre)
    {
        Nombre = nombre;
        efectividades = new Dictionary<string, double>();
    }

    public void AgregarEfectividad(string nombreTipo, double efectividad)
    {
        if (!efectividades.ContainsKey(nombreTipo))
        {
            efectividades[nombreTipo] = efectividad;
        }    
    }

    public double CalcularAtaqueEfectivo(Tipo tipoAtaqueOponente)
    {
        if (efectividades.ContainsKey(tipoAtaqueOponente.Nombre))
        {
            return efectividades[tipoAtaqueOponente.Nombre];
        }
        return 1;
    }
}