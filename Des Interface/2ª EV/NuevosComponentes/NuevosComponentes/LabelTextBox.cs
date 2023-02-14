using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NuevosComponentes
{

    [
    DefaultProperty("TextLbl"),
    DefaultEvent("Load")
    ]
    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
            TextLbl = "CONCHATUMADREEEEE!!";
            TextTxt = String.Empty;
            recolocar();
        }

        public enum ePosicion
        {
            DERECHA, IZQUIERDA
        }

        private ePosicion posicion = ePosicion.IZQUIERDA;

        [Category("Appearance")]
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA del Textbox")]
        public ePosicion Posicion
        {
            set
            {
                if (Enum.IsDefined(typeof(ePosicion), value))
                {
                    posicion = value;
                    recolocar();
                    OnPosicionChanged(EventArgs.Empty);
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return posicion;
            }
        }

        private void recolocar()
        {
            switch (posicion)
            {
                case ePosicion.IZQUIERDA:
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(0, 0);
                    // Establecemos posición componente txt
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    //Establecemos ancho del Textbox 
                    //(la label tiene ancho por autosize)
                    this.Width = lbl.Width + Separacion + txt.Width;
                    //Establecemos altura del componente
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case ePosicion.DERECHA:
                    //Establecemos posición del componente txt
                    txt.Location = new Point(0, 0);
                    //Establecemos ancho del LabelTextbox 
                    this.Width = lbl.Width + Separacion + txt.Width;
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    //Establecemos altura del componente (Puede sacarse del switch)
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
        }
        // Esta función has de enlazarla con el evento SizeChanged.
        // Sería necesario también tener en cuenta otros eventos como FontChanged
        // que aquí nos saltamos.
        private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            base.OnSizeChanged(e);
            recolocar();
        }


        private int separacion = 0;

        [Category("Design")]
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    recolocar();
                    OnSeparacionChanged(EventArgs.Empty);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }

        [Category("Appearance")]
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                recolocar();
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Appearance")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void labelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Text = "Letra: " + e.KeyChar;
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]
        public event System.EventHandler PosicionChanged;

        protected virtual void OnPosicionChanged(EventArgs e)
        {
            if (PosicionChanged != null)
            {
                PosicionChanged(this, e);
            }
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Separación cambia")]
        public event System.EventHandler SeparacionChanged;

        protected virtual void OnSeparacionChanged(EventArgs e)
        {
            if (SeparacionChanged != null)
            {
                SeparacionChanged(this, e);
            }
        }

        [Category("La propiedad cambio")]
        [Description("Se lanza cuando la propiedad Text de txt cambia")]
        public event System.EventHandler TxtChanged;

        protected virtual void OnTxtChanged(EventArgs e)
        {
            if (TxtChanged != null)
            {
                TxtChanged(this, e);
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            this.OnTxtChanged(EventArgs.Empty);
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        //private char pswChr;

        [Category("Design")]
        [Description("Caracter para el modo Password del txt")]
        public char PswChr
        {
            set
            {
                txt.PasswordChar = value;
            }
            get
            {
                return txt.PasswordChar;
            }
        }

    }
}
