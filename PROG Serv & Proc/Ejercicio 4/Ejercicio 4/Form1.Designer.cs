namespace Ejercicio_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtINFO = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnVP = new System.Windows.Forms.Button();
            this.buttonPI = new System.Windows.Forms.Button();
            this.buttonCP = new System.Windows.Forms.Button();
            this.buttonKP = new System.Windows.Forms.Button();
            this.buttonSW = new System.Windows.Forms.Button();
            this.buttonRP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtINFO
            // 
            this.txtINFO.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtINFO.Location = new System.Drawing.Point(12, 70);
            this.txtINFO.Multiline = true;
            this.txtINFO.Name = "txtINFO";
            this.txtINFO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtINFO.Size = new System.Drawing.Size(564, 219);
            this.txtINFO.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(564, 23);
            this.textBox2.TabIndex = 1;
            // 
            // btnVP
            // 
            this.btnVP.Location = new System.Drawing.Point(12, 41);
            this.btnVP.Name = "btnVP";
            this.btnVP.Size = new System.Drawing.Size(97, 23);
            this.btnVP.TabIndex = 2;
            this.btnVP.Text = "View Processes";
            this.btnVP.UseVisualStyleBackColor = true;
            this.btnVP.Click += new System.EventHandler(this.btnVP_Click);
            // 
            // buttonPI
            // 
            this.buttonPI.Location = new System.Drawing.Point(115, 41);
            this.buttonPI.Name = "buttonPI";
            this.buttonPI.Size = new System.Drawing.Size(83, 23);
            this.buttonPI.TabIndex = 3;
            this.buttonPI.Text = "Process Info";
            this.buttonPI.UseVisualStyleBackColor = true;
            this.buttonPI.Click += new System.EventHandler(this.buttonPI_Click);
            // 
            // buttonCP
            // 
            this.buttonCP.Location = new System.Drawing.Point(204, 41);
            this.buttonCP.Name = "buttonCP";
            this.buttonCP.Size = new System.Drawing.Size(97, 23);
            this.buttonCP.TabIndex = 4;
            this.buttonCP.Text = "Close Process";
            this.buttonCP.UseVisualStyleBackColor = true;
            // 
            // buttonKP
            // 
            this.buttonKP.Location = new System.Drawing.Point(307, 41);
            this.buttonKP.Name = "buttonKP";
            this.buttonKP.Size = new System.Drawing.Size(95, 23);
            this.buttonKP.TabIndex = 5;
            this.buttonKP.Text = "Kill Process";
            this.buttonKP.UseVisualStyleBackColor = true;
            // 
            // buttonSW
            // 
            this.buttonSW.Location = new System.Drawing.Point(497, 41);
            this.buttonSW.Name = "buttonSW";
            this.buttonSW.Size = new System.Drawing.Size(79, 23);
            this.buttonSW.TabIndex = 6;
            this.buttonSW.Text = "Start With";
            this.buttonSW.UseVisualStyleBackColor = true;
            // 
            // buttonRP
            // 
            this.buttonRP.Location = new System.Drawing.Point(408, 41);
            this.buttonRP.Name = "buttonRP";
            this.buttonRP.Size = new System.Drawing.Size(83, 23);
            this.buttonRP.TabIndex = 7;
            this.buttonRP.Text = "Run App";
            this.buttonRP.UseVisualStyleBackColor = true;
            this.buttonRP.Click += new System.EventHandler(this.buttonRP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 302);
            this.Controls.Add(this.buttonRP);
            this.Controls.Add(this.buttonSW);
            this.Controls.Add(this.buttonKP);
            this.Controls.Add(this.buttonCP);
            this.Controls.Add(this.buttonPI);
            this.Controls.Add(this.btnVP);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtINFO);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtINFO;
        private TextBox textBox2;
        private Button btnVP;
        private Button buttonPI;
        private Button buttonCP;
        private Button buttonKP;
        private Button buttonSW;
        private Button buttonRP;
    }
}