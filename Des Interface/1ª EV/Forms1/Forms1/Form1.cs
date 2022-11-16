#define EV

using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Forms1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X({e.X}) Y({e.Y})";
            if (sender is Button)
            {
                this.Text = $"X({e.X + ((Button)sender).Location.X}) Y({e.Y + ((Button)sender).Location.Y})";
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button is MouseButtons.Middle || (e.Button is MouseButtons.Left && e.Button is MouseButtons.Right))
            {
                this.button1.BackColor = Color.Blue;
                this.button2.BackColor = Color.Red;
            }
            else
            {
                if (e.Button is MouseButtons.Left)
                {
                    this.button1.BackColor = Color.Blue;
                }

                if (e.Button is MouseButtons.Right)
                {
                    this.button2.BackColor = Color.Red;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button is MouseButtons.Left)
            {
                button1.ResetBackColor();
            }
            else if (e.Button is MouseButtons.Right)
            {
                button2.ResetBackColor();
            }
            else
            {
                button1.ResetBackColor();
                button2.ResetBackColor();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
#if EV
            this.Text = e.KeyCode.ToString();
            if (e.KeyCode == Keys.Escape)
            {
                this.Text = "Mouse Tester";
            }
        }
#endif

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
#if !EV
            this.Text = e.KeyChar.ToString();
#endif
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que quiere cerrar la aplicación?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}