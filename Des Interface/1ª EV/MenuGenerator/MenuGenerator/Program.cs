using System;
using System.Numerics;

namespace MenuGenerator
{
    public delegate void MyDelegate();
    internal class Program
    {
        public static bool MenuGenerator(String[] nombres, MyDelegate[] funciones)
        {
            int respuesta;
            bool numComp;
            if (nombres != null && funciones != null && nombres.Length == funciones.Length)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("SELECT ONE OF THE FOLLOWING OPTIONS:");
                        Console.WriteLine();
                        for (int i = 0; i < nombres.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.- {nombres[i].ToUpper()}\n");
                        }
                        Console.WriteLine($"{nombres.Length + 1}.- EXIT");
                        Console.WriteLine();
                        numComp = int.TryParse(Console.ReadLine(), out respuesta);
                        if (numComp)
                        {
                            if (respuesta - 1 == nombres.Length)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("----BYE----");
                                Console.ResetColor();
                                Console.WriteLine();
                            }
                            else if (respuesta - 1 >= 0 && respuesta - 1 <= nombres.Length)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                funciones[respuesta - 1]();
                                Console.ResetColor();
                                Console.WriteLine();
                            }
                            //else
                            //{
                            //    Console.WriteLine("---ERROR---");
                            //    Console.WriteLine($"TYPE A VALID OPTION FROM: 1 to {nombres.Length + 1}");
                            //    Console.WriteLine();
                            //    bool numComp2 = int.TryParse(Console.ReadLine(), out respuesta);
                            //    while (!numComp2)
                            //    {
                            //        Console.WriteLine("---ERROR---");
                            //        Console.WriteLine($"TYPE A VALID OPTION FROM: 1 to {nombres.Length + 1}");
                            //        Console.WriteLine();
                            //        numComp2 = int.TryParse(Console.ReadLine(), out respuesta);
                            //    }
                            //    if (respuesta - 1 == nombres.Length)
                            //    {
                            //        Console.WriteLine("---BYE---");
                            //    }
                            //    else if (respuesta - 1 >= 0 && respuesta - 1 <= nombres.Length)
                            //    {
                            //        Console.WriteLine();
                            //        funciones[respuesta - 1]();
                            //        Console.WriteLine();
                            //    }
                            //    else
                            //    {
                            //        Console.WriteLine();
                            //        Console.WriteLine("---OUT OF RANGE---");
                            //        Console.WriteLine();
                            //    }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("---FORMAT ERROR---");
                            Console.WriteLine($"TYPE A VALID OPTION FROM: 1 to {nombres.Length + 1}");
                            Console.ResetColor();
                            Console.WriteLine();
                            //numComp = int.TryParse(Console.ReadLine(), out respuesta);
                            //}
                            //while (!numComp || respuesta - 1 < 0 || respuesta - 1 > nombres.Length)
                            //{
                            //if (respuesta - 1 == nombres.Length)
                            //{
                            //    Console.WriteLine("---BYE---");
                            //}
                            //else
                            //{
                            //    funciones[respuesta - 1]();
                            //}
                        }
                    } while (respuesta - 1 != nombres.Length || !numComp);
                    return true;
                }
                catch
                {
                    Console.WriteLine("---MENU ERROR---");
                }
            }
            else
            {
                Console.WriteLine("---CREATION MENU ERROR---");
            }
            return false;
        }

        //static void f1()
        //{
        //    Console.WriteLine("A");
        //}
        //static void f2()
        //{
        //    Console.WriteLine("B");
        //}
        //static void f3()
        //{
        //    Console.WriteLine("C");
        //}
        static void Main(string[] args)
        {
            MenuGenerator(new string[] { "Op1", "Op2", "Op3", },
            new MyDelegate[] { () => Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C"), });
            Console.ReadKey();
        }
    }
}