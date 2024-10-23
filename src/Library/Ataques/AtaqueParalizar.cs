namespace Library;

public class AtaqueParalizar : AtaqueEspecial
{
    public AtaqueParalizar() 
        : base("Paralizar", null, 0, 1.0)  // No tiene daño ni tipo, precisión del 100%
    {
    }

    // El efecto especial paraliza al objetivo
    protected override void AplicarEfecto(Pokemon objetivo)
    {
        if (!objetivo.EstaParalizado)
        {
            objetivo.Paralizar();
            Console.WriteLine($"{objetivo.Nombre} ha sido paralizado.");
        }
        else
        {
            Console.WriteLine($"{objetivo.Nombre} ya está paralizado.");
        }
    }
}