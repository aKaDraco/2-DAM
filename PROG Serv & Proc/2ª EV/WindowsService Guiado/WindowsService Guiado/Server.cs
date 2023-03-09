using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace WindowsService_Guiado
{
    internal class Server
    {
        private bool good = true;
        Socket sServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void run()
        {
            SimpleService ss = new SimpleService();
            int port = 31416;

            string portPath = Environment.GetEnvironmentVariable("%PROGRAMDATA%") + "/config.txt";
            if (File.Exists(portPath))
            {
                using (StreamReader sr = new StreamReader(portPath))
                {
                        port = Convert.ToInt32(sr.ReadLine());
                        ss.writeEvent("Puerto de escucha: " + port.ToString() + "\nNingun error en el archivo");
                }
            }
            else
            {
                ss.writeEvent("Puerto de escucha: " + port.ToString() + "\nError en el archivo");
            }
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);

            try
            {
                sServidor.Bind(ie);
            }
            catch (Exception)
            {
                good = false;
                ss.writeEvent("NO SE HA PODIDO CONECTAR AL SERVIDOR");
            }
            sServidor.Listen(1);

            Console.WriteLine("Server waiting at port: {0}", ie.Port);

            while (good)
            {
                Socket sCliente = sServidor.Accept();
                Thread hiloCliente = new Thread(servCliente);
                hiloCliente.IsBackground = true;
                hiloCliente.Start(sCliente);
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
                string welcome = "Welcome to the server";
                string pass = "";
                string passTxt = "";
                sw.WriteLine(welcome);
                sw.Flush();

                try
                {
                    mensaje = sr.ReadLine();
                    sw.Flush();

                    if (mensaje != null)
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
                            case "close":
                                using (StreamReader srPass = new StreamReader(Environment.GetEnvironmentVariable("%PROGRAMDATA%") + "\\password.txt"))
                                {
                                    try
                                    {
                                        passTxt = srPass.ReadLine();
                                    }
                                    catch (FileNotFoundException)
                                    {
                                        sw.WriteLine("ERROR AL ACCEDER AL ARCHIVO DE CONTRASEÑA");
                                    }
                                }
                                if (passTxt == pass)
                                {
                                    cliente.Close();
                                }
                                else if (pass == String.Empty)
                                {
                                    sw.WriteLine("Debe introducir una contraseña válida");
                                }
                                else
                                {
                                    sw.WriteLine("Contraseña incorrecta");
                                }
                                break;
                        }
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("ERROR");
                }
                sw.Flush();
                Console.WriteLine("USER DISCONECTED");
            }
        }

        public void stopServer()
        {
            good = false;
            sServidor.Close();
        }
    }
}
