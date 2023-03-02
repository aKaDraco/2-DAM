using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenEv2PruebaHugoRaña
{
    public partial class ValidateTextBox : UserControl
    {
        private Color recColor = Color.Red;

        public ValidateTextBox()
        {
            InitializeComponent();
            this.Height = textBox1.Height + 20;
            this.Width = textBox1.Width + 20;
        }

        private String texto;

        [Category("Apparence")]
        [Description("Texto asociado al txtBox")]
        public String Texto
        {
            set
            {
                textBox1.Text = value;
            }
            get
            {
                return textBox1.Text;
            }
        }

        private Boolean multilinea;

        [Category("Apparence")]
        [Description("Propiedad multilinea del txtBox")]
        public Boolean Multilinea
        {
            set
            {
                textBox1.Multiline = value;
            }
            get
            {
                return textBox1.Multiline;
            }
        }

        public enum eTipo
        {
            Numérico, Textual
        }

        private eTipo tipo;

        [Category("Apparence")]
        [Description("Indica el tipo de input valido en el txtBox")]
        public eTipo Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rec = new Rectangle();
            rec.X = 5;
            rec.Y = 5;
            rec.Width = this.Width - 10;
            rec.Height = this.Height - 10;
            e.Graphics.DrawRectangle(new Pen(recColor), rec);
        }

        private void comprobar()
        {
            long txtNumOut;
            if (tipo == eTipo.Numérico)
            {
                if (Int64.TryParse(textBox1.Text, out txtNumOut) && validateString())
                {
                    recColor = Color.Lime;
                    this.Refresh();
                }
                else
                {
                    recColor = Color.Red;
                    this.Refresh();
                }
            }
            else
            {
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (Char.IsLetter(textBox1.Text[i]) || textBox1.Text[i] == ' ')
                    {
                        recColor = Color.Lime;
                        this.Refresh();
                    }
                    else
                    {
                        recColor = Color.Red;
                        this.Refresh();
                    }
                }
            }
        }

        private Boolean validateString()
        {
            Boolean valid = true;
            String txtBoxTxt = textBox1.Text.Trim();
            for (int i = 0; i < txtBoxTxt.Length; i++)
            {
                if (txtBoxTxt[i] == ' ')
                {
                    valid = false;
                }
            }
            return valid;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comprobar();
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando se introducenn caracteres en el TextBox")]
        public event System.EventHandler CambiaTexto;

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            CambiaTexto(this, e);
        }
    }
}
