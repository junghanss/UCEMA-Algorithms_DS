using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subprocesamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool startBG1 = false, startBG2 = false, startBG3 = false, startBG4 = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);

            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker3.WorkerReportsProgress = true;
            backgroundWorker3.WorkerSupportsCancellation = true;
        }
        int resultadoAlgoritmoUno = 2;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int _progreso = 0;
            while (startBG1)
            {
                System.Threading.Thread.Sleep(2000);
                textBox1.Text = resultadoAlgoritmoUno.ToString();
                textBox1.Show();
                resultadoAlgoritmoUno = resultadoAlgoritmoUno + 2;
                backgroundWorker1.ReportProgress(_progreso = _progreso + 1);
            }
        }
        int resultadoAlgoritmoDos = 1;
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (startBG2)
            {
                System.Threading.Thread.Sleep(2000);
                textBox2.Text = resultadoAlgoritmoDos.ToString();
                textBox2.Show();
                resultadoAlgoritmoDos = resultadoAlgoritmoDos + 2;
            }
        }
        int resultadoAlgoritmoTres = 2;
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            while (startBG3)
            {
                
                if (resultadoAlgoritmoTres%2==0 || resultadoAlgoritmoTres%3==0 || resultadoAlgoritmoTres%5==0) // Es divisible por 2, 3 o 5? Ya no es primo...
                {
                    if(resultadoAlgoritmoTres==2 || resultadoAlgoritmoTres==3 || resultadoAlgoritmoTres==5) // Si es el mismisimo 2, 3 o 5, entonces son una excepcion
                    { 
                        textBox3.Text = resultadoAlgoritmoTres.ToString(); textBox3.Show(); resultadoAlgoritmoTres++;
                        System.Threading.Thread.Sleep(2000); // Solo seteamos el sleep cuando imprime en pantalla
                    }
                    else { resultadoAlgoritmoTres++; } // Para el caso 'n' solamente le sumamos uno...                    
                }
                else
                {
                    // Es primo (dado que no es divisible por dos, tres o cinco...)
                    textBox3.Text = resultadoAlgoritmoTres.ToString(); textBox3.Show(); resultadoAlgoritmoTres++;
                    System.Threading.Thread.Sleep(2000);
                }
                //System.Threading.Thread.Sleep(2000);
            }
        }
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(20000);
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true && backgroundWorker2.IsBusy != true && backgroundWorker3.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.RunWorkerAsync();
                backgroundWorker3.RunWorkerAsync();
                //StartButton.Enabled = false; StopButton.Enabled = true;
                
            }
            startBG1 = startBG2 = startBG3 = startBG4 = true;
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            { 
                backgroundWorker1.CancelAsync();
                backgroundWorker2.CancelAsync();
                backgroundWorker3.CancelAsync();
                //StopButton.Enabled = false; StartButton.Enabled = true;
            }
            startBG1 = startBG2 = startBG3 = startBG4 = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync(); startBG1 = true;
                    MessageBox.Show("Comienzo del proceso asincronico.", "Suma Números Pares");
                }
                else
                {
                    backgroundWorker1.CancelAsync(); startBG1 = false;
                    MessageBox.Show("Finalización del proceso asincronico.", "Suma Números Pares");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync(); startBG2 = true;
                    MessageBox.Show("Comienzo del proceso asincronico.", "Suma Números Impares");
                }
                else
                {
                    backgroundWorker2.CancelAsync(); startBG2 = false;
                    MessageBox.Show("Finalización del proceso asincronico.", "Suma Números Impares");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker3.IsBusy != true)
                {
                    backgroundWorker3.RunWorkerAsync(); startBG3 = true;
                    MessageBox.Show("Comienzo del proceso asincronico.", "Mostrar Números Primos");
                }
                else
                {
                    backgroundWorker3.CancelAsync(); startBG3 = false;
                    MessageBox.Show("Finalización del proceso asincronico.", "Mostrar Números Primos");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker4.IsBusy != true)
                {
                    backgroundWorker4.RunWorkerAsync(); startBG4 = true;
                    MessageBox.Show("Comienzo del proceso asincronico.", "Mostrar Mitad del Número");
                }
                else
                {
                    backgroundWorker4.CancelAsync(); startBG4 = false;
                    MessageBox.Show("Finalización del proceso asincronico.", "Mostrar Mitad del Número");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void textBox4_TextChanged(object sender, EventArgs e) { }




        // This event handler updates the progress bar.
        private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
    }




}
