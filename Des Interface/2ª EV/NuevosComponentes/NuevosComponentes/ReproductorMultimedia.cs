using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes
{
    public partial class ReproductorMultimedia : UserControl
    {
        private bool play = true;
        private int minutos;
        private int segundos;
        public ReproductorMultimedia()
        {
            InitializeComponent();
        }

        [Category("Click en el boton")]
        [Description("Se lanza cuando se hace click sobre en el boton play/pausa")]
        public event System.EventHandler PlayClick;

        protected virtual void OnPlayClick(EventArgs e)
        {
            if (PlayClick != null)
            {
                PlayClick(this, e);
            }
        }

        private void play_pausa_Click(object sender, EventArgs e)
        {
            play = !play;

            switch (play)
            {
                case true:
                    play_pausa.Text = "Play";
                    break;
                case false:
                    play_pausa.Text = "Pausa";
                    break;
            }
        }

        [Category("Control del tiempo")]
        [Description("Controlas los valores de los minutos y segundos de la etiqueta")]
        public event System.EventHandler DesbordaTiempo;

        protected virtual void OnDesbordaTiempo(EventArgs e)
        {
            if (DesbordaTiempo != null && segundos > 59)
            {
                DesbordaTiempo(this, e);
                //if (segundos >= 0 || minutos >= 0)
                //{
                //    if (segundos > 59)
                //    {
                //        segundos = segundos % 60;
                //    }

                //    if (minutos > 59)
                //    {
                //        minutos = 0;
                //    }
                //}
                //else
                //{
                //    throw new ArgumentException();
                //}
            }
        }
    }
}
