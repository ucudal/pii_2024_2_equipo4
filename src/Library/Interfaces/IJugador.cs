namespace Library.Interfaces;

public interface IJugador
{
    public List<Pokemon> Pokemons { get;  set; }
    string Nombre { get; }
    Pokemon PokemonActivo();
    void AgregarPokemon(Pokemon pokemon);
    void Atacar(IJugador oponente, int indiceAtaque);
    void CambiarPokemon(int nuevoIndice);
    void CambiarPokemonAutomaticamente();
    int PokemonsVivos();
    void MostrarPokemonsDisponibles();
}