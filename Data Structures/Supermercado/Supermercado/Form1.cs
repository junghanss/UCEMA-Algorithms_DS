using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using Microsoft.VisualBasic;

namespace Supermercado
{
    public partial class Form1 : Form
    {
        Caja Zhang;
        public Form1()
        {
            InitializeComponent();
            Zhang = new Caja();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /*private void Mostrar()
        {
            listView1.Items.Clear();
            Nodo N = Zhang.Desencolar();
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
            textBox1.Text = C.Ver() != null ? C.Ver().Id : "";
        }*/
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { } // Cola de Caja
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Show();
        } // Cola Por Cobrar
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // Cola Cobrados
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente(Interaction.InputBox("Nombre"), int.Parse(Interaction.InputBox("Importe")));
                dataGridView1.Rows.Add(nuevo.Nombre, nuevo.Importe);
                Zhang.AgregaCliente(nuevo);
                int _total = Zhang.DineroPorCobrar();
                int _cant = Zhang.CantidadClientesPorCobrar();
                dataGridView3.Rows.Clear();
                dataGridView3.Rows.Insert(0, _total, _cant);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        } // Agregar cliente
        private void button2_Click(object sender, EventArgs e) // Pase
        {
            try
            {
                Cliente aux = Zhang.Pase();
                listView1.Items.Add((aux.Importe).ToString());
                dataGridView1.Rows.RemoveAt(0);
                dataGridView3.Rows.Clear();
                int _total = Zhang.DineroPorCobrar();
                int _cant = Zhang.CantidadClientesPorCobrar();
                dataGridView3.Rows.Insert(0, _total, _cant);
            }
            catch (Exception NullReferenceException) { MessageBox.Show(NullReferenceException.Message); }

        }
        private void button3_Click(object sender, EventArgs e) // Cobrar
        {
            try
            {
                listView1.Items.RemoveAt(0);
                Cliente cobrado;
                cobrado = Zhang.Cobrar();
                dataGridView2.Rows.Insert(0, cobrado.Nombre, cobrado.Importe);
                int _total = Zhang.DineroCobrado(); // Almacenamos el int que nos devuelve la función con el total de dinero cobrado
                textBox1.Text = _total.ToString(); // Lo parseamos a texto para luego mostrarlo en la caja de texto
                textBox1.Show();
                int _cant = Zhang.CantidadClientesCobrados(); // Almacenamos el int que nos devuelve la función con el total de dinero cobrado
                textBox2.Text = _cant.ToString(); // Lo parseamos a texto para luego mostrarlo en la caja de texto
                textBox2.Show();
                dataGridView4.Rows.Clear();
                dataGridView4.Rows.Insert(0, _total, _cant);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<string> nombres = new List<string> 
            { 
                "Facundo", "Gabriel", "Ariana",
                "Dario", "Daniela", "Matias",
                "Fernando","Sofia","Pilar",
                "Ivan","Sandra","Miguel",   
            };
            string nombre_random = nombres[nombre.Next(12)];

            Cliente nuevo = new Cliente(nombre_random,r.Next(15000));
            dataGridView1.Rows.Add(nuevo.Nombre, nuevo.Importe);
            Zhang.AgregaCliente(nuevo);
            int _total = Zhang.DineroPorCobrar();
            int _cant = Zhang.CantidadClientesPorCobrar();
            dataGridView3.Rows.Clear();
            dataGridView3.Rows.Insert(0, _total, _cant);


        } // Temporizador 1
        private void Temporizador2_Tick(object sender, EventArgs e)
        {
            // Temporizador2.Start(); // No entiendo por qué no empiezan al mismo tiempo con el timer1

            Cliente aux = Zhang.Pase();
            listView1.Items.Add((aux.Importe).ToString());
            dataGridView1.Rows.RemoveAt(0);
            dataGridView3.Rows.Clear();
            int _total = Zhang.DineroPorCobrar();
            int _cant = Zhang.CantidadClientesPorCobrar();
            dataGridView3.Rows.Insert(0, _total, _cant);
        }   // Temporizador 2
        private void Temporizador3_Tick(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(0);
            Cliente cobrado;
            cobrado = Zhang.Cobrar();
            dataGridView2.Rows.Insert(0, cobrado.Nombre, cobrado.Importe);
            int _total = Zhang.DineroCobrado(); // Almacenamos el int que nos devuelve la función con el total de dinero cobrado
            textBox1.Text = _total.ToString(); // Lo parseamos a texto para luego mostrarlo en la caja de texto
            textBox1.Show();
            int _cant = Zhang.CantidadClientesCobrados(); // Almacenamos el int que nos devuelve la función con el total de dinero cobrado
            textBox2.Text = _cant.ToString(); // Lo parseamos a texto para luego mostrarlo en la caja de texto
            textBox2.Show();
            dataGridView4.Rows.Clear();
            dataGridView4.Rows.Insert(0, _total, _cant);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Temporizador1.Start();
            Temporizador2.Start();
            Temporizador3.Start();
        }   // Timer Start (operar)
        private void button5_Click(object sender, EventArgs e)
        {
            Temporizador1.Stop();
            Temporizador2.Stop();
            Temporizador3.Stop();
        }   // Timer Stop (finalizar)

        Random r = new Random(DateAndTime.Now.Millisecond); // Número semilla (seed)
        Random nombre = new Random(0);

    }
    public class Cola
    {
        public Cola() { CentinelaPrimero = new Cliente("CentinelaPrimero", 0); CentinelaUltimo = new Cliente("CentinelaUltimo", 0); }
        public Cliente CentinelaPrimero;  // Propiedad que nos devuelva el primero como variable interna
        public Cliente CentinelaUltimo;
        public void Encolar(string pNombre, int pImporte)       // No devuelve nada
        {
            try
            {
                Cliente _d = new Cliente(pNombre, pImporte); // Armamos un objeto nuevo para no tener que instanciar un disco varias veces en el cuerpo del código
                if (CentinelaPrimero.Siguiente == null) { CentinelaPrimero.Siguiente = _d; CentinelaUltimo.Siguiente = _d; } // Caso 1: si esta vacia y tenemos que crear un disco
                else { CentinelaUltimo.Siguiente.Siguiente = _d; CentinelaUltimo.Siguiente = _d; }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public Cliente Desencolar()       // Devuelve un cliente, el primero
        {
            Cliente r = null;
            try
            {
                if (CentinelaPrimero.Siguiente != null)
                {
                    r = CentinelaPrimero.Siguiente;
                    CentinelaPrimero.Siguiente = r.Siguiente;
                    if (CentinelaPrimero.Siguiente == null) { CentinelaUltimo.Siguiente = null; }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return r != null ? new Cliente(r.Nombre, r.Importe) : null;
        }
        public Cliente Ver() { return CentinelaPrimero.Siguiente != null ? new Cliente(CentinelaPrimero.Siguiente.Nombre, CentinelaPrimero.Siguiente.Importe) : null; } // Para proteger el encapsulamiento de la estructura, creamos un clon del primer nodo para ver, así nadie se agarra de ese y sus punteros.. sino nos cagan!!
    }
    public class Cliente //Clase autoreferenciada
    {
        public Cliente(string pNombre, int pImporte, Cliente pSiguienteCliente = null)
        { Nombre = pNombre; Importe = pImporte; Siguiente = pSiguienteCliente; } //Constructor
        public string Nombre { get; set; }
        public int Importe { get; set; }
        public Cliente Siguiente { get; set; }
    }
    public class Caja
    {
        Cola ClientesPorCobrar = new Cola();
        Cola ClientesCobrados = new Cola();
        Cola CajaPrincipal = new Cola();
        public int Numero { get; set; }
        public Cliente Pase()
        {
            Cliente aux;
            // bool flag = false; // testeo para contar
            if (ClientesPorCobrar.Ver() == null) { return null; }
            else
            {
                // flag = true;
                aux = ClientesPorCobrar.Desencolar();
                CajaPrincipal.Encolar(aux.Nombre, aux.Importe);
                return aux;
            }

            
        }
        
        public Cliente Cobrar()
        {
            Cliente aux;
            if (CajaPrincipal.Ver() == null) { }
            aux = CajaPrincipal.Desencolar();
            ClientesCobrados.Encolar(aux.Nombre, aux.Importe);
            return aux;
        }
        public void AgregaCliente(Cliente cliente) // Metodo para procesar el cliente que nos venga como input
        {
            ClientesPorCobrar.Encolar(cliente.Nombre,cliente.Importe);
        } 
        public void Mostrar()
        {

        } // Necesitariamos alguna funcion que actualice la caja completa 
        public int DineroCobrado() 
        {
            Cola Caux = new Cola();
            int TotalCobrado = 0;
            Cliente N = ClientesCobrados.Desencolar();
            while (N != null)
            {
                Caux.Encolar(N.Nombre,N.Importe);
                TotalCobrado = TotalCobrado + N.Importe;
                N = ClientesCobrados.Desencolar();
            }
            N = Caux.Desencolar();
            while (N != null)
            {
                ClientesCobrados.Encolar(N.Nombre,N.Importe);
                N = Caux.Desencolar();
            }
            return TotalCobrado; 
        } // Funcion que nos calcula los Cliente.Importe iterando la lista ClientesCobrados
        public int CantidadClientesCobrados() 
        {
            Cola Caux = new Cola();
            int CantidadClientes = 0;
            Cliente N = ClientesCobrados.Desencolar();
            while (N != null)
            {
                Caux.Encolar(N.Nombre, N.Importe);
                CantidadClientes = CantidadClientes + 1;
                N = ClientesCobrados.Desencolar();
            }

            N = Caux.Desencolar();
            while (N!=null)
            {
                ClientesCobrados.Encolar(N.Nombre, N.Importe);
                N = Caux.Desencolar();
            }

            return CantidadClientes;
        } // Funcion que nos calcula los clientes iterando la lista ClientesCobrados
        public int DineroPorCobrar() 
        {
            Cola Caux = new Cola();
            int TotalPorCobrar = 0;
            Cliente N = ClientesPorCobrar.Desencolar();
            while (N != null)
            {
                Caux.Encolar(N.Nombre, N.Importe);
                TotalPorCobrar = TotalPorCobrar + N.Importe;
                N = ClientesPorCobrar.Desencolar();
            }
            N = Caux.Desencolar();
            while (N != null)
            {
                ClientesPorCobrar.Encolar(N.Nombre, N.Importe);
                N = Caux.Desencolar();
            }
            return TotalPorCobrar;
        } // Funcion que nos calcula los Cliente.Importe iterando la lista ClientesPorCobrar
        public int CantidadClientesPorCobrar () 
        {
            Cola Caux = new Cola();
            int CantidadClientesSinCobrar = 0;
            Cliente N = ClientesPorCobrar.Desencolar();
            while (N != null)
            {
                Caux.Encolar(N.Nombre, N.Importe);
                CantidadClientesSinCobrar = CantidadClientesSinCobrar + 1;
                N = ClientesPorCobrar.Desencolar();
            }

            N = Caux.Desencolar();
            while (N != null)
            {
                ClientesPorCobrar.Encolar(N.Nombre, N.Importe);
                N = Caux.Desencolar();
            }

            return CantidadClientesSinCobrar;
        } // Funcion que nos calcula los clientes iterando la lista ClientesPorCobrar
    }
    public class Supermercado // Lista de cajas
    {
        List<Caja> LC;
        public Supermercado() { LC = new List<Caja>(); } // Constructor
        public void AgregarCaja(int pNumeroCaja) // Agrega la caja con el nro determinado
        {
            try
            {
                LC.Add(new Caja());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void QuitarCaja()
        {

        }

    }






}
