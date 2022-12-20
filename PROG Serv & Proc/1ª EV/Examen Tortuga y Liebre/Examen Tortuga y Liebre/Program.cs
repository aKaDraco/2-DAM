namespace Examen_Tortuga_y_Liebre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ganador;
            int linea = 0;
            int cantArchivos = 0;
            EsopoSimulation esopo = new EsopoSimulation();
            ganador = esopo.Init();

            using (StreamWriter sw = new StreamWriter(Environment.GetEnvironmentVariable("userprofile") + "\\examen.txt", true))
            {
                sw.WriteLine("Fecha y hora: " + DateTime.Now + "\tGanador: " + ganador);
                sw.WriteLine("------------------------------------------------------------------------------");
            }

            using (StreamReader sr = new StreamReader(Environment.GetEnvironmentVariable("userprofile") + "\\examen.txt"))
            {
                //sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    linea++;
                    Console.WriteLine(linea + "\t" + sr.ReadLine());
                }
            }

            DirectoryInfo di = new DirectoryInfo(Environment.GetEnvironmentVariable("appdata"));
            Array.ForEach(di.GetDirectories(), item =>
            {
                Console.WriteLine($"{item.Name}:{item.GetFiles().Length}");
            });
        }
    }
}