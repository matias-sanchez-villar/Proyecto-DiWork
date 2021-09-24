using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tipos tipo = Tipos.corsa;

            Console.WriteLine(tipo);
        }
    }

    class Auto
    {
        public Tipos tipo { get; set; }
    }

    enum Tipos { sedan, corsa, cupe}
}
