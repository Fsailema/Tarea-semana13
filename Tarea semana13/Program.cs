
using System;
using System.Collections.Generic;

class Program
{
    // Lista que contiene los títulos de las revistas
    static List<string> catalogoRevistas = new List<string>();

    static void Main(string[] args)
    {
        // Ingreso de 10 títulos al catálogo
        catalogoRevistas.AddRange(new List<string>
        {
            "Revista Ciencia",
            "Tecnología Hoy",
            "Historia Moderna",
            "Salud y Bienestar",
            "Mundo Deportivo",
            "Viajes y Turismo",
            "Arte Contemporáneo",
            "Innovación Empresarial",
            "Cocina Internacional",
            "Revista de Literatura"
        });

        int opcion;
        do
        {
            Console.WriteLine("Catálogo de Revistas Menú de Búsqueda ");
            Console.WriteLine("_____________________");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.WriteLine("                    ");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    BuscarTituloIterativo();
                    break;
                case 2:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcion != 2);
    }

    // Método de búsqueda iterativa
    static void BuscarTituloIterativo()
    {
        Console.Write("Ingrese el título de la revista a buscar: ");
        string tituloBuscado = Console.ReadLine();

        bool encontrado = false;
        foreach (var titulo in catalogoRevistas)
        {
            if (titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                encontrado = true;
                break;
            }
        }

        if (encontrado)
        {
            Console.WriteLine("Título encontrado.");
        }
        else
        {
            Console.WriteLine("Título no encontrado.");
        }
    }
}