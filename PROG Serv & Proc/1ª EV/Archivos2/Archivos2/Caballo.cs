using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos2
{
    internal class Caballo
    {
        Random rand = new Random();
        private int position;
        public int Position1 { get => position; set => position = value; }

        public void caballoCorre()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i + "\n");
            }
        }
    }
}
