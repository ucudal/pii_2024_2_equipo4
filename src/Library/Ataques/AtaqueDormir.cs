namespace Library;

public class AtaqueDormir : AtaqueEspecial
{
    public AtaqueDormir() 
        : base("Dormir", null, 0, 1.0)  // No tiene daño ni tipo, precisión del 100%
    {
    }

    // El efecto especial duerme al objetivo por 1-4 turnos
    protected override void AplicarEfecto(Pokemon objetivo)
    {
        if (!objetivo.EstaDormido)
        {
            int turnos = new Random().Next(1, 5);
            objetivo.QuedarDormido(turnos);
            Console.WriteLine($"{objetivo.Nombre} ha sido dormido por {turnos} turnos.");
        }
        else
        {
            Console.WriteLine($"{objetivo.Nombre} ya está dormido.");
        }
    }
}