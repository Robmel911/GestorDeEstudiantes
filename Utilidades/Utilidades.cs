using System;
using Estudiante;

namespace Utilidades
{
    public static class Utilidades
    {
        // Instancia privada de Estudiante: solo Utilidades la conoce
        private static Estudiante.Estudiante _estudiante;

        // Métodos de fachada: interfaz pública para el menú
        public static void RegistrarEstudiante()
        {
            try
            {
                // Recolectar datos
                string nombre = LeerTexto("Ingrese nombre del estudiante:");
                int matricula = LeerMatricula();
                double nota1 = LeerNota("Ingrese nota 1 (0-100):");
                double nota2 = LeerNota("Ingrese nota 2 (0-100):");
                double nota3 = LeerNota("Ingrese nota 3 (0-100):");

                // Pasar datos a Estudiante
                _estudiante = new Estudiante.Estudiante();
                _estudiante.RegistrarDatos(nombre, matricula, nota1, nota2, nota3);
                MostrarMensaje("Estudiante registrado correctamente.");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al registrar: " + ex.Message);
            }
        }

        public static void MostrarResumenEstudiante()
        {
            if (_estudiante == null || !_estudiante.EstaRegistrado())
            {
                Console.WriteLine("No hay estudiante registrado. Use la opción 1 para registrar.");
                return;
            }

            _estudiante.MostrarResumen();
        }

        public static double? CalcularPromedioEstudiante()
        {
            if (_estudiante == null || !_estudiante.EstaRegistrado())
            {
                return null;
            }

            return _estudiante.CalcularPromedio();
        }

        public static bool HayEstudianteRegistrado()
        {
            return _estudiante != null && _estudiante.EstaRegistrado();
        }

        public static string ObtenerMatriculaEstudiante()
        {
            if (_estudiante == null || !_estudiante.EstaRegistrado())
            {
                return "No disponible";
            }

            return _estudiante.ObtenerMatricula();
        }

        // Métodos privados de lectura/validación
        public static double LeerNota(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje + " ");
                string input = Console.ReadLine();
                if (!EsNumero(input))
                {
                    Console.WriteLine("Entrada inválida. Debe ingresar un número.");
                    continue;
                }

                double nota;
                if (!double.TryParse(input, out nota))
                {
                    Console.WriteLine("Error al convertir. Intente de nuevo.");
                    continue;
                }

                if (nota < 0.0 || nota > 100.0)
                {
                    Console.WriteLine("La nota debe estar entre 0 y 100.");
                    continue;
                }

                return nota;
            }
        }

        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje + " ");
                string texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine("No se admite valor vacío. Intente de nuevo.");
                    continue;
                }

                return texto.Trim();
            }
        }

        private static int LeerMatricula()
        {
            while (true)
            {
                Console.Write("Ingrese matrícula (número entero): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int matricula) && matricula > 0)
                {
                    return matricula;
                }

                Console.WriteLine("Matrícula inválida. Intente de nuevo.");
            }
        }

        private static bool EsNumero(string texto)
        {
            double temp;
            return double.TryParse(texto, out temp);
        }

        public static void MostrarMensaje(string texto)
        {
            Console.WriteLine(texto);
        }

        // Sobrecarga: ejemplo solicitado
        public static void MostrarMensaje(string texto, int veces)
        {
            for (int i = 0; i < veces; i++)
            {
                Console.WriteLine(texto);
            }
        }
    }
}

