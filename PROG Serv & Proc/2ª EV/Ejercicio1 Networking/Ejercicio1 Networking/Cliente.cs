using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Ejercicio1_Networking
{
    public partial class Cliente : Form
    {
        Socket socket;
        string mensaje = "";
        string ip = "127.0.0.1";
        int port = 31416;

        public Cliente()
        {
            InitializeComponent();
        }

        public void answerProcess(string comand)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ip), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(ie);

                respuesta(comand);

                socket.Close();
            }
            catch (SocketException)
            {
                labelResultado.Text = "CONECTION ERROR";
            }
        }

        public void respuesta(string comand)
        {
            using (NetworkStream ns = new NetworkStream(socket))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.AutoFlush = true;
                sw.WriteLine(comand);

                try
                {
                    labelResultado.Text = "Resultado: " + sr.ReadLine();
                }
                catch (IOException)
                {
                    labelResultado.Text = "COMMAND ERROR";
                }
            }
        }

        private void btnsConect(object sender, EventArgs e)
        {
            string auxMensaje = (sender as Button).Text.ToLower();
            if (auxMensaje.Equals("close"))
            {
                mensaje = $"{auxMensaje} {boxPass.Text}";
            }
            else
            {
                mensaje = auxMensaje;
            }
            answerProcess(mensaje);
        }

        private void changeIP_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(ip, port);
            f2.ShowDialog();

            if (f2.DialogResult == DialogResult.OK)
            {
                ip = f2.textBoxIP.Text.ToString();
                port = Int32.Parse(f2.textBoxPort.Text);
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