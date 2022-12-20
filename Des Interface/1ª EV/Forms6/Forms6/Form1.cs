namespace Forms6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PinForm f2 = new PinForm();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                creaBtns();
            }
        }

        private void creaBtns()
        {
            int x = 12;
            int y = 100;

            for (int i = 1; i < 10; i++)
            {
                Button btn = new Button();
                btn.BackColor = Color.Empty;
                btn.Text = i.ToString();
                btn.Location = new Point(x, y);
                btn.Size = new Size(70, 50);
                btn.Enabled = true;
                btn.Click += new System.EventHandler(this.btnTelefono);
                btn.MouseEnter += new System.EventHandler(this.btnTelefonoIN);
                btn.MouseLeave += new System.EventHandler(this.btnTelefonoOUT);
                this.Controls.Add(btn);
                x += 89;
                if (i == 3 || i == 6 || i == 9)
                {
                    y += 80;
                    x = 12;
                }
            }
        }

        public void btnTelefono(object sender, EventArgs e)
        {
            this.textBox1.Text += ((Button)sender).Text;
            ((Button)sender).BackColor = Color.Lime;
        }

        public void btnTelefonoIN(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.Lime)
            {
                ((Button)sender).BackColor = Color.Blue;
            }
        }

        public void btnTelefonoOUT(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.Lime)
            {
                ((Button)sender).BackColor = Color.Empty;
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    item.BackColor = Color.Empty;
                }
            }

        }

        private void acerdaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INFO: LA APLICACIÓN SE TRATA DE UNA RECREACIÓN DE UN MÓVIL EN WINDOWS FORMS\n\nAUTOR: HUGO RAÑA TEIXEIRA", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grabarNúmeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                StreamWriter s;
                this.saveFileDialog1.Title = "SELECCION DE DIRECCTORIO PARA ALMACENAR";
                this.saveFileDialog1.Filter = "Archivos de Texto (*.txt)|*.txt| Todos los archivos (*.*)|*.*";
                this.saveFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable("HOMEPATH");
                this.saveFileDialog1.ValidateNames = true;
                this.saveFileDialog1.ShowDialog();

                s = new StreamWriter(this.saveFileDialog1.FileName);
                s.Write(this.textBox1.Text);
                s.Close();
            }
            else
            {
                MessageBox.Show("NO HAY NINGÚN NÚMERO PARA GUARDAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}



