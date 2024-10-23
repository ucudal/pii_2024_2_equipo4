using Library.Interfaces;

namespace Library;

public class Revivir:IItem
{
    public string Nombre { get; } = "Revivir";

    public void RevivirPokemon(Pokemon pokemon)
    {
        pokemon.HP += pokemon.HPMax / 2;
        if (pokemon.HP > pokemon.HPMax)
        {
            pokemon.HP = pokemon.HPMax;
        }
    }
}