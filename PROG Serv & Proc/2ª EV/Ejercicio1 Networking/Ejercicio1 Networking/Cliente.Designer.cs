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
            btnTime = new Button();
            btnDate = new Button();
            btnAll = new Button();
            btnClose = new Button();
            pass = new Label();
            boxPass = new TextBox();
            labelResultado = new Label();
            changeIP = new Label();
            SuspendLayout();
            // 
            // btnTime
            // 
            btnTime.Location = new Point(14, 49);
            btnTime.Name = "btnTime";
            btnTime.Size = new Size(70, 70);
            btnTime.TabIndex = 0;
            btnTime.Text = "Time";
            btnTime.UseVisualStyleBackColor = true;
            btnTime.Click += btnsConect;
            // 
            // btnDate
            // 
            btnDate.Location = new Point(88, 49);
            btnDate.Name = "btnDate";
            btnDate.Size = new Size(70, 70);
            btnDate.TabIndex = 1;
            btnDate.Text = "Date";
            btnDate.UseVisualStyleBackColor = true;
            btnDate.Click += btnsConect;
            // 
            // btnAll
            // 
            btnAll.Location = new Point(164, 49);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(70, 70);
            btnAll.TabIndex = 2;
            btnAll.Text = "All";
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnsConect;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(240, 49);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(70, 70);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnsConect;
            // 
            // pass
            // 
            pass.AutoSize = true;
            pass.Location = new Point(14, 15);
            pass.Name = "pass";
            pass.Size = new Size(57, 15);
            pass.TabIndex = 4;
            pass.Text = "Password";
            // 
            // boxPass
            // 
            boxPass.Location = new Point(77, 12);
            boxPass.Name = "boxPass";
            boxPass.Size = new Size(100, 23);
            boxPass.TabIndex = 5;
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(33, 139);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(59, 15);
            labelResultado.TabIndex = 6;
            labelResultado.Text = "Resultado";
            // 
            // changeIP
            // 
            changeIP.AutoSize = true;
            changeIP.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            changeIP.Location = new Point(249, 9);
            changeIP.Name = "changeIP";
            changeIP.Size = new Size(66, 17);
            changeIP.TabIndex = 7;
            changeIP.Text = "ChangeIP";
            changeIP.Click += changeIP_Click;
            changeIP.MouseEnter += changeIP_MouseEnter;
            changeIP.MouseLeave += changeIP_MouseLeave;
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 163);
            Controls.Add(changeIP);
            Controls.Add(labelResultado);
            Controls.Add(boxPass);
            Controls.Add(pass);
            Controls.Add(btnClose);
            Controls.Add(btnAll);
            Controls.Add(btnDate);
            Controls.Add(btnTime);
            Name = "Cliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CLIENTE";
            ResumeLayout(false);
            PerformLayout();
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