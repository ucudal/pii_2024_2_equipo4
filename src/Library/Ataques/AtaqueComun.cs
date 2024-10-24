using Library.Interfaces;
using System;

namespace Library;

public class AtaqueComun : IAtaque
{
    public string Nombre { get; }
    public ITipo Tipo { get; }
    public int ValorAtaque { get; }
    public double Precision { get; }

    public AtaqueComun(string nombre, ITipo tipo, int daño, double precision)
    {
        Nombre = nombre;
        Tipo = tipo;
        ValorAtaque = daño;
        Precision = precision;
    }

    public void Ejecutar(Pokemon objetivo)
    {
        if (new Random().NextDouble() <= Precision)
        {
            // Cálculo de efectividad, fuera de la clase Pokemon
            double efectividad = objetivo.Tipo.CalcularAtaqueEfectivo(Tipo);
            int ataqueFinal = (int)(ValorAtaque * efectividad);

            objetivo.RecibirAtaque(ataqueFinal);
            Console.WriteLine($"{Nombre} fue exitoso y causó {ataqueFinal} puntos de daño a {objetivo.Nombre}.");
        }
        else
        {
            Console.WriteLine($"{Nombre} falló.");
        }
    }
}
