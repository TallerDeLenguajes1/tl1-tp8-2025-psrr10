using System;
using System.Collections.Generic;
using ToDo;



class Program
{
    static void Main()
    {
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();
        Random rand = new Random();

        Console.WriteLine("¿Cuantas tareas desea generar?");
        int N = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < N; i++)
        {
            Tarea nueva = new Tarea
            {
                TareaId = i,
                Descripcion = $"Tarea{i}",
                duracion = rand.Next(10, 101)
            };
            tareasPendientes.Add(nueva);
        }
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1 - Mostrar tareas pendientes");
            Console.WriteLine("2 - Mostrar tareas realizadas");
            Console.WriteLine("3 - Marcar tarea como realizada");
            Console.WriteLine("4 - Buscar tarea pendiente por descripción");
            Console.WriteLine("5 - Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            bool valido = int.TryParse(Console.ReadLine(), out opcion);

            if (!valido)
            {
                Console.WriteLine("Entrada invalida, intente nuevamente");
                continue;
            }

            switch (opcion)
            {
                 case 1:
                    Console.WriteLine("\n--- TAREAS PENDIENTES ---");
                    foreach (Tarea t in tareasPendientes)
                    {
                        Console.WriteLine($"ID:{t.TareaId}, Descripción: {t.Descripcion}, Duración: {t.duracion}");
                    }
                    break;

                case 2:
                    Console.WriteLine("\n--- TAREAS REALIZADAS ---");
                    foreach (Tarea t in tareasRealizadas)
                    {
                        Console.WriteLine($"ID:{t.TareaId}, Descripción: {t.Descripcion}, Duración: {t.duracion}");
                    }
                    break;

                case 3:
                    Console.Write("Ingrese el ID de la tarea que desea marcar como realizada: ");
                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        Tarea? tareaEncontrada = tareasPendientes.Find(t => t.TareaId == id);
                        if (tareaEncontrada != null)
                        {
                            tareasRealizadas.Add(tareaEncontrada);
                            tareasPendientes.Remove(tareaEncontrada);
                            Console.WriteLine("Tarea movida a realizadas correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Tarea no encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 4:
                    Console.Write("Ingrese una descripción para buscar una tarea pendiente: ");
                    string descripcionBuscada = Console.ReadLine()!.Trim();

                    Tarea? tareaEncontrada2 = tareasPendientes.Find(t =>
                        t.Descripcion.ToLower() == descripcionBuscada.ToLower());

                    if (tareaEncontrada2 != null)
                    {
                        Console.WriteLine($"Tarea encontrada: ID:{tareaEncontrada2.TareaId}, Descripción: {tareaEncontrada2.Descripcion}, Duración: {tareaEncontrada2.duracion}");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ninguna tarea con esa descripción.");
                    }
                    break;

                case 5:
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}