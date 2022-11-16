namespace Forms2
{
    public partial class Form1 : Form
    {
        Color btnBack;
        Color txtCol;
        public Form1()
        {
            InitializeComponent();
            btnBack = button1.BackColor;
            txtCol = textBox1.ForeColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que quiere cerrar la aplicaión?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void textBoxes(object sender, System.EventArgs e)
        {
            int comp;
            if (!Int32.TryParse(((TextBox)sender).Text, out comp))
            {
                ((TextBox)sender).ForeColor = Color.Red;
            }
            else
            {
                ((TextBox)sender).ForeColor = txtCol;
            }

            if (comp < 0 || comp > 255)
            {
                ((TextBox)sender).ForeColor = Color.Red;
            }
            else
            {
                ((TextBox)sender).ForeColor = txtCol;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty) || textBox2.Text.Equals(string.Empty) || textBox3.Text.Equals(string.Empty))
            {
                MessageBox.Show("Introduzca valores en las cajas de texto", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int txtRed = Convert.ToInt32(textBox1.Text);
                int txtGreen = Convert.ToInt32(textBox2.Text);
                int txtBlue = Convert.ToInt32(textBox3.Text);

                this.BackColor = Color.FromArgb(txtRed, txtGreen, txtBlue);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != String.Empty)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(textBox4.Text);
                }
                catch (FileNotFoundException)  //no genericas
                {
                    MessageBox.Show("Error al mostrar la imagen", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Introduzca una ruta", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void acptButtn(object sender, EventArgs e)
        {
            if (((TextBox)sender) == textBox4)
            {
                this.AcceptButton = button3;
            }
            else
            {
                this.AcceptButton = button2;
            }
        }

        private void mousEnters(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Red;
        }

        private void mousLevs(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = btnBack;
        }
    }
}