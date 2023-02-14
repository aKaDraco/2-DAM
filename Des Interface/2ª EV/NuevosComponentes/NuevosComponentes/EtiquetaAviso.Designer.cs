namespace NuevosComponentes
{
    partial class EtiquetaAviso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTextBox1 = new NuevosComponentes.LabelTextBox();
            this.SuspendLayout();
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.Location = new System.Drawing.Point(0, 0);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Posicion = NuevosComponentes.LabelTextBox.ePosicion.IZQUIERDA;
            this.labelTextBox1.PswChr = '\0';
            this.labelTextBox1.Separacion = 0;
            this.labelTextBox1.Size = new System.Drawing.Size(244, 20);
            this.labelTextBox1.TabIndex = 0;
            this.labelTextBox1.TextLbl = "CONCHATUMADREEEEE!!";
            this.labelTextBox1.TextTxt = "";
            this.labelTextBox1.TxtChanged += new System.EventHandler(this.labelTextBox1_TxtChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private LabelTextBox labelTextBox1;
    }
}
