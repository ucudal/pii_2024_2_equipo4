namespace Library;

public class CreacionElementosJuego
{
    public static Dictionary<string, Tipo> InicializarTipos()
    {
        var fuego = new Tipo("Fuego");
        var agua = new Tipo("Agua");
        var tierra = new Tipo("Tierra");
        var aire = new Tipo("Aire");

        // Configurar efectividades
        fuego.AgregarEfectividad("Agua", 2.0);  // Fuego es débil contra Agua
        fuego.AgregarEfectividad("Tierra", 0.5);  // Fuego es fuerte contra Tierra
        fuego.AgregarEfectividad("Aire", 1.0);  // Fuego es neutral contra Aire

        agua.AgregarEfectividad("Fuego", 0.5);  // Agua es fuerte contra Fuego
        agua.AgregarEfectividad("Tierra", 1.25);  // Agua es fuerte contra Tierra
        agua.AgregarEfectividad("Aire", 1.0);  // Agua es neutral contra Aire

        tierra.AgregarEfectividad("Fuego", 1.0);  // Tierra es neutral contra Fuego
        tierra.AgregarEfectividad("Agua", 0.5);  // Tierra es débil contra Agua
        tierra.AgregarEfectividad("Aire", 0.5);  // Tierra es débil contra Aire

        aire.AgregarEfectividad("Tierra", 2.0);  // Aire es fuerte contra Tierra
        aire.AgregarEfectividad("Fuego", 0.5);  // Aire es débil contra Fuego
        aire.AgregarEfectividad("Agua", 1.0);  // Aire es neutral contra Agua


        return new Dictionary<string, Tipo>
        {
            { "Fuego", fuego },
            { "Agua", agua },
            { "Tierra", tierra },
            { "Aire", aire }
        };
    }

    public static List<Pokemon> InicializarPokemons(Dictionary<string, Tipo> tipos)
    {
        var pokemons = new List<Pokemon>
        {
            // Tipo Fuego
            new Pokemon("Charmander", 100, tipos["Fuego"]),
            new Pokemon("Vulpix", 95, tipos["Fuego"]),
            new Pokemon("Growlithe", 110, tipos["Fuego"]),
            new Pokemon("Ponyta", 100, tipos["Fuego"]),
            new Pokemon("Magmar", 105, tipos["Fuego"]),

            // Tipo Agua
            new Pokemon("Squirtle", 120, tipos["Agua"]),
            new Pokemon("Psyduck", 105, tipos["Agua"]),
            new Pokemon("Poliwag", 115, tipos["Agua"]),
            new Pokemon("Goldeen", 110, tipos["Agua"]),
            new Pokemon("Seel", 120, tipos["Agua"]),

            // Tipo Tierra
            new Pokemon("Sandshrew", 110, tipos["Tierra"]),
            new Pokemon("Geodude", 120, tipos["Tierra"]),
            new Pokemon("Diglett", 100, tipos["Tierra"]),
            new Pokemon("Onix", 130, tipos["Tierra"]),
            new Pokemon("Cubone", 105, tipos["Tierra"]),

            // Tipo Aire
            new Pokemon("Pidgey", 90, tipos["Aire"]),
            new Pokemon("Spearow", 85, tipos["Aire"]),
            new Pokemon("Zubat", 95, tipos["Aire"]),
            new Pokemon("Fearow", 105, tipos["Aire"]),
            new Pokemon("Doduo", 100, tipos["Aire"]),
        };

        // Asignar ataques a los Pokémon
        AsignarAtaques(pokemons, tipos);

        return pokemons;
    }

    private static void AsignarAtaques(List<Pokemon> pokemons, Dictionary<string, Tipo> tipo)
    {
        // Charmander
    pokemons[0].Ataques.Add(new Ataque("Llamarada", 50, false, tipo["Fuego"]));
    pokemons[0].Ataques.Add(new Ataque("Hidro Bomba", 50, false, tipo["Agua"]));
    pokemons[0].Ataques.Add(new Ataque("Terremoto", 50, false, tipo["Tierra"]));
    pokemons[0].Ataques.Add(new Ataque("Ráfaga", 50, false, tipo["Aire"]));
    pokemons[0].Ataques.Add(new Ataque("Explosión Solar", 90, true, tipo["Fuego"]));

    // Vulpix
    pokemons[1].Ataques.Add(new Ataque("Ascuas", 40, false, tipo["Fuego"]));
    pokemons[1].Ataques.Add(new Ataque("Pulso Agua", 50, false, tipo["Agua"]));
    pokemons[1].Ataques.Add(new Ataque("Magnitud", 45, false, tipo["Tierra"]));
    pokemons[1].Ataques.Add(new Ataque("Tornado", 50, false, tipo["Aire"]));
    pokemons[1].Ataques.Add(new Ataque("Llama Azul", 80, true, tipo["Fuego"]));

    // Growlithe
    pokemons[2].Ataques.Add(new Ataque("Lanzallamas", 55, false, tipo["Fuego"]));
    pokemons[2].Ataques.Add(new Ataque("Torbellino", 50, false, tipo["Agua"]));
    pokemons[2].Ataques.Add(new Ataque("Fisura", 50, false, tipo["Tierra"]));
    pokemons[2].Ataques.Add(new Ataque("Ataque Ala", 50, false, tipo["Aire"]));
    pokemons[2].Ataques.Add(new Ataque("Sofoco", 85, true, tipo["Fuego"]));

    // Ponyta
    pokemons[3].Ataques.Add(new Ataque("Giro Fuego", 45, false, tipo["Fuego"]));
    pokemons[3].Ataques.Add(new Ataque("Aqua Jet", 40, false, tipo["Agua"]));
    pokemons[3].Ataques.Add(new Ataque("Avalancha", 45, false, tipo["Tierra"]));
    pokemons[3].Ataques.Add(new Ataque("Tajo Aéreo", 50, false, tipo["Aire"]));
    pokemons[3].Ataques.Add(new Ataque("Erupción", 80, true, tipo["Fuego"]));

    // Magmar
    pokemons[4].Ataques.Add(new Ataque("Fuego Fatuo", 35, false, tipo["Fuego"]));
    pokemons[4].Ataques.Add(new Ataque("Surf", 45, false, tipo["Agua"]));
    pokemons[4].Ataques.Add(new Ataque("Corteza Tierra", 50, false, tipo["Tierra"]));
    pokemons[4].Ataques.Add(new Ataque("Vendaval", 45, false, tipo["Aire"]));
    pokemons[4].Ataques.Add(new Ataque("Onda Ígnea", 85, true, tipo["Fuego"]));

    // Squirtle
    pokemons[5].Ataques.Add(new Ataque("Llamarada", 50, false, tipo["Fuego"]));
    pokemons[5].Ataques.Add(new Ataque("Hidro Bomba", 90, true, tipo["Agua"]));
    pokemons[5].Ataques.Add(new Ataque("Terremoto", 50, false, tipo["Tierra"]));
    pokemons[5].Ataques.Add(new Ataque("Huracán", 45, false, tipo["Aire"]));
    pokemons[5].Ataques.Add(new Ataque("Rayo Solar", 90, true, tipo["Fuego"]));

    // Psyduck
    pokemons[6].Ataques.Add(new Ataque("Ascuas", 40, false, tipo["Fuego"]));
    pokemons[6].Ataques.Add(new Ataque("Pulso Agua", 85, true, tipo["Agua"]));
    pokemons[6].Ataques.Add(new Ataque("Magnitud", 45, false, tipo["Tierra"]));
    pokemons[6].Ataques.Add(new Ataque("Tornado", 40, false, tipo["Aire"]));
    pokemons[6].Ataques.Add(new Ataque("Llama Azul", 80, true, tipo["Fuego"]));

    // Poliwag
    pokemons[7].Ataques.Add(new Ataque("Lanzallamas", 50, false, tipo["Fuego"]));
    pokemons[7].Ataques.Add(new Ataque("Torbellino", 50, false, tipo["Agua"]));
    pokemons[7].Ataques.Add(new Ataque("Fisura", 50, false, tipo["Tierra"]));
    pokemons[7].Ataques.Add(new Ataque("Ataque Ala", 50, false, tipo["Aire"]));
    pokemons[7].Ataques.Add(new Ataque("Sofoco", 85, true, tipo["Fuego"]));

    // Goldeen
    pokemons[8].Ataques.Add(new Ataque("Giro Fuego", 40, false, tipo["Fuego"]));
    pokemons[8].Ataques.Add(new Ataque("Aqua Jet", 50, false, tipo["Agua"]));
    pokemons[8].Ataques.Add(new Ataque("Avalancha", 45, false, tipo["Tierra"]));
    pokemons[8].Ataques.Add(new Ataque("Tajo Aéreo", 50, false, tipo["Aire"]));
    pokemons[8].Ataques.Add(new Ataque("Erupción", 80, true, tipo["Fuego"]));

    // Seel
    pokemons[9].Ataques.Add(new Ataque("Fuego Fatuo", 35, false, tipo["Fuego"]));
    pokemons[9].Ataques.Add(new Ataque("Surf", 45, false, tipo["Agua"]));
    pokemons[9].Ataques.Add(new Ataque("Corteza Tierra", 50, false, tipo["Tierra"]));
    pokemons[9].Ataques.Add(new Ataque("Vendaval", 50, false, tipo["Aire"]));
    pokemons[9].Ataques.Add(new Ataque("Onda Ígnea", 85, true, tipo["Fuego"]));

    // Sandshrew
    pokemons[10].Ataques.Add(new Ataque("Corte Fuego", 50, false, tipo["Fuego"]));
    pokemons[10].Ataques.Add(new Ataque("Cañón de Agua", 50, false, tipo["Agua"]));
    pokemons[10].Ataques.Add(new Ataque("Terremoto", 60, false, tipo["Tierra"]));
    pokemons[10].Ataques.Add(new Ataque("Vendaval", 50, false, tipo["Aire"]));
    pokemons[10].Ataques.Add(new Ataque("Excavar", 90, true, tipo["Tierra"]));

    // Geodude
    pokemons[11].Ataques.Add(new Ataque("Corte Fuego", 50, false, tipo["Fuego"]));
    pokemons[11].Ataques.Add(new Ataque("Cañón de Agua", 50, false, tipo["Agua"]));
    pokemons[11].Ataques.Add(new Ataque("Roca Afilada", 60, false, tipo["Tierra"]));
    pokemons[11].Ataques.Add(new Ataque("Huracán", 55, false, tipo["Aire"]));
    pokemons[11].Ataques.Add(new Ataque("Golpe Rocoso", 90, true, tipo["Tierra"]));

    // Diglett
    pokemons[12].Ataques.Add(new Ataque("Corte Fuego", 45, false, tipo["Fuego"]));
    pokemons[12].Ataques.Add(new Ataque("Hidrochorro", 45, false, tipo["Agua"]));
    pokemons[12].Ataques.Add(new Ataque("Excavar", 55, false, tipo["Tierra"]));
    pokemons[12].Ataques.Add(new Ataque("Viento Cortante", 50, false, tipo["Aire"]));
    pokemons[12].Ataques.Add(new Ataque("Ataque Sísmico", 90, true, tipo["Tierra"]));

    // Onix
    pokemons[13].Ataques.Add(new Ataque("Cola Ígnea", 55, false, tipo["Fuego"]));
    pokemons[13].Ataques.Add(new Ataque("Hidro Bomba", 55, false, tipo["Agua"]));
    pokemons[13].Ataques.Add(new Ataque("Destrucción", 70, false, tipo["Tierra"]));
    pokemons[13].Ataques.Add(new Ataque("Huracán", 60, false, tipo["Aire"]));
    pokemons[13].Ataques.Add(new Ataque("Roca Mortal", 100, true, tipo["Tierra"]));

    // Cubone
    pokemons[14].Ataques.Add(new Ataque("Fuego Sagrado", 55, false, tipo["Fuego"]));
    pokemons[14].Ataques.Add(new Ataque("Ola Trueno", 50, false, tipo["Agua"]));
    pokemons[14].Ataques.Add(new Ataque("Fisura", 55, false, tipo["Tierra"]));
    pokemons[14].Ataques.Add(new Ataque("Vendaval", 50, false, tipo["Aire"]));
    pokemons[14].Ataques.Add(new Ataque("Hueso Poderoso", 85, true, tipo["Tierra"]));

    // Pidgey
    pokemons[15].Ataques.Add(new Ataque("Llamarada", 50, false, tipo["Fuego"]));
    pokemons[15].Ataques.Add(new Ataque("Bomba de Agua", 50, false, tipo["Agua"]));
    pokemons[15].Ataques.Add(new Ataque("Excavar", 50, false, tipo["Tierra"]));
    pokemons[15].Ataques.Add(new Ataque("Ataque Aéreo", 60, false, tipo["Aire"]));
    pokemons[15].Ataques.Add(new Ataque("Torbellino", 85, true, tipo["Aire"]));

    // Spearow
    pokemons[16].Ataques.Add(new Ataque("Fuego Fatuo", 40, false, tipo["Fuego"]));
    pokemons[16].Ataques.Add(new Ataque("Pulso Agua", 45, false, tipo["Agua"]));
    pokemons[16].Ataques.Add(new Ataque("Excavar", 45, false, tipo["Tierra"]));
    pokemons[16].Ataques.Add(new Ataque("Vendaval", 50, false, tipo["Aire"]));
    pokemons[16].Ataques.Add(new Ataque("Huracán", 85, true, tipo["Aire"]));

    // Zubat
    pokemons[17].Ataques.Add(new Ataque("Llama Azul", 40, false, tipo["Fuego"]));
    pokemons[17].Ataques.Add(new Ataque("Tsunami", 50, false, tipo["Agua"]));
    pokemons[17].Ataques.Add(new Ataque("Avalancha", 50, false, tipo["Tierra"]));
    pokemons[17].Ataques.Add(new Ataque("Corte Viento", 50, false, tipo["Aire"]));
    pokemons[17].Ataques.Add(new Ataque("Explosión Aérea", 90, true, tipo["Aire"]));

    // Fearow
    pokemons[18].Ataques.Add(new Ataque("Llamarada", 55, false, tipo["Fuego"]));
    pokemons[18].Ataques.Add(new Ataque("Aqua Jet", 50, false, tipo["Agua"]));
    pokemons[18].Ataques.Add(new Ataque("Fisura", 50, false, tipo["Tierra"]));
    pokemons[18].Ataques.Add(new Ataque("Huracán", 55, false, tipo["Aire"]));
    pokemons[18].Ataques.Add(new Ataque("Tornado Mortal", 95, true, tipo["Aire"]));

    // Doduo
    pokemons[19].Ataques.Add(new Ataque("Explosión Ígnea", 50, false, tipo["Fuego"]));
    pokemons[19].Ataques.Add(new Ataque("Bomba Agua", 45, false, tipo["Agua"]));
    pokemons[19].Ataques.Add(new Ataque("Terremoto", 50, false, tipo["Tierra"]));
    pokemons[19].Ataques.Add(new Ataque("Viento Cortante", 55, false, tipo["Aire"]));
    pokemons[19].Ataques.Add(new Ataque("Vendaval Supremo", 90, true, tipo["Aire"]));
    }
}