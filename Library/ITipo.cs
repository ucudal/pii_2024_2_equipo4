namespace DefaultNamespace;

public interface ITipo
{
    string Nombre { get; }
    double CalcularAtaqueEfectivo(ITipo tipoAtaque);
}