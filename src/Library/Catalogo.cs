using Library.Interfaces;

namespace Library
{
    public class Catalogo : ICatalogo
    {
        private List<Pokemon> pokemonsDisponibles;

        public Catalogo()
        {
            pokemonsDisponibles = new List<Pokemon>();
            InicializarPokemons();
        }

        private void InicializarPokemons()  
        {
            // Tipo Fuego
            pokemonsDisponibles.Add(CrearPokemonConAtaques("Charmander", 100, new TipoFuego(),
                new Ataque("Llamarada", 50, false, new TipoFuego()),
                new Ataque("Hidro Bomba", 50, false, new TipoAgua()),
                new Ataque("Terremoto", 50, false, new TipoTierra()),
                new Ataque("Explosión Solar", 90, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Vulpix", 95, new TipoFuego(),
                new Ataque("Ascuas", 40, false, new TipoFuego()),
                new Ataque("Pulso Agua", 50, false, new TipoAgua()),
                new Ataque("Magnitud", 45, false, new TipoTierra()),
                new Ataque("Llama Azul", 80, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Growlithe", 110, new TipoFuego(),
                new Ataque("Lanzallamas", 55, false, new TipoFuego()),
                new Ataque("Torbellino", 50, false, new TipoAgua()),
                new Ataque("Fisura", 50, false, new TipoTierra()),
                new Ataque("Sofoco", 85, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Ponyta", 100, new TipoFuego(),
                new Ataque("Giro Fuego", 45, false, new TipoFuego()),
                new Ataque("Aqua Jet", 40, false, new TipoAgua()),
                new Ataque("Avalancha", 45, false, new TipoTierra()),
                new Ataque("Erupción", 80, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Magmar", 105, new TipoFuego(),
                new Ataque("Fuego Fatuo", 35, false, new TipoFuego()),
                new Ataque("Surf", 45, false, new TipoAgua()),
                new Ataque("Corteza Tierra", 50, false, new TipoTierra()),
                new Ataque("Onda Ígnea", 85, true, new TipoFuego())));

            // Tipo Agua
            pokemonsDisponibles.Add(CrearPokemonConAtaques("Squirtle", 120, new TipoAgua(),
                new Ataque("Llamarada", 50, false, new TipoFuego()),
                new Ataque("Hidro Bomba", 90, true, new TipoAgua()),
                new Ataque("Terremoto", 50, false, new TipoTierra()),
                new Ataque("Rayo Solar", 90, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Psyduck", 105, new TipoAgua(),
                new Ataque("Ascuas", 40, false, new TipoFuego()),
                new Ataque("Pulso Agua", 85, true, new TipoAgua()),
                new Ataque("Magnitud", 45, false, new TipoTierra()),
                new Ataque("Llama Azul", 80, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Poliwag", 115, new TipoAgua(),
                new Ataque("Lanzallamas", 50, false, new TipoFuego()),
                new Ataque("Torbellino", 50, false, new TipoAgua()),
                new Ataque("Fisura", 50, false, new TipoTierra()),
                new Ataque("Sofoco", 85, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Goldeen", 110, new TipoAgua(),
                new Ataque("Giro Fuego", 40, false, new TipoFuego()),
                new Ataque("Aqua Jet", 50, false, new TipoAgua()),
                new Ataque("Avalancha", 45, false, new TipoTierra()),
                new Ataque("Erupción", 80, true, new TipoFuego())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Seel", 120, new TipoAgua(),
                new Ataque("Fuego Fatuo", 35, false, new TipoFuego()),
                new Ataque("Surf", 45, false, new TipoAgua()),
                new Ataque("Corteza Tierra", 50, false, new TipoTierra()),
                new Ataque("Onda Ígnea", 85, true, new TipoFuego())));

            // Tipo Tierra
            pokemonsDisponibles.Add(CrearPokemonConAtaques("Sandshrew", 110, new TipoTierra(),
                new Ataque("Corte Fuego", 50, false, new TipoFuego()),
                new Ataque("Cañón de Agua", 50, false, new TipoAgua()),
                new Ataque("Terremoto", 60, false, new TipoTierra()),
                new Ataque("Excavar", 90, true, new TipoTierra())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Geodude", 120, new TipoTierra(),
                new Ataque("Corte Fuego", 50, false, new TipoFuego()),
                new Ataque("Cañón de Agua", 50, false, new TipoAgua()),
                new Ataque("Roca Afilada", 60, false, new TipoTierra()),
                new Ataque("Golpe Rocoso", 90, true, new TipoTierra())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Diglett", 100, new TipoTierra(),
                new Ataque("Corte Fuego", 45, false, new TipoFuego()),
                new Ataque("Hidrochorro", 45, false, new TipoAgua()),
                new Ataque("Excavar", 55, false, new TipoTierra()),
                new Ataque("Ataque Sísmico", 90, true, new TipoTierra())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Onix", 130, new TipoTierra(),
                new Ataque("Cola Ígnea", 55, false, new TipoFuego()),
                new Ataque("Hidro Bomba", 55, false, new TipoAgua()),
                new Ataque("Destrucción", 70, false, new TipoTierra()),
                new Ataque("Roca Mortal", 100, true, new TipoTierra())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Cubone", 105, new TipoTierra(),
                new Ataque("Fuego Sagrado", 55, false, new TipoFuego()),
                new Ataque("Ola Trueno", 50, false, new TipoAgua()),
                new Ataque("Hueso Poderoso", 85, true, new TipoTierra())));

            // Tipo Aire
            pokemonsDisponibles.Add(CrearPokemonConAtaques("Pidgey", 90, new TipoAgua(),
                new Ataque("Llamarada", 50, false, new TipoFuego()),
                new Ataque("Bomba de Agua", 50, false, new TipoAgua()),
                new Ataque("Excavar", 50, false, new TipoTierra())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Spearow", 85, new TipoFuego(),
                new Ataque("Fuego Fatuo", 40, false, new TipoFuego()),
                new Ataque("Pulso Agua", 45, false, new TipoAgua()),
                new Ataque("Excavar", 45, false, new TipoTierra())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Zubat", 95, new TipoTierra(),
                new Ataque("Llama Azul", 40, false, new TipoFuego()),
                new Ataque("Tsunami", 50, false, new TipoAgua()),
                new Ataque("Avalancha", 50, false, new TipoTierra()),
                new Ataque("Corte Viento", 50, false, new TipoTierra())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Fearow", 105, new TipoAgua(),
                new Ataque("Llamarada", 55, false, new TipoFuego()),
                new Ataque("Aqua Jet", 50, false, new TipoAgua()),
                new Ataque("Fisura", 50, false, new TipoTierra()),
                new Ataque("Huracán", 55, false, new TipoAgua())));

            pokemonsDisponibles.Add(CrearPokemonConAtaques("Doduo", 100, new TipoFuego(),
                new Ataque("Explosión Ígnea", 50, false, new TipoFuego()),
                new Ataque("Bomba Agua", 45, false, new TipoAgua()),
                new Ataque("Terremoto", 50, false, new TipoTierra()),
                new Ataque("Viento Cortante", 55, false, new TipoFuego()),
                new Ataque("Llamarada", 55, false, new TipoFuego())));
        }

        private Pokemon CrearPokemonConAtaques(string nombre, double hp, ITipo tipo, params Ataque[] ataques)
        {
            // Crear el nuevo Pokémon
            var pokemon = new Pokemon(nombre, hp, tipo);

            // Agregar los ataques proporcionados al Pokémon
            pokemon.Ataques.AddRange(ataques);

            return pokemon;
        }

        public void VerCatalogo()
        {
            Console.WriteLine("Pokémon disponibles en el catálogo:");
            for (int i = 0; i < pokemonsDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemonsDisponibles[i].Nombre} (HP: {pokemonsDisponibles[i].HP}/{pokemonsDisponibles[i].HPMax})");
            }
        }

        public void SeleccionarPokemon(IJugador jugador)
        {
            Console.WriteLine($"Selecciona 6 Pokémon para tu equipo, {jugador.Nombre}.");
            VerCatalogo();

            List<string> nombresSeleccionados = new List<string>();

            for (int i = 0; i < 6; i++)  // Permitimos seleccionar 6 Pokémon.
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

                    // Verificar si el jugador ya seleccionó este Pokémon
                    if (nombresSeleccionados.Contains(nuevoPokemon.Nombre))
                    {
                        Console.WriteLine("Ya seleccionaste este Pokémon, por favor elige otro.");
                        i--;  // Repetir selección si el Pokémon ya fue seleccionado
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
                    i--;  // Repetir selección si es inválida.
                }
            }
        }
    }
}
