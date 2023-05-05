using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ejercicio2_REPASO
{
    internal class Aula
    {
        private int[,] notas;
        private string[] nomAlumnos;
        private string[] nomAsignaturas;

        public int[,] Notas
        {
            set => notas = value;
            get => notas;
        }
        public string[] NomAlumnos
        {
            get => nomAlumnos;
        }
        public string[] NomAsignaturas
        {
            get => nomAsignaturas;
        }

        public Aula(string[] alumnos, string[] asignaturas)
        {
            Random r = new Random();
            int[,] notas = new int[alumnos.Length, asignaturas.Length];

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    notas[i, j] = r.Next(3, 11);
                }
            }

            this.notas = notas;
            this.nomAlumnos = alumnos;
            this.nomAsignaturas = asignaturas;
        }

        public void maxMin(ref int maX, ref int miN)
        {
            if (notas != null)
            {
                maX = 3;
                miN = 11;
                for (int i = 0; i < notas.GetLength(0); i++)
                {
                    for (int j = 0; j < notas.GetLength(1); j++)
                    {
                        if (notas[i, j] > maX)
                        {
                            maX = notas[i, j];
                        }

                        if (notas[i, j] < miN)
                        {
                            miN = notas[i, j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("LA TABLA DE NOTAS ESTA VACIA");
            }
        }


        public Hashtable aprobados()
        {
            Hashtable aprobados = new Hashtable();
            int[] notasAprobadas = new int[4];
            string alumno;
            bool compAprobado;

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                compAprobado = true;
                alumno = notas[i].ToString();
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    if (notas[i, j] < 5)
                    {
                        compAprobado = false;
                    }
                    else
                    {
                        notasAprobadas[j] = notas[i, j];

                    }
                }
                if (compAprobado)
                {
                    aprobados.Add();
                }
            }

            return aprobados;
        }

        public double mediaAlumno(int alumno)
        {
            double media = 0;

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                media += notas[alumno, i];
            }
            return media / notas.GetLength(0);
        }

        public double mediaAsignatura(int asigantura)
        {
            double media = 0;

            for (int i = 0; i < notas.GetLength(1); i++)
            {
                media += notas[i, asigantura];
            }
            return media / notas.GetLength(1);
        }
    }
}

