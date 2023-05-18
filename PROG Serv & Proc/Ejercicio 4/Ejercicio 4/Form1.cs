using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Ejercicio_4
{
    public partial class Form1 : Form
    {
        Process[] processes = Process.GetProcesses();
        Color h;
        int pid;
        public Form1()
        {
            InitializeComponent();
            h = textBox2.BackColor;
        }

        /*
         Ver procesos actualizados
        kill
        Tamaño form
        getprocessbyid
         
         */
        private void btnVP_Click(object sender, EventArgs e)
        {
            txtINFO.Text = "";
            processes = Process.GetProcesses();
            Array.ForEach(processes, p =>
            {
                if (p.ProcessName.Length > 10)
                {
                    if (p.MainWindowTitle == String.Empty)
                    {
                        txtINFO.AppendText($"PID: {p.Id,5} {"Name:",5} {p.ProcessName.Substring(0, 7)}...\r\n");
                    }
                    else if (p.MainWindowTitle.Length > 10)
                    {
                        txtINFO.AppendText($"PID: {p.Id,5} {"Name:",5} {p.ProcessName.Substring(0, 7)}... {"Window Name:",15} {p.MainWindowTitle.Substring(0, 7),5}...\r\n");
                    }
                    else
                    {
                        txtINFO.AppendText($"PID: {p.Id,5} {"Name:",5} {p.ProcessName.Substring(0, 7)}... {"Window Name:",15} {p.MainWindowTitle,5}\r\n");
                    }
                }
                else
                {
                    if (p.MainWindowTitle == String.Empty)
                    {
                        txtINFO.AppendText($"PID: {p.Id,5} {"Name:",5} {p.ProcessName}\r\n");
                    }
                    else if (p.MainWindowTitle.Length > 10)
                    {
                        txtINFO.AppendText($"PID: {p.Id,5} {"Name:",5} {p.ProcessName} {"Window Name:",19} {p.MainWindowTitle.Substring(0, 7),5}...\r\n");
                    }
                    else
                    {
                        txtINFO.AppendText($"PID: {p.Id,5} {"Name:",5} {p.ProcessName} {"Window Name:",19} {p.MainWindowTitle,5}\r\n");
                    }
                }
            });
        }

        private void buttonPI_Click(object sender, EventArgs e)
        {
            if (compPID())
            {
                Process p = Process.GetProcessById(pid);
                txtINFO.AppendText($"PID: {p.Id}\r\nName: {p.ProcessName}\r\nWindow name: {p.MainWindowTitle}\r\n");
                for (int i = 0; i < p.Threads.Count; i++)
                {
                    try
                    {
                        txtINFO.AppendText($"Subproceso {i}:\r\nID: {p.Threads[i].Id}\r\nStart time: {p.Threads[i].StartTime}\r\n");
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = h;
            textBox2.ForeColor = Color.Black;
        }


        public bool compPID()
        {
            txtINFO.Text = "";
            if (textBox2.Text != String.Empty)
            {
                if (Int32.TryParse(textBox2.Text, out pid))
                {
                    return true;
                }
                else
                {
                    textBox2.ForeColor = Color.Red;
                    return false;
                }
            }
            else
            {
                textBox2.BackColor = Color.Red;
                return false;
            }
        }
        private void buttonCP_Click(object sender, EventArgs e)
        {
            if (compPID())
            {
                try
                {
                    Process p = Process.GetProcessById(pid);
                    p.CloseMainWindow();
                }
                catch (ArgumentException)
                {
                    txtINFO.Text = "NO SE HA ENCONTRADO EL PROCESO";
                }
            }
        }

        private void buttonKP_Click(object sender, EventArgs e)
        {
            if (compPID())
            {
                try
                {
                    Process p = Process.GetProcessById(pid);
                    p.Kill();
                }
                catch (Win32Exception)
                {
                    txtINFO.Text = "NO SE PUEDE CERRAR EL PROGRAMA";
                }
                catch (ArgumentException)
                {
                    txtINFO.Text = "NO SE HA ENCONTRADO EL PROGRAMA";
                }

            }
        }

        private void buttonRP_Click(object sender, EventArgs e)
        {
            txtINFO.Text = "";

            if (textBox2.Text != String.Empty)
            {
                try
                {
                    Process.Start(textBox2.Text);
                }
                catch (Win32Exception)
                {
                    txtINFO.Text = "NINGUNA APLICACIÓN INICIADA";
                }
            }
            else
            {
                textBox2.BackColor = Color.Red;
            }
        }
        private void buttonSW_Click(object sender, EventArgs e)
        {
            txtINFO.Text = "";
            processes = Process.GetProcesses();

            if (textBox2.Text != String.Empty)
            {
                Array.ForEach(processes, p =>
                {
                    if (p.ProcessName.StartsWith(textBox2.Text))
                    {
                        txtINFO.AppendText($"Name: {p.ProcessName}\r\nPID: {p.Id}\r\n");
                    }
                    else
                    {
                        txtINFO.Text = "NINGÚN PROGRAMA EMPIEZA POR ESA CADENA";
                    }
                });
            }
            else
            {
                textBox2.BackColor = Color.Red;
            }
        }
    }
}