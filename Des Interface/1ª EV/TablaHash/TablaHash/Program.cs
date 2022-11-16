using System.Collections;

namespace TablaHash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable tabla = new Hashtable();
            bool comp = true;
            string direccion;
            double ram;
            int respuesta;
            try
            {
                do
                {
                    bool comprobante = true;
                    bool comprobanteRAM = true;
                    Console.WriteLine("Seleccione una de las siguiente opciones:");
                    Console.WriteLine("1.- Introduccion de datos");
                    Console.WriteLine("2.- Eliminar un dato");
                    Console.WriteLine("3.- Mostrar colección entera");
                    Console.WriteLine("4.- Mostrar un elemento de la colección");
                    Console.WriteLine("5.- Salir");
                    Console.WriteLine();

                    comp = int.TryParse(Console.ReadLine(), out respuesta);
                    if (comp)
                    {

                        switch (respuesta)
                        {
                            case 1:
                                while (comprobante)
                                {
                                    Console.Write("Introduzca la IP: ");
                                    direccion = Console.ReadLine();
                                    Console.Write("Introduzca la capacidad de memoria RAM: ");
                                    comprobanteRAM = double.TryParse(Console.ReadLine(), out ram);
                                    if (comprobanteRAM)
                                    {
                                        if (compIP(direccion) && compRAM(ram))
                                        {
                                            tabla.Add(direccion, ram);
                                            comprobante = false;
                                        }
                                    }
                                    Console.WriteLine();
                                }
                                break;
                            case 2:
                                Console.Write("Introduzca el elemento que quiere eliminar: ");
                                string resp = Console.ReadLine();
                                Console.WriteLine();
                                if (tabla.ContainsKey(resp)) tabla.Remove(resp); Console.WriteLine("ELEMENTO ELIMINADO");
                                Console.WriteLine();
                                break;
                            case 3:
                                Console.WriteLine($"\tIP \t{"RAM",11}");
                                Console.WriteLine();
                                foreach (DictionaryEntry de in tabla)
                                {
                                    Console.WriteLine("\t{0} \t{1}GB\n", de.Key, de.Value);
                                }
                                break;
                            case 4:
                                Console.WriteLine("Introduzca la IP que desea mostrar");
                                string ipR = Console.ReadLine();
                                if (compIP(ipR)) Console.WriteLine("Ana tiene {0} años", tabla[ipR]);
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("--BYE--");
                                Console.ResetColor();
                                Console.WriteLine();
                                comp = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("---FORMAT ERROR---");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                } while (respuesta != 5);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("ERROR");
            }
        }

        public static bool compRAM(double vRAM)
        {
            if (vRAM >= 0) return true;
            return false;
        }

        public static bool compIP(string cIPS)
        {
            string[] aux = cIPS.Split('.');

            if (aux.Length == 4)
            {
                for (int i = 0; i < aux.Length; i++)
                {
                    if (Convert.ToInt32(aux[i]) >= 0 && Convert.ToInt32(aux[i]) <= 255)
                    {
                        return true;
                    }

                }
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}