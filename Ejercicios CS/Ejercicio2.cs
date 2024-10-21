//Usando listas y tuplas Crea un programa que administre un inventario de productos.
//Cada producto tiene un nombre, un precio y una cantidad en
//stock. El programa debe permitir:
//✓ Añadir nuevos productos al inventario.
//✓ Actualizar la cantidad en stock de un producto
//existente.
//✓ Calcular el valor total del inventario (sumando el valor
//de cada producto: precio × cantidad en stock).
//Requisitos:
//✓ Implementar la función agregar_producto (inventario,
//nombre, precio, cantidad) para añadir productos.
//✓ Implementar la función actualizar_stock (inventario,
//nombre, nueva_cantidad) para modificar la cantidad de
//un producto.
//✓ Implementar la función calcular_valor_total (inventario)
//que devuelva el valor total del inventario.


using System;
using System.Collections.Generic;

class Program
{
    // Lista de tuplas que contiene el inventario de productos
    static List<Tuple<string, double, int>> inventario = new List<Tuple<string, double, int>>();

    static void Main()
    {
        int opcion;
        // Ciclo principal para mantener el programa ejecutándose hasta que el usuario elija salir
        do
        {
            // Llama al menú principal y espera la elección del usuario
            opcion = menuPrincipal();
            switch (opcion)
            {
                case 1:
                    agregar_producto(); 
                    break;
                case 2:
                    mostrar_productos(); 
                    break;
                case 3:
                    buscar_producto(); 
                    break;
                case 4:
                    actualizar_stock(); 
                    break;
                case 5:
                    eliminar_producto(); 
                    break;
                case 6:
                    calcular_valor_total(); 
                    break;
                case 7:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Selecciona una opción válida."); 
                    break;
            }
        }
        while (opcion != 7); 
    }

    // Muestra el menú principal y devuelve la opción seleccionada por el usuario
    static int menuPrincipal()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("Menú de opciones:");
        Console.WriteLine("1. Agregar productos");
        Console.WriteLine("2. Mostrar productos");
        Console.WriteLine("3. Buscar producto");
        Console.WriteLine("4. Actualizar productos");
        Console.WriteLine("5. Eliminar producto");
        Console.WriteLine("6. Calcular valor total del inventario");
        Console.WriteLine("7. Salir");
        Console.WriteLine("=================================================");
        Console.Write("Opción: ");
        int op = int.Parse(Console.ReadLine()); 
        return op;
    }

    // Función para agregar un nuevo producto al inventario
    static void agregar_producto()
    {
        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine(); 

        Console.Write("Precio del producto: ");
        double precio = double.Parse(Console.ReadLine());

        Console.Write("Cantidad en stock: ");
        int cantidad = int.Parse(Console.ReadLine()); 

        // Añade el producto al inventario como una nueva tupla 
        inventario.Add(Tuple.Create(nombre, precio, cantidad));
        Console.WriteLine($"Producto {nombre} agregado correctamente.\n");
    }

    // Función para mostrar todos los productos del inventario
    static void mostrar_productos()
    {
        Console.WriteLine("\nLista de productos en inventario:");
        // Verifica si hay productos en el inventario
        if (inventario.Count == 0)
        {
            Console.WriteLine("No hay productos en el inventario.");
        }
        else
        {
            // Recorre e imprime los detalles de cada producto
            foreach (var producto in inventario)
            {
                Console.WriteLine($"Nombre: {producto.Item1}, Precio: {producto.Item2}, Cantidad en stock: {producto.Item3}");
            }
        }
        Console.WriteLine();
    }

    // Función para buscar un producto en el inventario por nombre
    static void buscar_producto()
    {
        Console.Write("Ingrese el nombre del producto que desea buscar: ");
        string nombre = Console.ReadLine();

        // Busca el producto que coincida con el nombre ingresado (ignora mayúsculas/minúsculas)
        // Este metodo recibe una expresión lambda (una función anónima que especifica la condición de búsqueda).
        var producto = inventario.Find(p => p.Item1.Replace(" ", "").Equals(nombre.Replace(" ", ""), StringComparison.OrdinalIgnoreCase));


        // Muestra el resultado de la búsqueda
        if (producto != null)
        {
            Console.WriteLine($" - Producto encontrado - \n2Nombre: {producto.Item1}, Precio: {producto.Item2}, Cantidad en stock: {producto.Item3}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
        Console.WriteLine();
    }

    // Función para actualizar el stock de un producto existente
    static void actualizar_stock()
    {
        Console.Write("Ingrese el nombre del producto que desea actualizar: ");
        string nombre = Console.ReadLine(); // Lee el nombre del producto

        // Busca el índice del producto en la lista
        // Este metodo recibe una expresión lambda (una función anónima que especifica la condición de búsqueda).
        var index = inventario.FindIndex(p => p.Item1.Replace(" ", "").Equals(nombre.Replace(" ", ""), StringComparison.OrdinalIgnoreCase));

        // Si el producto existe, permite actualizar la cantidad en stock
        if (index != -1)
        {
            Console.WriteLine("Producto encontrado!..."); 
            Console.Write("Nueva cantidad en stock: ");
            int nuevaCantidad = int.Parse(Console.ReadLine()); // Lee la nueva cantidad

            // Actualiza la cantidad en stock manteniendo el mismo nombre y precio
            var producto = inventario[index];
            inventario[index] = Tuple.Create(producto.Item1, producto.Item2, nuevaCantidad);
            Console.WriteLine($"Stock actualizado correctamente para {nombre}.\n");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.\n");
        }
    }

    // Función para eliminar un producto del inventario
    static void eliminar_producto()
    {
        Console.Write("Ingrese el nombre del producto que desea eliminar: ");
        string nombre = Console.ReadLine(); // Lee el nombre del producto

        // Busca el producto que coincida con el nombre ingresado
        var producto = inventario.Find(p => p.Item1.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        // Si el producto se encuentra, lo elimina del inventario
        if (producto != null)
        {
            inventario.Remove(producto);
            Console.WriteLine($"Producto {nombre} eliminado correctamente.\n");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.\n");
        }
    }

    // Función para calcular el valor total del inventario
    static void calcular_valor_total()
    {
        double valorTotal = 0;

        // Recorre cada producto y suma su valor (precio * cantidad) al valor total
        foreach (var producto in inventario)
        {
            valorTotal += producto.Item2 * producto.Item3;
        }

        // Muestra el valor total del inventario
        Console.WriteLine($"El valor total del inventario es: {valorTotal:C}\n");
    }
}
