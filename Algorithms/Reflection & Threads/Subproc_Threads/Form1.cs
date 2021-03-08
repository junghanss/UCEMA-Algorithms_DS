using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Subproc_Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Threading.Thread _AlgoritmoUno;
        System.Threading.Thread _AlgoritmoDos;
        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Threading.ThreadStart _TStartAlgoritmoUno = new System.Threading.ThreadStart(AlgoritmoUno);
            Form.CheckForIllegalCrossThreadCalls = false;
            _AlgoritmoUno = new System.Threading.Thread(new System.Threading.ThreadStart(AlgoritmoUno));
            _AlgoritmoDos = new System.Threading.Thread(new System.Threading.ThreadStart(AlgoritmoDos));
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_AlgoritmoUno.IsAlive) { startUno = startDos = true; _AlgoritmoUno.Resume(); _AlgoritmoDos.Resume(); }
            else
            {
                startUno = startDos = true; _AlgoritmoUno.Start(); _AlgoritmoDos.Start();
            }
            button1.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            startUno = startDos = false; _AlgoritmoUno.Suspend(); _AlgoritmoDos.Suspend();
            button1.Enabled = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        int resultadoAlgoritmoUno = 2, resultadoAlgoritmoDos = 1, resultadoAlgoritmoTres = 2;


        bool startUno = false, startDos = false, startTres = false;

        #region "Safe Call on Form Controls"

        private delegate void SafeCallDelegate(string text);
        private void WriteTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                textBox1.Invoke(d, new object[] { text });
            }
            else
            {
                while (startUno)
                {
                    //textBox1.Text = text;
                    textBox1.Text = resultadoAlgoritmoUno.ToString(); textBox1.Show();
                    resultadoAlgoritmoUno = resultadoAlgoritmoUno + 2;
                }
            }
        }
        private void SetText()
        {
            WriteTextSafe("This text was set safely.");
        }

        #endregion

        private void AlgoritmoUno()
        {
            while (startUno)
            {
                textBox1.Text = resultadoAlgoritmoUno.ToString(); textBox1.Show();
                resultadoAlgoritmoUno = resultadoAlgoritmoUno + 2;
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void AlgoritmoDos()
        {
            while (startDos)
            {
                textBox2.Text = resultadoAlgoritmoDos.ToString(); textBox2.Show();
                resultadoAlgoritmoDos = resultadoAlgoritmoDos + 2;
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
