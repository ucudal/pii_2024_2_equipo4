using Library;

namespace Pokemones_personal;

public class Jugador
{
    public string Nombre { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public int IndicePokemon { get; set; } = 0;  // Indica el Pokémon activo

    public Jugador(string nombre, int pokemonActivo)
    {
        Nombre = nombre;
        Pokemons = new List<Pokemon>();
        IndicePokemon = pokemonActivo;
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
            Console.WriteLine("Ya tienes 6 Pokémones en tu equipo.");
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
    public void Atacar(Jugador oponente, int indiceAtaque)
    {
        Pokemon atacante = PokemonActivo();
        Pokemon oponentePokemon = oponente.PokemonActivo();

        if (indiceAtaque >= 0 && indiceAtaque < atacante.Ataques.Count)
        {
            Ataque ataqueSeleccionado = atacante.Ataques[indiceAtaque];

            // Verificar si el ataque es especial
            if (ataqueSeleccionado.Especial)
            {
                // Verificar si el Pokémon puede usar el ataque especial
                if (atacante.PuedeUsarAtaqueEspecial())
                {
                    // Realizar el ataque especial
                    Console.WriteLine($"{Nombre} ordena a {atacante.Nombre} usar {ataqueSeleccionado.Nombre} (Especial) contra {oponentePokemon.Nombre}.");
                    oponentePokemon.RecibirAtaque(ataqueSeleccionado);
                    atacante.UsarAtaqueEspecial();  // Resetear el contador de ataques especiales
                }
                else
                {
                    // Mostrar mensaje de que no se puede usar el ataque especial en este turno
                    Console.WriteLine($"No puedes usar el ataque especial {ataqueSeleccionado.Nombre} en este turno. Debes realizar dos ataques normales antes de usar un ataque especial.");
                    return;  // Detener la ejecución si no se puede usar el ataque especial
                }
            }
            else
            {
                // Si el ataque no es especial, se realiza normalmente
                Console.WriteLine($"{Nombre} ordena a {atacante.Nombre} usar {ataqueSeleccionado.Nombre} contra {oponentePokemon.Nombre}.");
                oponentePokemon.RecibirAtaque(ataqueSeleccionado);
                atacante.IncrementarContadorAtaques();  // Incrementar el contador de ataques normales
            }

            // Verificar si el Pokémon oponente ha muerto
            if (!oponentePokemon.EstaVivo())
            {
                Console.WriteLine($"{oponentePokemon.Nombre} ha muerto.");
                oponente.CambiarPokemonAutomaticamente();
            }
        }
        else
        {
            Console.WriteLine("Índice de ataque inválido.");
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