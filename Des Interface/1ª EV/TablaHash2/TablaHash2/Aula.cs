using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TablaHash2
{
    internal class Aula
    {
        Random notaRand = new Random();
        public int[,] notas;
        public string[] nombresAlum;
        private int notaMin;
        public int NotaMin { set; get; }
        int notaMax;
        public int NotaMax { set; get; }
        public enum asignatura
        {
            Pociones,
            Quidditch,
            Criaturas,
            ArtesOscuras
        }

        public Aula(string[] alumnos)
        {
            this.notas = new int[alumnos.Length, 4];
            for (int i = 0; i < alumnos.Length; i++)
            {
                nombresAlum[i] = alumnos[i].Trim().ToUpper();
            }
        }

        public Aula(string nombres)
        {
            string[] alumnos = nombres.Split(',');
            for (int i = 0; i < nombres.Length; i++)
            {
                alumnos[i] = alumnos[i].Trim().ToUpper();
            }
        }

        public int minMax(int alumno)
        {
            for (int i = 0; i < notas.GetLength(1); i++)
            {
                notaMax = notas[alumno, i];
                if (notaMax > notas[alumno, i])
                {
                    return notaMax = notas[alumno, i];
                }
                else
                {
                    return notaMin = notas[alumno, i];
                }
            }
            return notaMax;
        }

        public int this[int n1, int n2]
        {
            set
            {
                notas[n1, n2] = value;
            }

            get
            {
                return notas[n1, n2];
            }
        }
    }
}
