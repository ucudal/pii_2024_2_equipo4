using DefaultNamespace;

namespace Pokemones_perosnal;

public class Ataque
{
    public string Nombre { get; set; }
    public int ValorAtaque { get; set; }
    public bool Especial { get; set; }
    public ITipo Tipo { get; set; }

    public Ataque(string nombre, int valorAtaque, bool especial, ITipo tipo)
    {
        Nombre = nombre;
        ValorAtaque = valorAtaque;
        Especial = especial;
        Tipo = tipo;
    }
}