using System;
using System.Net;
using System.Net.Sockets;


namespace EjemploNetworking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Obtenemos el nombre del equipo local y lo mostramos
            String localHost = Dns.GetHostName();
            Console.WriteLine("Localhost name: {0} \n", localHost);
            //Mostramos información del equipo local y de uno remoto
            ShowNetInformation(localHost);
            ShowNetInformation("www.google.es");
            // ShowNetInformation(new IPAddress(new byte[] { 82, 98, 160, 124 }));
            ShowNetInformation(IPAddress.Parse("82.98.160.124"));
            Console.ReadKey();
        }


        static void ShowNetInformation(string name)
        {
            IPHostEntry hostInfo;
            //Tratamos de resolver el DNS
            hostInfo = Dns.GetHostEntry(name);
            // Mostramos el nombre del equipo
            Console.WriteLine("Name: {0}", hostInfo.HostName);

            //Lista de IPs del equipo
            Console.WriteLine("IP list: ");
            foreach (IPAddress ip in hostInfo.AddressList)
            {
                //Para ver sólo las direcciones IPv4 se compara con AddressFamily.InterNetwork
                //Para IPv6 se usaría AddressFamily.InterNetworkV6
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("\t{0,16}", ip);
                }
            }
            Console.WriteLine("\n");
        }
        // Sobrecarga con parámetro IPAddress
        static void ShowNetInformation(IPAddress ipAddress)
        {
            //Llama a la otra sobrecarga obteniendo previamente el nombre del host
            IPHostEntry hostInfo = Dns.GetHostEntry(ipAddress);
            ShowNetInformation(hostInfo.HostName);
        }
    }
}