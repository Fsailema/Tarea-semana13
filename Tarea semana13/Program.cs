
using System;

class Revista
{
    public string Titulo { get; set; }
    public Revista Izquierda { get; set; }
    public Revista Derecha { get; set; }

    public Revista(string titulo)
    {
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}

class Catalogo
{
    public Revista Raiz { get; private set; }

    public void Insertar(string titulo)
    {
        Raiz = InsertarRecursivo(Raiz, titulo);
    }

    private Revista InsertarRecursivo(Revista nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Revista(titulo);
        }

        if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, titulo);
        }

        return nodo;
    }

    public bool Buscar(string titulo)
    {
        return BuscarRecursivo(Raiz, titulo);
    }

    private bool BuscarRecursivo(Revista nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }

        if (titulo.Equals(nodo.Titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, titulo);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, titulo);
        }
    }
}

class Program
{
    static void Main()
    {
        Catalogo catalogo = new Catalogo();

        // Ingresar 10 títulos de revistas
        string[] titulos = { "Deportes", "Novelas", "Accion", "Comedia", "Drama",
                             "Hoticias", "Moda", "Canina", "Iluminacion", "Belleza" };

        foreach (var titulo in titulos)
        {
            catalogo.Insertar(titulo);
        }

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Catalogo de Revista");
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.WriteLine("Seleccione una opcion:   ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título a buscar: ");
                    string tituloABuscar = Console.ReadLine();
                    bool encontrado = catalogo.Buscar(tituloABuscar);
                    Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
                    break;
                case 2:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}