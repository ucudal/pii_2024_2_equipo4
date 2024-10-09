using Pokemones_perosnal;

namespace DefaultNamespace;

public class Pokemon
{
    public string Nombre { get; set; }
    public double HP { get; set; }
    public List<Ataque> Ataques { get; set; }
    public ITipo Tipo;

    public Pokemon(string nombre, double hp, ITipo tipo)
    {
        Nombre = nombre;
        HP = hp;
        Ataques = new List<Ataque>();
        Tipo = tipo;
    }

    public void RecibirAtaque(Ataque ataque)
    {
        // Se accede al tipo de pokemon para ver que tan efectivo es el ataque seleccionado contra él.
        double efectividad = Tipo.CalcularAtaqueEfectivo(ataque.Tipo);
        // Se calcula el ataque efectivo.
        double ataqueEfectivo = ataque.ValorAtaque * efectividad;
        if (ataqueEfectivo < HP)
        {
            HP -= ataqueEfectivo;
            Console.WriteLine($"{Nombre} recibió {ataqueEfectivo} puntos de daño y ahora tiene {HP} HP.");
        }
        else
        {
            HP = 0; 
            Console.WriteLine($"{Nombre} murió.");
        }
    }
}