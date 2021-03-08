﻿namespace EjemploCliente
{
    partial class ClienteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtBoxIPEnvioPrivado = new System.Windows.Forms.TextBox();
            this.txtBoxPortEnvioPrivado = new System.Windows.Forms.TextBox();
            this.txtBoxMensajePrivado = new System.Windows.Forms.TextBox();
            this.BtnEnvioPrivado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puerto:";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(59, 38);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(100, 20);
            this.txtPuerto.TabIndex = 2;
            this.txtPuerto.Text = "8050";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(59, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "127.0.0.1";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(59, 64);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 3;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Enabled = false;
            this.txtMensaje.Location = new System.Drawing.Point(224, 12);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(232, 20);
            this.txtMensaje.TabIndex = 4;
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.Enabled = false;
            this.btnEnviarMensaje.Location = new System.Drawing.Point(224, 41);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarMensaje.TabIndex = 5;
            this.btnEnviarMensaje.Text = "Enviar";
            this.btnEnviarMensaje.UseVisualStyleBackColor = true;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(12, 111);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(475, 357);
            this.txtLog.TabIndex = 7;
            this.txtLog.WordWrap = false;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // txtBoxIPEnvioPrivado
            // 
            this.txtBoxIPEnvioPrivado.Location = new System.Drawing.Point(608, 67);
            this.txtBoxIPEnvioPrivado.Name = "txtBoxIPEnvioPrivado";
            this.txtBoxIPEnvioPrivado.Size = new System.Drawing.Size(100, 20);
            this.txtBoxIPEnvioPrivado.TabIndex = 8;
            this.txtBoxIPEnvioPrivado.Text = "127.0.0.1";
            // 
            // txtBoxPortEnvioPrivado
            // 
            this.txtBoxPortEnvioPrivado.Location = new System.Drawing.Point(608, 41);
            this.txtBoxPortEnvioPrivado.Name = "txtBoxPortEnvioPrivado";
            this.txtBoxPortEnvioPrivado.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPortEnvioPrivado.TabIndex = 9;
            this.txtBoxPortEnvioPrivado.Text = "8050";
            // 
            // txtBoxMensajePrivado
            // 
            this.txtBoxMensajePrivado.Enabled = false;
            this.txtBoxMensajePrivado.Location = new System.Drawing.Point(476, 12);
            this.txtBoxMensajePrivado.Name = "txtBoxMensajePrivado";
            this.txtBoxMensajePrivado.Size = new System.Drawing.Size(232, 20);
            this.txtBoxMensajePrivado.TabIndex = 10;
            // 
            // BtnEnvioPrivado
            // 
            this.BtnEnvioPrivado.Enabled = false;
            this.BtnEnvioPrivado.Location = new System.Drawing.Point(476, 41);
            this.BtnEnvioPrivado.Name = "BtnEnvioPrivado";
            this.BtnEnvioPrivado.Size = new System.Drawing.Size(75, 23);
            this.BtnEnvioPrivado.TabIndex = 11;
            this.BtnEnvioPrivado.Text = "Enviar a";
            this.BtnEnvioPrivado.UseVisualStyleBackColor = true;
            this.BtnEnvioPrivado.Click += new System.EventHandler(this.BtnEnvioPrivado_Click);
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 480);
            this.Controls.Add(this.BtnEnvioPrivado);
            this.Controls.Add(this.txtBoxMensajePrivado);
            this.Controls.Add(this.txtBoxIPEnvioPrivado);
            this.Controls.Add(this.txtBoxPortEnvioPrivado);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnEnviarMensaje);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClienteForm";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.ClienteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtBoxIPEnvioPrivado;
        private System.Windows.Forms.TextBox txtBoxPortEnvioPrivado;
        private System.Windows.Forms.TextBox txtBoxMensajePrivado;
        private System.Windows.Forms.Button BtnEnvioPrivado;
    }
}

