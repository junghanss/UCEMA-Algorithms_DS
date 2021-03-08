namespace EjemploServidor
{
    partial class ServidorForm
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
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnVerConectados = new System.Windows.Forms.Button();
            this.txtConectados = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.Location = new System.Drawing.Point(409, 12);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(127, 49);
            this.btnEnviarMensaje.TabIndex = 3;
            this.btnEnviarMensaje.Text = "Enviar mensaje a todos los clientes";
            this.btnEnviarMensaje.UseVisualStyleBackColor = true;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(12, 12);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(391, 21);
            this.txtMensaje.TabIndex = 2;
            this.txtMensaje.TextChanged += new System.EventHandler(this.txtMensaje_TextChanged);
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(12, 67);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(524, 431);
            this.txtLog.TabIndex = 4;
            this.txtLog.WordWrap = false;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnVerConectados
            // 
            this.btnVerConectados.Location = new System.Drawing.Point(542, 12);
            this.btnVerConectados.Name = "btnVerConectados";
            this.btnVerConectados.Size = new System.Drawing.Size(96, 49);
            this.btnVerConectados.TabIndex = 5;
            this.btnVerConectados.Text = "Ver clientes conectados";
            this.btnVerConectados.UseVisualStyleBackColor = true;
            this.btnVerConectados.Click += new System.EventHandler(this.btnVerConectados_Click);
            // 
            // txtConectados
            // 
            this.txtConectados.Location = new System.Drawing.Point(542, 67);
            this.txtConectados.Multiline = true;
            this.txtConectados.Name = "txtConectados";
            this.txtConectados.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConectados.Size = new System.Drawing.Size(245, 158);
            this.txtConectados.TabIndex = 6;
            this.txtConectados.WordWrap = false;
            this.txtConectados.TextChanged += new System.EventHandler(this.txtConectados_TextChanged);
            // 
            // ServidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 510);
            this.Controls.Add(this.txtConectados);
            this.Controls.Add(this.btnVerConectados);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnEnviarMensaje);
            this.Controls.Add(this.txtMensaje);
            this.Name = "ServidorForm";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnVerConectados;
        private System.Windows.Forms.TextBox txtConectados;
    }
}

