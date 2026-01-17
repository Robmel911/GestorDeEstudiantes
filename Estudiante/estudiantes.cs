using System;

namespace Estudiante
{
    public class Estudiante
    {
        private string _nombre;
        private int _matricula;
        private double _nota1;
        private double _nota2;
        private double _nota3;
        private bool _estaRegistrado;

        public void RegistrarDatos(string nombre, int matricula, double nota1, double nota2, double nota3)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            if (matricula <= 0)
            {
                throw new ArgumentException("La matrícula debe ser positiva.");
            }

            if (!this.ValidarNota(nota1) || !this.ValidarNota(nota2) || !this.ValidarNota(nota3))
            {
                throw new ArgumentException("Las notas deben estar entre 0 y 100.");
            }

            this._nombre = nombre;
            this._matricula = matricula;
            this._nota1 = nota1;
            this._nota2 = nota2;
            this._nota3 = nota3;
            this._estaRegistrado = true;
        }

        public double CalcularPromedio()
        {
            if (!this._estaRegistrado)
            {
                throw new InvalidOperationException("No hay datos del estudiante. Registre primero.");
            }

            double promedio = (this._nota1 + this._nota2 + this._nota3) / 3.0;
            return promedio;
        }

        public void MostrarResumen()
        {
            if (!this._estaRegistrado)
            {
                Console.WriteLine("No hay estudiante registrado. Use la opción Registrar estudiante.");
                return;
            }

            double promedio = this.CalcularPromedio();
            string estatus = this.DeterminarEstatus(promedio);

            Console.WriteLine("----- Resumen del Estudiante -----");
            Console.WriteLine("Nombre: " + this._nombre);
            Console.WriteLine("Matrícula: " + this._matricula);
            Console.WriteLine("Notas: {0}, {1}, {2}", this._nota1, this._nota2, this._nota3);
            Console.WriteLine("Promedio: {0:F2}", promedio);
            Console.WriteLine("Estatus: " + estatus);
            Console.WriteLine("----------------------------------");
        }

        private bool ValidarNota(double nota)
        {
            return nota >= 0.0 && nota <= 100.0;
        }

        private string DeterminarEstatus(double promedio)
        {
            return promedio >= 70.0 ? "Aprobado" : "Reprobado";
        }

        public string ObtenerMatricula()
        {
            return this._matricula.ToString();
        }

        public bool EstaRegistrado()
        {
            return this._estaRegistrado;
        }
    }
}