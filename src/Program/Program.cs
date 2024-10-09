namespace Library;

public class Program
{
    public static void Main()
    {
        // Crear una instancia del Facade
        BatallapokemonFacade battleFacade = new BatallapokemonFacade();

        // Crear los jugadores
        Console.WriteLine("Introduce el nombre del Jugador 1:");
        string nombreJugador1 = Console.ReadLine();
        Console.WriteLine("Introduce el nombre del Jugador 2:");
        string nombreJugador2 = Console.ReadLine();
        
        battleFacade.CrearJugadores(nombreJugador1, nombreJugador2);

        // Los jugadores seleccionan sus 6 Pokémon
        battleFacade.SeleccionarPokemonJugadores();

        // Iniciar la batalla
        battleFacade.IniciarBatalla();

        // Bucle principal de la batalla
        while (!battleFacade.VerificarGanador())
        {
            // Mostrar estado de la batalla
            battleFacade.MostrarEstado();

            // Ejecutar el turno de ataque
            battleFacade.Atacar();
        }
    }
}