﻿using System;
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

        public void maxMin(ref int maX, ref int miN, int alumno)
        {

            maX = notas[alumno - 1, 0];
            miN = notas[alumno - 1, 0];

            for (int i = 0; i < notas.GetLength(1); i++)
            {
                if (notas[alumno - 1, i] > maX)
                {
                    maX = notas[alumno - 1, i];
                }

                if (notas[alumno - 1, i] < miN)
                {
                    miN = notas[alumno - 1, i];
                }

            }

        }


        public Hashtable aprobados()
        {
            Hashtable hAprobados = new Hashtable();
            int[] notasAprobadas = new int[nomAsignaturas.Length];
            bool compAprobado;

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                compAprobado = true;
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
                    hAprobados.Add(nomAlumnos[i], notasAprobadas);
                }
                notasAprobadas = new int[4];
            }

            return hAprobados;
        }

        public double mediaAlumno(int alumno)
        {
            double media = 0;

            for (int i = 0; i < notas.GetLength(1); i++)
            {
                media += notas[alumno - 1, i];
            }
            return media / nomAsignaturas.Length;
        }

        public double mediaAsignatura(int asigantura)
        {
            double media = 0;

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                media += notas[i, asigantura - 1];
            }
            return media / nomAlumnos.Length;
        }

        public double mediaNotas()
        {
            double media = 0;

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    media += notas[i, j];
                }
            }
            return media / (nomAlumnos.Length * nomAsignaturas.Length);
        }
    }
}

