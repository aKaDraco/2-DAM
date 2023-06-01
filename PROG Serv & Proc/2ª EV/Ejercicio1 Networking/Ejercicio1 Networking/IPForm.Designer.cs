namespace Ejercicio1_Networking
{
    partial class Form2
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
            labelIP = new Label();
            textBoxIP = new TextBox();
            labelPort = new Label();
            textBoxPort = new TextBox();
            changeButton = new Button();
            SuspendLayout();
            // 
            // labelIP
            // 
            labelIP.AutoSize = true;
            labelIP.Location = new Point(12, 21);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(17, 15);
            labelIP.TabIndex = 0;
            labelIP.Text = "IP";
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(56, 18);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(100, 23);
            textBoxIP.TabIndex = 1;
            textBoxIP.TextChanged += textBoxIP_TextChanged;
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(12, 64);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(35, 15);
            labelPort.TabIndex = 2;
            labelPort.Text = "PORT";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(56, 61);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 23);
            textBoxPort.TabIndex = 3;
            textBoxPort.TextChanged += textBoxPort_TextChanged;
            // 
            // changeButton
            // 
            changeButton.Location = new Point(169, 84);
            changeButton.Name = "changeButton";
            changeButton.Size = new Size(75, 23);
            changeButton.TabIndex = 4;
            changeButton.Text = "Change";
            changeButton.UseVisualStyleBackColor = true;
            changeButton.Click += changeButton_Click;
            // 
            // Form2
            // 
            AcceptButton = changeButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 119);
            Controls.Add(changeButton);
            Controls.Add(textBoxPort);
            Controls.Add(labelPort);
            Controls.Add(textBoxIP);
            Controls.Add(labelIP);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CHANGE IP AND PORT";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIP;
        private Label labelPort;
        private Button changeButton;
        public TextBox textBoxIP;
        public TextBox textBoxPort;
    }
}