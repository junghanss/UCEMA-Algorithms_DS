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

namespace Balance_de_Signos
{
    public partial class Form3 : Form
    {
        string expresion = "";
        char s = ' ';
        Pila pila;
        public Form3()
        {
            InitializeComponent();
            pila = new Pila();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e) // Cargar expresion
        {
            textBox1.Clear();
            expresion = Interaction.InputBox("Ingrese la expresión a evaluar: ");
            textBox1.Text = expresion;
            textBox1.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Evalaur expresion
        {
            try
            {
                foreach (char c in expresion)
                {
                    if (c == '(' || c == '{' || c == '[')
                    {
                        pila.Apilar(c);
                    }
                    if (c == ')' || c == '}' || c == ']')
                    {
                        if (pila.PilaVacia())
                        {
                            MessageBox.Show("Exceso de símbolos de cierre");
                        }
                        else
                        {
                            // Obtenemos el caracter correspondiente al desapilarlo
                            s = pila.Desapilar();
                            // Verificamos que haya coincidencia con el caracter obtenido
                            if (s == '(' && c != ')')
                            {
                                MessageBox.Show("Se esperaba )");
                            }
                            if (s == '{' && c != '}')
                            {
                                MessageBox.Show("Se esperaba }");
                            }
                            if (s == '[' && c != ']')
                            {
                                MessageBox.Show("Se esperaba ]");
                            }

                        }
                    }
                }
                if (pila.PilaVacia() == false) // Si despues del foreach todavia sigue con items la pila
                {
                    MessageBox.Show("Exceso de símbolos de apertura.");
                }
                //else { MessageBox.Show("La expresión es correcta!"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }


    public class Pila
    {
        public Pila() { CentinelaPrimero = new Disco(); CentinelaUltimo = new Disco(); }
        private Disco CentinelaPrimero;
        private Disco CentinelaUltimo;
        public Disco Primero() { return CentinelaPrimero.Siguiente; }
        public Disco Ultimo() { return CentinelaUltimo.Siguiente; }
        public char Desapilar() 
        {
            Disco _auxUltimo = null; // Disco auxiliar para devolver lo que desapilemos
            Disco _auxAnteUltimo = AnteUltimo(Primero());
            // Hay dos casos distintos: que sea una pila unitaria, o que tenga varios discos.
            if (Primero() == Ultimo()) 
            {
                _auxUltimo = Primero();
                CentinelaPrimero.Siguiente = null;
                CentinelaUltimo.Siguiente = null;
            }
            else
            {
                if (_auxAnteUltimo == null) { return _auxUltimo.Dato; } // Por si llegamos a encontrarnos que la lista estaba vacia y no haya una Excepcion
                _auxUltimo = _auxAnteUltimo.Siguiente;
                CentinelaUltimo.Siguiente = _auxAnteUltimo;
                _auxAnteUltimo.Siguiente = null;
            }
            return _auxUltimo.Dato; 
        }
        public void Apilar(char pDato) 
        {
            Disco _disco = new Disco(pDato);
            if (Primero() == null) // Si la pila está vacia
            {
                CentinelaPrimero.Siguiente = _disco;
                CentinelaUltimo.Siguiente = _disco;
            }
            else
            {
                    CentinelaUltimo.Siguiente.Siguiente = _disco;
                    CentinelaUltimo.Siguiente = _disco;
            }      
        }
        public char Ver() 
        { 
            return Ultimo().Dato;
        }
        private Disco AnteUltimo(Disco pPrimerDisco)
        {
            // pPrimerDisco es el parametro input igual a Primero(), es decir, el primer nodo de la pila
            Disco _anteUltimo = null;
            Disco _auxiliar = null;
            if(pPrimerDisco != null && pPrimerDisco.Siguiente != null)
            {
                _anteUltimo = pPrimerDisco;
                _auxiliar = pPrimerDisco.Siguiente.Siguiente; // El auxiliar tiene que estar verificando siempre el casillero <siguiente> al ultimo!
                while (_auxiliar != null)
                {
                    _anteUltimo = _anteUltimo.Siguiente;
                    _auxiliar = _auxiliar.Siguiente;
                }
            }
            return _anteUltimo;
        }
        public bool PilaVacia()
        {
            if (CentinelaPrimero.Siguiente != null) { return false; }
            return true;
        }

    }

    public class Disco
    {
        public Disco() { }
        public Disco(char pDato, Disco pSiguiente = null) { Dato = pDato; Siguiente = pSiguiente; }
        public char Dato { get; set; }
        public Disco Siguiente { get; set; }
    }
}
