namespace Library.Interfaces;

public interface IAtaque
{
    string Nombre { get; }  // Nombre del ataque
    ITipo Tipo { get; }     // Tipo del ataque (Fuego, Agua, etc.)
    int ValorAtaque { get; }       // Valor de daño del ataque
    double Precision { get; }  // Precisión del ataque (0.0 a 1.0)

    void Ejecutar(Pokemon objetivo);  // Método para ejecutar el ataque sobre un objetivo
}