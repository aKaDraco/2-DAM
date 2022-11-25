using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms6
{
    public partial class PinForm : Form
    {
        int cont = 3;
        public PinForm()
        {
            InitializeComponent();
        }

        private void btnPin(object sender, EventArgs e)
        {
            if (textBox1.Text == "1234")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                cont--;
                this.Text = "PIN: " + cont + " INTENTOS";
                this.textBox1.BackColor = Color.Red;
                if (cont == 0)
                {
                    if (MessageBox.Show("NUMERO DE INTENTOS EXCEDIDO", "PIN ERRONEO", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}