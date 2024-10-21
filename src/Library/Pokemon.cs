namespace Library;

public class Pokemon
{
    public string Nombre { get; set; }
    public double HP { get; set; }
    public double HPMax { get; set; }
    public List<Ataque> Ataques { get; set; }
    public ITipo Tipo { get; set; }
    private int contadorAtaques = 0;  // Contador para los turnos de ataque

    public Pokemon(string nombre, double hp, ITipo tipo)
    {
        Nombre = nombre;
        HP = hp;
        HPMax = hp;
        Ataques = new List<Ataque>();
        Tipo = tipo;
    }

    // Método que incrementa el contador de ataques y controla el uso de ataques especiales
    public bool PuedeUsarAtaqueEspecial()
    {
        return contadorAtaques >= 2;  // Puede usar el ataque especial después de dos ataques normales
    }

    // Resetea el contador después de usar un ataque especial
    public void UsarAtaqueEspecial()
    {
        contadorAtaques = 0;  // Se resetea tras el uso del ataque especial
    }

    // Incrementar el contador después de cada ataque normal
    public void IncrementarContadorAtaques()
    {
        contadorAtaques++;
    }

    // Método para recibir ataques y reducir HP
    public void RecibirAtaque(Ataque ataque)
    {
        double efectividad = Tipo.CalcularAtaqueEfectivo(ataque.Tipo);
        double ataqueEfectivo = ataque.ValorAtaque * efectividad;
        if (ataqueEfectivo < HP)
        {
            HP -= ataqueEfectivo;
            Console.WriteLine($"{Nombre} recibió {ataqueEfectivo} puntos de daño ({efectividad}x efectividad) y ahora tiene {HP}/{HPMax} HP.");
        }
        else
        {
            HP = 0;
            Console.WriteLine($"{Nombre} murió.");
        }
    }

    public bool EstaVivo()
    {
        return HP > 0;
    }

    public string MostrarVida()
    {
        return $"{HP}/{HPMax}";
    }
}