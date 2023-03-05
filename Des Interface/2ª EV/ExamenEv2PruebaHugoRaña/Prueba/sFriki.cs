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

        private String foto;

        public String Foto
        {
            set
            {
                foto = value;
            }
            get
            {
                return foto;
            }
        }

        public sFriki(string nombre, int edad, eSexo sexoOpuesto, string foto)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexoOpuesto = sexoOpuesto;
            this.foto = foto;
        }

        public sFriki()
        {
            this.nombre = "";
            this.edad = 0;
            this.sexoOpuesto = eSexo.Hombre;
            this.foto = foto;
        }
    }
}
