namespace DefaultNamespace;

public class Catalogo
{
    private List<Pokemon> pokemonsDisponibles;

    public Catalogo()
    {
        pokemonsDisponibles = new List<Pokemon>
        { 
            new Pokemon("Charmander", 100, new List<Ataque> 
            {
                new Ataque("Llamarada", 50, false, new TipoFuego())
            }
            new Pokemon("Squirtle", 120, new List<Ataque> 
            { 
                new Ataque("HidroBomba", 45, false, new TipoAgua())
            } 

            new Pokemon("Bulbasaur", 110, new List<Ataque> 
            { 
                new Ataque("Latigazo", 40, false, new TipoTierra()) 
            } 
            

            new Pokemon("Pidgey", 90, new List<Ataque> 
            { 
                new Ataque("Ráfaga", 35, false, new TipoAire()) 
            }, 
            new TipoAire())
        };
    }

    public void mostrarPokemons()
    {
        foreach ( Pokemon Pokemon in pokemons)
        {
            Console.Writeline(Pokemon);
        }
    }

    public ArrayList misPokemons;
    public void agregarMisPokemons;
    {
        int totalPokemos = 0;
        Console.WriteLine("Ingrese el pokemon que desa agregar")
        string pokemonAgregar = Console.ReadLine();
        while (totalPokemos < 5)
        {
            if (pokemos.Contains(pokemonAgregar))
            {
                int indx = pokemons.IndexOf(pokemonAgregar);
                misPokemos.add(pokemos[indx]);
            }
        }
    }


}