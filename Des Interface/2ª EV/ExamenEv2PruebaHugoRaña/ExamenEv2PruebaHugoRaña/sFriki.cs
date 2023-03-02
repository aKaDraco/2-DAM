using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEv2PruebaHugoRaña
{
    internal class sFriki
    {
        String nombre;
        int edad;
        public enum eAficion
        {
            Manga, SciFi, RPG, Fantasia, Terror, Tecnologia
        }
        public enum eSexo
        {
            Hombre, Mujer
        }
        private eSexo sexoOpuesto;
        public eSexo SexoOpuesto
        {
            set
            {
                if (value != eSexo.Hombre)
                {
                    sexoOpuesto = eSexo.Hombre;
                }
            }
            get
            {
                return sexoOpuesto;
            }
        }
    }
}
