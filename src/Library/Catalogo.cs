using Library.Interfaces;

namespace Library
{
    public class Catalogo : ICatalogo
    {
        private List<Pokemon> pokemonsDisponibles;

        public Catalogo(List<Pokemon> pokemonsInicializados)
        {
            pokemonsDisponibles = pokemonsInicializados;
        }

        public void VerCatalogo()
        {
            Console.WriteLine("Pokémon disponibles en el catálogo:");
            for (int i = 0; i < pokemonsDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemonsDisponibles[i].Nombre} (HP: {pokemonsDisponibles[i].HP})");
            }
        }

        public void SeleccionarPokemon(IJugador jugador)
        {
            Console.WriteLine($"Selecciona 6 Pokémon para tu equipo, {jugador.Nombre}.");
            VerCatalogo();

            List<string> nombresSeleccionados = new List<string>();

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Selecciona el Pokémon número {i + 1}:");
                int seleccion = Convert.ToInt32(Console.ReadLine());

                if (seleccion >= 1 && seleccion <= pokemonsDisponibles.Count)
                {
                    Pokemon pokemonDelCatalogo = pokemonsDisponibles[seleccion - 1];

                    // Crear una nueva instancia de Pokemon con los mismos datos
                    Pokemon nuevoPokemon = new Pokemon(
                        pokemonDelCatalogo.Nombre,
                        pokemonDelCatalogo.HP,
                        pokemonDelCatalogo.Tipo);

                    // Copiamos los ataques también
                    nuevoPokemon.Ataques.AddRange(pokemonDelCatalogo.Ataques);

                    if (nombresSeleccionados.Contains(nuevoPokemon.Nombre))
                    {
                        Console.WriteLine("Ya seleccionaste este Pokémon, por favor elige otro.");
                        i--;
                    }
                    else
                    {
                        nombresSeleccionados.Add(nuevoPokemon.Nombre);
                        jugador.AgregarPokemon(nuevoPokemon);
                        Console.WriteLine($"{nuevoPokemon.Nombre} ha sido agregado a tu equipo.");
                    }
                }
                else
                {
                    Console.WriteLine("Selección inválida, intenta nuevamente.");
                    i--;
                }
            }
        }
    }
}
