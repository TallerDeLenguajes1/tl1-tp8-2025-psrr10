using System;
using System.Collections.Generic;

namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato = 0;
        private bool primeraOperacion = true;
        private List<Operacion> historial = new List<Operacion>();

        public void Sumar(double termino)
        {
            historial.Add(new Operacion(dato, termino, TipoOperacion.Suma));
            dato += termino;
            primeraOperacion = false;
        }

        public void Restar(double termino)
        {
            historial.Add(new Operacion(dato, termino, TipoOperacion.Resta));
            dato -= termino;
            primeraOperacion = false;
        }

        public void Multiplicar(double termino)
        {
            if (primeraOperacion)
            {
                dato = termino;
                primeraOperacion = false;
            }
            else
            {
                historial.Add(new Operacion(dato, termino, TipoOperacion.Multiplicacion));
                dato *= termino;
            }
        }

        public void Dividir(double termino)
        {
            if (termino == 0)
            {
                Console.WriteLine("No se puede dividir por cero.");
                return;
            }

            if (primeraOperacion)
            {
                dato = termino;
                primeraOperacion = false;
            }
            else
            {
                historial.Add(new Operacion(dato, termino, TipoOperacion.Division));
                dato /= termino;
            }
        }

        public void Limpiar()
        {
            historial.Add(new Operacion(dato, 0, TipoOperacion.Limpiar));
            dato = 0;
            primeraOperacion = true;
        }

        public double Resultado => dato;

        public void MostrarHistorial()
        {
            if (historial.Count == 0)
            {
                Console.WriteLine("No hay operaciones en el historial.");
                return;
            }

            Console.WriteLine("\nHistorial de operaciones:");
            foreach (var op in historial)
            {
                Console.WriteLine(op.ToString());
            }
        }
    }
}
