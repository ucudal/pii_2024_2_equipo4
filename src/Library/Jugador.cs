using Library.Interfaces;

namespace Library;

public class Jugador: IJugador
{
    public string Nombre { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public int IndicePokemon { get; set; } = 0;  // Indica el Pokémon activo

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Pokemons = new List<Pokemon>();
    }

    // Método para agregar Pokémon al equipo
    public void AgregarPokemon(Pokemon pokemon)
    {
        if (Pokemons.Count < 6)  // Se permite un máximo de 6 Pokémon en el equipo
        {
            Pokemons.Add(pokemon);
        }
        else
        {
            Console.WriteLine("Ya tienes 6 Pokémon en tu equipo.");
        }
    }

    // Método para seleccionar el Pokémon activo
    public Pokemon PokemonActivo()
    {
        return Pokemons[IndicePokemon];
    }

    // Método para cambiar de Pokémon manualmente
    public void CambiarPokemon(int nuevoIndice)
    {
        if (nuevoIndice >= 0 && nuevoIndice < Pokemons.Count)
        {
            IndicePokemon = nuevoIndice;
            Console.WriteLine($"Has cambiado al Pokémon activo a {PokemonActivo().Nombre}.");
        }
    }

   // Método para atacar al oponente
   public void Atacar(IJugador oponente, int indiceAtaque)
   {
       Pokemon atacante = PokemonActivo();  // Pokémon del jugador que ataca
       Pokemon defensor = oponente.PokemonActivo();  // Pokémon del oponente que defiende

       // Antes de atacar, se verifica si el atacante puede realizar el ataque (por efectos de estado como paralizado, dormido, etc.)
       if (atacante.PuedeAtacar)
       {
           // Ejecutar el ataque seleccionado sobre el Pokémon defensor
           atacante.EjecutarAtaque(defensor, indiceAtaque);

           // Verificar si el Pokémon defensor ha sido derrotado
           if (!defensor.EstaVivo())
           {
               Console.WriteLine($"{defensor.Nombre} ha sido derrotado.");
               oponente.CambiarPokemonAutomaticamente();  // Cambiar automáticamente al siguiente Pokémon vivo
           }
       }
       else
       {
           Console.WriteLine($"{atacante.Nombre} no puede atacar este turno.");
       }
   }
    
    // Método para cambiar automáticamente al siguiente Pokémon vivo
    public void CambiarPokemonAutomaticamente()
    {
        for (int i = 0; i < Pokemons.Count; i++)
        {
            if (Pokemons[i].EstaVivo())
            {
                IndicePokemon = i;
                Console.WriteLine($"El siguiente Pokémon activo es {PokemonActivo().Nombre}.");
                return;
            }
        }
        Console.WriteLine("No hay más Pokémon vivos para cambiar.");
    }

    // Método para contar cuántos Pokémon vivos tiene el jugador
    public int PokemonsVivos()
    {
        return Pokemons.Count(pokemon => pokemon.HP > 0);
    }

    // Mostrar los Pokémon disponibles
    public void MostrarPokemonsDisponibles()
    {
        Console.WriteLine($"Pokémon en el equipo de {Nombre}:");
        for (int i = 0; i < Pokemons.Count; i++)
        {
            var pokemon = Pokemons[i];
            Console.WriteLine($"{i + 1}. {pokemon.Nombre} (HP: {pokemon.HP}/{pokemon.HPMax})");
        }
    }
}