namespace Ejercicio1_REPASO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Astro> astros = new List<Astro>();
            int res = 0;
            while (res != 5)
            {
                Console.WriteLine("--- SELECCIONA UNA OPCION ---\n");
                Console.WriteLine("1.- Añade Planeta");
                Console.WriteLine("2- Añade otro astro");
                Console.WriteLine("3.- Mostrar datos");
                Console.WriteLine("4.- Elimina repetidos");
                Console.WriteLine("5.- Salir\n");
                switch (res)
                {
                    case 1:

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