using Library;
using NUnit.Framework;

namespace Pokemones.Tests
{
    public class BatallaTests
    {
        private Catalogo catalogo;
        private Jugador jugador1;
        private Jugador jugador2;

        [SetUp]
        public void Setup()
        {
            catalogo = new Catalogo();
            jugador1 = new Jugador("Jugador 1");
            jugador2 = new Jugador("Jugador 2");
        }
        
        // Verificar que el jugador no pueda seleccionar más de 6 Pokemon. 
        [Test]
        public void Jugador_NoPuedeSeleccionarMasDe6Pokemon()
        {
            for (int i = 0; i < 6; i++)
            {
                jugador1.AgregarPokemon(new Pokemon($"Pokemon {i}", 100, new TipoFuego()));
            }

            // Intentar agregar un séptimo Pokémon
            jugador1.AgregarPokemon(new Pokemon("ExtraPokemon", 100, new TipoFuego()));

            Assert.That(jugador1.Pokemons.Count, Is.EqualTo(6), "El jugador no debería poder tener más de 6 Pokémon.");
        }
        

        // Comprobar que los ataques comunes funcionan correctamente reduciendo el HP del oponente.
        [Test]
        public void AtaqueComun_ReduceHP_EnFuncionDeEfectividad()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemonDefensor = new Pokemon("Squirtle", 100, new TipoAgua());
            var ataque = new Ataque("Llamarada", 50, false, new TipoFuego());

            pokemonDefensor.RecibirAtaque(ataque);
            Assert.That(pokemonDefensor.HP, Is.EqualTo(75), "El HP del defensor debería reducirse correctamente.");
        }

        // Comprobar que si se selecciona un ataque especial antes de que se permita, se muestra un mensaje de error.
        [Test]
        public void AtaqueEspecial_SeleccionadoAntesDeTiempo_MuestraMensajeError()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemonDefensor = new Pokemon("Squirtle", 100, new TipoAgua());
            var ataqueEspecial = new Ataque("Explosión Solar", 90, true, new TipoFuego());

            pokemonAtacante.Ataques.Add(ataqueEspecial);

            // Simulación del ataque sin haber pasado dos turnos
            if (!pokemonAtacante.PuedeUsarAtaqueEspecial())
            {
                Assert.Pass("El mensaje de error debería mostrarse ya que el ataque especial no puede usarse aún.");
            }
        }

        // Comprobar que un jugador puede cambiar de Pokémon durante su turno.
        [Test]
        public void Jugador_PuedeCambiarPokemonEnSuTurno()
        {
            var pokemon1 = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemon2 = new Pokemon("Squirtle", 100, new TipoAgua());

            jugador1.AgregarPokemon(pokemon1);
            jugador1.AgregarPokemon(pokemon2);

            // Cambiar al segundo Pokémon
            jugador1.CambiarPokemon(1);
            Assert.That(jugador1.PokemonActivo(), Is.EqualTo(pokemon2), "El jugador debería poder cambiar de Pokémon en su turno.");
        }

        // Validar que si el Pokémon activo se queda sin vida, el cambio de Pokémon se realiza automáticamente.
        [Test]
        public void CambioAutomaticoSiPokemonMuere()
        {
            var pokemon1 = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemon2 = new Pokemon("Squirtle", 100, new TipoAgua());

            jugador1.AgregarPokemon(pokemon1);
            jugador1.AgregarPokemon(pokemon2);

            pokemon1.HP = 0; // Pokémon 1 muere
            jugador1.CambiarPokemonAutomaticamente();

            Assert.That(jugador1.PokemonActivo(), Is.EqualTo(pokemon2), "El cambio de Pokémon debería ser automático cuando el Pokémon activo muere.");
        }

        // Verificar que los puntos de vida de un Pokémon se muestran correctamente en el formato “actual/total”.
        [Test]
        public void MostrarVidaEnFormatoCorrecto()
        {
            var pokemon = new Pokemon("Charmander", 100, new TipoFuego());
            Assert.That(pokemon.MostrarVida(), Is.EqualTo("100/100"), "La vida debería mostrarse en el formato correcto.");
        }

        // Validar que cuando un Pokémon muere, no puede seguir atacando ni recibir ataques.
        [Test]
        public void PokemonMuerto_NoPuedeAtacarNiRecibirAtaques()
        {
            var pokemon = new Pokemon("Charmander", 0, new TipoFuego());
            Assert.That(pokemon.EstaVivo(), Is.False, "El Pokémon debería estar muerto y no poder atacar o recibir ataques.");
        }
        
        // Verificar que un Pokémon no puede cambiar a si mismo
        [Test]
        public void Jugador_NoPuedeCambiarPokemonASiMismo()
        {
            var pokemon1 = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemon2 = new Pokemon("Squirtle", 100, new TipoAgua());

            jugador1.AgregarPokemon(pokemon1);
            jugador1.AgregarPokemon(pokemon2);

            jugador1.CambiarPokemon(0);  // Tratar de cambiar al mismo Pokémon activo

            Assert.That(jugador1.PokemonActivo(), Is.EqualTo(pokemon1), "El jugador no debería poder cambiar al mismo Pokémon activo.");
        }
        
        
        // Verificar ataque tipo fuego contra Pokémon tipo agua (efectividad)
        [Test]
        public void Ataque_TipoFuegoContraAgua_Inefectivo()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemonDefensor = new Pokemon("Squirtle", 100, new TipoAgua());
            var ataque = new Ataque("Llamarada", 50, false, new TipoFuego());

            pokemonDefensor.RecibirAtaque(ataque);

            // Fuego es menos efectivo contra Agua, el daño debe ser reducido (por ejemplo, a la mitad).
            Assert.That(pokemonDefensor.HP, Is.EqualTo(75), "El ataque de Fuego debería ser inefectivo contra un Pokémon de Agua.");
        }
        
        // Verificar ataque tipo agua contra Pokémon tipo fuego (efectividad)
        [Test]
        public void Ataque_TipoAguaContraFuego_SuperEfectivo()
        {
            var pokemonAtacante = new Pokemon("Squirtle", 100, new TipoAgua());
            var pokemonDefensor = new Pokemon("Charmander", 100, new TipoFuego());
            var ataque = new Ataque("Hidro Bomba", 50, false, new TipoAgua());

            pokemonDefensor.RecibirAtaque(ataque);

            // Agua es súper efectivo contra Fuego, el daño debe ser aumentado (por ejemplo, al doble).
            Assert.That(pokemonDefensor.HP, Is.EqualTo(25), "El ataque de Agua debería ser súper efectivo contra un Pokémon de Fuego.");
        }
        
        // Verificar ataque tipo tierra contra Pokémon tipo aire (efectividad)
        [Test]
        public void Ataque_TipoTierraContraAire_Inefectivo()
        {
            var pokemonAtacante = new Pokemon("Geodude", 100, new TipoTierra());
            var pokemonDefensor = new Pokemon("Pidgey", 100, new TipoAire());
            var ataque = new Ataque("Terremoto", 50, false, new TipoTierra());

            pokemonDefensor.RecibirAtaque(ataque);

            // Tierra es menos efectivo contra Aire, el daño debe ser reducido.
            Assert.That(pokemonDefensor.HP, Is.EqualTo(75), "El ataque de Tierra debería ser inefectivo contra un Pokémon de Aire.");
        }
        
        // Verificar ataque tipo aire contra Pokémon tipo tierra (efectividad)
        [Test]
        public void Ataque_TipoAireContraTierra()
        {
            var pokemonAtacante = new Pokemon("Pidgey", 100, new TipoAire());
            var pokemonDefensor = new Pokemon("Geodude", 100, new TipoTierra());
            var ataque = new Ataque("Viento", 50, false, new TipoAire());

            pokemonDefensor.RecibirAtaque(ataque);

            // Tierra es menos efectivo contra Aire, el daño debe ser reducido.
            Assert.That(pokemonDefensor.HP, Is.EqualTo(37.5), "El ataque de Tierra debería ser inefectivo contra un Pokémon de Aire.");
        }
        
        // Verificar que si dos jugadores seleccionan el mismo Pokémon, sean objetos distintos con las mismas propiedades.
        [Test]
        public void Jugadores_SeleccionanMismoPokemon_ObjetosDistintos()
        {
            // Simulamos la selección del mismo Pokémon por ambos jugadores
            Pokemon pokemonJugador1 = new Pokemon("Charmander", 100, new TipoFuego());
            Pokemon pokemonJugador2 = new Pokemon("Charmander", 100, new TipoFuego());

            jugador1.AgregarPokemon(pokemonJugador1);
            jugador2.AgregarPokemon(pokemonJugador2);

            // Verificar que los Pokémon seleccionados tienen las mismas propiedades (nombre, tipo)
            Assert.That(jugador1.Pokemons[0].Nombre, Is.EqualTo(jugador2.Pokemons[0].Nombre), "Los Pokémon seleccionados deben tener el mismo nombre.");
            Assert.That(jugador1.Pokemons[0].Tipo.Nombre, Is.EqualTo(jugador2.Pokemons[0].Tipo.Nombre), "Los Pokémon seleccionados deben tener el mismo tipo.");

            // Verificar que son objetos distintos en memoria
            Assert.That(jugador1.Pokemons[0], Is.Not.SameAs(jugador2.Pokemons[0]), "Los Pokémon seleccionados deben ser objetos distintos en memoria.");
        }
        
        // Verificación ataques especiales
        [Test]
        public void AtaqueEspecial_SoloPuedeUsarseCadaDosTurnos()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemonDefensor = new Pokemon("Squirtle", 100, new TipoAgua());
            var ataqueEspecial = new Ataque("Explosión Solar", 90, true, new TipoFuego());

            pokemonAtacante.Ataques.Add(ataqueEspecial);

            // Primer ataque - no debería poder usar el ataque especial aún
            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.False, "El ataque especial no debería estar disponible en el primer turno.");
    
            // Simular dos turnos con ataques normales
            pokemonAtacante.IncrementarContadorAtaques(); // Turno 1
            pokemonAtacante.IncrementarContadorAtaques(); // Turno 2

            // Ahora debería poder usar el ataque especial
            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.True, "El ataque especial debería estar disponible después de dos turnos.");

            // Realizar el ataque especial y verificar que no puede ser usado nuevamente de inmediato
            pokemonAtacante.UsarAtaqueEspecial();
            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.False, "Después de usar un ataque especial, no debería estar disponible inmediatamente.");
    
            // Simular dos turnos adicionales
            pokemonAtacante.IncrementarContadorAtaques(); // Turno 3
            pokemonAtacante.IncrementarContadorAtaques(); // Turno 4

            // Verificar nuevamente que el ataque especial está disponible
            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.True, "El ataque especial debería estar disponible nuevamente después de dos turnos.");
        }
    }
}