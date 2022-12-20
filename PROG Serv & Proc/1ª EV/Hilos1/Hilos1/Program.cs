using System.Threading;
namespace Hilos1
{
    internal class Program
    {
        static private object l = new object();
        static bool end = false;
        static int cont = 0;
        static void Main(string[] args)
        {
            Thread[] tr = new Thread[2];
            for (int i = 0; i < 2; i++)
            {
                tr[0] = new Thread(incre);
                tr[1] = new Thread(decre);
                tr[i].Start();

            }
                tr[i].Join();

            if (cont == 1000)
            {
                Console.WriteLine("THREAD 1 WINS");
            }
            else if (cont == -1000)
            {
                Console.WriteLine("THREAD 2 WINS");
            }
        }

        static void incre()
        {
            while (!end)
            {
                lock (l)
                {
                    if (!end)
                    {
                        cont++;
                        Console.WriteLine("TR 1: " + cont);
                    }
                    if (cont == 1000)
                    {
                        end = true;
                    }

                }
            }
        }

        static void decre()
        {
            while (!end)
            {
                lock (l)
                {
                    if (!end)
                    {
                        cont--;
                        Console.WriteLine("TR 2: " + cont);
                    }
                    if (cont == -1000)
                    {
                        end = true;
                    }
                }
            }
        }

    }
}