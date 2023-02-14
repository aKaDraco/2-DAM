namespace NuevosComponentes
{
    partial class ReproductorMultimedia
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
            this.play_pausa = new System.Windows.Forms.Button();
            this.etiqueta_tiempo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // play_pausa
            // 
            this.play_pausa.Location = new System.Drawing.Point(90, 269);
            this.play_pausa.Name = "play_pausa";
            this.play_pausa.Size = new System.Drawing.Size(75, 23);
            this.play_pausa.TabIndex = 0;
            this.play_pausa.Text = "Play";
            this.play_pausa.UseVisualStyleBackColor = true;
            this.play_pausa.Click += new System.EventHandler(this.play_pausa_Click);
            // 
            // etiqueta_tiempo
            // 
            this.etiqueta_tiempo.AutoSize = true;
            this.etiqueta_tiempo.Location = new System.Drawing.Point(213, 288);
            this.etiqueta_tiempo.Name = "etiqueta_tiempo";
            this.etiqueta_tiempo.Size = new System.Drawing.Size(34, 13);
            this.etiqueta_tiempo.TabIndex = 1;
            this.etiqueta_tiempo.Text = "00:00";
            // 
            // ReproductorMultimedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.etiqueta_tiempo);
            this.Controls.Add(this.play_pausa);
            this.Name = "ReproductorMultimedia";
            this.Size = new System.Drawing.Size(250, 310);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button play_pausa;
        private System.Windows.Forms.Label etiqueta_tiempo;
    }
}
