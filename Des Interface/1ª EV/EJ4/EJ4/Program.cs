namespace EJ4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string volerJugar;
            Boolean comp = true;
            Boolean juegos = true;
            while (comp == true)
                try
                {
                    Console.WriteLine("Selecciona uno de los siguiente juegos:");
                    Console.WriteLine();
                    Console.WriteLine("1.- Tirar dado");
                    Console.WriteLine("2.- Adivina el numero");
                    Console.WriteLine("3.- Quiniela");
                    Console.WriteLine("4.- Jugar a todos");
                    Console.WriteLine("5.- Salir");
                    Console.WriteLine();
                    int respuesta = Convert.ToInt32(Console.ReadLine());

                    switch (respuesta)
                    {
                        case 1:
                            Console.WriteLine();
                            dado();
                            Console.WriteLine();
                            Console.WriteLine("VOLVER A JUGAR: y = si || n = no");
                            volerJugar = Console.ReadLine().ToLower();
                            if (volerJugar == "y")
                            {
                                goto case 1;
                            }
                            else
                            {
                                if (juegos) goto case 2;

                                break;
                            }
                        case 2:
                            Console.WriteLine();
                            guessNum();
                            Console.WriteLine();
                            Console.WriteLine("VOLVER A JUGAR: y = si || n = no");
                            volerJugar = Console.ReadLine().ToLower();
                            if (volerJugar == "y")
                            {
                                goto case 2;
                            }
                            else
                            {
                                if (juegos)goto case 3;

                                break;
                            }
                        case 3:
                            Console.WriteLine();
                            mostrarQuiniela();
                            Console.WriteLine();
                            Console.WriteLine("VOLVER A JUGAR: y = si || n = no");
                            volerJugar = Console.ReadLine().ToLower();
                            if (volerJugar == "y")
                            {
                                goto case 3;
                            }
                            else
                            {
                                juegos = false;
                                goto case 4;
                            }
                        case 4:
                            if (juegos) goto case 1;
                            Console.WriteLine();
                            Console.WriteLine("VOLVER A JUGAR A TODOS LOS JUEGOS: y = si || n = no");
                            volerJugar = Console.ReadLine().ToLower();
                            if (volerJugar == "y")
                            {
                                juegos = true;
                                goto case 4;
                            }
                            else
                            {
                                break;
                            }
                        case 5:
                            Console.WriteLine("ADIOS");
                            comp = false;
                            break;
                        default:
                            Console.WriteLine("OPCIÓN NO VALIDA");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("ERROR");
                }
        }

        public static void dado()
        {
            int caras = 2;
            int num = 1;
            String v = "ACERTADO";
            Random dado = new Random();
        Introduce:
            Console.WriteLine("Introduce el número de caras que quieres que tenga el dado: 1-6");
            try
            {
                caras = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("ERROR AL INTRODUCIR EL NUMERO");
            }
            if (caras < 2 || caras > 6)
            {
                Console.WriteLine("NUMERO DE CARAS NO VÁLIDO");
                goto Introduce;
            }
            Console.WriteLine();
            Console.WriteLine("Ahora introduce el número que crees que saldrá");
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("ERROR AL INTRODUCIR EL NUMERO");
            }
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                int numRand = dado.Next(1, caras + 1);
                if (num == numRand)
                {
                    Console.WriteLine("Tirada " + i + ": " + numRand + "   " + v);
                }
                else
                {
                    Console.WriteLine("Tirada " + i + ": " + numRand);
                }
            }
        }

        public static void guessNum()
        {
            int guess;
            Random num = new Random();
            int numRand = num.Next(1, 101);
            Console.WriteLine("Adivina el número entre 1-100");
            try
            {
                for (int i = 5; i >= 0; i--)
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                    if (guess != numRand)
                    {
                        if (guess < numRand)
                        {
                            Console.WriteLine("Your number is lower, you have " + i + " tries left");
                        }
                        else
                        {
                            Console.WriteLine("Your number is upper, you have " + i + " tries left");
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("YOU GUESSED THE NUMBER!!");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("THE NUMBER WAS: " + numRand);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("ERROR AL INTRODUCIR LOS DATOS");
            }
        }

        public static string quiniela()
        {
            Random rand = new Random();
            int numRand = rand.Next(1, 101);
            switch (numRand)
            {
                case <= 60: return "1";
                case > 60 and <= 85: return "X";
                case > 85: return "2";
            }
        }

        public static void mostrarQuiniela()
        {
            for (int i = 1; i <= 14; i++)
            {
                Console.WriteLine("Resultado {0,5}: {1}", i, quiniela());
            }
        }
    }
}