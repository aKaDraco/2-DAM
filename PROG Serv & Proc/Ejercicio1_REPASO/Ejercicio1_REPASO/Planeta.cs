using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_REPASO
{
    internal class Planeta : Astro
    {
        private bool gaseoso;

        public bool Gaseoso { get => gaseoso; set => gaseoso = value; }

        public List<Astro> satelites;

        public Planeta(bool gaseoso, string nombre, double radio) : base(nombre, radio)
        {
            Gaseoso = gaseoso;
            this.satelites = new List<Astro>();
        }

        public Planeta() : this(false, "", 0)
        {
        }
    }
}
