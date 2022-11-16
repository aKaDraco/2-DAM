namespace Forms4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.suma = new System.Windows.Forms.RadioButton();
            this.resta = new System.Windows.Forms.RadioButton();
            this.multiplicacion = new System.Windows.Forms.RadioButton();
            this.division = new System.Windows.Forms.RadioButton();
            this.simbolo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.resultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.compTxtboxes);
            this.textBox1.Enter += new System.EventHandler(this.acptButtn);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(139, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.compTxtboxes);
            this.textBox2.Enter += new System.EventHandler(this.acptButtn);
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(245, 12);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(75, 23);
            this.btnOperar.TabIndex = 2;
            this.btnOperar.Text = "OPERAR";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // suma
            // 
            this.suma.AutoSize = true;
            this.suma.Checked = true;
            this.suma.Location = new System.Drawing.Point(12, 58);
            this.suma.Name = "suma";
            this.suma.Size = new System.Drawing.Size(33, 19);
            this.suma.TabIndex = 3;
            this.suma.TabStop = true;
            this.suma.Text = "+";
            this.suma.UseVisualStyleBackColor = true;
            this.suma.CheckedChanged += new System.EventHandler(this.selecOperaciones);
            // 
            // resta
            // 
            this.resta.AutoSize = true;
            this.resta.Location = new System.Drawing.Point(51, 58);
            this.resta.Name = "resta";
            this.resta.Size = new System.Drawing.Size(30, 19);
            this.resta.TabIndex = 4;
            this.resta.Text = "-";
            this.resta.UseVisualStyleBackColor = true;
            this.resta.CheckedChanged += new System.EventHandler(this.selecOperaciones);
            // 
            // multiplicacion
            // 
            this.multiplicacion.AutoSize = true;
            this.multiplicacion.Location = new System.Drawing.Point(87, 58);
            this.multiplicacion.Name = "multiplicacion";
            this.multiplicacion.Size = new System.Drawing.Size(30, 19);
            this.multiplicacion.TabIndex = 5;
            this.multiplicacion.Text = "*";
            this.multiplicacion.UseVisualStyleBackColor = true;
            this.multiplicacion.CheckedChanged += new System.EventHandler(this.selecOperaciones);
            // 
            // division
            // 
            this.division.AutoSize = true;
            this.division.Location = new System.Drawing.Point(123, 58);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(30, 19);
            this.division.TabIndex = 6;
            this.division.Text = "/";
            this.division.UseVisualStyleBackColor = true;
            this.division.CheckedChanged += new System.EventHandler(this.selecOperaciones);
            // 
            // simbolo
            // 
            this.simbolo.AutoSize = true;
            this.simbolo.Location = new System.Drawing.Point(118, 16);
            this.simbolo.Name = "simbolo";
            this.simbolo.Size = new System.Drawing.Size(15, 15);
            this.simbolo.TabIndex = 8;
            this.simbolo.Text = "+";
            this.simbolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // resultado
            // 
            this.resultado.AutoSize = true;
            this.resultado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultado.Location = new System.Drawing.Point(205, 69);
            this.resultado.Name = "resultado";
            this.resultado.Size = new System.Drawing.Size(86, 21);
            this.resultado.TabIndex = 9;
            this.resultado.Text = "Resultado: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 99);
            this.Controls.Add(this.resultado);
            this.Controls.Add(this.simbolo);
            this.Controls.Add(this.division);
            this.Controls.Add(this.multiplicacion);
            this.Controls.Add(this.resta);
            this.Controls.Add(this.suma);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "00:00";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnOperar;
        private RadioButton suma;
        private RadioButton resta;
        private RadioButton multiplicacion;
        private RadioButton division;
        private Label simbolo;
        private System.Windows.Forms.Timer timer1;
        private Label resultado;
    }
}