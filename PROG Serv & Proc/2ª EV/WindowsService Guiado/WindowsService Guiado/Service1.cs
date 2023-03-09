using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService_Guiado
{
    public partial class SimpleService : ServiceBase
    {
        Server s = new Server();
        public SimpleService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            writeEvent("Servicio iniciado");
            Thread hilo = new Thread(s.run);
            hilo.Start();
        }

        protected override void OnStop()
        {
            writeEvent("Deteniendo servicio");
            s.stopServer();
        }

        //protected override void OnPause()
        //{
        //    writeEvent("Servicio en Pausa");
        //}
        //protected override void OnContinue()
        //{
        //    writeEvent("Continuando servicio");
        //}

        public void writeEvent(string mensaje)
        {
            string nombre = "SimpleService";
            string logDestino = "Application";
            if (!EventLog.SourceExists(nombre))
            {
                EventLog.CreateEventSource(nombre, logDestino);
            }
            EventLog.WriteEntry(nombre, mensaje);
        }
    }
}
