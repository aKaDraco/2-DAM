using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio3_REPASO
{
    internal class Program
    {
        static private object l = new object();
        static bool end = false;
        static int cont = 0;
        static void Main(string[] args)
        {
            Thread incremento = new Thread(() =>
            {
                while (!end)
                {
                    lock (l)
                    {
                        if (!end)
                        {
                            cont++;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("HILO 1: " + cont);
                        }
                        if (cont == 500)
                        {
                            end = true;
                        }

                    }
                }

                lock (l)
                {
                    Monitor.Pulse(l);
                }
            });

            Thread decremento = new Thread(() =>
            {
                while (!end)
                {
                    lock (l)
                    {
                        if (!end)
                        {
                            cont--;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("HILO 2: " + cont);
                        }
                        if (cont == -500)
                        {
                            end = true;
                        }
                    }
                }

                lock (l)
                {
                    Monitor.Pulse(l);
                }
            });

            incremento.Start();
            decremento.Start();

            lock (l)
            {
                Monitor.Wait(l);
            }

            if (cont == 500)
            {
                Console.WriteLine("HILO 1 GANA");
                Console.ReadKey();
            }
            else if (cont == -500)
            {
                Console.WriteLine("HILO 2 GANA");
                Console.ReadKey();
            }
        }
    }
}
