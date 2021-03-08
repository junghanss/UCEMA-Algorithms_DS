namespace TP_Recursividad___Libre
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Ventana1 = new System.Windows.Forms.ListBox();
            this.Ventana2 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.Ventana3 = new System.Windows.Forms.ListBox();
            this.Ventana4 = new System.Windows.Forms.ListBox();
            this.Ventana5 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "";
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(47, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tasa de Interés";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(282, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ackermann";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(47, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 42);
            this.button3.TabIndex = 4;
            this.button3.Text = "Reversa String";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(282, 203);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 42);
            this.button4.TabIndex = 6;
            this.button4.Text = "Minúsculas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Ventana1
            // 
            this.Ventana1.FormattingEnabled = true;
            this.Ventana1.Location = new System.Drawing.Point(28, 99);
            this.Ventana1.Name = "Ventana1";
            this.Ventana1.Size = new System.Drawing.Size(170, 69);
            this.Ventana1.TabIndex = 8;
            this.Ventana1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Ventana2
            // 
            this.Ventana2.FormattingEnabled = true;
            this.Ventana2.Location = new System.Drawing.Point(282, 99);
            this.Ventana2.Name = "Ventana2";
            this.Ventana2.Size = new System.Drawing.Size(130, 69);
            this.Ventana2.TabIndex = 9;
            this.Ventana2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(542, 204);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 42);
            this.button5.TabIndex = 10;
            this.button5.Text = "Comparación";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Ventana3
            // 
            this.Ventana3.FormattingEnabled = true;
            this.Ventana3.Location = new System.Drawing.Point(28, 269);
            this.Ventana3.Name = "Ventana3";
            this.Ventana3.Size = new System.Drawing.Size(170, 69);
            this.Ventana3.TabIndex = 11;
            this.Ventana3.SelectedIndexChanged += new System.EventHandler(this.Ventana3_SelectedIndexChanged);
            // 
            // Ventana4
            // 
            this.Ventana4.FormattingEnabled = true;
            this.Ventana4.Location = new System.Drawing.Point(260, 269);
            this.Ventana4.Name = "Ventana4";
            this.Ventana4.Size = new System.Drawing.Size(176, 69);
            this.Ventana4.TabIndex = 12;
            this.Ventana4.SelectedIndexChanged += new System.EventHandler(this.Ventana4_SelectedIndexChanged);
            // 
            // Ventana5
            // 
            this.Ventana5.FormattingEnabled = true;
            this.Ventana5.Location = new System.Drawing.Point(508, 269);
            this.Ventana5.Name = "Ventana5";
            this.Ventana5.Size = new System.Drawing.Size(202, 69);
            this.Ventana5.TabIndex = 13;
            this.Ventana5.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.Ventana5);
            this.Controls.Add(this.Ventana4);
            this.Controls.Add(this.Ventana3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Ventana2);
            this.Controls.Add(this.Ventana1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox Ventana1;
        private System.Windows.Forms.ListBox Ventana2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox Ventana3;
        private System.Windows.Forms.ListBox Ventana4;
        private System.Windows.Forms.ListBox Ventana5;
    }
}

