using System;
using System.Collections.Generic;
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

        // Inicializar el catálogo con los Pokémon disponibles y sus ataques
        private void InicializarPokemons()
        {
            // Cada Pokémon tiene tres ataques comunes y uno de los cuatro ataques especiales (Dormir, Envenenar, Paralizar, Quemar)
            
            // Pokémon tipo Fuego - Charmander
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            charmander.Ataques.Add(new AtaqueComun("Arañazo", new TipoNormal(), 40, 1.0));
            charmander.Ataques.Add(new AtaqueComun("Giro Fuego", new TipoFuego(), 50, 1.0));
            charmander.Ataques.Add(new AtaqueComun("Cola Dragón", new TipoDragon(), 45, 0.9));
            charmander.Ataques.Add(new AtaqueQuemar());  // Ataque especial: Quemar
            pokemonsDisponibles.Add(charmander);

            // Pokémon tipo Agua - Squirtle
            Pokemon squirtle = new Pokemon("Squirtle", 120, new TipoAgua());
            squirtle.Ataques.Add(new AtaqueComun("Placaje", new TipoNormal(), 50, 1.0));
            squirtle.Ataques.Add(new AtaqueComun("Burbuja", new TipoAgua(), 40, 1.0));
            squirtle.Ataques.Add(new AtaqueComun("Golpe Cuerpo", new TipoLucha(), 55, 0.9));
            squirtle.Ataques.Add(new AtaqueParalizar());  // Ataque especial: Paralizar
            pokemonsDisponibles.Add(squirtle);

            // Pokémon tipo Planta - Bulbasaur
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 105, new TipoPlanta());
            bulbasaur.Ataques.Add(new AtaqueComun("Latigazo", new TipoPlanta(), 45, 1.0));
            bulbasaur.Ataques.Add(new AtaqueComun("Hoja Afilada", new TipoPlanta(), 50, 1.0));
            bulbasaur.Ataques.Add(new AtaqueComun("Bomba Lodo", new TipoVeneno(), 55, 0.9));
            bulbasaur.Ataques.Add(new AtaqueEnvenenar());  // Ataque especial: Envenenar
            pokemonsDisponibles.Add(bulbasaur);

            // Pokémon tipo Eléctrico - Pikachu
            Pokemon pikachu = new Pokemon("Pikachu", 95, new TipoElectrico());
            pikachu.Ataques.Add(new AtaqueComun("Impactrueno", new TipoElectrico(), 40, 1.0));
            pikachu.Ataques.Add(new AtaqueComun("Ataque Rápido", new TipoNormal(), 50, 1.0));
            pikachu.Ataques.Add(new AtaqueComun("Cola Férrea", new TipoRoca(), 45, 0.9));
            pikachu.Ataques.Add(new AtaqueParalizar());  // Ataque especial: Paralizar
            pokemonsDisponibles.Add(pikachu);

            // Pokémon tipo Roca - Onix
            Pokemon onix = new Pokemon("Onix", 130, new TipoRoca());
            onix.Ataques.Add(new AtaqueComun("Lanzarrocas", new TipoRoca(), 50, 1.0));
            onix.Ataques.Add(new AtaqueComun("Excavar", new TipoTierra(), 55, 1.0));
            onix.Ataques.Add(new AtaqueComun("Golpe Cabeza", new TipoNormal(), 45, 0.9));
            onix.Ataques.Add(new AtaqueQuemar());  // Ataque especial: Quemar
            pokemonsDisponibles.Add(onix);

            // Pokémon tipo Volador - Pidgeotto
            Pokemon pidgeotto = new Pokemon("Pidgeotto", 100, new TipoVolador());
            pidgeotto.Ataques.Add(new AtaqueComun("Ataque Ala", new TipoVolador(), 45, 1.0));
            pidgeotto.Ataques.Add(new AtaqueComun("Remolino", new TipoVolador(), 50, 1.0));
            pidgeotto.Ataques.Add(new AtaqueComun("Picotazo", new TipoVolador(), 40, 1.0));
            pidgeotto.Ataques.Add(new AtaqueDormir());  // Ataque especial: Dormir
            pokemonsDisponibles.Add(pidgeotto);

            // Pokémon tipo Hielo - Dewgong
            Pokemon dewgong = new Pokemon("Dewgong", 120, new TipoHielo());
            dewgong.Ataques.Add(new AtaqueComun("Rayo Hielo", new TipoHielo(), 45, 1.0));
            dewgong.Ataques.Add(new AtaqueComun("Cabezazo", new TipoNormal(), 50, 1.0));
            dewgong.Ataques.Add(new AtaqueComun("Agua Lodosa", new TipoAgua(), 55, 1.0));
            dewgong.Ataques.Add(new AtaqueQuemar());  // Ataque especial: Quemar
            pokemonsDisponibles.Add(dewgong);

            // Pokémon tipo Fantasma - Gengar
            Pokemon gengar = new Pokemon("Gengar", 110, new TipoFantasma());
            gengar.Ataques.Add(new AtaqueComun("Lengüetazo", new TipoFantasma(), 40, 1.0));
            gengar.Ataques.Add(new AtaqueComun("Puño Sombra", new TipoFantasma(), 50, 1.0));
            gengar.Ataques.Add(new AtaqueComun("Bola Sombra", new TipoFantasma(), 55, 1.0));
            gengar.Ataques.Add(new AtaqueEnvenenar());  // Ataque especial: Envenenar
            pokemonsDisponibles.Add(gengar);

            // Pokémon tipo Dragón - Dragonite
            Pokemon dragonite = new Pokemon("Dragonite", 150, new TipoDragon());
            dragonite.Ataques.Add(new AtaqueComun("Garra Dragón", new TipoDragon(), 45, 1.0));
            dragonite.Ataques.Add(new AtaqueComun("Puño Trueno", new TipoElectrico(), 50, 1.0));
            dragonite.Ataques.Add(new AtaqueComun("Cola Dragón", new TipoDragon(), 55, 1.0));
            dragonite.Ataques.Add(new AtaqueQuemar());  // Ataque especial: Quemar
            pokemonsDisponibles.Add(dragonite);

            // Pokémon tipo Veneno - Nidoking
            Pokemon nidoking = new Pokemon("Nidoking", 130, new TipoVeneno());
            nidoking.Ataques.Add(new AtaqueComun("Cuchillada", new TipoNormal(), 45, 1.0));
            nidoking.Ataques.Add(new AtaqueComun("Golpe Bajo", new TipoFantasma(), 50, 1.0));
            nidoking.Ataques.Add(new AtaqueComun("Terremoto", new TipoTierra(), 55, 1.0));
            nidoking.Ataques.Add(new AtaqueEnvenenar());  // Ataque especial: Envenenar
            pokemonsDisponibles.Add(nidoking);

            // Otros 10 Pokémon con ataques similares

            Pokemon machamp = new Pokemon("Machamp", 140, new TipoLucha());
            machamp.Ataques.Add(new AtaqueComun("Puño Dinámico", new TipoLucha(), 45, 1.0));
            machamp.Ataques.Add(new AtaqueComun("Patada Baja", new TipoLucha(), 50, 1.0));
            machamp.Ataques.Add(new AtaqueComun("Golpe Karate", new TipoLucha(), 55, 1.0));
            machamp.Ataques.Add(new AtaqueParalizar());  // Ataque especial: Paralizar
            pokemonsDisponibles.Add(machamp);

            // Aquí puedes seguir añadiendo más Pokémon con la misma estructura.
        }

        // Mostrar todos los Pokémon disponibles en el catálogo
        public void VerCatalogo()
        {
            Console.WriteLine("Pokémon disponibles en el catálogo:");
            for (int i = 0; i < pokemonsDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemonsDisponibles[i].Nombre} (HP: {pokemonsDisponibles[i].HP}/{pokemonsDisponibles[i].HPMax})");
            }
        }

        // Seleccionar 6 Pokémon del catálogo y agregarlos al equipo del jugador
        public void SeleccionarPokemon(IJugador jugador)
        {
            Console.WriteLine($"Selecciona 6 Pokémon para tu equipo, {jugador.Nombre}.");
            VerCatalogo();

            for (int i = 0; i < 6; i++)  // Seleccionar 6 Pokémon
            {
                Console.WriteLine($"Selecciona el Pokémon número {i + 1}:");
                int seleccion = Convert.ToInt32(Console.ReadLine()) - 1;

                if (seleccion >= 0 && seleccion < pokemonsDisponibles.Count)
                {
                    Pokemon pokemonSeleccionado = pokemonsDisponibles[seleccion];

                    // Clonar el Pokémon y agregarlo al equipo del jugador
                    Pokemon nuevoPokemon = new Pokemon(pokemonSeleccionado.Nombre, pokemonSeleccionado.HPMax, pokemonSeleccionado.Tipo)
                    {
                        Ataques = new List<IAtaque>(pokemonSeleccionado.Ataques)  // Copiar ataques
                    };

                    jugador.AgregarPokemon(nuevoPokemon);
                    Console.WriteLine($"{nuevoPokemon.Nombre} ha sido agregado a tu equipo.");
                }
                else
                {
                    Console.WriteLine("Selección inválida, intenta nuevamente.");
                    i--;  // Repetir si la selección es inválida
                }
            }
        }
    }
}
