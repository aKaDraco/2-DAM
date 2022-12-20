namespace Archivos2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread[] caballos = new Thread[5];
            if (apostarCaballo())
            {
                for (int i = 0; i < caballos.Length; i++)
                {
                    caballos[i] = new Thread(()=> );
                    caballos[i].Start();
                }
            }
        }

        private static bool apostarCaballo()
        {
            string[] nombres_caballos = { "Jose Luis", "Juan", "Rocinante", "Perdigón", "Potrillo" };
            int apuesta;
            bool apuesta_correcta = false;

            while (!apuesta_correcta)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- REALIZA TU APUESTA ---\n");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + "- " + nombres_caballos[i]);
                }
                Console.ResetColor();
                apuesta_correcta = Int32.TryParse(Console.ReadLine(), out apuesta);
                if (apuesta >= 0 && apuesta <= 5 && apuesta_correcta && apuesta != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("APUESTA REALIZADA\n");
                    Console.ResetColor();
                    apuesta_correcta = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("APUESTA NO VÁLIDA\n");
                    Console.ResetColor();
                    apuesta_correcta = false;
                }
            }
            return apuesta_correcta;
        }
    }
}