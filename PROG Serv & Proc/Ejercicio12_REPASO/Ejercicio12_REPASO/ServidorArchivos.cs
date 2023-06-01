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
            try
            {
                using (StreamWriter sw = new StreamWriter(archivoPuerto, true))
                {
                    sw.WriteLine(numero);
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
            bool good = true;
            int port = leePuerto();
            Socket sServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ieServer = new IPEndPoint(IPAddress.Any, port);

            try
            {
                sServer.Bind(ieServer);
            }
            catch (SocketException)
            {
                good = false;
                Console.WriteLine("PUERTO EN USO");
                Environment.Exit(0);
            }

            if (good)
            {
                Console.WriteLine($"SERVER WAITING AT PORT");

                sServer.Listen(3);

                while (good)
                {
                    Socket sCliente = sServer.Accept();
                    Thread t = new Thread(hiloCliente);
                    t.Start(sCliente);
                }
            }
        }

        public void hiloCliente(object socket)
        {

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
