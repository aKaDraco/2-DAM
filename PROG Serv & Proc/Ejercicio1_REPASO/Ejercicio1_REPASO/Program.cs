namespace Ejercicio1_REPASO
{
    internal class Program
    {
        static List<Astro> astros;
        static Planeta p;
        static void Main(string[] args)
        {
            int res = 0;
            astros = new List<Astro>();
            while (res != 5)
            {
                Console.WriteLine("--- SELECCIONA UNA OPCION ---\n");
                Console.WriteLine("1.- Añade Planeta");
                Console.WriteLine("2.- Añade otro astro");
                Console.WriteLine("3.- Mostrar datos");
                Console.WriteLine("4.- Elimina repetidos");
                Console.WriteLine("5.- Salir\n");
                if (Int32.TryParse(Console.ReadLine(), out res))
                {
                    switch (res)
                    {
                        case 1:
                            creaPlaneta();
                            break;
                        case 2:
                            if (creaAstro())
                            {
                                Console.WriteLine("SE HA AÑADIDO UN NUEVO ASTRO");
                            }
                            break;
                        case 3:
                            Planeta pla;
                            if (astros != null && astros.Count > 0)
                            {
                                for (int i = 0; i < astros.Count; i++)
                                {
                                    if (astros.ElementAt(i).GetType() == typeof(Astro))
                                    {
                                        Console.WriteLine(astros.ElementAt(i).ToString());
                                    }
                                    else
                                    {
                                        Console.WriteLine(astros.ElementAt(i).getNombre('.'));
                                        pla = (Planeta)astros[i];

                                        for (int j = 0; j < pla.satelites.Count; j++)
                                        {
                                            Console.WriteLine(pla.satelites[j].ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("LA LISTA DE ASTROS ESTA VACIA O NO EXISTE\n");
                            }
                            break;
                        case 4:
                            if (astros != null && astros.Count > 0)
                            {
                                for (int i = 0; i < astros.Count; i++)
                                {
                                    for (int j = astros.Count - 1; j > i; j--)
                                    {
                                        if (astros[i].Equals(astros[j]))
                                        {
                                            astros.RemoveAt(j);
                                        }
                                    }
                                }
                                Console.WriteLine("PLANETAS Y ASTROS REPETIDOS ELIMINADOS");
                            }
                            else
                            {
                                Console.WriteLine("LA LISTA DE ASTROS ESTA VACIA O NO EXISTE\n");
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
                else
                {
                    Console.WriteLine("\nVALOR INTRODUCIDO NO VÁLIDO");
                }
            }
        }

        public static void creaPlaneta()
        {
            bool gas, compName = true, compRadio = true, compLunas = true;
            string planName;
            double planRad;
            int lunas;

            Console.WriteLine("ES GASEOSO? S para SI, cualquier otro valor para NO\n");
            if (Console.ReadLine().ToLower() == "s")
            {
                gas = true;
                Console.WriteLine("EL PLANETA ES GASEOSO\n");
            }
            else
            {
                gas = false;
                Console.WriteLine("EL PLANETA NO ES GASEOSO\n");
            }

            while (compName)
            {
                Console.WriteLine("Introduzca el nombre del planeta:\n");
                planName = Console.ReadLine();
                if (planName == "")
                {
                    Console.WriteLine("NOMBRE INTRODUCIDO NO VÁLIDO");
                }
                else
                {
                    compName = false;
                    while (compRadio)
                    {
                        Console.WriteLine("Introduzca el radio del planeta\n");
                        if (Double.TryParse(Console.ReadLine(), out planRad) && planRad > 0)
                        {
                            compRadio = false;
                            p = new Planeta(gas, planName, planRad);

                            while (compLunas)
                            {
                                Console.WriteLine("Cuantas lunas tiene el planeta?\n");
                                if (Int32.TryParse(Console.ReadLine(), out lunas) && lunas > 0)
                                {
                                    for (int i = 0; i < lunas; i++)
                                    {
                                        if (creaLuna(p))
                                        {
                                            Console.WriteLine("LUNA " + (i + 1) + " CREADA\n");
                                        }
                                    }
                                    Console.WriteLine("SE HAN CREADO " + lunas + " LUNAS.\n");
                                    compLunas = false;
                                }
                                else if (lunas == 0)
                                {
                                    Console.WriteLine("EL PLANETA NO TIENE LUNAS");
                                    compLunas = false;
                                }
                                else
                                {
                                    Console.WriteLine("VALOR NO VÁLIDO\n");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("RADIO NO VÁLIDO\n");
                        }
                    }
                }
            }
            Console.WriteLine("Planeta " + p.Nombre + " con radio " + p.Radio + " creado.\n");
            astros.Add(p);
        }

        public static bool creaLuna(Planeta p)
        {
            bool compRadioLuna = true, compNameLuna = true;
            string lunaName;
            double lunaRad;

            while (compNameLuna)
            {
                Console.WriteLine("Introduce el nombre de la Luna:\n");
                lunaName = Console.ReadLine();
                if (lunaName == "")
                {
                    Console.WriteLine("NOMBRE INTRODUCIDO NO VÁLIDO");
                }
                else
                {
                    compNameLuna = false;
                    while (compRadioLuna)
                    {
                        Console.WriteLine("Introduce el radio de la Luna:\n");
                        if (Double.TryParse(Console.ReadLine(), out lunaRad) && lunaRad > 0)
                        {
                            compRadioLuna = false;
                            p.satelites.Add(new Astro(lunaName, lunaRad));
                        }
                        else
                        {
                            Console.WriteLine("RADIO NO VÁLIDO\n");
                        }
                    }
                }
            }
            return true;
        }

        public static bool creaAstro()
        {
            bool compRadioLuna = true, compNameLuna = true;
            string lunaName;
            double lunaRad;

            while (compNameLuna)
            {
                Console.WriteLine("Introduce el nombre del Astro:\n");
                lunaName = Console.ReadLine();
                if (lunaName == "")
                {
                    Console.WriteLine("NOMBRE INTRODUCIDO NO VÁLIDO");
                }
                else
                {
                    compNameLuna = false;
                    while (compRadioLuna)
                    {
                        Console.WriteLine("Introduce el radio del Astro:\n");
                        if (Double.TryParse(Console.ReadLine(), out lunaRad) && lunaRad > 0)
                        {
                            compRadioLuna = false;
                            astros.Add(new Astro(lunaName, lunaRad));
                        }
                        else
                        {
                            Console.WriteLine("RADIO NO VÁLIDO\n");
                        }
                    }
                }
            }
            return true;
        }
    }
}