using Library.Interfaces;

namespace Library
{
    public class Program
    {
        public static void Main()
        {
            var tipos = CreacionElementosJuego.InicializarTipos();
            var pokemons = CreacionElementosJuego.InicializarPokemons(tipos);
            ICatalogo catalogo = new Catalogo(pokemons);

            BatallapokemonFacade battleFacade = new BatallapokemonFacade(catalogo);

            Console.WriteLine("Introduce el nombre del Jugador 1:");
            string nombreJugador1 = Console.ReadLine();
            Console.WriteLine("Introduce el nombre del Jugador 2:");
            string nombreJugador2 = Console.ReadLine();
            
            battleFacade.CrearJugadores(nombreJugador1, nombreJugador2);
            battleFacade.SeleccionarPokemonJugadores();
            battleFacade.IniciarBatalla();

            while (!battleFacade.VerificarGanador())
            {
                battleFacade.MostrarEstado();
                battleFacade.Atacar();
            }
        }
    }
}