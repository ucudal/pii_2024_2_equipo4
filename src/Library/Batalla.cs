using Library;

namespace Pokemones_personal;

public class Batalla
{
    private Jugador jugador1;
    private Jugador jugador2;
    private int turno;

    public Batalla(Jugador j1, Jugador j2)
    {
        jugador1 = j1;
        jugador2 = j2;
        turno = 1;
    }

    public void IniciarBatalla()
    {
        Console.WriteLine("¡La batalla ha comenzado!");
        MostrarEstado();
    }

    public void TurnoJugador()
    {
        Jugador atacante = (turno % 2 != 0) ? jugador1 : jugador2;
        Jugador defensor = (turno % 2 != 0) ? jugador2 : jugador1;

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

        turno++;
        CambiarTurno();
    }

    public void CambiarTurno()
    {
        Console.WriteLine($"Turno {turno} completado.");
    }

    public void MostrarEstado()
    {
        Console.WriteLine("Estado de la batalla:");
        jugador1.MostrarPokemonsDisponibles();
        jugador2.MostrarPokemonsDisponibles();
    }

    public bool VerGanador()
    {
        if (jugador1.PokemonsVivos() == 0)
        {
            Console.WriteLine($"{jugador2.Nombre} ha ganado la batalla.");
            return true;
        }
        else if (jugador2.PokemonsVivos() == 0)
        {
            Console.WriteLine($"{jugador1.Nombre} ha ganado la batalla.");
            return true;
        }
        else
        {
            Console.WriteLine("La batalla continúa.");
            return false;
        }
    }
}