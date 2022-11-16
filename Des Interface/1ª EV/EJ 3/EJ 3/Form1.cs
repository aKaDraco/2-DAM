#define DEPU
namespace EJ_3
{
    public partial class Form1 : Form
    {
        int cred = 50;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random num = new Random();
            if (cred >= 2)
            {
                cred -= 2;
                button1.Enabled = true;
                label2.Text = "Crédito: " + cred + "€";
                textBox1.Text = num.Next(1, 7).ToString();
                textBox2.Text = num.Next(1, 7).ToString();
                textBox3.Text = num.Next(1, 7).ToString();
                if (textBox1.Text == textBox2.Text || textBox1.Text == textBox3.Text || textBox2.Text == textBox3.Text)
                {
#if DEPU
                    label1.ForeColor = Color.Red;
                    label1.Text = "PERDIDAS";
                    cred -= 5;
                    label2.Text = "Crédito: " + cred + "€";
#else
                    label1.ForeColor = Color.Red;
                    label1.Text = "PREMIO";
                    cred += 5;
#endif
                }
                else if (textBox1.Text == textBox2.Text && textBox1.Text == textBox3.Text && textBox2.Text == textBox3.Text)
                {
                    label1.ForeColor = Color.Lime;
                    label1.Text = "JACKPOT";
                    cred += 20;
                    label2.Text = "Crédito: " + cred + "€";

                }
            }
            else
            {
                label1.Text = "";
                button1.Enabled = false;
                label2.Text = "Crédito: " + cred + "€";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cred += 10;
            button1.Enabled = true;
            label2.Text = "Crédito: " + cred + "€";
        }
    }

}