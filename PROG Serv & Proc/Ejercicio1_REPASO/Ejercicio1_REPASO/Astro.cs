using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_REPASO
{
    internal class Astro
    {
        private string nombre;
        private double radio;

        public Astro()
        {
            nombre = string.Empty;
            radio = 0;
        }
        public Astro(string nombre, double radio)
        {
            this.Nombre = nombre;
            this.Radio = radio;
        }

        public double Radio
        {
            get => radio;
            set => radio = value;
        }
        public string Nombre { get => nombre; set => nombre = value.ToUpper().Trim(); }
        public string getNombre(char c)
        {
            string aux = "";
            for (int i = 0; i < nombre.ToCharArray().Length; i++)
            {
                if (i == nombre.ToCharArray().Length - 1)
                {
                    aux += nombre.ToCharArray()[i];
                }
                else
                {
                    aux += nombre.ToCharArray()[i] + c.ToString();
                }
            }
            return aux;
        }

        public double setRadio(double value)
        {
            if (value < 0) throw new RadioNegativoException();
            return radio = value;
        }

        public override bool Equals(object obj)
        {

            return obj != null && obj.GetType() == this.GetType() && ((Astro)obj).Nombre == this.Nombre;
        }

        public override string ToString()
        {
            return "Nombre: " + getNombre + "\nRadio: " + Radio.ToString("N2");
        }
    }
}
