using System.Collections;

namespace Forms4
{
    delegate double Cositas(double n1, double n2);
    public partial class Form1 : Form
    {
        Hashtable operaciones = new Hashtable();
        Cositas cosita;

        double n1 = 0.0;
        double n2 = 0.0;
        int contSec = 0;
        int contMin = 0;
        public Form1()
        {
            InitializeComponent();
            operaciones.Add("+", (Cositas)((n1, n2) => n1 + n2));
            operaciones.Add("-", (Cositas)((n1, n2) => n1 - n2));
            operaciones.Add("*", (Cositas)((n1, n2) => n1 * n2));
            operaciones.Add("/", (Cositas)((n1, n2) => n1 / n2));
            cosita = (Cositas)(operaciones["+"]);
        }

        private void selecOperaciones(object sender, EventArgs e)
        {
            string txtCheckbox = ((RadioButton)sender).Text;
            simbolo.Text = txtCheckbox;
            cosita = (Cositas)(operaciones[simbolo.Text]);
        }

        private void compTxtboxes(object sender, EventArgs e)
        {
            double num;
            bool compNum = true;
            if (((TextBox)sender).Text != string.Empty)
            {
                compNum = Double.TryParse(((TextBox)sender).Text, out num);
            }
            if (!compNum)
            {
                ((TextBox)sender).BackColor = Color.Red;
            }
            else
            {
                ((TextBox)sender).BackColor = Color.White;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere salir?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contSec++;
            if (contSec == 60)
            {
                contMin++;
                contSec = 0;
            }
            this.Text = $"{contMin:d2}:{contSec:d2}";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            bool n1Comp = Double.TryParse(textBox1.Text, out n1);
            bool n2Comp = Double.TryParse(textBox2.Text, out n2);
            if (n1Comp && n2Comp)
            {
                resultado.ForeColor = Color.Black;
                resultado.Text = "Resultado: " + cosita(n1, n2).ToString();
            }
            else
            {
                resultado.ForeColor = Color.Red;
                resultado.Text = "ERROR";
            }
        }

        private void acptButtn(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                this.AcceptButton = btnOperar;
            }
        }
    }
}
