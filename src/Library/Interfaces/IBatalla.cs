namespace Library.Interfaces;

public interface IBatalla
{
    void IniciarBatalla();
    void TurnoJugador();
    void CambiarTurno();
    void MostrarEstado();
    bool VerGanador();
}