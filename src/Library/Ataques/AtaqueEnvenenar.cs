namespace Library;

public class AtaqueEnvenenar : AtaqueEspecial
{
    public AtaqueEnvenenar() 
        : base("Envenenar", null, 0, 1.0)  // No tiene daño ni tipo, precisión del 100%
    {
    }

    // El efecto especial envenena al objetivo
    protected override void AplicarEfecto(Pokemon objetivo)
    {
        if (!objetivo.EstaEnvenenado)  // Verificar si ya está envenenado
        {
            objetivo.Envenenar();
            Console.WriteLine($"{objetivo.Nombre} ha sido envenenado.");
        }
        else
        {
            Console.WriteLine($"{objetivo.Nombre} ya está envenenado.");
        }
    }
}