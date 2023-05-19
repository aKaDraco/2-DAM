using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio9_REPASO
{
    internal class Server
    {
        static void Main(string[] args)
        {
            IPEndPoint ieServer = new IPEndPoint(IPAddress.Any, 31416);

            using (Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socketServer.Bind(ieServer);
                Socket socketCliente = socketServer.Accept();
                IPEndPoint ieCliente = (IPEndPoint)socketCliente.RemoteEndPoint;

                Console.WriteLine("Nueva conexión: {0}; {1}", ieCliente.Address, ieCliente.Port);
                using (NetworkStream ns = new NetworkStream(socketCliente))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    string welcome = "Bienvenido al servidor de fecha y hora";
                }
            }
        }
    }
}