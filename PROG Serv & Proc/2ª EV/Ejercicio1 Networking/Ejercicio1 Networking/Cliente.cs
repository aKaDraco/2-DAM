using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Ejercicio1_Networking
{
    public partial class Cliente : Form
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string mensaje = "";
        string ip = "127.0.0.1";
        int port = 54768;
        IPEndPoint iPEndPoint;

        public Cliente()
        {
            InitializeComponent();
        }

        public void conexion(string mensaje, string pass)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            try
            {
                socket.Connect(iPEndPoint);
            }
            catch (Exception)
            {
                Console.WriteLine("CONEXION ERROR");
            }
            respuesta();
        }

        public void respuesta()
        {
            using (NetworkStream ns = new NetworkStream(socket))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                if (mensaje != String.Empty)
                {
                    this.Text = sr.ReadLine();
                    sw.WriteLine(mensaje);
                    sw.Flush();
                }
                try
                {
                    labelResultado.Text = sr.ReadLine();
                }
                catch (IOException)
                {
                    sw.WriteLine("COMAND ERROR");
                }
            }
        }

        private void btnsConect(object sender, EventArgs e)
        {
            string pass = "";

            mensaje = (sender as Button).Text.ToString().ToLower();
            if (mensaje.Equals("close")) pass = boxPass.Text.ToLower();
            conexion(mensaje, pass);
        }

        private void changeIP_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

            if (f2.DialogResult == DialogResult.OK)
            {
                try
                {
                    ip = f2.textBoxIP.Text.ToString();
                    port = Int32.Parse(f2.textBoxPort.Text);

                    conexion("", "");

                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR", "VALUE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void changeIP_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void changeIP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}