//Desarrolla un programa que gestione las calificaciones de un
//grupo de estudiantes. El programa debe:
//✓ Permitir ingresar las calificaciones de varios
//estudiantes.
//✓ Calcular el promedio de calificaciones de cada
//estudiante.
//✓ Determinar el estudiante con el promedio más alto y el
//más bajo.
//Requisitos:
//✓ Implementar la función agregar_estudiante
//(estudiantes, nombre, calificaciones) para agregar
//estudiantes y sus calificaciones (una lista de notas).
//✓ Implementar la función calcular_promedio
//(calificaciones) para calcular el promedio de un
//estudiante.
//✓ Implementar la función
//determinar_mejor_peor_estudiante (estudiantes) que
//devuelva los nombres del estudiante con el promedio
//más alto y el promedio más bajo.


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Función para agregar un estudiante con su lista de calificaciones
    static void AgregarEstudiante(List<(string nombre, List<int> calificaciones)> estudiantes, string nombre, List<int> calificaciones)
    {
        estudiantes.Add((nombre, calificaciones));
    }

    // Función para calcular el promedio de las calificaciones de un estudiante
    static double CalcularPromedio(List<int> calificaciones)
    {
        return calificaciones.Average();
    }

    // Función para determinar el estudiante con el promedio más alto y el más bajo
    static (string mejorEstudiante, string peorEstudiante) DeterminarMejorPeorEstudiante(List<(string nombre, List<int> calificaciones)> estudiantes)
    {
        // Inicialización de variables
        string mejorEstudiante = "";
        string peorEstudiante = "";
        double promedioMax = double.MinValue;
        double promedioMin = double.MaxValue;

        // Iterar sobre la lista de estudiantes
        foreach (var estudiante in estudiantes)
        {
            // Calcular el promedio del estudiante actual
            double promedio = CalcularPromedio(estudiante.calificaciones);

            // Verificar si es el promedio más alto
            if (promedio > promedioMax)
            {
                // Si el promedio actual es mayor que el máximo encontrado hasta ahora,
                // actualizamos el promedio máximo y almacenamos el nombre del estudiante
                promedioMax = promedio;
                mejorEstudiante = estudiante.nombre;
            }

            // Verificar si es el promedio más bajo
            if (promedio < promedioMin)
            {
                // Si el promedio actual es menor que el mínimo encontrado hasta ahora,
                // actualizamos el promedio mínimo y almacenamos el nombre del estudiante
                promedioMin = promedio;
                peorEstudiante = estudiante.nombre;
            }
        }

        return (mejorEstudiante, peorEstudiante);
    }

    static void Main(string[] args)
    {
        // Listas anidadas para almacenar los estudiantes y sus calificaciones
        List<(string nombre, List<int> calificaciones)> estudiantes = new List<(string, List<int>)>();

        // Permitir ingresar estudiantes y sus calificaciones
        while (true)
        {
            Console.Write("Ingrese el nombre del estudiante (o 'salir' para terminar): ");
            string nombre = Console.ReadLine();

            // Salir del bucle si el usuario ingresa 'salir'
            if (nombre.ToLower() == "salir")
                break;

            List<int> calificaciones = new List<int>();
            while (true)
            {
                Console.Write($"Ingrese una calificación para {nombre} (o 'fin' para terminar): ");
                string input = Console.ReadLine();

                // Terminar la entrada de calificaciones si el usuario ingresa 'fin'
                if (input.ToLower() == "fin")
                    break;

                // Intentar convertir la entrada a un entero
                if (int.TryParse(input, out int calificacion))
                {
                    calificaciones.Add(calificacion);
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }

            // Agregar el estudiante y sus calificaciones a la lista
            AgregarEstudiante(estudiantes, nombre, calificaciones);
        }

        // Mostrar los promedios de cada estudiante
        Console.WriteLine("\nPromedios de los estudiantes:");
        foreach (var estudiante in estudiantes)
        {
            double promedio = CalcularPromedio(estudiante.calificaciones);
            Console.WriteLine($"El promedio de {estudiante.nombre} es {promedio}");
        }

        // Determinar el mejor y peor estudiante
        var (mejorEstudiante, peorEstudiante) = DeterminarMejorPeorEstudiante(estudiantes);
        Console.WriteLine($"\nEl estudiante con el mejor promedio es {mejorEstudiante}");
        Console.WriteLine($"El estudiante con el peor promedio es {peorEstudiante}");
        Console.ReadKey(); 
    }
}
