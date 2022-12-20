using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Tortuga_y_Liebre
{
    internal class EsopoSimulation
    {
        private readonly object l = new object();
        bool finish = false;
        int turtleSteps = 0;
        int rabitSteps = 0;
        Random rand = new Random();
        int meta = 0;
        string winner;

        public void RunTurtleRun()
        {
            while (!finish)
            {
                lock (l)
                {
                    if (!finish)
                    {
                        turtleSteps++;
                        Console.WriteLine("Turtle Steps: " + turtleSteps);
                        if (turtleSteps >= meta)
                        {
                            finish = true;
                            winner = "TURTLE";
                        }
                    }
                }
                Thread.Sleep(300);
            }
        }

        public void RunAndSleepRabit()
        {
            while (!finish)
            {
                lock (l)
                {
                    if (!finish)
                    {
                        rabitSteps += 4;
                        Console.WriteLine("Rabbit Steps: " + rabitSteps);
                        if (turtleSteps == rabitSteps)
                        {
                            if (rand.Next(1,3) == 1)
                            {
                                Console.WriteLine("Turtle wakes up Rabit");
                                Monitor.Pulse(l);
                            }
                        }
                        if (rabitSteps >= meta)
                        {
                            finish = true;
                            winner = "RABBIT";
                        }
                        else
                        {
                            if (rand.Next(1, 101) <= 60)
                            {
                                int auxRabitSetps = rabitSteps;
                                new Thread(() => SweetDreams(auxRabitSetps)).Start();
                                Console.WriteLine("Rabit sleeps at " + rabitSteps + " steps");
                                Monitor.Wait(l);
                                Console.WriteLine("Rabit wakes at " + rabitSteps + " steps");
                            }
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }

        public void SweetDreams(int rabbitSteps)
        {
            Console.WriteLine("Rabbit Sleeps");
            Thread.Sleep(2500);
            lock (l)
            {
                if (rabbitSteps == rabitSteps)
                {
                    Monitor.Pulse(l);
                }
            }
        }

        public string Init()
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(Environment.GetEnvironmentVariable("userprofile") + "\\meta.bin", FileMode.Open)))
                {
                    meta = br.ReadInt32();
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine("EROR EN EL ARCHIVO");
            }

            Thread rabit = new Thread(RunAndSleepRabit);
            Thread turtle = new Thread(RunTurtleRun);

            rabit.Start();
            turtle.Start();
            rabit.Join();
            turtle.Join();

            Console.WriteLine("The winner is: " + winner);
            return winner;
        }
    }
}
