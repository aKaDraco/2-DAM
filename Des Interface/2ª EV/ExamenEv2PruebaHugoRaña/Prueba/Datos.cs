using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenEv2PruebaHugoRaña
{
    public partial class Datos : Form
    {
        public Datos()
        {
            InitializeComponent();
            foreach (sFriki.eAficion aficion in Enum.GetValues(typeof(sFriki.eAficion)))
            {
                comboBox1.Items.Add(aficion);
            }
        }
    }
}
