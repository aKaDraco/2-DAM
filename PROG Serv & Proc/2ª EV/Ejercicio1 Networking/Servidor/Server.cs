using System.Net;
using System.Net.Sockets;

namespace Servidor
{
    internal class Server
    {
        static bool good = true;
        static Socket sServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            int port = 31416;
            string portPath = Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\config.txt";
            if (File.Exists(portPath))
            {
                using (StreamReader sr = new StreamReader(portPath))
                {
                    string h = sr.ReadLine();
                    port = Convert.ToInt32(h);
                }
            }
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);

            try
            {
                sServidor.Bind(ie);
            }
            catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
            {
                good = false;
                Console.WriteLine("BIND ERROR");
            }
            if (good)
            {
                Console.WriteLine("Server waiting at port: {0}", ie.Port);
                sServidor.Listen(1);
                while (good)
                {
                    try
                    {
                        Socket sCliente = sServidor.Accept();
                        Thread hiloCliente = new Thread(servCliente);
                        hiloCliente.Start(sCliente);
                    }
                    catch (SocketException)
                    {
                        Console.WriteLine("SERVER TURNED OFF");
                    }
                }
            }
        }

        static void servCliente(object socket)
        {
            string mensaje;
            Socket cliente = (Socket)socket;
            IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;

            Console.WriteLine("Connected with client ip {0} at port {1}", ieCliente.Address, ieCliente.Port);

            using (NetworkStream ns = new NetworkStream(cliente))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.AutoFlush = true;
                string welcome = "Welcome to the server";
                string pass = "";
                string passTxt = "";
                sw.WriteLine(welcome);
                try
                {
                    mensaje = sr.ReadLine();

                    if (mensaje != null)
                    {
                        if (mensaje.StartsWith("close "))
                        {
                            pass = mensaje.Substring(6);
                            try
                            {
                                using (StreamReader streamR = new StreamReader(Environment.GetEnvironmentVariable("programdata") + "\\password.txt"))
                                {
                                    passTxt = streamR.ReadLine();
                                }
                                if (passTxt == pass)
                                {
                                    good = false;
                                    sw.WriteLine("SERVER CLOSED");
                                    try
                                    {
                                        sServidor.Close();
                                    }
                                    catch (SocketException)
                                    {
                                        Console.WriteLine("SERVER CLOSED");
                                    }
                                }
                                else
                                {
                                    sw.WriteLine("WRONG PASSWORD");
                                }
                            }
                            catch (FileNotFoundException)
                            {
                                sw.WriteLine("FILE NOT FOUND");
                            }
                            catch (IOException)
                            {
                                sw.WriteLine("FILE ERROR");
                            }
                        }
                        else
                        {
                            switch (mensaje)
                            {
                                case "time":
                                    sw.WriteLine("Time ({0})", DateTime.Now.ToString("t"));
                                    break;
                                case "date":
                                    sw.WriteLine("Date ({0})", DateTime.Now.ToString("d"));
                                    break;
                                case "all":
                                    sw.WriteLine("Date and time ({0})", DateTime.Now.ToString("g"));
                                    break;
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("ERROR");
                }
                Console.WriteLine("USER DISCONECTED");
                cliente.Close();
            }
        }
    }
}