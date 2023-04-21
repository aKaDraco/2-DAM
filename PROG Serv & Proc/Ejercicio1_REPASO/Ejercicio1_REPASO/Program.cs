namespace Ejercicio1_REPASO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Astro> astros = new List<Astro>();
            int res = 0, lunas = 0;
            bool gas = false, compRadio = true, compName = true;
            string auxName, planName, lunaName;
            double auxRad, planRad, lunaRad;
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
                            Console.WriteLine("ES GASEOSO? S para SI, cualquier otro valor para NO\n");
                            if (Console.ReadLine().ToLower() == "s")
                            {
                                gas = true;
                            }
                            else
                            {
                                gas = false;
                            }

                            //TODO REALIZAR COMPROBACIONES DEL RADIO Y EL NOMBRE
                            while (compName)
                            {
                                Console.WriteLine("Introduzca el nombre del planeta:\n");
                                auxName = Console.ReadLine();
                                if (auxName == "")
                                {
                                    Console.WriteLine("NOMBRE INTRODUCIDO NO VÁLIDO");
                                }
                                else
                                {
                                    compName = false;
                                }
                            }

                            while (compRadio)
                            {
                                Console.WriteLine("Introduzca el radio del planeta\n");
                                if (Double.TryParse(Console.ReadLine(), out planRad) && planRad > 0)
                                {
                                    compRadio = false;
                                    astros.Add(new Planeta(gas, planName, planRad));
                                }
                                else
                                {
                                    Console.WriteLine("RADIO NO VÁLIDO\n");
                                }
                            }

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

                            Console.WriteLine("SE HAN CREADO " + lunas + " LUNAS.\n");
                            break;
                        case 2:
                            Console.WriteLine("Introduce el nombre:\n");
                            lunaName = Console.ReadLine();

                            while (compRadio)
                            {
                                Console.WriteLine("Introduzca el radio\n");
                                if (Double.TryParse(Console.ReadLine(), out lunaRad) && lunaRad > 0)
                                {
                                    compRadio = false;
                                    astros.Add(new Astro(lunaName, lunaRad));
                                }
                                else
                                {
                                    Console.WriteLine("RADIO NO VÁLIDO\n");
                                }
                            }
                            break;
                        case 3:
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
                                for (int i = astros.Count; i >= 0; i--)
                                {
                                    for (int j = astros.Count; j >= 0; j--)
                                    {
                                        if (astros[i].Equals(astros[j]))
                                        {
                                            Console.WriteLine("ASTRO " + astros.ElementAt(j).Nombre + " ESTABA REPETIDO");
                                            astros.RemoveAt(j);
                                        }
                                    }
                                }
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
    }
}