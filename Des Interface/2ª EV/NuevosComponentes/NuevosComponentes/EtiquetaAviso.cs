using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NuevosComponentes
{
    public partial class EtiquetaAviso : Control
    {
        private int offsetX;
        private int grosor;

        public enum eMarca
        {
            Nada,
            Cruz,
            Circulo,
            Imagen
        }

        private eMarca marca = eMarca.Nada;
        [Category("Apparence")]
        [Description("Indica la marca que aparece junto al texto")]
        public eMarca Marca
        {
            set
            {
                marca = value;
                this.Refresh();
            }

            get
            {
                return marca;
            }
        }
        public EtiquetaAviso()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            grosor = 0; //Grosor de las líneas de dibujo
            offsetX = 0; //Desplazamiento a la derecha del texto
            int offsetY = 0; //Desplazamiento hacia abajo del texto
                             // Altura de fuente, usada como referencia en varias partes
            int h = this.Font.Height;
            //Esta propiedad provoca mejoras en la apariencia o en la eficiencia 
            // a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            LinearGradientBrush l = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, this.Height), colorUno, colorDos);
            if (Gradiente)
            {
                g.FillRectangle(l, new Rectangle(0, 0, this.Width, this.Height));
            }
            switch (Marca)
            {
                case eMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,
                    h, h);
                    offsetX = h + grosor;
                    offsetY = grosor;
                    break;
                case eMarca.Cruz:
                    grosor = 3;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, h, h);
                    g.DrawLine(lapiz, h, grosor, grosor, h);
                    offsetX = h + grosor;
                    offsetY = grosor / 2;
                    //Es recomendable liberar recursos de dibujo pues se 
                    //pueden realizar muchos y cogen memoria
                    lapiz.Dispose();
                    break;
                case eMarca.Imagen:
                    if (imagenMarca != null)
                    {
                        g.DrawImage(imagenMarca, offsetX, offsetY + 5, h, h);
                        offsetX = h + grosor;
                        offsetY = grosor;
                    }
                    break;
            }
            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);

            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
            b.Dispose();
        }

        private void labelTextBox1_TxtChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        private bool gradiente;

        [Category("Apparence")]
        [Description("Indica si posee o no gradiente el fondo")]
        public bool Gradiente
        {
            set
            {
                gradiente = value;
                this.Refresh();
            }

            get
            {
                return gradiente;
            }
        }

        private Color colorUno;

        [Category("Apparence")]
        [Description("Indica el primer color del gradiente")]
        public Color ColorUno
        {
            set
            {
                colorUno = value;
                this.Refresh();
            }

            get
            {
                return colorUno;
            }
        }

        private Color colorDos;

        [Category("Apparence")]
        [Description("Indica el segundo color del gradiente")]
        public Color ColorDos
        {
            set
            {
                colorDos = value;
                this.Refresh();
            }

            get
            {
                return colorDos;
            }
        }

        private Image imagenMarca;

        [Category("Apparence")]
        [Description("Indica la imagen que aparece de fondo")]
        public Image ImagenMarca
        {
            set
            {
                imagenMarca = value;
                this.Refresh();
            }

            get
            {
                return imagenMarca;
            }
        }

        [Category("Click en la marca")]
        [Description("Se lanza cuando se hace click sobre la marca")]
        public event System.EventHandler ClickEnMarca;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (ClickEnMarca != null && Marca != eMarca.Nada)
            {
                if (e.Location.X < offsetX + grosor)
                {
                    ClickEnMarca(this, e);
                }
            }
        }
    }
}
