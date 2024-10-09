namespace Library;

public class BatallapokemonFacade
{
    private Catalogo catalogo;
    private Jugador jugador1;
    private Jugador jugador2;
    private Batalla batalla;

    public BatallapokemonFacade()
    {
        catalogo = new Catalogo();
    }

    // Crear jugadores
    public void CrearJugadores(string nombreJugador1, string nombreJugador2)
    {
        jugador1 = new Jugador(nombreJugador1);
        jugador2 = new Jugador(nombreJugador2);
    }

    // Seleccionar Pokémon para ambos jugadores
    public void SeleccionarPokemonJugadores()
    {
        Console.WriteLine($"{jugador1.Nombre}, selecciona tus 6 Pokémon:");
        catalogo.SeleccionarPokemon(jugador1);

        Console.WriteLine($"{jugador2.Nombre}, selecciona tus 6 Pokémon:");
        catalogo.SeleccionarPokemon(jugador2);
    }

    // Iniciar la batalla
    public void IniciarBatalla()
    {
        batalla = new Batalla(jugador1, jugador2);
        batalla.IniciarBatalla();
    }

    // Ejecutar un turno de la batalla
    public void Atacar()
    {
        batalla.TurnoJugador();
    }

    // Mostrar estado de los Pokémon de ambos jugadores
    public void MostrarEstado()
    {
        batalla.MostrarEstado();
    }

    // Verificar si hay un ganador
    public bool VerificarGanador()
    {
        return batalla.VerGanador();
    }
}