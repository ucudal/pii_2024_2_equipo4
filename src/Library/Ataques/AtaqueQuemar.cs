namespace Library;

public class AtaqueQuemar : AtaqueEspecial
{
    public AtaqueQuemar() 
        : base("Quemar", null, 0, 1.0)  // No tiene daño ni tipo, precisión del 100%
    {
    }

    // El efecto especial quema al objetivo
    protected override void AplicarEfecto(Pokemon objetivo)
    {
        if (!objetivo.EstaQuemado)
        {
            objetivo.Quemar();
            Console.WriteLine($"{objetivo.Nombre} ha sido quemado.");
        }
        else
        {
            Console.WriteLine($"{objetivo.Nombre} ya está quemado.");
        }
    }
}