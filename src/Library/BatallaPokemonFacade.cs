using Library.Interfaces;

namespace Library
{
    public class BatallapokemonFacade
    {
        private readonly ICatalogo catalogo;
        private IJugador jugador1;
        private IJugador jugador2;
        private IBatalla batalla;

        public BatallapokemonFacade(ICatalogo catalogo)
        {
            this.catalogo = catalogo;
        }

        public void CrearJugadores(string nombreJugador1, string nombreJugador2)
        {
            jugador1 = new Jugador(nombreJugador1);
            jugador2 = new Jugador(nombreJugador2);
        }

        public void SeleccionarPokemonJugadores()
        {
            Console.WriteLine($"{jugador1.Nombre}, selecciona tus 6 Pokémon:");
            catalogo.SeleccionarPokemon(jugador1);

            Console.WriteLine($"{jugador2.Nombre}, selecciona tus 6 Pokémon:");
            catalogo.SeleccionarPokemon(jugador2);
        }

        public void IniciarBatalla()
        {
            batalla = new Batalla(jugador1, jugador2);
            batalla.IniciarBatalla();
        }

        public void Atacar()
        {
            batalla.TurnoJugador();
        }

        public void MostrarEstado()
        {
            batalla.MostrarEstado();
        }

        public bool VerificarGanador()
        {
            return batalla.VerGanador();
        }
    }
}
