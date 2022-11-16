using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablaHash2
{
    internal class Menu
    {
        public void inicio(params string[] nombresAlumnos)
        {
            Aula clase = new Aula(nombresAlumnos);
            int respuesta;
            bool comp;
            int numAlumno;
            int numAasig;
            double media;
            int cont;
            double sumNotas;
            string[] asig;
            bool compAlumno;
            try
            {
                do
                {
                    Console.WriteLine("Seleccione una de las siguientes opciones:");
                    Console.WriteLine();
                    Console.WriteLine("1.- Calcular la media de notas de toda la tabla");
                    Console.WriteLine("2.- Media de un alumno");
                    Console.WriteLine("3.- Media de una asigantura");
                    Console.WriteLine("4.- Visualizar notas de un alumno");
                    Console.WriteLine("5.- Visualizar notas de una asignatura");
                    Console.WriteLine("6.- Nota máxima y mínima de un alumno");
                    Console.WriteLine("7.- Visualizar tabla completa");
                    Console.WriteLine("8.- Salir");
                    Console.WriteLine();
                    comp = int.TryParse(Console.ReadLine(), out respuesta);

                    if (comp)
                    {
                        switch (respuesta)
                        {
                            case 1:
                                Console.Write("LA MEDIA DE TODAS LAS NOTAS DE LA TABLA ES:");
                                Console.WriteLine();
                                sumNotas = 0.0;
                                media = 0.0;
                                cont = 0;
                                for (int i = 0; i < clase.notas.GetLength(0); i++)
                                {
                                    for (int j = 0; j < clase.notas.GetLength(1); j++)
                                    {
                                        sumNotas = sumNotas + Convert.ToDouble(clase.notas[i, j]);
                                        cont++;
                                    }
                                }
                                media = sumNotas / cont;
                                Console.WriteLine(media);
                                break;
                            case 2:
                                try
                                {
                                    Console.Write("SELECCIONE UN ALUMNO:");
                                    Console.WriteLine();
                                    for (int i = 0; i < clase.nombresAlum.Length; i++)
                                    {
                                        Console.WriteLine($"{i + 1}.- {clase.nombresAlum[i]}");
                                    }
                                }
                                catch
                                {
                                    Console.Error.WriteLine("---ERROR---");
                                }
                                compAlumno = int.TryParse(Console.ReadLine(), out numAlumno);
                                if (compAlumno)
                                {
                                    sumNotas = 0.0;
                                    media = 0.0;
                                    cont = 0;
                                    for (int i = 0; i < clase.notas.GetLength(0); i++)
                                    {
                                        sumNotas = sumNotas + clase.notas[i, numAlumno];
                                        cont++;
                                    }
                                    media = sumNotas / cont;
                                }
                                break;
                            case 3:
                                try
                                {
                                    asig = Enum.GetNames(typeof(Aula.asignatura));
                                    Console.Write("SELECCIONE ASIGNATURA:");
                                    Console.WriteLine();
                                    for (int i = 0; i < asig.GetLength(0); i++)
                                    {
                                        Console.WriteLine($"{i + 1}.- {asig[i]}");
                                    }
                                }
                                catch
                                {
                                    Console.Error.WriteLine("---ERROR---");
                                }
                                compAlumno = int.TryParse(Console.ReadLine(), out numAasig);
                                if (compAlumno)
                                {
                                    sumNotas = 0.0;
                                    media = 0.0;
                                    cont = 0;
                                    for (int i = 0; i < clase.notas.GetLength(1); i++)
                                    {
                                        sumNotas = sumNotas + clase.notas[numAasig, i];
                                        cont++;
                                    }
                                    media = sumNotas / cont;
                                }
                                break;
                            case 4:
                                try
                                {
                                    Console.Write("SELECCIONE UN ALUMNO:");
                                    Console.WriteLine();
                                    for (int i = 0; i < clase.nombresAlum.Length; i++)
                                    {
                                        Console.WriteLine($"{i + 1}.- {clase.nombresAlum[i]}");
                                    }
                                }
                                catch
                                {
                                    Console.Error.WriteLine("---ERROR---");
                                }
                                compAlumno = int.TryParse(Console.ReadLine(), out numAlumno);
                                if (compAlumno)
                                {
                                    for (int i = 0; i < clase.notas.GetLength(0); i++)
                                    {
                                        Console.WriteLine(clase.notas[i, numAlumno]);
                                    }
                                }
                                break;
                            case 5:
                                try
                                {
                                    asig = Enum.GetNames(typeof(Aula.asignatura));
                                    Console.Write("SELECCIONE ASIGNATURA:");
                                    Console.WriteLine();
                                    for (int i = 0; i < asig.GetLength(0); i++)
                                    {
                                        Console.WriteLine($"{i + 1}.- {asig[i]}");
                                    }
                                }
                                catch
                                {
                                    Console.Error.WriteLine("---ERROR---");
                                }
                                compAlumno = int.TryParse(Console.ReadLine(), out numAasig);
                                if (compAlumno)
                                {
                                    for (int i = 0; i < clase.notas.GetLength(0); i++)
                                    {
                                        Console.WriteLine(clase.notas[numAasig, i]);
                                    }
                                }
                                break;
                            case 6:
                                try
                                {
                                    Console.Write("SELECCIONE UN ALUMNO:");
                                    Console.WriteLine();
                                    for (int i = 0; i < clase.nombresAlum.Length; i++)
                                    {
                                        Console.WriteLine($"{i + 1}.- {clase.nombresAlum[i]}");
                                    }
                                }
                                catch
                                {
                                    Console.Error.WriteLine("---ERROR---");
                                }
                                compAlumno = int.TryParse(Console.ReadLine(), out numAlumno);
                                Console.WriteLine();
                                Console.WriteLine(clase.minMax(numAlumno));
                                break;
                            case 7:
                                for (int i = 0; i < clase.notas.GetLength(0); i++)
                                {
                                    for (int j = 0; j < clase.notas.GetLength(1); j++)
                                    {
                                        Console.WriteLine(clase.notas[i, j]);
                                    }
                                }
                                break;
                            case 8:
                                Console.WriteLine();
                                Console.WriteLine("---ADIOS---");
                                break;
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("ERROR EN EL FORMATO INTRODUCIDO, INTRODUZCA UN VALOR ENTRE 1 - 8:");
                        Console.WriteLine();
                    }
                } while (respuesta != 8);
            }
            catch (Exception)
            {
                Console.Error.WriteLine("ERROR");
            }
        }
    }
}
