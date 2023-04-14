using System.Diagnostics;

namespace Ejercicio_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRP_Click(object sender, EventArgs e)
        {
            txtINFO.AppendText($"Hola{5,6}Hola");
        }

        private void btnVP_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
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
            if (textBox2.Text != String.Empty)
            {

            }
        }
    }
}