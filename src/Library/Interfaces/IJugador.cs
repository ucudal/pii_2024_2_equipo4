namespace Library.Interfaces;

public interface IJugador
{
    string Nombre { get; set; }
    Pokemon PokemonActivo();
    void AgregarPokemon(Pokemon pokemon);
    void CambiarPokemon(int nuevoIndice);
    void Atacar(IJugador oponente, int indiceAtaque);
    void CambiarPokemonAutomaticamente();
    int PokemonsVivos();
    void MostrarPokemonsDisponibles();
}