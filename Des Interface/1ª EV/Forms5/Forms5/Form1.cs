using System.Collections.ObjectModel;
using System.Runtime.Versioning;

namespace Forms5
{
    public partial class elementos : Form
    {
        string titulo;
        int countTitulo;

        public elementos()
        {
            InitializeComponent();
            timer1.Start();
            titulo = this.Text.ToString();
            countTitulo = titulo.Length;
            this.Text = string.Empty;
            toolTip1.SetToolTip(this.listBox1, "Lista 1");
            toolTip2.SetToolTip(this.anhadir, "Botón añadir a lista 1");
            toolTip3.SetToolTip(this.quitar, "Botón quitar de lista 1");
            toolTip4.SetToolTip(this.textBox1, "Textbox para lista 1");
            toolTip5.SetToolTip(this.traspasarDerecha, "Traspasa elemento de izquierda a derecha");
            toolTip6.SetToolTip(this.traspasarIzquierda, "Traspasa elemento de izquierda a derecha");
            toolTip7.SetToolTip(this.listBox2, listBox2.Items.Count.ToString());

        }

        private void anhadir_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                compList();
                if (compList() == true)
                {
                    listBox1.Items.Add(textBox1.Text);
                    lista_elementos.Text = "Elementos: " + listBox1.Items.Count;
                    textBox1.Text = string.Empty;
                }
            }
        }

        private bool compList()
        {
            if (listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString().Equals(textBox1.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender) == textBox1)
            {
                this.AcceptButton = anhadir;
            }
        }

        private void quitar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    lista_elementos.Text = "Elementos: " + listBox1.Items.Count;
                }
            }
        }

        private void traspasarDerecha_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                lista_indices.Text = "Indices: ";
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    lista_indices.Text += listBox1.SelectedIndices[i] + " ";
                }
            }
            else
            {
                lista_indices.Text = "Indices: 0";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (countTitulo != 0)
            {
                this.Text = titulo[countTitulo - 1].ToString() + this.Text;
                countTitulo--;
                if (countTitulo % 2 == 0)
                {
                    this.Icon = Properties.recursos.R;
                }
                else
                {
                    this.Icon = Properties.recursos.OIP;
                }
            }
            else
            {
                countTitulo = titulo.Length;
                this.Text = string.Empty;
            }
        }

        private void toolTip7_Popup(object sender, PopupEventArgs e)
        {

        }

        private void traspasar2_Click(object sender, EventArgs e)
        {

        }
    }
}
