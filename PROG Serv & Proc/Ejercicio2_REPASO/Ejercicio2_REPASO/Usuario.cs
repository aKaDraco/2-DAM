using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_REPASO
{
    internal class Usuario
    {
        static string[] nomAlum = { "PEDRO", "JUAN", "HUGO", "GABRIEL", "LOIS", "JOSE" };
        static string[] nomAsig = { "MATEMATICAS", "LENGUA", "HISTORIA", "GALLEGO" };
        Aula aula = new Aula(nomAlum, nomAsig);
        bool comp;
        int num = 0, max = 0, min = 0;
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
                            aula.mostrarTabla();
                            break;
                        case 2:
                            Console.WriteLine("LA MEDIA DE TODAS LAS NOTAS ES: " + aula.mediaNotas());
                            break;
                        case 3:
                            compAlumno();
                            Console.WriteLine("LA MEDIA DE" + nomAlum[num - 1] + " ES: " + aula.mediaAlumno(num));
                            break;
                        case 4:
                            compAsignatura();
                            Console.WriteLine("LA MEDIA DE " + nomAsig[num - 1] + " ES: " + aula.mediaAsignatura(num));
                            break;
                        case 5:
                            compAlumno();
                            Console.Write("LAS NOTAS DE " + nomAlum[num - 1] + " SON:");
                            for (int i = 0; i < aula.Notas.GetLength(1); i++)
                            {
                                Console.Write($"{aula.Notas[num - 1, i],3}");
                            }
                            Console.WriteLine();
                            break;
                        case 6:
                            compAsignatura();
                            Console.Write("LAS NOTAS DE " + nomAsig[num - 1] + " SON:");
                            for (int i = 0; i < aula.Notas.GetLength(0); i++)
                            {
                                Console.Write($"{aula.Notas[i, num - 1],3}");
                            }
                            Console.WriteLine();
                            break;
                        case 7:
                            compAlumno();
                            aula.maxMin(ref max, ref min, num);
                            Console.WriteLine("LA NOTA MÁS ALTA DE " + nomAlum[num - 1] + " ES " + max + " Y LA MÍNIMA " + min);
                            break;
                        case 8:
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
                Console.WriteLine("--- INTRODUZCA EL NUMERO DEL ALUMNO ---\n");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    if (num > aula.NomAlumnos.Length || num < 0)
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
                Console.WriteLine("--- INTRODUZCA EL NUMERO DE LA ASIGNATURA ---\n");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    if (num > aula.NomAsignaturas.Length || num < 0)
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
    }
}
