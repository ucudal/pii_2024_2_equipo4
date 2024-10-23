namespace Library.Interfaces;

public interface IItem
{
    public string Nombre { get; }
    void UsarItem(IJugador jugador, Pokemon pokemon);
    int ObtenerCantidad();
}