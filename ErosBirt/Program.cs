using System.Collections.Concurrent; //Para poder usar BlockingCollection

namespace ErosBirt
{
    internal class Program
    {
        // BlockingCollection ya está preparada para trabajar con varios hilos/tareas
        // Y así no tenemos que controlar manualmente problemas de sincronización
        // La cola puede contener como máximo 10 pedidos
        private static BlockingCollection<Pedido> colaPedidos =
        new BlockingCollection<Pedido>(10);

        static async Task Main(string[] args)
        {
            try
            {
                // Crear la tarea PRODUCTOR
                Task tareaProductor = Productor();

                // Crear el CONSUMIDOR 1
                Task tareaConsumidor1 =
                    Consumidor("CENTRO LOGÍSTICO1", 1000);

                // Crear el CONSUMIDOR 2
                Task tareaConsumidor2 =
                    Consumidor("CENTRO LOGÍSTICO2", 2000);

                // Esperar a que terminen las tres tareas
                await Task.WhenAll(
                    tareaProductor,
                    tareaConsumidor1,
                    tareaConsumidor2);

                // Mensaje final
                Console.WriteLine();
                Console.WriteLine(
                    "Tanto el almacén como los centros logísticos están cerrados. " +
                    $"Número de elementos del almacén: {colaPedidos.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Se ha producido un error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadKey();
        }

        // ============================================================
        // PRODUCTOR
        // ============================================================

        private static async Task Productor()
        {
            try
            {
                //Mostramos
                Console.WriteLine("Comienza la generación de pedidos por el productor.");

                string[] productos = { "Ropa", "Electrónica", "Juguetes" };

                // Creamos los 30 pedidos
                for (int i = 0; i < 30; i++)
                {
                    // Generamos aletoriamente el producto
                    string tipoProducto = productos[Random.Shared.Next(productos.Length)];

                    // Generamos aleatoriamente el tiempo
                    int horas = Random.Shared.Next(0, 24);
                    int minutos = Random.Shared.Next(0, 60);

                    // Creamos la hora (por ejemplo: 16:35:00)
                    TimeSpan tiempoRespuesta = new TimeSpan(horas, minutos, 0);

                    // Creamos el pedido (Por ejemplo:
                    // ID = 1
                    // Producto = Juguetes
                    // Tiempo = 16:35:00)
                    Pedido pedido = new Pedido(i, tipoProducto, tiempoRespuesta);

                    // Metemos cada pedido en la cola
                    colaPedidos.Add(pedido);

                    // Mostramos el pedido por consola
                    Console.WriteLine();
                    Console.WriteLine("-------------");
                    Console.WriteLine("Nuevo pedido:");
                    Console.WriteLine("-------------");
                    Console.WriteLine($"Pedido {pedido.Id}");
                    Console.WriteLine($"{pedido.TipoProducto}");
                    Console.WriteLine($"{pedido.TiempoRespuesta}");

                    // Esperamos 300 milisegundos
                    await Task.Delay(300);
                }
            }
            // Controlamos la excepciones
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el productor: {ex.Message}");
            }
            // Y cuando termine y no se van a añadir más pedidos a la cola cerramos la cola
            finally
            {
                colaPedidos.CompleteAdding();

                Console.WriteLine();
                Console.WriteLine("Cierre de la cola de pedidos.");
            }
        }

        private static async Task Consumidor(string nombreCentro, int tiempoEspera)
        {
            try
            {
                Console.WriteLine($"Comienza a procesar pedidos el {nombreCentro}.");

                // El consumidor cojera productos de la cola mientras haya pedidos que consumir o el productor todavia puede añadirlos
                foreach (Pedido pedido in colaPedidos.GetConsumingEnumerable())
                {
                    //Muestra el centro logistico y el pedido consumido
                    Console.WriteLine();
                    Console.WriteLine($"Cargando pedido en {nombreCentro}:");

                    Console.WriteLine("+++++++++++++++++++++++++++++++++++");
                    Console.WriteLine($"Pedido num:{pedido.Id}");
                    Console.WriteLine($"{pedido.TipoProducto}");
                    Console.WriteLine($"{pedido.TiempoRespuesta}");


                    // Muestra los pedidos que quedan
                    Console.WriteLine($"Número de pedidos que quedan en la cola para procesar por los consumidores: {colaPedidos.Count}");

                    await Task.Delay(tiempoEspera);
                }

                Console.WriteLine();
                Console.WriteLine($"{nombreCentro} no tiene material para procesar");
            }
            // Controlamos las excepciones
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error en {nombreCentro}: {ex.Message}");
            }
        }
    }
}
