using Library.Interfaces;

namespace Library;

 public class Pokemon
{
    public string Nombre { get; set; }
    public double HP { get; set; }
    public double HPMax { get; set; }
    public List<IAtaque> Ataques { get; set; }
    public ITipo Tipo { get; set; }
    public bool EstaDormido { get; private set; }
    public bool EstaEnvenenado { get; private set; }
    public bool EstaQuemado { get; private set; }
    public bool EstaParalizado { get; private set; }
    public bool PuedeAtacar { get; private set; } = true;
    private int turnosDormido;
    private Random random = new Random();
    private int contadorAtaques = 0;  // Contador para controlar cuántos ataques normales se han realizado


    public Pokemon(string nombre, double hp, ITipo tipo)
    {
        Nombre = nombre;
        HP = hp;
        HPMax = hp;
        Ataques = new List<IAtaque>();
        Tipo = tipo;
    }

    // Método para recibir daño, ahora ajustando por la efectividad de los tipos
    public void RecibirAtaque(int daño)
    {
        if (HP > daño)
        {
            HP -= daño;
            Console.WriteLine($"{Nombre} recibió {daño} puntos de daño. {HP}/{HPMax} HP restantes.");
        }
        else
        {
            HP = 0;
            Console.WriteLine($"{Nombre} ha sido derrotado.");
        }
    }

    public bool EstaVivo()
    {
        return HP > 0;
    }

    public string MostrarVida()
    {
        return $"{HP}/{HPMax}";
    }

    public void QuedarDormido(int turnos)
    {
        EstaDormido = true;
        turnosDormido = turnos;
        Console.WriteLine($"{Nombre} está dormido por {turnos} turnos.");
    }

    public void Envenenar()
    {
        EstaEnvenenado = true;
        Console.WriteLine($"{Nombre} ha sido envenenado.");
    }

    public void Quemar()
    {
        EstaQuemado = true;
        Console.WriteLine($"{Nombre} ha sido quemado.");
    }

    public void Paralizar()
    {
        EstaParalizado = true;
        Console.WriteLine($"{Nombre} ha sido paralizado.");
    }

    // Método para manejar los efectos al inicio de cada turno
    public void ProcesarEfectos()
    {
        if (EstaDormido)
        {
            if (turnosDormido > 0)
            {
                turnosDormido--;
                Console.WriteLine($"{Nombre} sigue dormido. Turnos restantes: {turnosDormido}.");
                PuedeAtacar = false;
            }
            else
            {
                EstaDormido = false;
                Console.WriteLine($"{Nombre} se ha despertado.");
                PuedeAtacar = true;
            }
        }

        if (EstaEnvenenado)
        {
            double dañoPorVeneno = HPMax * 0.05;  // Pierde 5% de HP por turno
            HP -= dañoPorVeneno;
            Console.WriteLine($"{Nombre} pierde {dañoPorVeneno} HP debido al veneno.");
        }

        if (EstaQuemado)
        {
            double dañoPorQuemadura = HPMax * 0.1;  // Pierde 10% de HP por turno
            HP -= dañoPorQuemadura;
            Console.WriteLine($"{Nombre} pierde {dañoPorQuemadura} HP debido a las quemaduras.");
        }

        if (EstaParalizado)
        {
            PuedeAtacar = random.NextDouble() > 0.5;  // 50% de probabilidad de que no pueda atacar
            if (!PuedeAtacar)
            {
                Console.WriteLine($"{Nombre} está paralizado y no puede atacar este turno.");
            }
        }
    }
    
    // Método que incrementa el contador de ataques y controla el uso de ataques especiales
    public bool PuedeUsarAtaqueEspecial()
    {
        return contadorAtaques >= 2;  // Puede usar el ataque especial después de dos ataques normales
    }

    // Resetea el contador después de usar un ataque especial
    public void UsarAtaqueEspecial()
    {
        contadorAtaques = 0;  // Se resetea tras el uso del ataque especial
    }

    // Incrementar el contador después de cada ataque normal
    public void IncrementarContadorAtaques()
    {
        contadorAtaques++;
    }

    // Método para ejecutar un ataque
    public void EjecutarAtaque(Pokemon objetivo, int indiceAtaque)
    {
        if (indiceAtaque >= 0 && indiceAtaque < Ataques.Count)
        {
            IAtaque ataque = Ataques[indiceAtaque];

            // Comprobar si es un ataque especial y si puede ser usado
            if (ataque is AtaqueEspecial && !PuedeUsarAtaqueEspecial())
            {
                Console.WriteLine("No puedes usar un ataque especial hasta que realices más ataques normales.");
                return;
            }

            ataque.Ejecutar(objetivo);  // Ejecuta el ataque sobre el objetivo

            // Si es un ataque especial, resetea el contador, de lo contrario, lo incrementa
            if (ataque is AtaqueEspecial)
            {
                UsarAtaqueEspecial();  // Resetea el contador si es ataque especial
            }
            else
            {
                IncrementarContadorAtaques();  // Incrementa el contador si es ataque normal
            }
        }
        else
        {
            Console.WriteLine("Índice de ataque inválido.");
        }
    }

}