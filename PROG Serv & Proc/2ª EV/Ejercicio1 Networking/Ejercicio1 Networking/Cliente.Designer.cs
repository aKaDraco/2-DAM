namespace Ejercicio1_Networking
{
    partial class Cliente
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
            this.btnTime = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pass = new System.Windows.Forms.Label();
            this.boxPass = new System.Windows.Forms.TextBox();
            this.labelResultado = new System.Windows.Forms.Label();
            this.changeIP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(14, 49);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(70, 70);
            this.btnTime.TabIndex = 0;
            this.btnTime.Text = "Time";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnsConect);
            // 
            // btnDate
            // 
            this.btnDate.Location = new System.Drawing.Point(88, 49);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(70, 70);
            this.btnDate.TabIndex = 1;
            this.btnDate.Text = "Date";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnsConect);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(164, 49);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(70, 70);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnsConect);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(240, 49);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 70);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnsConect);
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(14, 15);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(57, 15);
            this.pass.TabIndex = 4;
            this.pass.Text = "Password";
            // 
            // boxPass
            // 
            this.boxPass.Location = new System.Drawing.Point(77, 12);
            this.boxPass.Name = "boxPass";
            this.boxPass.Size = new System.Drawing.Size(100, 23);
            this.boxPass.TabIndex = 5;
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Location = new System.Drawing.Point(33, 139);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(59, 15);
            this.labelResultado.TabIndex = 6;
            this.labelResultado.Text = "Resultado";
            // 
            // changeIP
            // 
            this.changeIP.AutoSize = true;
            this.changeIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.changeIP.Location = new System.Drawing.Point(249, 9);
            this.changeIP.Name = "changeIP";
            this.changeIP.Size = new System.Drawing.Size(66, 17);
            this.changeIP.TabIndex = 7;
            this.changeIP.Text = "ChangeIP";
            this.changeIP.Click += new System.EventHandler(this.changeIP_Click);
            this.changeIP.MouseEnter += new System.EventHandler(this.changeIP_MouseEnter);
            this.changeIP.MouseLeave += new System.EventHandler(this.changeIP_MouseLeave);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 163);
            this.Controls.Add(this.changeIP);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.boxPass);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.btnTime);
            this.Name = "Cliente";
            this.Text = "CLIENTE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnTime;
        private Button btnDate;
        private Button btnAll;
        private Button btnClose;
        private Label pass;
        private TextBox boxPass;
        private Label labelResultado;
        private Label changeIP;
    }
}