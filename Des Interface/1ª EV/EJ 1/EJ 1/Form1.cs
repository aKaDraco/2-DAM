using System;

namespace EJ_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double suma;
                double n1 = Convert.ToDouble(textBox1.Text);
                double n2 = Convert.ToDouble(textBox2.Text);
                if (n1 < 0 || n2 < 0)
                {
                    Text = "Numero no valido";
                    label2.Text = "=";
                }
                else
                {
                    suma = n1 + n2;
                    Text = "Programa de Suma";
                    label2.Text = "= " + suma;
                }
            }
            catch (FormatException)
            {
                Text = "Error en los valores introducidos";
            }
        }
    }
}