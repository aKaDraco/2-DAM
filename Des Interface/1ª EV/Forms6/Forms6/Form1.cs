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
                btn.BackColor = Color.White;
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
                ((Button)sender).BackColor = Color.White;
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            //sender.BackColor = Color.White;
           
        }
    }
}



