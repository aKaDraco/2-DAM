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
            txtINFO = new TextBox();
            textBox2 = new TextBox();
            btnVP = new Button();
            buttonPI = new Button();
            buttonCP = new Button();
            buttonKP = new Button();
            buttonSW = new Button();
            buttonRP = new Button();
            SuspendLayout();
            // 
            // txtINFO
            // 
            txtINFO.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtINFO.Location = new Point(12, 70);
            txtINFO.Multiline = true;
            txtINFO.Name = "txtINFO";
            txtINFO.ScrollBars = ScrollBars.Vertical;
            txtINFO.Size = new Size(564, 219);
            txtINFO.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(564, 23);
            textBox2.TabIndex = 1;
            textBox2.Enter += textBox2_Enter;
            // 
            // btnVP
            // 
            btnVP.Location = new Point(12, 41);
            btnVP.Name = "btnVP";
            btnVP.Size = new Size(97, 23);
            btnVP.TabIndex = 2;
            btnVP.Text = "View Processes";
            btnVP.UseVisualStyleBackColor = true;
            btnVP.Click += btnVP_Click;
            // 
            // buttonPI
            // 
            buttonPI.Location = new Point(115, 41);
            buttonPI.Name = "buttonPI";
            buttonPI.Size = new Size(83, 23);
            buttonPI.TabIndex = 3;
            buttonPI.Text = "Process Info";
            buttonPI.UseVisualStyleBackColor = true;
            buttonPI.Click += buttonPI_Click;
            // 
            // buttonCP
            // 
            buttonCP.Location = new Point(204, 41);
            buttonCP.Name = "buttonCP";
            buttonCP.Size = new Size(97, 23);
            buttonCP.TabIndex = 4;
            buttonCP.Text = "Close Process";
            buttonCP.UseVisualStyleBackColor = true;
            // 
            // buttonKP
            // 
            buttonKP.Location = new Point(307, 41);
            buttonKP.Name = "buttonKP";
            buttonKP.Size = new Size(95, 23);
            buttonKP.TabIndex = 5;
            buttonKP.Text = "Kill Process";
            buttonKP.UseVisualStyleBackColor = true;
            // 
            // buttonSW
            // 
            buttonSW.Location = new Point(497, 41);
            buttonSW.Name = "buttonSW";
            buttonSW.Size = new Size(79, 23);
            buttonSW.TabIndex = 6;
            buttonSW.Text = "Start With";
            buttonSW.UseVisualStyleBackColor = true;
            // 
            // buttonRP
            // 
            buttonRP.Location = new Point(408, 41);
            buttonRP.Name = "buttonRP";
            buttonRP.Size = new Size(83, 23);
            buttonRP.TabIndex = 7;
            buttonRP.Text = "Run App";
            buttonRP.UseVisualStyleBackColor = true;
            buttonRP.Click += buttonRP_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 302);
            Controls.Add(buttonRP);
            Controls.Add(buttonSW);
            Controls.Add(buttonKP);
            Controls.Add(buttonCP);
            Controls.Add(buttonPI);
            Controls.Add(btnVP);
            Controls.Add(textBox2);
            Controls.Add(txtINFO);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
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