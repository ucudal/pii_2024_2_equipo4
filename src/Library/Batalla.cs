namespace Library
{
    public class Batalla
    {
        private Jugador Jugador1;
        private Jugador Jugador2;
        private int turnoActual;

        public Batalla(Jugador jugador1, Jugador jugador2)
        {
            this.Jugador1 = jugador1;
            this.Jugador2 = jugador2;
            this.turnoActual = 1; // comienza el jugador 1
        }

        public Jugador JugadorActual()
        {
            return turnoActual == 1 ? Jugador1 : Jugador2;
        }

        public void CambiarTurno()
        {
            turnoActual = turnoActual == 1 ? 2 : 1;
        }

        public void IniciarBatalla()
        {
            Console.WriteLine("¡La batalla ha comenzado!");
            MostrarEstado();
        }

        public void TurnoJugador()
        {
            Jugador atacante = JugadorActual();
            Jugador defensor = turnoActual == 1 ? Jugador2 : Jugador1;

            Console.WriteLine($"{atacante.Nombre}, es tu turno. ¿Qué deseas hacer?");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Cambiar Pokémon");

            string accion = Console.ReadLine();

            switch (accion)
            {
                case "1":
                    Atacar(atacante, defensor);
                    break;
                case "2":
                    CambiarPokemon(atacante);
                    break;
                default:
                    Console.WriteLine("Opción inválida. Pierdes el turno.");
                    break;
            }

            CambiarTurno();
        }

        public void Atacar(Jugador atacante, Jugador defensor)
        {
            Console.WriteLine($"{atacante.Nombre}, elige un ataque:");
            for (int i = 0; i < atacante.Ataques.Count; i++)
            {
                Ataque ataque = atacante.Ataques[i];
                Console.WriteLine($"{i + 1}. {ataque.Nombre} (Ataque: {ataque.ValorAtaque}, Especial: {ataque.Especial})");
            }

            int opcion = int.Parse(Console.ReadLine()) - 1;
            Ataque ataqueElegido = atacante.Ataques[opcion];

            Console.WriteLine($"{atacante.Nombre} usa {ataqueElegido.Nombre} contra {defensor.Nombre}.");
            defensor.HP -= ataqueElegido.ValorAtaque;

            MostrarEstado();

            if(Jugador1.PokemonsVivos()==0 || Jugador2.PokemonsVivos()==0)
            {
                VerGanador();
            }
        }

        private void CambiarPokemon(Jugador atacante)
        {
            Console.WriteLine("Selecciona el Pokémon al que quieres cambiar:");
            atacante.MostrarPokemonsDisponibles();

            int seleccionPokemon = Convert.ToInt32(Console.ReadLine()) - 1;
            atacante.CambiarPokemon(seleccionPokemon);
        }

        public void MostrarEstado()
        {   
            Console.WriteLine($"{Jugador1.Nombre} tiene {Jugador1.PokemonsVivos} Pokémon vivos.");
            Console.WriteLine($"{Jugador2.Nombre} tiene {Jugador2.PokemonsVivos} Pokémon vivos.");
        }

        public void VerGanador()
        {
            if (Jugador1.PokemonsVivos == 0)
            {
                Console.WriteLine($"El jugador {Jugador2.Nombre} vencio {Jugador1.Nombre}.");
            }
            else if (Jugador2.PokemonsVivos == 0)
            {
                Console.WriteLine($"El jugador {Jugador1.Nombre} vencio {Jugador2.Nombre}.");
            }
        }
    }
}
