using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenEv2PruebaHugoRaña
{
    public partial class Principal : Form
    {
        private Collection<sFriki> frikis = new Collection<sFriki>();
        public Principal()
        {
            InitializeComponent();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    frikis.Remove(frikis[listBox1.SelectedIndex]);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            datos.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INFORMACION", "PROGRAMA: GESTOR DE FRIKIS\nAUTOR: HUGO RAÑA TEIXEIRA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
