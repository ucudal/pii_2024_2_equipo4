namespace Library;


public class Catalogo
{
    private List<Pokemon> pokemonsDisponibles;

    public Catalogo()
    {
        // Inicializamos con 20 Pokémon predefinidos, todos de los tipos Fuego, Aire, Agua y Tierra.
        pokemonsDisponibles = new List<Pokemon>
        {
            // Tipo Fuego
            new Pokemon("Charmander", 100, new TipoFuego()),
            new Pokemon("Vulpix", 95, new TipoFuego()),
            new Pokemon("Growlithe", 110, new TipoFuego()),
            new Pokemon("Ponyta", 100, new TipoFuego()),
            new Pokemon("Magmar", 105, new TipoFuego()),

            // Tipo Agua
            new Pokemon("Squirtle", 120, new TipoAgua()),
            new Pokemon("Psyduck", 105, new TipoAgua()),
            new Pokemon("Poliwag", 115, new TipoAgua()),
            new Pokemon("Goldeen", 110, new TipoAgua()),
            new Pokemon("Seel", 120, new TipoAgua()),

            // Tipo Tierra
            new Pokemon("Sandshrew", 110, new TipoTierra()),
            new Pokemon("Geodude", 120, new TipoTierra()),
            new Pokemon("Diglett", 100, new TipoTierra()),
            new Pokemon("Onix", 130, new TipoTierra()),
            new Pokemon("Cubone", 105, new TipoTierra()),

            // Tipo Aire
            new Pokemon("Pidgey", 90, new TipoAire()),
            new Pokemon("Spearow", 85, new TipoAire()),
            new Pokemon("Zubat", 95, new TipoAire()),
            new Pokemon("Fearow", 105, new TipoAire()),
            new Pokemon("Doduo", 100, new TipoAire())
        };

        // Asignamos 5 ataques a cada Pokémon: 1 de cada tipo (Fuego, Agua, Tierra, Aire) y un ataque especial.
        AsignarAtaques();
    }

    private void AsignarAtaques()
    {
        // Asignación de ataques a cada Pokémon

        // Charmander
        pokemonsDisponibles[0].Ataques.Add(new Ataque("Llamarada", 50, false, new TipoFuego()));
        pokemonsDisponibles[0].Ataques.Add(new Ataque("Hidro Bomba", 50, false, new TipoAgua()));
        pokemonsDisponibles[0].Ataques.Add(new Ataque("Terremoto", 50, false, new TipoTierra()));
        pokemonsDisponibles[0].Ataques.Add(new Ataque("Ráfaga", 50, false, new TipoAire()));
        pokemonsDisponibles[0].Ataques.Add(new Ataque("Explosión Solar", 90, true, new TipoFuego()));

        // Vulpix
        pokemonsDisponibles[1].Ataques.Add(new Ataque("Ascuas", 40, false, new TipoFuego()));
        pokemonsDisponibles[1].Ataques.Add(new Ataque("Pulso Agua", 50, false, new TipoAgua()));
        pokemonsDisponibles[1].Ataques.Add(new Ataque("Magnitud", 45, false, new TipoTierra()));
        pokemonsDisponibles[1].Ataques.Add(new Ataque("Tornado", 50, false, new TipoAire()));
        pokemonsDisponibles[1].Ataques.Add(new Ataque("Llama Azul", 80, true, new TipoFuego()));

        // Growlithe
        pokemonsDisponibles[2].Ataques.Add(new Ataque("Lanzallamas", 55, false, new TipoFuego()));
        pokemonsDisponibles[2].Ataques.Add(new Ataque("Torbellino", 50, false, new TipoAgua()));
        pokemonsDisponibles[2].Ataques.Add(new Ataque("Fisura", 50, false, new TipoTierra()));
        pokemonsDisponibles[2].Ataques.Add(new Ataque("Ataque Ala", 50, false, new TipoAire()));
        pokemonsDisponibles[2].Ataques.Add(new Ataque("Sofoco", 85, true, new TipoFuego()));

        // Ponyta
        pokemonsDisponibles[3].Ataques.Add(new Ataque("Giro Fuego", 45, false, new TipoFuego()));
        pokemonsDisponibles[3].Ataques.Add(new Ataque("Aqua Jet", 40, false, new TipoAgua()));
        pokemonsDisponibles[3].Ataques.Add(new Ataque("Avalancha", 45, false, new TipoTierra()));
        pokemonsDisponibles[3].Ataques.Add(new Ataque("Tajo Aéreo", 50, false, new TipoAire()));
        pokemonsDisponibles[3].Ataques.Add(new Ataque("Erupción", 80, true, new TipoFuego()));

        // Magmar
        pokemonsDisponibles[4].Ataques.Add(new Ataque("Fuego Fatuo", 35, false, new TipoFuego()));
        pokemonsDisponibles[4].Ataques.Add(new Ataque("Surf", 45, false, new TipoAgua()));
        pokemonsDisponibles[4].Ataques.Add(new Ataque("Corteza Tierra", 50, false, new TipoTierra()));
        pokemonsDisponibles[4].Ataques.Add(new Ataque("Vendaval", 45, false, new TipoAire()));
        pokemonsDisponibles[4].Ataques.Add(new Ataque("Onda Ígnea", 85, true, new TipoFuego()));

        // Squirtle
        pokemonsDisponibles[5].Ataques.Add(new Ataque("Llamarada", 50, false, new TipoFuego()));
        pokemonsDisponibles[5].Ataques.Add(new Ataque("Hidro Bomba", 90, true, new TipoAgua()));
        pokemonsDisponibles[5].Ataques.Add(new Ataque("Terremoto", 50, false, new TipoTierra()));
        pokemonsDisponibles[5].Ataques.Add(new Ataque("Huracán", 45, false, new TipoAire()));
        pokemonsDisponibles[5].Ataques.Add(new Ataque("Rayo Solar", 90, true, new TipoFuego()));

        // Psyduck
        pokemonsDisponibles[6].Ataques.Add(new Ataque("Ascuas", 40, false, new TipoFuego()));
        pokemonsDisponibles[6].Ataques.Add(new Ataque("Pulso Agua", 85, true, new TipoAgua()));
        pokemonsDisponibles[6].Ataques.Add(new Ataque("Magnitud", 45, false, new TipoTierra()));
        pokemonsDisponibles[6].Ataques.Add(new Ataque("Tornado", 40, false, new TipoAire()));
        pokemonsDisponibles[6].Ataques.Add(new Ataque("Llama Azul", 80, true, new TipoFuego()));

        // Poliwag
        pokemonsDisponibles[7].Ataques.Add(new Ataque("Lanzallamas", 50, false, new TipoFuego()));
        pokemonsDisponibles[7].Ataques.Add(new Ataque("Torbellino", 50, false, new TipoAgua()));
        pokemonsDisponibles[7].Ataques.Add(new Ataque("Fisura", 50, false, new TipoTierra()));
        pokemonsDisponibles[7].Ataques.Add(new Ataque("Ataque Ala", 50, false, new TipoAire()));
        pokemonsDisponibles[7].Ataques.Add(new Ataque("Sofoco", 85, true, new TipoFuego()));

        // Goldeen
        pokemonsDisponibles[8].Ataques.Add(new Ataque("Giro Fuego", 40, false, new TipoFuego()));
        pokemonsDisponibles[8].Ataques.Add(new Ataque("Aqua Jet", 50, false, new TipoAgua()));
        pokemonsDisponibles[8].Ataques.Add(new Ataque("Avalancha", 45, false, new TipoTierra()));
        pokemonsDisponibles[8].Ataques.Add(new Ataque("Tajo Aéreo", 50, false, new TipoAire()));
        pokemonsDisponibles[8].Ataques.Add(new Ataque("Erupción", 80, true, new TipoFuego()));

        // Seel
        pokemonsDisponibles[9].Ataques.Add(new Ataque("Fuego Fatuo", 35, false, new TipoFuego()));
        pokemonsDisponibles[9].Ataques.Add(new Ataque("Surf", 45, false, new TipoAgua()));
        pokemonsDisponibles[9].Ataques.Add(new Ataque("Corteza Tierra", 50, false, new TipoTierra()));
        pokemonsDisponibles[9].Ataques.Add(new Ataque("Vendaval", 50, false, new TipoAire()));
        pokemonsDisponibles[9].Ataques.Add(new Ataque("Onda Ígnea", 85, true, new TipoFuego()));

        // Los siguientes 10 Pokémon y sus ataques:

        // Sandshrew
        pokemonsDisponibles[10].Ataques.Add(new Ataque("Corte Fuego", 50, false, new TipoFuego()));
        pokemonsDisponibles[10].Ataques.Add(new Ataque("Cañón de Agua", 50, false, new TipoAgua()));
        pokemonsDisponibles[10].Ataques.Add(new Ataque("Terremoto", 60, false, new TipoTierra()));
        pokemonsDisponibles[10].Ataques.Add(new Ataque("Vendaval", 50, false, new TipoAire()));
        pokemonsDisponibles[10].Ataques.Add(new Ataque("Excavar", 90, true, new TipoTierra()));

        // Geodude
        pokemonsDisponibles[11].Ataques.Add(new Ataque("Corte Fuego", 50, false, new TipoFuego()));
        pokemonsDisponibles[11].Ataques.Add(new Ataque("Cañón de Agua", 50, false, new TipoAgua()));
        pokemonsDisponibles[11].Ataques.Add(new Ataque("Roca Afilada", 60, false, new TipoTierra()));
        pokemonsDisponibles[11].Ataques.Add(new Ataque("Huracán", 55, false, new TipoAire()));
        pokemonsDisponibles[11].Ataques.Add(new Ataque("Golpe Rocoso", 90, true, new TipoTierra()));

        // Diglett
        pokemonsDisponibles[12].Ataques.Add(new Ataque("Corte Fuego", 45, false, new TipoFuego()));
        pokemonsDisponibles[12].Ataques.Add(new Ataque("Hidrochorro", 45, false, new TipoAgua()));
        pokemonsDisponibles[12].Ataques.Add(new Ataque("Excavar", 55, false, new TipoTierra()));
        pokemonsDisponibles[12].Ataques.Add(new Ataque("Viento Cortante", 50, false, new TipoAire()));
        pokemonsDisponibles[12].Ataques.Add(new Ataque("Ataque Sísmico", 90, true, new TipoTierra()));

        // Onix
        pokemonsDisponibles[13].Ataques.Add(new Ataque("Cola Ígnea", 55, false, new TipoFuego()));
        pokemonsDisponibles[13].Ataques.Add(new Ataque("Hidro Bomba", 55, false, new TipoAgua()));
        pokemonsDisponibles[13].Ataques.Add(new Ataque("Destrucción", 70, false, new TipoTierra()));
        pokemonsDisponibles[13].Ataques.Add(new Ataque("Huracán", 60, false, new TipoAire()));
        pokemonsDisponibles[13].Ataques.Add(new Ataque("Roca Mortal", 100, true, new TipoTierra()));

        // Cubone
        pokemonsDisponibles[14].Ataques.Add(new Ataque("Fuego Sagrado", 55, false, new TipoFuego()));
        pokemonsDisponibles[14].Ataques.Add(new Ataque("Ola Trueno", 50, false, new TipoAgua()));
        pokemonsDisponibles[14].Ataques.Add(new Ataque("Fisura", 55, false, new TipoTierra()));
        pokemonsDisponibles[14].Ataques.Add(new Ataque("Vendaval", 50, false, new TipoAire()));
        pokemonsDisponibles[14].Ataques.Add(new Ataque("Hueso Poderoso", 85, true, new TipoTierra()));

        // Pidgey
        pokemonsDisponibles[15].Ataques.Add(new Ataque("Llamarada", 50, false, new TipoFuego()));
        pokemonsDisponibles[15].Ataques.Add(new Ataque("Bomba de Agua", 50, false, new TipoAgua()));
        pokemonsDisponibles[15].Ataques.Add(new Ataque("Excavar", 50, false, new TipoTierra()));
        pokemonsDisponibles[15].Ataques.Add(new Ataque("Ataque Aéreo", 60, false, new TipoAire()));
        pokemonsDisponibles[15].Ataques.Add(new Ataque("Torbellino", 85, true, new TipoAire()));

        // Spearow
        pokemonsDisponibles[16].Ataques.Add(new Ataque("Fuego Fatuo", 40, false, new TipoFuego()));
        pokemonsDisponibles[16].Ataques.Add(new Ataque("Pulso Agua", 45, false, new TipoAgua()));
        pokemonsDisponibles[16].Ataques.Add(new Ataque("Excavar", 45, false, new TipoTierra()));
        pokemonsDisponibles[16].Ataques.Add(new Ataque("Vendaval", 50, false, new TipoAire()));
        pokemonsDisponibles[16].Ataques.Add(new Ataque("Huracán", 85, true, new TipoAire()));

        // Zubat
        pokemonsDisponibles[17].Ataques.Add(new Ataque("Llama Azul", 40, false, new TipoFuego()));
        pokemonsDisponibles[17].Ataques.Add(new Ataque("Tsunami", 50, false, new TipoAgua()));
        pokemonsDisponibles[17].Ataques.Add(new Ataque("Avalancha", 50, false, new TipoTierra()));
        pokemonsDisponibles[17].Ataques.Add(new Ataque("Corte Viento", 50, false, new TipoAire()));
        pokemonsDisponibles[17].Ataques.Add(new Ataque("Explosión Aérea", 90, true, new TipoAire()));

        // Fearow
        pokemonsDisponibles[18].Ataques.Add(new Ataque("Llamarada", 55, false, new TipoFuego()));
        pokemonsDisponibles[18].Ataques.Add(new Ataque("Aqua Jet", 50, false, new TipoAgua()));
        pokemonsDisponibles[18].Ataques.Add(new Ataque("Fisura", 50, false, new TipoTierra()));
        pokemonsDisponibles[18].Ataques.Add(new Ataque("Huracán", 55, false, new TipoAire()));
        pokemonsDisponibles[18].Ataques.Add(new Ataque("Tornado Mortal", 95, true, new TipoAire()));

        // Doduo
        pokemonsDisponibles[19].Ataques.Add(new Ataque("Explosión Ígnea", 50, false, new TipoFuego()));
        pokemonsDisponibles[19].Ataques.Add(new Ataque("Bomba Agua", 45, false, new TipoAgua()));
        pokemonsDisponibles[19].Ataques.Add(new Ataque("Terremoto", 50, false, new TipoTierra()));
        pokemonsDisponibles[19].Ataques.Add(new Ataque("Viento Cortante", 55, false, new TipoAire()));
        pokemonsDisponibles[19].Ataques.Add(new Ataque("Vendaval Supremo", 90, true, new TipoAire()));
    }

    public void VerCatalogo()
    {
        Console.WriteLine("Pokémon disponibles en el catálogo:");
        for (int i = 0; i < pokemonsDisponibles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemonsDisponibles[i].Nombre} (HP: {pokemonsDisponibles[i].HP})");
        }
    }

    public void SeleccionarPokemon(Jugador jugador)
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