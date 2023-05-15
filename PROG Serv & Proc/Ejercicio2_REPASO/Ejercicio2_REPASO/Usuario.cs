using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_REPASO
{
    internal class Usuario
    {
        static string[] nomAlum = { "PEDRO", "JUAN", "HUGO", "GABRIEL", "LOIS" };
        static string[] nomAsig = { "MATEMATICAS", "LENGUA", "HISTORIA" };
        Aula aula = new Aula(nomAlum, nomAsig);
        bool comp;
        int num = 0, max = 0, min = 0;
        Hashtable aprobados;
        public void init()
        {
            int res = 0;
            while (res != 9)
            {
                Console.WriteLine("\n--- SELECCIONA UNA OPCIÓN ---\n");
                Console.WriteLine("1.- Visualizar tabla completa");
                Console.WriteLine("2.- Calcular la media de notas de la tabla");
                Console.WriteLine("3.- Media de un alumno");
                Console.WriteLine("4.- Media de una asignatura");
                Console.WriteLine("5.- Visualizar notas de un alumno");
                Console.WriteLine("6.- Visualizar notas de una asignatura");
                Console.WriteLine("7.- Nota máxima y mínima de un alumno");
                Console.WriteLine("8.- Tabla solo de aprobados");
                Console.WriteLine("9.- Salir\n");
                if (Int32.TryParse(Console.ReadLine(), out res))
                {
                    Console.Clear();
                    switch (res)
                    {
                        case 1:
                            mostrarTabla();
                            break;
                        case 2:
                            Console.WriteLine("LA MEDIA DE TODAS LAS NOTAS ES: " + aula.mediaNotas());
                            break;
                        case 3:
                            compAlumno();
                            Console.WriteLine("LA MEDIA DE " + nomAlum[num - 1] + " ES: " + aula.mediaAlumno(num).ToString("F2"));
                            break;
                        case 4:
                            compAsignatura();
                            Console.WriteLine("LA MEDIA DE " + nomAsig[num - 1] + " ES: " + aula.mediaAsignatura(num).ToString("F2"));
                            break;
                        case 5:
                            compAlumno();
                            Console.WriteLine("LAS NOTAS DE " + nomAlum[num - 1] + " SON:\n");
                            for (int i = 0; i < aula.Notas.GetLength(1); i++)
                            {
                                Console.WriteLine($"{aula.NomAsignaturas[i]}: {aula.Notas[num - 1, i]}");
                            }
                            Console.WriteLine();
                            break;
                        case 6:
                            compAsignatura();
                            Console.WriteLine("LAS NOTAS DE " + nomAsig[num - 1] + " SON:\n");
                            for (int i = 0; i < aula.Notas.GetLength(0); i++)
                            {
                                Console.WriteLine($"{aula.NomAlumnos[i]}: {aula.Notas[i, num - 1]}");
                            }
                            Console.WriteLine();
                            break;
                        case 7:
                            compAlumno();
                            if (aula.Notas != null)
                            {
                                aula.maxMin(ref max, ref min, num);
                            }
                            else
                            {
                                Console.WriteLine("LA TABLA ESTA VACÍA");
                            }
                            Console.WriteLine("LA NOTA MÁS ALTA DE " + nomAlum[num - 1] + " ES " + max + " Y LA MÍNIMA " + min);
                            break;
                        case 8:
                            mostrarTablaAprobados();
                            break;
                        case 9:
                            Console.WriteLine("ADIOS");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("VALOR FUERA DE RANGO\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("OPCIÓN NO VÁLIDA\n");
                }
            }
        }

        public void compAlumno()
        {
            comp = true;
            while (comp)
            {
                Console.WriteLine("--- INTRODUZCA EL NUMERO DEL ALUMNO ( 1 - " + nomAlum.Length + " ) ---\n");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    if (num > aula.NomAlumnos.Length || num < 1)
                    {
                        Console.WriteLine("VALOR FUERA DE RANGO\n");
                    }
                    else
                    {
                        comp = false;
                    }
                }
                else
                {
                    Console.WriteLine("VALOR NO VÁLIDO\n");
                }
            }
        }

        public void compAsignatura()
        {
            comp = true;
            while (comp)
            {
                Console.WriteLine("--- INTRODUZCA EL NUMERO DE LA ASIGNATURA ( 1 - " + nomAsig.Length + " ) ---\n");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    if (num > aula.NomAsignaturas.Length || num < 1)
                    {
                        Console.WriteLine("VALOR FUERA DE RANGO\n");
                    }
                    else
                    {
                        comp = false;
                    }
                }
                else
                {
                    Console.WriteLine("VALOR NO VÁLIDO\n");
                }
            }
        }

        public void mostrarTabla()
        {
            Console.Write($"{"",13}");
            for (int i = 0; i < aula.NomAsignaturas.Length; i++)
            {
                Console.Write($"{aula.NomAsignaturas[i],10}");
            }
            Console.WriteLine();
            for (int i = 0; i < aula.Notas.GetLength(0); i++)
            {
                Console.Write($"{i + 1}- {aula.NomAlumnos[i],-10}");
                for (int j = 0; j < aula.Notas.GetLength(1); j++)
                {
                    Console.Write($"{aula.Notas[i, j],10}");
                }
                Console.WriteLine();
            }
        }

        public void mostrarTablaAprobados()
        {
            Hashtable aprobadoss = aula.aprobados();

            Console.Write($"{"",13}");
            for (int i = 0; i < aula.NomAsignaturas.Length; i++)
            {
                Console.Write($"{aula.NomAsignaturas[i],10}");
            }
            Console.WriteLine();
            foreach (DictionaryEntry s in aprobadoss)
            {
                Console.Write($"{s.Key,-10}");
                int[] ap = (int[])s.Value;
                for (int i = 0; i < ap.Length; i++)
                {
                    Console.Write($"{ap[i],10}");
                }
                Console.WriteLine();
            }
        }
    }
}
