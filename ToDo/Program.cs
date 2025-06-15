using System.Collections.Generic;
using ToDo;


class Program
{

    static void Main()
    {
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();

        Random rand = new Random();

        Console.WriteLine("¿Cuantas tareas desea generar?: ");
        int N = int.Parse(Console.ReadLine()!);


        for (int i = 1; i <= N; i++)
        {
            Tarea nueva = new Tarea
            {
                TareaId = i,
                Descripcion = $"Tarea{i}",
                duracion = rand.Next(10, 101)
            };
            tareasPendientes.Add(nueva);
        }

        Console.WriteLine("\nTareas generadas:");
        foreach (Tarea t in tareasPendientes)
        {
            Console.WriteLine($"ID:{t.TareaId} - Descripcion: {t.Descripcion} - Duracion: {t.duracion}");
        }



        Console.WriteLine("Ingrese el ID de la tarea que desea marcar como realizada: ");
        int id = int.Parse(Console.ReadLine()!);

        Tarea? tareaEncontrada = tareasPendientes.Find(t => t.TareaId == id);

        if (tareaEncontrada != null)
        {
            tareasRealizadas.Add(tareaEncontrada);
            tareasPendientes.Remove(tareaEncontrada);
            Console.WriteLine("Tarea movida a realizadas correctamente");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada");
        }

        Console.WriteLine("Ingrese una descripcion para buscar una tarea pendiente:");
        string descripcionBuscada = Console.ReadLine()!.Trim();

        Tarea? tareaEncontrada2 = tareasPendientes.Find(t => t.Descripcion.ToLower() == descripcionBuscada.ToLower());
        if (tareaEncontrada2 != null)
        {
            Console.WriteLine($"Descripcion Tarea encontrada: {tareaEncontrada2.Descripcion}");
        }
        else
        {
            Console.WriteLine("No se encontró ninguna tarea con esa descripcion");
        }
    }


}
