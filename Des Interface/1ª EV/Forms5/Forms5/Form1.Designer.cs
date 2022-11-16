namespace Forms5
{
    partial class elementos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(elementos));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.traspasarDerecha = new System.Windows.Forms.Button();
            this.quitar = new System.Windows.Forms.Button();
            this.traspasarIzquierda = new System.Windows.Forms.Button();
            this.anhadir = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lista_elementos = new System.Windows.Forms.Label();
            this.lista_indices = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(120, 94);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(410, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 94);
            this.listBox2.TabIndex = 1;
            // 
            // traspasarDerecha
            // 
            this.traspasarDerecha.Location = new System.Drawing.Point(138, 83);
            this.traspasarDerecha.Name = "traspasarDerecha";
            this.traspasarDerecha.Size = new System.Drawing.Size(75, 23);
            this.traspasarDerecha.TabIndex = 2;
            this.traspasarDerecha.Text = "Traspasar >";
            this.traspasarDerecha.UseVisualStyleBackColor = true;
            this.traspasarDerecha.Click += new System.EventHandler(this.traspasarDerecha_Click);
            // 
            // quitar
            // 
            this.quitar.Location = new System.Drawing.Point(329, 12);
            this.quitar.Name = "quitar";
            this.quitar.Size = new System.Drawing.Size(75, 23);
            this.quitar.TabIndex = 3;
            this.quitar.Text = "Quitar";
            this.quitar.UseVisualStyleBackColor = true;
            this.quitar.Click += new System.EventHandler(this.quitar_Click);
            // 
            // traspasarIzquierda
            // 
            this.traspasarIzquierda.Location = new System.Drawing.Point(329, 83);
            this.traspasarIzquierda.Name = "traspasarIzquierda";
            this.traspasarIzquierda.Size = new System.Drawing.Size(75, 23);
            this.traspasarIzquierda.TabIndex = 4;
            this.traspasarIzquierda.Text = "< Traspasar";
            this.traspasarIzquierda.UseVisualStyleBackColor = true;
            this.traspasarIzquierda.Click += new System.EventHandler(this.traspasar2_Click);
            // 
            // anhadir
            // 
            this.anhadir.Location = new System.Drawing.Point(138, 12);
            this.anhadir.Name = "anhadir";
            this.anhadir.Size = new System.Drawing.Size(75, 23);
            this.anhadir.TabIndex = 5;
            this.anhadir.Text = "Añadir";
            this.anhadir.UseVisualStyleBackColor = true;
            this.anhadir.Click += new System.EventHandler(this.anhadir_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(219, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 6;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // lista_elementos
            // 
            this.lista_elementos.AutoSize = true;
            this.lista_elementos.Location = new System.Drawing.Point(12, 121);
            this.lista_elementos.Name = "lista_elementos";
            this.lista_elementos.Size = new System.Drawing.Size(0, 15);
            this.lista_elementos.TabIndex = 7;
            // 
            // lista_indices
            // 
            this.lista_indices.AutoSize = true;
            this.lista_indices.Location = new System.Drawing.Point(410, 121);
            this.lista_indices.Name = "lista_indices";
            this.lista_indices.Size = new System.Drawing.Size(50, 15);
            this.lista_indices.TabIndex = 8;
            this.lista_indices.Text = "Indices: ";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip7
            // 
            this.toolTip7.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip7_Popup);
            // 
            // elementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 153);
            this.Controls.Add(this.lista_indices);
            this.Controls.Add(this.lista_elementos);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.anhadir);
            this.Controls.Add(this.traspasarIzquierda);
            this.Controls.Add(this.quitar);
            this.Controls.Add(this.traspasarDerecha);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "elementos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de listas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private Button traspasarDerecha;
        private Button quitar;
        private Button traspasarIzquierda;
        private Button anhadir;
        private TextBox textBox1;
        private Label lista_elementos;
        private Label lista_indices;
        private System.Windows.Forms.Timer timer1;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private ToolTip toolTip6;
        private ToolTip toolTip7;
    }
}