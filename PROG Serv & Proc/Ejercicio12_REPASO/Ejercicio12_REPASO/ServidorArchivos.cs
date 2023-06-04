using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio12_REPASO
{
    internal class ServidorArchivos
    {
        static string archivoPuerto = Environment.GetEnvironmentVariable("EXAMEN") + "\\puerto.txt";
        Socket sServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        bool good = true;
        public string leeArchivo(string nombreArchivo, int nLineas)
        {
            int contLineas = 0, lineasTotales;
            string textoArchivo = "";
            try
            {
                using (StreamReader sr = new StreamReader(Environment.GetEnvironmentVariable("EXAMEN") + "\\" + nombreArchivo))
                {
                    lineasTotales = contadorLineas(sr);
                    if (lineasTotales < nLineas)
                    {
                        while (sr.ReadLine() != null)
                        {
                            textoArchivo += sr.ReadLine() + " ";
                        }
                    }
                    else
                    {
                        while (contLineas < nLineas)
                        {
                            textoArchivo += sr.ReadLine() + " ";
                            contLineas++;
                        }
                    }
                }
                return textoArchivo;
            }
            catch (IOException)
            {
                return "<ERROR_IO>";
            }
        }

        public int leePuerto()
        {
            if (UInt16.TryParse(leeArchivo("puerto.txt", 1), out UInt16 puerto))
            {
                return puerto;
            }
            else
            {
                return 31416;
            }
        }

        public void guardaPuerto(int numero)
        {
            string sNum = numero.ToString();
            try
            {
                if (UInt16.TryParse(sNum, out UInt16 num))
                {
                    using (StreamWriter sw = new StreamWriter(archivoPuerto, true))
                    {
                        sw.WriteLine(num);
                    }
                }
                else
                {
                    Console.WriteLine("INVALID PORT");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("<ERROR_IO>");
            }
        }

        public string listaArchivos()
        {
            string lista = "";

            Directory.SetCurrentDirectory(Environment.GetEnvironmentVariable("EXAMEN"));
            DirectoryInfo dI = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = dI.GetFiles("*.txt");

            foreach (FileInfo file in files)
            {
                lista += file.Name + "\r";
            }
            return lista;
        }

        public void iniciaServidor()
        {
            int port = leePuerto();
            IPEndPoint ieServer = new IPEndPoint(IPAddress.Any, port);

            try
            {
                sServer.Bind(ieServer);
            }
            catch (SocketException)
            {
                good = false;
                Console.WriteLine($"PORT {port} ALREADY USED");
                Environment.Exit(0);
            }

            if (good)
            {
                Console.WriteLine($"SERVER WAITING AT PORT {ieServer.Port}");

                sServer.Listen(3);

                while (good)
                {
                    try
                    {
                        Socket sCliente = sServer.Accept();
                        Thread t = new Thread(hiloCliente);
                        t.IsBackground = true;
                        t.Start(sCliente);
                    }
                    catch (SocketException)
                    {
                    }
                }
            }
        }

        public void hiloCliente(object socket)
        {
            Socket cliente = (Socket)socket;
            IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;

            Console.WriteLine($"CLIENT CONNECTED ON PORT {ieCliente.Port} AND IP {ieCliente.Address}");

            using (NetworkStream ns = new NetworkStream(cliente))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string mensaje = "";
                sw.AutoFlush = true;
                sw.WriteLine("CONNECTED");

                while (mensaje != null)
                {
                    try
                    {
                        mensaje = sr.ReadLine();

                        if (mensaje != null)
                        {
                            mensaje = mensaje.ToLower();

                            if (mensaje == "port ")
                            {
                                int por = Int32.Parse(mensaje.Substring(5));
                                guardaPuerto(por);
                            }
                            else if (mensaje == "get ")
                            {
                                string[] men = mensaje.Substring(4).Split(',');
                                if (Int32.TryParse(men[1], out Int32 nlineas))
                                {
                                    leeArchivo(men[0], nlineas);
                                }
                                else
                                {
                                    sw.WriteLine("INVALID NUMBER OF LINES");
                                }
                            }
                            else
                            {
                                switch (mensaje)
                                {
                                    case "list":
                                        sw.WriteLine(listaArchivos());
                                        break;
                                    case "close":
                                        cliente.Close();
                                        break;
                                    case "halt":
                                        good = false;
                                        sServer.Close();
                                        break;
                                    default:
                                        sw.WriteLine("INVALID COMMAND");
                                        break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        mensaje = null;
                    }
                }
                cliente.Close();
                Console.WriteLine("USER DISCONECTED");
            }
        }

        public int contadorLineas(StreamReader sr)
        {
            int cont = 0;
            while (sr.ReadLine() != null)
            {
                cont++;
            }
            return cont;
        }
    }
}
