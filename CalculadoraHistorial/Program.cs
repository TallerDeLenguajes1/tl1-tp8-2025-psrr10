using EspacioCalculadora;

class Program
{
    static void Main(string[] args)
    {
        Calculadora calc = new Calculadora();
        string opcion;
        double numero;

        do
        {
            Console.WriteLine($"\nResultado actual: {calc.Resultado}");
            Console.WriteLine("Elija una operación:");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Limpiar");
            Console.WriteLine("6. Mostrar historial");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese un número a sumar: ");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Sumar(numero);
                    break;
                case "2":
                    Console.Write("Ingrese un número a restar: ");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Restar(numero);
                    break;
                case "3":
                    Console.Write("Ingrese un número a multiplicar: ");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Multiplicar(numero);
                    break;
                case "4":
                    Console.Write("Ingrese un número a dividir: ");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Dividir(numero);
                    break;
                case "5":
                    calc.Limpiar();
                    Console.WriteLine("Se reinició la calculadora.");
                    break;
                case "6":
                    calc.MostrarHistorial();
                    break;
                case "0":
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;

            }
        } while (opcion != "0");

    }
}