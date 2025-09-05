using System;

namespace _4JLSC_JhonatanGuizar_04cs
{
    // Clase abstracta base
    abstract class FiguraGeometrica
    {
        public abstract string Descripcion();
        public abstract double Area();
    }

    class Cuadrilatero : FiguraGeometrica
    {
        private readonly double _base;
        private readonly double _altura;

        public Cuadrilatero(double baseCuadrilatero, double altura)
        {
            _base = baseCuadrilatero;
            _altura = altura;
        }

        public override string Descripcion()
        {
            return _base == _altura ? "Cuadrado" : "Rectángulo";
        }

        public override double Area() => _base * _altura;
    }

    class Triangulo : FiguraGeometrica
    {
        private readonly double _base;
        private readonly double _altura;

        public Triangulo(double baseTriangulo, double altura)
        {
            _base = baseTriangulo;
            _altura = altura;
        }

        public override string Descripcion() => "Triángulo";

        public override double Area() => (_base * _altura) / 2;
    }

    class Circulo : FiguraGeometrica
    {
        private readonly double _radio;

        public Circulo(double radio)
        {
            _radio = radio;
        }

        public override string Descripcion() => "Círculo";

        public override double Area() => Math.PI * Math.Pow(_radio, 2);
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Selecciona una figura geométrica:");
            Console.WriteLine("1. Cuadrilátero");
            Console.WriteLine("2. Triángulo");
            Console.WriteLine("3. Círculo");

            int opcion = LeerEntero("Ingresa un número entero del 1 al 3: ");

            FiguraGeometrica figura = opcion switch
            {
                1 => new Cuadrilatero(
                        LeerDouble("Base del cuadrilátero: "),
                        LeerDouble("Altura del cuadrilátero: ")),
                2 => new Triangulo(
                        LeerDouble("Base del triángulo: "),
                        LeerDouble("Altura del triángulo: ")),
                3 => new Circulo(
                        LeerDouble("Radio del círculo: ")),
                _ => throw new ArgumentException("Opción no válida")
            };

            Console.WriteLine(figura.Descripcion());
            Console.WriteLine($"Área: {figura.Area():F2}");
            Console.ReadKey();
        }

        // Métodos auxiliares para validación
        static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Intenta de nuevo: ");
            }
            return valor;
        }

        static double LeerDouble(string mensaje)
        {
            double valor;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Intenta de nuevo: ");
            }
            return valor;
        }
    }
}
