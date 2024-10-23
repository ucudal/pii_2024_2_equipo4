using Library.Interfaces;

namespace Library;

public abstract class AtaqueEspecial : IAtaque
{
    public string Nombre { get; }
    public ITipo? Tipo { get; }  // Puede ser nulo si el ataque especial no tiene tipo
    public int ValorAtaque { get; }
    public double Precision { get; }

    public AtaqueEspecial(string nombre, ITipo? tipo, int daño, double precision)
    {
        Nombre = nombre;
        Tipo = tipo;
        ValorAtaque = daño;
        Precision = precision;
    }

    public void Ejecutar(Pokemon objetivo)
    {
        if (new Random().NextDouble() <= Precision)
        {
            // Calcular daño, aplicando la efectividad del tipo si el ataque tiene tipo
            int ataqueFinal = ValorAtaque;
            if (Tipo != null)
            {
                double efectividad = Tipo.CalcularAtaqueEfectivo(objetivo.Tipo);
                ataqueFinal = (int)(ValorAtaque * efectividad);
                Console.WriteLine($"{Nombre} fue exitoso y causó {ataqueFinal} puntos de daño a {objetivo.Nombre}. (Efectividad: {efectividad}x)");
            }

            // Aplicar el daño
            objetivo.RecibirAtaque(ataqueFinal);

            // Aplicar el efecto especial después del cálculo de daño
            AplicarEfecto(objetivo);
        }
        else
        {
            Console.WriteLine($"{Nombre} falló.");
        }
    }

    // Método abstracto para que cada ataque especial aplique su efecto específico
    protected abstract void AplicarEfecto(Pokemon objetivo);
}
