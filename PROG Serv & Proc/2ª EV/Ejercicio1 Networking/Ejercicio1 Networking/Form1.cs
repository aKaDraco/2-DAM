using System.Net;
using System.Net.Sockets;

namespace Ejercicio1_Networking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void creaServidor()
        {

        }

        public void conexion(string mensaje, string pass)
        {
            string ip = "127.0.0.1";
            int port = 54768;

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            using (NetworkStream ns = new NetworkStream(socket))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                try
                {
                    sw.WriteLine(mensaje);
                    sw.Flush();

                    try
                    {
                        resultado.Text = "Resultado: " + sr.ReadLine();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("ERROR");
                }
            }
        }

        private void btnsConect(object sender, EventArgs e)
        {
            string mensaje;
            string pass = "";

            mensaje = (sender as Button).Text.ToString().ToLower();
            if (mensaje.Equals("close")) pass = boxPass.Text.ToLower();
            conexion(mensaje, pass);
        }
    }
}