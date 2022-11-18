using Microsoft.VisualBasic.ApplicationServices;

namespace Forms3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = String.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
                openFileDialog.Filter = "Todos los archivos (*.*)|*.*|Archivos jpg(*.jpg)|*.jpg|Archivos png (*.png)|*.png";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    Form2 f2 = new Form2();
                    try
                    {
                        f2.pictureBox1.Image = Image.FromFile(filePath);
                        String tituloF2 = openFileDialog.FileName;
                        if (checkBox1.Checked)
                        {
                            f2.ShowDialog();
                            checkBox1.ForeColor = Color.Red;
                        }
                        else
                        {
                            f2.Show();
                            checkBox1.ForeColor = Color.Black;
                        }
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("EROR EN EL ARCHIVO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("EROR EN EL ARCHIVO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.ForeColor = Color.Red;
            }
            else
            {
                checkBox1.ForeColor = Color.Black;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere salir", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}