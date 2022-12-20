namespace Archivos1
{
    public partial class Form1 : Form
    {
        String varEntorno;
        DirectoryInfo directo;
        DirectoryInfo directoDad;
        public Form1()
        {
            InitializeComponent();
        }

        private void cambio_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.StartsWith('%') && ! textBox1.Text.EndsWith('%'))
            {
                if (Directory.Exists(textBox1.Text))
                {
                    listBox1.Items.Clear();
                    Directory.SetCurrentDirectory(textBox1.Text);
                    directo = new DirectoryInfo(Directory.GetCurrentDirectory());
                    listBox1.Items.Add("..");
                    foreach (DirectoryInfo item in directo.GetDirectories())
                    {
                        listBox1.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR AL ACCEDER AL DIRECTORIO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listBox1.Items.Clear();
                    textBox1.ResetText();
                }
            }
            else
            {
                varEntorno = textBox1.Text.Trim('%').Trim();
                listBox1.Items.Clear();
                Directory.SetCurrentDirectory(Environment.GetEnvironmentVariable(varEntorno));
                directo = new DirectoryInfo(Environment.GetEnvironmentVariable(varEntorno));
                listBox1.Items.Add("..");
                foreach (DirectoryInfo item in directo.GetDirectories())
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex.Equals(0))
            {
                listBox1.Items.Clear();
                directo = new DirectoryInfo(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
                Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
                listBox1.Items.Add("..");
                foreach (DirectoryInfo item in directo.GetDirectories())
                {
                    listBox1.Items.Add(item);
                }
            }
            else
            {
                listBox1.Items.Clear();
                directo = new DirectoryInfo(listBox1.SelectedItem.ToString());
                Directory.SetCurrentDirectory(listBox1.SelectedItem.ToString());
                listBox1.Items.Add("..");
                foreach (DirectoryInfo item in directo.GetDirectories())
                {
                    listBox1.Items.Add(item);
                }
            }
        }
    }
}