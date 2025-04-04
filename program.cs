using System;
using System.Collections;
using System.Diagnostics;
using Arbolbalanceado;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario bst = new ArbolBinario();
            ArbolAVL avl = new ArbolAVL();
            Stopwatch stopwatch = new Stopwatch();
            Random random = new Random();
            int numElementos = 10000; 
            int[] elementos = new int[numElementos];
            bool salir = false;

            //aquí se generan elementos aleatorios para insertar en el arbol, en el rango de 1 a 10000
            //para que se puedan visualizar los numeros en los tiempos de búsqueda y eliminación, es decir imprime el primer, medio y último elemento
            for (int i = 0; i < numElementos; i++)
            {
                elementos[i] = random.Next(1, 10000); 
            }

            while (!salir)
            {
                Console.WriteLine("\n----- MENÚ DE COMPARACIÓN ÁRBOLES -----");
                Console.WriteLine("1. Insertar en BST y AVL");
                Console.WriteLine("2. Buscar en BST y AVL");
                Console.WriteLine("3. Eliminar en BST y AVL");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion )
                {
                    case 1:
                        stopwatch.Restart();
                        foreach (int valor in elementos)
                        {
                            bst.Insertar(valor);
                        }
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de inserción en BST: {stopwatch.ElapsedMilliseconds} ms");

                        stopwatch.Restart();
                        foreach (int valor in elementos)
                        {
                            avl.Insertar(valor);
                        }
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de inserción en AVL: {stopwatch.ElapsedMilliseconds} ms");
                        break;

                    case 2:
                        int primero = elementos[0];
                        int medio = elementos[numElementos / 2];
                        int ultimo = elementos[numElementos - 1];

                        Console.WriteLine($"\n====Busqueda en BST=====");
                        Console.WriteLine($"Primer elemento: {primero}");
                        stopwatch.Restart();
                        bst.Buscar(primero);
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de búsqueda del primer elemento en BST es: {stopwatch.Elapsed.TotalMilliseconds} ms");

                        Console.WriteLine($"Elemento medio: {medio}");
                        stopwatch.Restart();
                        bst.Buscar(medio);
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de búsqueda del elemento medio en BST es: {stopwatch.Elapsed.TotalMilliseconds} ms");

                        Console.WriteLine($"Último elemento: {ultimo}");
                        stopwatch.Restart();
                        bst.Buscar(ultimo);
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de búsqueda del último en BST: {stopwatch.Elapsed.TotalMilliseconds} ms");

                        Console.WriteLine($"\n====Busqueda en AVL=====");
                        Console.WriteLine($"Primer elemento: {primero}");
                        stopwatch.Restart();
                        avl.Buscar(primero);
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de búsqueda del primer elemento en AVL: {stopwatch.Elapsed.TotalMilliseconds} ms");

                        Console.WriteLine($"Elemento medio: {medio}");
                        stopwatch.Restart();
                        avl.Buscar(medio);
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de búsqueda del elemento medio en AVL: {stopwatch.Elapsed.TotalMilliseconds} ms");
                        
                        Console.WriteLine($"Último elemento: {ultimo}");
                        stopwatch.Restart();
                        avl.Buscar(ultimo);
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de búsqueda del último elemento en AVL: {stopwatch.Elapsed.TotalMilliseconds} ms");
                        break;

                    case 3:
                        Console.Write("\nIngrese el número a eliminar: ");
                        int valorAEliminar = int.Parse(Console.ReadLine());

                        stopwatch.Restart();
                        bst.Eliminar(valorAEliminar);
                        stopwatch.Stop();
                        Console.WriteLine($"\nTiempo de eliminación en BST: {stopwatch.Elapsed.TotalMilliseconds} ms");

                        stopwatch.Restart();
                        avl.Eliminar(valorAEliminar);
                        stopwatch.Stop();
                        Console.WriteLine($"Tiempo de eliminación en AVL: {stopwatch.Elapsed.TotalMilliseconds} ms");
                        break;

                    case 4:
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
