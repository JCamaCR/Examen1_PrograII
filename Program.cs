using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_PrograII
{
    internal class Program
    {
        public static string[,] Espanol = new string[5, 3];
        public static string[,] Mate = new string[5, 3];
        public static string[,] Ciencias = new string[5, 3];
        public static string[,] Sociales = new string[5, 3];

        public static void Main(string[] args)
        {

            float opt = 0;

            for (int i = 0; i <= 4; i++)
            {
               // for (int j = 0; j <= 2; i++)
               // {
               //     Espanol[i, j] = "";
               //     Mate[i, j] = "";
               //     Ciencias[i, j] = "";
               //     Sociales[i, j] = "";
               // }
            }

            do
            {
                MostrarPantallaPrincipal();
                opt = Menu("Digite la opción del menú: ");
                switch (opt)
                {
                    case 1:
                        registroestudiante();
                        break;
                    case 2:
                        EliminarEstudiante();
                        break;
                    case 3:

                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Fin del programa...");
                        break;
                }
            } while (opt != 4);
        }

        private static void MostrarPantallaPrincipal()
        {
            Console.Clear();
            Console.WriteLine("**** Examen I de Progra II *****");
            Console.WriteLine();
            Console.WriteLine("Registro de Registro de Asistencia Semanal --->");
            Console.WriteLine();
        }//Fin de método MostrarPantallaPrincipal

        //Método para mostrar y seleccionar menu
        private static float Menu(string campo)
        {
            //Variables a utilizar
            float opcion;
            bool esValido;
            Console.WriteLine("********************************");
            Console.WriteLine();
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine();
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Eliminar estudiante de una materia");
            Console.WriteLine("3. Consultar estudiantes por materia y día");
            Console.WriteLine("3. Consultar estudiantes por día");
            Console.WriteLine("4. Salir");
            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.WriteLine("");
            do //Se repite hasta que se ingrese un número valido del menu
            {
                //Lee el dato
                Console.Write($"{campo}: ");
                string entrada = Console.ReadLine();

                //Compara y define si es un número valido
                esValido = float.TryParse(entrada, out opcion) && opcion >= 1 && opcion <= 4;
                if (!esValido) //Si no es válido devuelve error y repite la lectura del dato
                {
                    Console.WriteLine($"Error: la selección debe ser una opción válida del menú.");
                }
            } while (!esValido);
            return opcion;//Retorna el valor del menú
        }//Fin de método Menu

        private static void registroestudiante()
        {
            string Nombre = "";
            int Dia = 0;
            int Materia = 0;
            bool free = false;
            Console.WriteLine();
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            Console.WriteLine("**************** Nuevo Registro de Estudiante *******************");
            Console.WriteLine();
            Console.WriteLine("Digite el nombre del estudiante");
            Nombre = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("1.Lunes   2.Martes   3.Miercoles   4.Jueves   5.Viernes");
            Console.WriteLine();
            Dia = ValidaDia("Seleccione el número de día: ");
            Console.WriteLine();
            Console.WriteLine("1.Español   2.Matemáticas   3.Ciencias   4.Ciencias Sociales");
            Console.WriteLine();
            Materia = ValidaMateria("Seleccione el número que identifica la Materia: ");
            Console.WriteLine();
            Console.WriteLine("***************************************************");
            free = ValidaEstudiante(Nombre, Dia, Materia);
            if (free)
            {               
                AgregaEstudiante(Nombre, Dia, Materia);
                Console.WriteLine();
                Console.WriteLine("EL estudiante fue registrado satisfactoriamente");
                Console.WriteLine();
                Console.WriteLine("Digite una tecla para volver al menú...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("EL estudiante ya se encuentra registrado en este curso este día. Por favor selecciones de nuevo su opción");
                Console.WriteLine();
                Console.WriteLine("Digite una tecla para volver al menú...");
                Console.ReadKey();
            }                      
        }//Fin de método registroestudiante

        private static int ValidaDia(string campo)
        {
            //Variables a utilizar
            int day;
            bool esValido;
           
            do //Se repite hasta que se ingrese un número valido del menu
            {
                //Lee el dato
                Console.Write($"{campo}: ");
                string entrada = Console.ReadLine();

                //Compara y define si es un número valido
                esValido = int.TryParse(entrada, out day) && day >= 1 && day <= 5;
                if (!esValido) //Si no es válido devuelve error y repite la lectura del dato
                {
                    Console.WriteLine($"Error: la selección debe ser una opción válida de día.");
                }
            } while (!esValido);
            return day;//Retorna el valor del día
        }//Fin de método validadia

        private static int ValidaMateria(string campo)
        {
            //Variables a utilizar
            int materia;
            bool esValido;

            do //Se repite hasta que se ingrese un número valido del menu
            {
                //Lee el dato
                Console.Write($"{campo}: ");
                string entrada = Console.ReadLine();

                //Compara y define si es un número valido
                esValido = int.TryParse(entrada, out materia) && materia >= 1 && materia <= 4;
                if (!esValido) //Si no es válido devuelve error y repite la lectura del dato
                {
                    Console.WriteLine($"Error: la selección debe ser una opción válida de materia.");
                }
            } while (!esValido);
            return materia;//Retorna el valor de la materia
        }//Fin de método validamateria
        private static bool ValidaEstudiante(string nombre, int diasemana, int asignatura)
        {
            bool pasa = true;
            switch (asignatura)
            {
                case 1:
                    for (int i = 0; i <= 2; i++)
                    {

                        if (Espanol[diasemana, i] == nombre)
                        {
                            pasa = false;
                        }
                        
                    }
                    break;
                case 2:
                    for (int i = 0; i <= 2; i++)
                    {
                        if (Mate[diasemana, i] == nombre)
                        {
                            pasa = false;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i <= 2; i++)
                    {
                        if(Ciencias[diasemana, i] == nombre)
                        {
                            pasa = false;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i <= 2; i++)
                    {
                        if (Sociales[diasemana, i] == nombre)
                        {
                            pasa = false;
                        }
                    }
                    break;
            }
            return pasa;

        }
        private static void EliminarEstudiante()       
        {
            string Nombre = "";
            int Dia = 0;
            int Materia = 0;
            Console.WriteLine("**************** Eliminar Registro de Estudiante *******************");
            Console.WriteLine();
            Console.WriteLine("Digite el nombre del estudiante");
            Nombre = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("1.Lunes   2.Martes   3.Miercoles   4.Jueves   5.Viernes");
            Console.WriteLine();
            Dia = ValidaDia("Seleccione el número de día: ");
            Console.WriteLine();
            Console.WriteLine("1.Español   2.Matemáticas   3.Ciencias   4.Ciencias Sociales");
            Console.WriteLine();
            Materia = ValidaMateria("Seleccione el número que identifica la Materia: ");
            Console.WriteLine();
            Console.WriteLine("***************************************************");
            EliminaEstudiante(Nombre, Dia, Materia);
        }
        private static void AgregaEstudiante(string estudiante, int diasemana, int asignatura)
        {
            for (int i = 0; i <= 2; i++)
            {

                if (Espanol[diasemana, i] == "")
                {
                    Espanol[diasemana, i] = estudiante;
                }
                if (Mate[diasemana, i] == "")
                {
                    Mate[diasemana, i] = estudiante;
                }
                if (Ciencias[diasemana, i] == "")
                {
                    Ciencias[diasemana, i] = estudiante;
                }
                if (Sociales[diasemana, i] == "")
                {
                    Sociales[diasemana, i] = estudiante;
                }
            }
        }
        private static void EliminaEstudiante(string estudiante, int diasemana, int asignatura)
        {
                      
            for (int i = 0; i <= 2; i++)
            {

                if (Espanol[diasemana, i] == estudiante)
                {
                    Espanol[diasemana, i] = "";
                }
                if (Mate[diasemana, i] == estudiante)
                {
                    Mate[diasemana, i] = "";
                }
                if (Ciencias[diasemana, i] == estudiante)
                {
                    Ciencias[diasemana, i] = "";
                }
                if (Sociales[diasemana, i] == estudiante)
                {
                    Sociales[diasemana, i] = "";
                }
                
            }
        }
    }
}
