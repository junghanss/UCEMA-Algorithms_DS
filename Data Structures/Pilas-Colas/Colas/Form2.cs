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

namespace Colas
{
    public partial class Form2 : Form
    {
        Cola C;
        public Form2()
        {
            InitializeComponent();
            C = new Cola();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) //listview horizontal
        {

        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Mostrar()
        {
            listView1.Items.Clear();
            Nodo N = C.Desencolar();
            Cola Caux = new Cola();
            while (N != null)
            {
                listView1.Items.Add(N.Id);
                Caux.Encolar(N.Id);
                N = C.Desencolar(); // Recordemos que desencolar retorna un nodo...
            }

            N = Caux.Desencolar();
            while (N != null)
            {
                C.Encolar(N.Id);
                N = Caux.Desencolar(); // Recordemos que desencolar retorna un nodo...
            }
            textBox1.Text = C.Ver()!=null ? C.Ver().Id:"";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { C.Encolar(Interaction.InputBox("ID: ")); Mostrar(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }   // Encolar
        private void button2_Click(object sender, EventArgs e)
        {
            try { C.Desencolar(); Mostrar(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }   // Desencolar

        Random r = new Random(DateAndTime.Now.Millisecond); // Seed es el primer numero que le generamos, importante
        private void timer1_Tick(object sender, EventArgs e) // Ejemplo Timer
        {
            BackColor = Color.FromArgb(r.Next(256), r.Next(256),r.Next(256));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

    }

    public class Cola
    {
        public Cola() { CentinelaPrimero = new Nodo("CentinelaPrimero"); CentinelaUltimo = new Nodo("CentinelaUltimo"); }
        public Nodo CentinelaPrimero;  // Propiedad que nos devuelva el primero como variable interna
        public Nodo CentinelaUltimo;
        public void Encolar(string pId)       // No devuelve nada
        {
            try
            {
                // Similar a agregar al final en una lista enlazada...
                Nodo _d = new Nodo(pId); // Armamos un objeto nuevo para no tener que instanciar un disco varias veces en el cuerpo del código
                if (CentinelaPrimero.Siguiente == null) { CentinelaPrimero.Siguiente = _d; CentinelaUltimo.Siguiente = _d; } // Caso 1: si esta vacia y tenemos que crear un disco
                else { CentinelaUltimo.Siguiente.Siguiente = _d; CentinelaUltimo.Siguiente = _d; }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public Nodo Desencolar()       // Devuelve un nodo, el primero
        {
            // Similar a borrar inicio en una lista enlazada... 
            Nodo r = null;
            try
            {
               if(CentinelaPrimero.Siguiente != null)
                {
                    r = CentinelaPrimero.Siguiente;
                    CentinelaPrimero.Siguiente = r.Siguiente;
                    if(CentinelaPrimero.Siguiente == null) { CentinelaUltimo.Siguiente = null; }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return r!=null ? new Nodo(r.Id) : null;
        }
        //public List<Nodo> ToList() { } // Si quisieramos retornar una lista en
        public Nodo Ver() { return CentinelaPrimero.Siguiente != null ? new Nodo(CentinelaPrimero.Siguiente.Id) : null; } // Para proteger el encapsulamiento de la estructura, creamos un clon del primer nodo para ver, así nadie se agarra de ese y sus punteros.. sino nos cagan!!



    }

    public class Nodo // Clase autoreferenciada
    {
        public Nodo(string pId, Nodo pNodo=null)
        { Id = pId; Siguiente = pNodo; } // Constructor
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }
    }

    // En un ejemplo de un supermercado
    public class Caja
    {
        Cola ClientePorCobrar = new Cola();
        Cola ClientesCobrados = new Cola();
    }


}
