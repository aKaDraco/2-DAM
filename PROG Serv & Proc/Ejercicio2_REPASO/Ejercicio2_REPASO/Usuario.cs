using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_REPASO
{
    internal class Usuario
    {
        Aula aula = new Aula();

        public void init()
        {
            int res = 0;
            while (res != 9)
            {

                Console.WriteLine("1.- Visualizar tabla completa");
                Console.WriteLine("2.- Calcular la media de notas de la tabla");
                Console.WriteLine("3.- Media de un alumno");
                Console.WriteLine("4.- Media de una asignatura");
                Console.WriteLine("5.- Visualizar notas de un alumno");
                Console.WriteLine("6.- Visualizar notas de una asignatura");
                Console.WriteLine("7.- Nota máxima y mínima de un alumno");
                Console.WriteLine("8.- Tabla solo de aprobados");
                Console.WriteLine("9.- Salir\n");
                res = Convert.ToInt32(Console.ReadLine());
                switch (res)
                {
                    case 9:
                        Console.WriteLine("ADIOS");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("OPCIÓN NO VÁLIDA\n");
                        break;
                }
            }
        }
    }
}
