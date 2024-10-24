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
        public void AtaqueComun_ReduceHP_EnFuncionDeEfectividadMayorDanio()
        {
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 100, new TipoPlanta());
            AtaqueComun ataqueFuego = new AtaqueComun("Llamarada", new TipoFuego(), 40, 1.0);
            
            ataqueFuego.Ejecutar(bulbasaur);
            Assert.That(bulbasaur.HP, Is.EqualTo(20), "El HP del defensor debería reducirse correctamente.");
        }

        [Test]
        public void AtaqueComun_ReduceHP_EnFuncionDeEfectividadMenorDanio()
        {
            Pokemon squirtle = new Pokemon("Squirtle", 100, new TipoAgua());
            AtaqueComun ataqueFuego = new AtaqueComun("Llamarada", new TipoFuego(), 40, 1.0);


            ataqueFuego.Ejecutar(squirtle);
            Assert.That(squirtle.HP, Is.EqualTo(80), "El HP del defensor debería reducirse correctamente.");
        }

        // Comprobar que si se selecciona un ataque especial antes de que se permita, se muestra un mensaje de error.
        [Test]
        public void AtaqueEspecial_PuedeUsarseLuegoDeDosTurnos()
        {
            Pokemon charizard = new Pokemon("Charizard", 100, new TipoFuego());
            Pokemon blastoise = new Pokemon("Blastoise", 100, new TipoAgua());
            AtaqueComun ataqueFuego = new AtaqueComun("Llamarada", new TipoFuego(), 40, 1.0);
            charizard.Ataques.Add(ataqueFuego);

            charizard.EjecutarAtaque(blastoise, 0);
            charizard.EjecutarAtaque(blastoise, 0);
            charizard.EjecutarAtaque(blastoise, 0);

            bool puedeUsarAtaqueEspecial = charizard.PuedeUsarAtaqueEspecial();

            Assert.That(puedeUsarAtaqueEspecial, Is.True);
        }

        [Test]
        public void AtaqueEspecial_NoPuedeSeleccionarseSiempre()
        {
            Pokemon charizard = new Pokemon("Charizard", 100, new TipoFuego());
            Pokemon blastoise = new Pokemon("Blastoise", 100, new TipoAgua());
            AtaqueEspecial quemar = new AtaqueQuemar();

            charizard.EjecutarAtaque(blastoise, 0); // Primer ataque normal
            bool puedeUsarEspecial = charizard.PuedeUsarAtaqueEspecial(); // No debe permitirse usar ataque especial

            Assert.That(puedeUsarEspecial, Is.False);
        }

        // Comprobar que un jugador puede cambiar de Pokémon durante su turno.
        [Test]
        public void Jugador_PuedeCambiarPokemonEnSuTurno()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 100, new TipoPlanta());
            Jugador jugador = new Jugador("Ash");
            jugador.AgregarPokemon(charmander);
            jugador.AgregarPokemon(bulbasaur);

            jugador.CambiarPokemon(1); // Cambiar a Bulbasaur
            Assert.That(jugador.PokemonActivo(), Is.EqualTo(bulbasaur), "El jugador debería poder cambiar de Pokémon en su turno.");
        }

        // Validar que si el Pokémon activo se queda sin vida, el cambio de Pokémon se realiza automáticamente.
        [Test]
        public void CambioAutomaticoSiPokemonMuere()
        {
            Pokemon charmander = new Pokemon("Charmander", 0, new TipoFuego()); // Muerto
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 100, new TipoPlanta());
            Jugador jugador = new Jugador("Ash");
            jugador.AgregarPokemon(charmander);
            jugador.AgregarPokemon(bulbasaur);

            charmander.HP = 0; // Pokémon 1 muere
            jugador.CambiarPokemonAutomaticamente();

            Assert.That(jugador.PokemonActivo(), Is.EqualTo(bulbasaur),
                "El cambio de Pokémon debería ser automático cuando el Pokémon activo muere.");
        }

        // Verificar que los puntos de vida de un Pokémon se muestran correctamente en el formato “actual/total”.
        [Test]
        public void MostrarVidaEnFormatoCorrecto()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            Assert.That(charmander.MostrarVida(), Is.EqualTo("100/100"),
                "La vida debería mostrarse en el formato correcto.");
        }

        // Validar que cuando un Pokémon muere, no puede seguir atacando ni recibir ataques.
        [Test]
        public void PokemonMuerto_NoPuedeAtacar()
        {
            Pokemon charmander = new Pokemon("Charmander", 0, new TipoFuego()); // Muerto
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 100, new TipoPlanta());
            Jugador jugador = new Jugador("Ash");
            jugador.AgregarPokemon(charmander);

            charmander.EjecutarAtaque(bulbasaur, 0);

            Assert.That(bulbasaur.HP, Is.EqualTo(100)); // El ataque no debe ocurrir
        }

        [Test]
        public void PokemonMuerto_NoPuedeRecibirAtaque()
        {
            Pokemon charmander = new Pokemon("Charmander", 0, new TipoFuego()); // Muerto
            AtaqueComun ataqueFuego = new AtaqueComun("Llamarada", new TipoFuego(), 40, 1.0);

            ataqueFuego.Ejecutar(charmander);

            Assert.That(charmander.HP, Is.EqualTo(0)); // El HP no debe cambiar, sigue siendo 0
        }
        
        [Test]
        public void AtaqueDormir_PokemonDormido()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            AtaqueDormir dormir = new AtaqueDormir();

            dormir.Ejecutar(charmander);

            Assert.That(charmander.EstaDormido, Is.True, "El Pokémon debería estar dormido.");
        }
        
        [Test]
        public void AtaqueEnvenenar_PokemonEnvenenado()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            AtaqueEnvenenar envenenar = new AtaqueEnvenenar();

            envenenar.Ejecutar(charmander);
            charmander.ProcesarEfectos();

            Assert.That(charmander.EstaEnvenenado, Is.True, "El Pokémon debería estar envenenado.");
            Assert.That(charmander.HP, Is.EqualTo(95));  // 5% de HP perdido por el veneno
        }

        [Test]
        public void AtaqueQuemar_PokemonQuemado()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            AtaqueQuemar quemar = new AtaqueQuemar();

            quemar.Ejecutar(charmander);
            charmander.ProcesarEfectos();

            Assert.That(charmander.EstaQuemado, Is.True, "El Pokémon debería estar quemado.");
            Assert.That(charmander.HP, Is.EqualTo(90));  // 10% de HP perdido por la quemadura
        }

        [Test]
        public void AtaqueParalizar_PokemonParalizado()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            AtaqueParalizar paralizar = new AtaqueParalizar();

            paralizar.Ejecutar(charmander);
            charmander.ProcesarEfectos();

            Assert.That(charmander.EstaParalizado, Is.True, "El Pokémon debería estar paralizado.");
        }

        [Test]
        public void AtaqueDormir_PokemonDormidoNoAtaca()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 100, new TipoPlanta());
            AtaqueDormir dormir = new AtaqueDormir();

            dormir.Ejecutar(charmander);
            charmander.ProcesarEfectos();  // Procesar el turno en el que está dormido

            Assert.That(charmander.EstaDormido, Is.True, "El Pokémon debería estar dormido.");
            Assert.That(charmander.PuedeAtacar, Is.False, "El Pokémon no debería poder atacar mientras está dormido.");
        }

        [Test]
        public void AtaqueParalizar_Pokemon50ChanceAtacar()
        {
            Pokemon charmander = new Pokemon("Charmander", 100, new TipoFuego());
            AtaqueParalizar paralizar = new AtaqueParalizar();

            paralizar.Ejecutar(charmander);
            bool puedeAtacarAlMenosUnaVez = false;

            // Ejecutamos varios turnos para probar la probabilidad del 50%
            for (int i = 0; i < 10; i++)
            {
                charmander.ProcesarEfectos();
                if (charmander.PuedeAtacar)
                {
                    puedeAtacarAlMenosUnaVez = true;
                    break;
                }
            }

            Assert.That(charmander.EstaParalizado, Is.True, "El Pokémon debería estar paralizado.");
            Assert.That(puedeAtacarAlMenosUnaVez, Is.True, "El Pokémon debería poder atacar al menos una vez en 10 turnos.");
        }
    }
}
