using Library;

public class Batalla
{
    private Jugador Jugador1;
    private Jugador Jugador2;
    private int turnoActual;

    public Batalla(Jugador j1, Jugador j2)
    {
        Jugador1 = j1;
        Jugador2 = j2;
        turnoActual = 1; // comienza el jugador 1
    }

    public Jugador JugadorActual()
    {
        return turnoActual == 1 ? Jugador1 : Jugador2;
    }

    public void CambiarTurno()
    {
        Console.WriteLine($"Turno {turnoActual} completado.");
    }

    public void IniciarBatalla()
    {
        Console.WriteLine("¡La batalla ha comenzado!");
        MostrarEstado();
    }

    public void TurnoJugador()
    {
        Jugador atacante = (turnoActual % 2 != 0) ? Jugador1 : Jugador2;
        Jugador defensor = (turnoActual % 2 != 0) ? Jugador2 : Jugador1;

        Console.WriteLine($"{atacante.Nombre}, es tu turno. ¿Qué deseas hacer?");
        Console.WriteLine("1. Atacar");
        Console.WriteLine("2. Cambiar Pokémon");

        string accion = Console.ReadLine();
        
        if (accion == "1")
        {
            // Atacar
            Console.WriteLine("Selecciona un ataque:");
            for (int i = 0; i < atacante.PokemonActivo().Ataques.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {atacante.PokemonActivo().Ataques[i].Nombre}");
            }

            int seleccionAtaque = Convert.ToInt32(Console.ReadLine()) - 1;
            Ataque ataqueSeleccionado = atacante.PokemonActivo().Ataques[seleccionAtaque];
            Console.WriteLine($"{atacante.PokemonActivo().Nombre} usó {ataqueSeleccionado.Nombre}!");

            defensor.PokemonActivo().RecibirAtaque(ataqueSeleccionado);

            if (!defensor.PokemonActivo().EstaVivo())
            {
                Console.WriteLine($"{defensor.PokemonActivo().Nombre} ha muerto.");

                // Cambia automáticamente al siguiente Pokémon vivo si el actual muere.
                if (defensor.PokemonsVivos() > 0)
                {
                    defensor.CambiarPokemonAutomaticamente();
                }
                else
                {
                    Console.WriteLine($"{atacante.Nombre} ha ganado la batalla. ¡No quedan más Pokémon vivos en el equipo de {defensor.Nombre}!");
                    return;
                }
            }
        }
        else if (accion == "2")
        {
            // Cambiar Pokémon manualmente
            Console.WriteLine("Selecciona el Pokémon al que quieres cambiar:");
            atacante.MostrarPokemonsDisponibles();

            int seleccionPokemon = Convert.ToInt32(Console.ReadLine()) - 1;
            atacante.CambiarPokemon(seleccionPokemon);
        }
        else
        {
            Console.WriteLine("Opción inválida. Pierdes el turno.");
        }

        turnoActual++;
        CambiarTurno();
    }
    
    public void MostrarEstado()
    {   
        Console.WriteLine("Estado de la batalla:");
        Jugador1.MostrarPokemonsDisponibles();
        Jugador2.MostrarPokemonsDisponibles();
    }

    public bool VerGanador()
    {
        if (Jugador1.PokemonsVivos() == 0)
        {
            Console.WriteLine($"{Jugador2.Nombre} ha ganado la batalla.");
            return true;
        }
        else if (Jugador2.PokemonsVivos() == 0)
        {
            Console.WriteLine($"{Jugador1.Nombre} ha ganado la batalla.");
            return true;
        }
        else
        {
            Console.WriteLine("La batalla continúa.");
            return false;
        }
    }
}

