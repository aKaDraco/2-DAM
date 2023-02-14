using System.ComponentModel.Design;
using System.Net;
using System.Net.Sockets;

namespace EjemploGuiadoNetworking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);

            //Creacion del Socket
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Enlace de socket al puerto (y en cualquier interfaz de red)Salta excepción si el puerto está ocupado
            s.Bind(ie);

            //Esperando una conexión y estableciendo cola de clientes pendientes
            s.Listen(10);

            //Esperamos y aceptamos la conexion del cliente (socket bloqueante)
            Socket sCliente = s.Accept();

            //Obtenemos la info del cliente, el casting es necesario ya que RemoteEndPoint es del tipo EndPoint mas genérico
            IPEndPoint ieCliente = (IPEndPoint)sCliente.RemoteEndPoint;

            //Mostramos la dirección del cliente junto al puerto al que esta conectado
            Console.WriteLine("Cliente connected: {0} at port {1}", ieCliente.Address, ieCliente.Port);

            //Primero se crea el NetworkStream con un Socket, luego este se le pasa al reader/writer
            NetworkStream ns = new NetworkStream(sCliente);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            //Creamos el mensaje dee bienvenida
            string welcome = "Welcome to the Dark Net";

            //Escribimos el mensaje mediante el writer
            sw.WriteLine(welcome);

            //Forzamos el envio de datos
            sw.Flush();

            //Se puede usar el using y nos ahorramos los close
            ns.Close();
            sr.Close();
            sw.Close();
            sCliente.Close();
            s.Close();
        }

        public void codigoLimpio()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(10);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                Socket sClient = s.Accept();
                IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
                Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address,
               ieClient.Port);
                using (NetworkStream ns = new NetworkStream(sClient))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    string welcome = "Welcome to The Echo-Logic, Odd, Desiderable," +
                    "Incredible, and Javaless Echo Server(T.E.L.O.D.I.J.E. Server)";
                    sw.WriteLine(welcome);
                    sw.Flush();
                    string msg = "";
                    while (msg != null)
                    {
                        try
                        {
                            msg = sr.ReadLine();
                            if (msg != null)
                            {
                                Console.WriteLine(msg);
                                sw.WriteLine(msg);
                                sw.Flush();
                            }
                        }
                        catch (IOException e)
                        {
                            msg = null;
                        }
                    }
                    Console.WriteLine("Client disconnected.\nConnection closed");
                }
                sClient.Close(); // Este no se abre con using, pues lo devuelve el accept.
            }
        }
    }
}