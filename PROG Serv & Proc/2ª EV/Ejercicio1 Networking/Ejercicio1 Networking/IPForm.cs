using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1_Networking
{
    public partial class Form2 : Form
    {
        public Form2(string ip, int port)
        {
            InitializeComponent();
            this.Text = $"{ip} {port}";
        }

        private void changeButton_Click(object sender, EventArgs e)
        {

            if (textBoxIP.BackColor == Color.Lime && textBoxPort.BackColor == Color.Lime)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("ANY VALUE IS WRONG", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBoxIP_TextChanged(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(textBoxIP.Text, out IPAddress ip))
            {
                textBoxIP.BackColor = Color.Lime;
            }
            else
            {
                textBoxIP.BackColor = Color.Red;
            }
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (UInt16.TryParse(textBoxPort.Text, out UInt16 port))
            {
                textBoxPort.BackColor = Color.Lime;
            }
            else
            {
                textBoxPort.BackColor = Color.Red;
            }
        }
    }
}
