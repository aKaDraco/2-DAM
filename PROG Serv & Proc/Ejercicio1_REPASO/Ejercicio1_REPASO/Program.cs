namespace Ejercicio1_REPASO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Astro> astros = new List<Astro>();
            int res = 0, lunas = 0, eqCont = 0;
            bool gas = false;
            string planName, lunaName;
            double planRad, lunaRad;
            while (res != 5)
            {
                Console.WriteLine("--- SELECCIONA UNA OPCION ---\n");
                Console.WriteLine("1.- Añade Planeta");
                Console.WriteLine("2.- Añade otro astro");
                Console.WriteLine("3.- Mostrar datos");
                Console.WriteLine("4.- Elimina repetidos");
                Console.WriteLine("5.- Salir\n");
                res = Convert.ToInt32(Console.ReadLine());
                switch (res)
                {
                    case 1:
                        Console.WriteLine("ES GASEOSO? S/N\n");
                        switch (Console.ReadLine().ToLower())
                        {
                            case "s":
                                gas = true;
                                break;
                            case "n":
                                gas = false;
                                break;
                        }
                        Console.WriteLine("Introduzca el nombre del planeta:\n");
                        planName = Console.ReadLine();
                        Console.WriteLine("Introduzca el radio del planeta:\n");
                        planRad = Convert.ToDouble(Console.ReadLine());
                        astros.Add(new Planeta(gas, planName, planRad));
                        Console.WriteLine("Planeta " + planName + " creado.\n");

                        Console.WriteLine("Cuantas lunas tiene el planeta?\n");
                        lunas = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < lunas; i++)
                        {
                            Console.WriteLine("Introduce el nombre de la Luna " + (i + 1) + ":\n");
                            lunaName = Console.ReadLine();
                            Console.WriteLine("Introduce el radio de la Luna " + (i + 1) + ":\n");
                            lunaRad = Convert.ToDouble(Console.ReadLine());
                            astros.Add(new Astro(lunaName, lunaRad));
                            Console.WriteLine("Luna " + lunaName + " creada.\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Introduce el nombre:\n");
                        lunaName = Console.ReadLine();
                        Console.WriteLine("Introduce el radio:\n");
                        lunaRad = Convert.ToDouble(Console.ReadLine());
                        astros.Add(new Astro(lunaName, lunaRad));
                        break;
                    case 3:
                        for (int i = 0; i < astros.Count; i++)
                        {
                            if (astros.ElementAt(i).GetType() == typeof(Astro))
                            {
                                Console.WriteLine(astros.ElementAt(i).ToString());
                            }
                            else
                            {
                                Console.WriteLine(astros.ElementAt(i).getNombre('.'));
                            }
                        }
                        break;
                    case 4:
                        for (int i = astros.Count; i >= 0; i--)
                        {
                            for (int j = astros.Count; j >= 0; j--)
                            {
                                if (astros.ElementAt(i).Equals(astros.ElementAt(j)))
                                {
                                    eqCont++;
                                    if (eqCont > 1)
                                    {
                                        astros.RemoveAt(i);
                                        astros.RemoveAt(j);
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("ADIOS");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("OPCION NO VÁLIDA, INTRDUZCA UN NÚMERO VÁLIDO");
                        break;
                }
            }
        }
    }
}