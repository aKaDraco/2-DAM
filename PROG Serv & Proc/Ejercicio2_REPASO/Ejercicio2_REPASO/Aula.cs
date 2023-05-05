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

        public void maxMin(ref int maX, ref int miN)
        {
            if (notas != null)
            {
                for (int i = 0; i < notas.GetLength(0); i++)
                {
                    for (int j = 0; j < notas.GetLength(1); j++)
                    {
                        maX = notas[i, j];
                        miN = notas[i, j];
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
        }

        public Aula(string[] nomAlumnos, string[] nomAsignaturas)
        {
            Random rand = new Random();
            int[,] tabla = new int[nomAlumnos.Length, nomAsignaturas.Length];
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i, j] = rand.Next(1, 11);
                }
            }
        }

        //TODO NOTAS DE CADA ALUMNO
        public Hashtable aprobados()
        {
            Hashtable aprobados = new Hashtable();
            for (int i = 0; i < nomAlumnos.Length; i++)
            {

                // comprobar notas >=5 del alumno i

                // crear vector con notas (si procede)


                aprobados.Add(nomAlumnos[i],vectoir]);
            }
            return aprobados;
        }

        public double media()
        {
            
        }
    }
}
