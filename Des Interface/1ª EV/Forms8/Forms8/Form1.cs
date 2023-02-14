namespace Forms8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Selecciona la imagen para abrir";
            fbd.RootFolder = Environment.SpecialFolder.UserProfile;
            if(fbd.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}