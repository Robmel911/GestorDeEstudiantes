using System;
using Estudiante;
using Utilidades;

namespace MenuPrincipal
{
    class Menu
    {
        static void Main(string[] args)
        {
            var estudiante = new Estudiante.Estudiante();
            bool salir = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine("GestorDeEstudiantes - Menú");
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Mostrar resumen del estudiante");
                Console.WriteLine("3. Calcular promedio");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        try
                        {
                            estudiante.RegistrarDatos();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al registrar: " + ex.Message);
                        }
                        break;

                    case "2":
                        estudiante.MostrarResumen();
                        break;

                    case "3":
                        try
                        {
                            if (!estudiante.EstaRegistrado())
                            {
                                Console.WriteLine("Primero registre un estudiante (opción 1).");
                                break;
                            }

                            double promedio = estudiante.CalcularPromedio();
                            Console.WriteLine("Promedio calculado: {0:F2}", promedio);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al calcular promedio: " + ex.Message);
                        }
                        break;

                    case "4":
                        Console.WriteLine("Saliendo...");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (!salir);
        }
    }
}






