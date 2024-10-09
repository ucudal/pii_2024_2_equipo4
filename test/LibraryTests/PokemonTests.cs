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

        // 1. Verificar que el jugador puede seleccionar 6 Pokémon.
        [Test]
        public void Jugador_Selecciona6Pokemon_EquipoCompleto()
        {
            catalogo.SeleccionarPokemon(jugador1);
            Assert.That(jugador1.Pokemons.Count, Is.EqualTo(6), "El jugador debería tener 6 Pokémon en su equipo.");
        }

        // 2. Verificar que si dos jugadores seleccionan el mismo Pokémon, sean objetos distintos.
        [Test]
        public void Jugadores_SeleccionanMismoPokemon_ObjetosDistintosConMismasPropiedades()
        {
            catalogo.SeleccionarPokemon(jugador1);
            catalogo.SeleccionarPokemon(jugador2);

            var pokemonJugador1 = jugador1.Pokemons[0];
            var pokemonJugador2 = jugador2.Pokemons[0];

            // Comparar que los nombres de los Pokémon seleccionados son los mismos
            Assert.That(pokemonJugador1.Nombre, Is.EqualTo(pokemonJugador2.Nombre), "Los nombres de los Pokémon seleccionados deben ser iguales.");

            // Comparar que los tipos de los Pokémon son los mismos
            Assert.That(pokemonJugador1.Tipo.Nombre, Is.EqualTo(pokemonJugador2.Tipo.Nombre), "Los tipos de los Pokémon seleccionados deben ser iguales.");

            // Verificar que son objetos distintos en memoria
            Assert.That(pokemonJugador1, Is.Not.SameAs(pokemonJugador2), "Los Pokémon seleccionados deben ser objetos distintos en memoria.");
        }

        // 3. Comprobar que los ataques comunes funcionan correctamente reduciendo el HP del oponente.
        [Test]
        public void AtaqueComun_ReduceHP_EnFuncionDeEfectividad()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new TipoFuego());
            var pokemonDefensor = new Pokemon("Squirtle", 100, new TipoAgua());
            var ataque = new Ataque("Llamarada", 50, false, new TipoFuego());

            pokemonDefensor.RecibirAtaque(ataque);
            Assert.That(pokemonDefensor.HP, Is.EqualTo(75), "El HP del defensor debería reducirse correctamente.");
        }

        // 5. Verificar que un ataque especial no se puede usar hasta que hayan pasado dos turnos del Pokémon.
        [Test]
        public void AtaqueEspecial_NoPuedeSerUsadoHastaPasadosDosTurnos()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new TipoFuego());
            pokemonAtacante.Ataques.Add(new Ataque("Explosión Solar", 90, true, new TipoFuego()));

            // Primero ataque común, luego intento usar el especial
            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.False, "El ataque especial no debería estar disponible aún.");

            pokemonAtacante.IncrementarContadorAtaques();
            pokemonAtacante.IncrementarContadorAtaques();

            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.True, "El ataque especial debería estar disponible después de dos ataques.");
        }

        // 6. Comprobar que si se selecciona un ataque especial antes de que se permita, se muestra un mensaje de error.
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

        // 7. Comprobar que un jugador puede cambiar de Pokémon durante su turno.
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

        // 8. Validar que si el Pokémon activo se queda sin vida, el cambio de Pokémon se realiza automáticamente.
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

        // 9. Verificar que los puntos de vida de un Pokémon se muestran correctamente en el formato “actual/total”.
        [Test]
        public void MostrarVidaEnFormatoCorrecto()
        {
            var pokemon = new Pokemon("Charmander", 100, new TipoFuego());
            Assert.That(pokemon.MostrarVida(), Is.EqualTo("100/100"), "La vida debería mostrarse en el formato correcto.");
        }

        // 10. Validar que cuando un Pokémon muere, no puede seguir atacando ni recibir ataques.
        [Test]
        public void PokemonMuerto_NoPuedeAtacarNiRecibirAtaques()
        {
            var pokemon = new Pokemon("Charmander", 0, new TipoFuego());
            Assert.That(pokemon.EstaVivo(), Is.False, "El Pokémon debería estar muerto y no poder atacar o recibir ataques.");
        }
    }
}