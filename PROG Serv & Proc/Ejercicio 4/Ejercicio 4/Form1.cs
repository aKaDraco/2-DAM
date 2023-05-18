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


        private void btnVP_Click(object sender, EventArgs e)
        {
            txtINFO.Text = "";
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
                Array.ForEach(processes, p =>
                {
                    if (p.Id == pid)
                    {
                        txtINFO.AppendText($"PID: {p.Id}\r\nName: {p.ProcessName}\r\nWindow name: {p.MainWindowTitle}\r\n");
                        for (int i = 0; i < p.Threads.Count; i++)
                        {
                            try
                            {
                                txtINFO.AppendText($"Subproceso {i}:\r\nID: {p.Threads[i].Id}\r\nStart time: {p.Threads[i].StartTime}\r\n");
                            }
                            catch (ThreadAbortException)
                            {
                            }
                        }
                    }
                });
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = h;
            textBox2.ForeColor = Color.Black;
        }

        /*
         * TODO
         * PREGUNTAR COMO ESPERAR A CERRAR UN PROCESO
         */
        private void buttonCP_Click(object sender, EventArgs e)
        {
            if (compPID())
            {
                Array.ForEach(processes, p =>
                {
                    if (p.Id == pid)
                    {
                        p.WaitForExit();
                    }
                });
            }
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

        private void buttonKP_Click(object sender, EventArgs e)
        {
            if (compPID())
            {
                Array.ForEach(processes, p =>
                {
                    if (p.Id == pid)
                    {
                        p.Kill();
                    }
                });
            }
        }

        private void buttonRP_Click(object sender, EventArgs e)
        {
            /*
            *TODO
            * PREGUNTAR COMO HACER ESTE BOTON
            */

        }
        private void buttonSW_Click(object sender, EventArgs e)
        {
            txtINFO.Text = "";

            if (textBox2.Text != String.Empty)
            {
                Array.ForEach(processes, p =>
                {
                    if (p.ProcessName.StartsWith(textBox2.Text))
                    {
                        txtINFO.AppendText($"Name: {p.ProcessName}\r\nPID: {p.Id}\r\n");
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