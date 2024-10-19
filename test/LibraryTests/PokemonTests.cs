using Library;
using Library.Interfaces;
using NUnit.Framework;

namespace Pokemones.Tests
{
    public class BatallaTests
    {
        private ICatalogo catalogo;
        private IJugador jugador1;
        private IJugador jugador2;

        [SetUp]
        public void Setup()
        {
            var tipos = CreacionElementosJuego.InicializarTipos();
            var pokemons = CreacionElementosJuego.InicializarPokemons(tipos);
            catalogo = new Catalogo(pokemons);

            jugador1 = new Jugador("Jugador 1");
            jugador2 = new Jugador("Jugador 2");
        }
        
        [Test]
        public void Jugador_NoPuedeSeleccionarMasDe6Pokemon()
        {
            for (int i = 0; i < 6; i++)
            {
                jugador1.AgregarPokemon(new Pokemon($"Pokemon {i}", 100, new Tipo("Fuego")));
            }

            // Intentar agregar un séptimo Pokémon
            jugador1.AgregarPokemon(new Pokemon("ExtraPokemon", 100, new Tipo("Fuego")));

            Assert.That(jugador1.PokemonsVivos(), Is.EqualTo(6), "El jugador no debería poder tener más de 6 Pokémon.");
        }

        [Test]
        public void AtaqueComun_ReduceHP_EnFuncionDeEfectividad()
        {
            // Arrange
            var tipos = CreacionElementosJuego.InicializarTipos();
    
            var pokemonAtacante = new Pokemon("Charmander", 100, tipos["Fuego"]);
            var pokemonDefensor = new Pokemon("Squirtle", 100, tipos["Agua"]);
            var ataque = new Ataque("Llamarada", 50, false, tipos["Fuego"]);

            // Act
            pokemonDefensor.RecibirAtaque(ataque);

            // Assert
            double expectedHP = 100 - (50 * 0.5); // El tipo Agua debería recibir la mitad del daño del tipo Fuego
            Assert.That(pokemonDefensor.HP, Is.EqualTo(expectedHP), "El HP del defensor debería reducirse correctamente en función de la efectividad.");
        }


        [Test]
        public void AtaqueEspecial_SeleccionadoAntesDeTiempo_MuestraMensajeError()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new Tipo("Fuego"));
            var pokemonDefensor = new Pokemon("Squirtle", 100, new Tipo("Agua"));
            var ataqueEspecial = new Ataque("Explosión Solar", 90, true, new Tipo("Fuego"));

            pokemonAtacante.Ataques.Add(ataqueEspecial);

            if (!pokemonAtacante.PuedeUsarAtaqueEspecial())
            {
                Assert.Pass("El mensaje de error debería mostrarse ya que el ataque especial no puede usarse aún.");
            }
        }

        [Test]
        public void Jugador_PuedeCambiarPokemonEnSuTurno()
        {
            var pokemon1 = new Pokemon("Charmander", 100, new Tipo("Fuego"));
            var pokemon2 = new Pokemon("Squirtle", 100, new Tipo("Agua"));

            jugador1.AgregarPokemon(pokemon1);
            jugador1.AgregarPokemon(pokemon2);

            jugador1.CambiarPokemon(1);
            Assert.That(jugador1.PokemonActivo(), Is.EqualTo(pokemon2), "El jugador debería poder cambiar de Pokémon en su turno.");
        }

        [Test]
        public void CambioAutomaticoSiPokemonMuere()
        {
            var pokemon1 = new Pokemon("Charmander", 100, new Tipo("Fuego"));
            var pokemon2 = new Pokemon("Squirtle", 100, new Tipo("Agua"));

            jugador1.AgregarPokemon(pokemon1);
            jugador1.AgregarPokemon(pokemon2);

            pokemon1.HP = 0;
            jugador1.CambiarPokemonAutomaticamente();

            Assert.That(jugador1.PokemonActivo(), Is.EqualTo(pokemon2), "El cambio de Pokémon debería ser automático cuando el Pokémon activo muere.");
        }

        [Test]
        public void MostrarVidaEnFormatoCorrecto()
        {
            var pokemon = new Pokemon("Charmander", 100, new Tipo("Fuego"));
            Assert.That(pokemon.MostrarVida(), Is.EqualTo("100/100"), "La vida debería mostrarse en el formato correcto.");
        }

        [Test]
        public void PokemonMuerto_NoPuedeAtacarNiRecibirAtaques()
        {
            var pokemon = new Pokemon("Charmander", 0, new Tipo("Fuego"));
            Assert.That(pokemon.EstaVivo(), Is.False, "El Pokémon debería estar muerto y no poder atacar o recibir ataques.");
        }

        [Test]
        public void Jugador_NoPuedeCambiarPokemonASiMismo()
        {
            var pokemon1 = new Pokemon("Charmander", 100, new Tipo("Fuego"));
            var pokemon2 = new Pokemon("Squirtle", 100, new Tipo("Agua"));

            jugador1.AgregarPokemon(pokemon1);
            jugador1.AgregarPokemon(pokemon2);

            jugador1.CambiarPokemon(0);
            Assert.That(jugador1.PokemonActivo(), Is.EqualTo(pokemon1), "El jugador no debería poder cambiar al mismo Pokémon activo.");
        }

        [Test]
        public void Jugadores_SeleccionanMismoPokemon_ObjetosDistintos()
        {
            var pokemonJugador1 = new Pokemon("Charmander", 100, new Tipo("Fuego"));
            var pokemonJugador2 = new Pokemon("Charmander", 100, new Tipo("Fuego"));

            jugador1.AgregarPokemon(pokemonJugador1);
            jugador2.AgregarPokemon(pokemonJugador2);

            Assert.That(jugador1.Pokemons[0].Nombre, Is.EqualTo(jugador2.Pokemons[0].Nombre), "Los Pokémon seleccionados deben tener el mismo nombre.");
            Assert.That(jugador1.Pokemons[0].Tipo.Nombre, Is.EqualTo(jugador2.Pokemons[0].Tipo.Nombre), "Los Pokémon seleccionados deben tener el mismo tipo.");
            Assert.That(jugador1.Pokemons[0], Is.Not.SameAs(jugador2.Pokemons[0]), "Los Pokémon seleccionados deben ser objetos distintos en memoria.");
        }

        [Test]
        public void AtaqueEspecial_SoloPuedeUsarseCadaDosTurnos()
        {
            var pokemonAtacante = new Pokemon("Charmander", 100, new Tipo("Fuego"));
            var pokemonDefensor = new Pokemon("Squirtle", 100, new Tipo("Agua"));
            var ataqueEspecial = new Ataque("Explosión Solar", 90, true, new Tipo("Fuego"));

            pokemonAtacante.Ataques.Add(ataqueEspecial);

            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.False, "El ataque especial no debería estar disponible en el primer turno.");

            pokemonAtacante.IncrementarContadorAtaques(); // Turno 1
            pokemonAtacante.IncrementarContadorAtaques(); // Turno 2

            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.True, "El ataque especial debería estar disponible después de dos turnos.");

            pokemonAtacante.UsarAtaqueEspecial();
            Assert.That(pokemonAtacante.PuedeUsarAtaqueEspecial(), Is.False, "Después de usar un ataque especial, no debería estar disponible inmediatamente.");
        }
        
        [Test]
        public void CalcularAtaqueEfectivo_TipoFuegoContraAgua_DeberiaDevolverEfectividadCorrecta()
        {
            // Arrange
            var tipoFuego = new Tipo("Fuego");
            var tipoAgua = new Tipo("Agua");
    
            // Configuramos las efectividades para el tipo Fuego
            tipoFuego.AgregarEfectividad("Agua", 0.5); // Fuego es débil contra Agua
            tipoFuego.AgregarEfectividad("Tierra", 1.5); // Fuego es fuerte contra Tierra

            // Act
            double efectividadContraAgua = tipoFuego.CalcularAtaqueEfectivo(tipoAgua);
            double efectividadContraFuego = tipoFuego.CalcularAtaqueEfectivo(tipoFuego);

            // Assert
            Assert.That(efectividadContraAgua, Is.EqualTo(0.5), "La efectividad del ataque de Agua contra Fuego debería ser 0.5.");
            Assert.That(efectividadContraFuego, Is.EqualTo(1.0), "La efectividad del ataque de Fuego contra Fuego debería ser neutral (1.0).");
        }
        
       [Test]
public void RecibirAtaque_TipoFuegoContraAgua()
{
    // Arrange
    var tipos = CreacionElementosJuego.InicializarTipos();

    var pokemonDefensor = new Pokemon("Squirtle", 100, tipos["Agua"]);
    var ataqueFuego = new Ataque("Llamarada", 50, false, tipos["Fuego"]);

    // Act
    pokemonDefensor.RecibirAtaque(ataqueFuego);

    // Assert
    double expectedHP = 100 - (50 * 0.5); // El daño se reduce a la mitad
    Assert.That(pokemonDefensor.HP, Is.EqualTo(expectedHP), "El Pokémon de tipo Agua debería recibir un daño reducido de un ataque de tipo Fuego.");
}

[Test]
public void RecibirAtaque_TipoAguaContraFuego()
{
    // Arrange
    var tipos = CreacionElementosJuego.InicializarTipos();

    var pokemonDefensor = new Pokemon("Charmander", 100, tipos["Fuego"]);
    var ataqueAgua = new Ataque("Hidro Bomba", 50, false, tipos["Agua"]);

    // Act
    pokemonDefensor.RecibirAtaque(ataqueAgua);

    // Assert
    double expectedHP = 100 - (50 * 2.0); // El daño se duplica
    Assert.That(pokemonDefensor.HP, Is.EqualTo(0), "El Pokémon de tipo Fuego debería recibir el doble de daño de un ataque de tipo Agua.");
}

[Test]
public void RecibirAtaque_TipoTierraContraAire()
{
    // Arrange
    var tipos = CreacionElementosJuego.InicializarTipos();

    var pokemonDefensor = new Pokemon("Pidgey", 100, tipos["Aire"]);
    var ataqueTierra = new Ataque("Terremoto", 50, false, tipos["Tierra"]);

    // Act
    pokemonDefensor.RecibirAtaque(ataqueTierra);

    // Assert
    double expectedHP = 100 - (50 * 2.0); // El daño se duplica debido a la debilidad del tipo Aire frente a Tierra
    Assert.That(pokemonDefensor.HP, Is.EqualTo(0), "El Pokémon de tipo Aire debería recibir el doble de daño de un ataque de tipo Tierra.");
}

[Test]
public void RecibirAtaque_TipoAireContraTierra()
{
    // Arrange
    var tipos = CreacionElementosJuego.InicializarTipos();

    var pokemonDefensor = new Pokemon("Sandshrew", 100, tipos["Tierra"]);
    var ataqueAire = new Ataque("Vendaval", 50, false, tipos["Aire"]);

    // Act
    pokemonDefensor.RecibirAtaque(ataqueAire);

    // Assert
    double expectedHP = 100 - (50 * 0.5); // El daño se reduce a la mitad debido a la debilidad del tipo Tierra frente a Aire
    Assert.That(pokemonDefensor.HP, Is.EqualTo(75), "El Pokémon de tipo Tierra debería recibir la mitad del daño de un ataque de tipo Aire.");
}



    }
}
