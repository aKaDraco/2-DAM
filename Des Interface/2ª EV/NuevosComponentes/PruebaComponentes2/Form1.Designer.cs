namespace PruebaComponentes2
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPos = new System.Windows.Forms.Button();
            this.sepMas = new System.Windows.Forms.Button();
            this.etiquetaAviso1 = new NuevosComponentes.EtiquetaAviso();
            this.labelTextBox1 = new NuevosComponentes.LabelTextBox();
            this.SuspendLayout();
            // 
            // btnPos
            // 
            this.btnPos.AutoSize = true;
            this.btnPos.Location = new System.Drawing.Point(12, 43);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(87, 23);
            this.btnPos.TabIndex = 1;
            this.btnPos.Text = "Camb Posicion";
            this.btnPos.UseVisualStyleBackColor = true;
            this.btnPos.Click += new System.EventHandler(this.btnPos_Click);
            // 
            // sepMas
            // 
            this.sepMas.AutoSize = true;
            this.sepMas.Location = new System.Drawing.Point(105, 43);
            this.sepMas.Name = "sepMas";
            this.sepMas.Size = new System.Drawing.Size(80, 23);
            this.sepMas.TabIndex = 2;
            this.sepMas.Text = "Separacion +";
            this.sepMas.UseVisualStyleBackColor = true;
            this.sepMas.Click += new System.EventHandler(this.sepMas_Click);
            // 
            // etiquetaAviso1
            // 
            this.etiquetaAviso1.ColorDos = System.Drawing.Color.Red;
            this.etiquetaAviso1.ColorUno = System.Drawing.SystemColors.Control;
            this.etiquetaAviso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaAviso1.Gradiente = true;
            this.etiquetaAviso1.ImagenMarca = ((System.Drawing.Image)(resources.GetObject("etiquetaAviso1.ImagenMarca")));
            this.etiquetaAviso1.Location = new System.Drawing.Point(12, 83);
            this.etiquetaAviso1.Marca = NuevosComponentes.EtiquetaAviso.eMarca.Circulo;
            this.etiquetaAviso1.Name = "etiquetaAviso1";
            this.etiquetaAviso1.Size = new System.Drawing.Size(567, 120);
            this.etiquetaAviso1.TabIndex = 3;
            this.etiquetaAviso1.Text = "etiquetaAviso1";
            this.etiquetaAviso1.ClickEnMarca += new System.EventHandler(this.etiquetaAviso1_ClickEnMarca);
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.AutoSize = true;
            this.labelTextBox1.Location = new System.Drawing.Point(12, 12);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Posicion = NuevosComponentes.LabelTextBox.ePosicion.IZQUIERDA;
            this.labelTextBox1.PswChr = '8';
            this.labelTextBox1.Separacion = 30;
            this.labelTextBox1.Size = new System.Drawing.Size(277, 23);
            this.labelTextBox1.TabIndex = 0;
            this.labelTextBox1.TextLbl = "CONCHATUMADREEEEE!!";
            this.labelTextBox1.TextTxt = "";
            this.labelTextBox1.PosicionChanged += new System.EventHandler(this.labelTextBox1_PosicionChanged);
            this.labelTextBox1.SeparacionChanged += new System.EventHandler(this.labelTextBox1_SeparacionChanged);
            this.labelTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.labelTextBox1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.etiquetaAviso1);
            this.Controls.Add(this.sepMas);
            this.Controls.Add(this.btnPos);
            this.Controls.Add(this.labelTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NuevosComponentes.LabelTextBox labelTextBox1;
        private System.Windows.Forms.Button btnPos;
        private System.Windows.Forms.Button sepMas;
        private NuevosComponentes.EtiquetaAviso etiquetaAviso1;
    }
}

