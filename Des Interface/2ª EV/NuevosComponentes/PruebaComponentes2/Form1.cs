using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuevosComponentes;

namespace PruebaComponentes2
{
    public partial class Form1 : Form
    {
        bool bandera = false;
        int cont = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = labelTextBox1.Posicion.ToString();
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            bandera = !bandera;
            switch (bandera)
            {
                case false:
                    labelTextBox1.Posicion = LabelTextBox.ePosicion.IZQUIERDA;
                    break;

                case true:
                    labelTextBox1.Posicion = LabelTextBox.ePosicion.DERECHA;
                    break;
            }
        }

        private void labelTextBox1_PosicionChanged(object sender, EventArgs e)
        {
            this.Text = labelTextBox1.Posicion.ToString();
        }

        private void sepMas_Click(object sender, EventArgs e)
        {
            labelTextBox1.Separacion += 1;
        }

        private void labelTextBox1_SeparacionChanged(object sender, EventArgs e)
        {
            cont++;
            this.Text = labelTextBox1.Posicion.ToString() + " " + cont;
        }

        private void labelTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.Text = labelTextBox1.Posicion.ToString() + " " + e.KeyValue.ToString();
        }

        private void etiquetaAviso1_ClickEnMarca(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha hecho click en la marca", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
