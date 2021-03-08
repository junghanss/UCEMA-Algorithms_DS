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

namespace Pilas_Colas
{
    public partial class Form1 : Form
    {
        Pila Pila1; Pila Pila2; Pila Pila3;
        public Form1()
        {
            InitializeComponent();
            Pila1 = new Pila(); Pila2 = new Pila(); Pila3 = new Pila();

        }
        int d;
        private void Vencedor()
        {
            if (listBox3.Items.Count==d) { MessageBox.Show("Ganaste!!"); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                d = int.Parse(Interaction.InputBox("Ingrese un número de Discos: "));
                for (int x = d; x >= 1; x--) // Decremento de InputBox(d) hasta 1
                {
                    Pila1.Apilar(x);
                    listBox1.Items.Insert(0, x);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(Pila2.Ver()==null ||  Pila2.Ver().Size>Pila1.Ver().Size) // Valisa si el tamaño del disco a la pila que va es mayor que la de origen
                {
                    Pila2.Apilar(Pila1.Desapilar().Size);
                    var _v = listBox1.Items[0].ToString();
                    listBox2.Items.Insert(0, _v);
                    listBox1.Items.RemoveAt(0);
                }
                else { throw new MovimientoInvalidoException(); } 
            }
            catch (MovimientoInvalidoException ex) { MessageBox.Show(ex.Message); } // Atrapa el error personalizado por mal movimiento
            catch (NullReferenceException) { } // Atrapa error por algun apilar/desapilar null
            catch (Exception ex) { throw new Exception(ex.Message); } // Atrapa error general
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pila3.Ver() == null || Pila3.Ver().Size > Pila1.Ver().Size) // Valisa si el tamaño del disco a la pila que va es mayor que la de origen
                {
                    Pila3.Apilar(Pila1.Desapilar().Size);
                    var _v = listBox1.Items[0].ToString();
                    listBox3.Items.Insert(0, _v);
                    listBox1.Items.RemoveAt(0);
                    Vencedor();
                }
                else { throw new MovimientoInvalidoException(); }
            }
            catch (MovimientoInvalidoException ex) { MessageBox.Show(ex.Message); }
            catch (NullReferenceException) { }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pila1.Ver() == null || Pila1.Ver().Size > Pila2.Ver().Size) // Valisa si el tamaño del disco a la pila que va es mayor que la de origen
                {
                    Pila1.Apilar(Pila2.Desapilar().Size);
                    var _v = listBox2.Items[0].ToString();
                    listBox1.Items.Insert(0, _v);
                    listBox2.Items.RemoveAt(0);
                }
                else { throw new MovimientoInvalidoException(); }
            }
            catch (MovimientoInvalidoException ex) { MessageBox.Show(ex.Message); }
            catch (NullReferenceException) { }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pila3.Ver() == null || Pila3.Ver().Size > Pila2.Ver().Size) // Valida si el tamaño del disco a la pila que va es mayor que la de origen
                {
                    Pila3.Apilar(Pila2.Desapilar().Size);
                    var _v = listBox2.Items[0].ToString();
                    listBox3.Items.Insert(0, _v);
                    listBox2.Items.RemoveAt(0);
                    Vencedor();
                }
                else { throw new MovimientoInvalidoException(); }
            }
            catch (MovimientoInvalidoException ex) { MessageBox.Show(ex.Message); }
            catch (NullReferenceException) { }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pila1.Ver() == null || Pila1.Ver().Size > Pila3.Ver().Size) // Valisa si el tamaño del disco a la pila que va es mayor que la de origen
                {
                    Pila1.Apilar(Pila3.Desapilar().Size);
                    var _v = listBox3.Items[0].ToString();
                    listBox1.Items.Insert(0, _v);
                    listBox3.Items.RemoveAt(0);
                }
                else { throw new MovimientoInvalidoException(); }
            }
            catch (MovimientoInvalidoException ex) { MessageBox.Show(ex.Message); }
            catch (NullReferenceException) { }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pila2.Ver() == null || Pila2.Ver().Size > Pila3.Ver().Size) // Valisa si el tamaño del disco a la pila que va es mayor que la de origen
                {
                    Pila2.Apilar(Pila3.Desapilar().Size);
                    var _v = listBox3.Items[0].ToString();
                    listBox2.Items.Insert(0, _v);
                    listBox3.Items.RemoveAt(0);
                }
                else { throw new MovimientoInvalidoException(); }
            }
            catch (MovimientoInvalidoException ex) { MessageBox.Show(ex.Message); }
            catch (NullReferenceException) { }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }

    
    public class Pila
    {
        public Pila() { Primero = null; Ultimo = null; }

        //Disco CentinelaPrimero;           // Por si usaramos centinelas, Disco CentinelaUltimo;
        public Disco Primero { get; set; }  // Propiedad que nos devuelva el primero como variable interna
        public Disco Ultimo { get; set; }   // Propiedad que nos devuelva el ultimo
        public void Apilar(int pSize)       // No devuelve nada
        {
            try
            {
                Disco disco = new Disco(pSize); // Armamos un objeto nuevo para no tener que instanciar un disco varias veces en el cuerpo del código
                if (Primero == null) { Primero = disco; Ultimo = Primero; } // Caso 1: si esta vacia y tenemos que crear un disco
                else { Ultimo.Siguiente = disco; Ultimo = disco; }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public Disco CreaDisco() { return new Disco(int.Parse(Interaction.InputBox("Ingrese el tamaño del disco:"))); }
        
        public class PilaVacia :Exception
        { public override string Message => "La pila está vacía. Considere por favor agregar discos."; }
        public Disco Desapilar() // Devuelve un disco, el que será extraído de la pila
        {
            Disco _d=null; // Auxiliar que usaremos para almacenar al disco extraido
            try
            {
                if (Primero == Ultimo) // Caso 1: nos sirve tambien como comportamiento redundante si Primero==null, o sea no hay nada
                {
                    _d = Primero;
                    Primero = null;
                    Ultimo = null;
                }
                else    // Caso General: if(!(Primero == null)), es decir, si es distinto de null
                {
                    // Caso doble enlace: Disco aux = Ultimo.Anterior   --> despues metemos aux.Siguiente=null;
                    // Razonamiento mio: aux2=Primero ; for(int i; i<CantidadNodos();i++) {if(aux2.Siguiente.Siguiente=null){aux2.Siguiente=null;break;}   ; else{aux2 = aux2.Siguiente;} }
                    _d = Ultimo;
                    Ultimo = RetornaAnteUltimo(Primero);
                    Ultimo.Siguiente = null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return _d;
        }
        private Disco RetornaAnteUltimo(Disco pPrimerDisco) // Devuelve el anteultimo, nos sirve para Desapilar...
        {
            Disco _d = null;
            Disco _aux = null;
            try
            {
                if (pPrimerDisco != null && pPrimerDisco.Siguiente !=null)
                {
                    _aux = pPrimerDisco.Siguiente.Siguiente; // Auxiliar para almacenar el nodo dos casillas posterior
                    _d = pPrimerDisco; // Auxiliar base, es el nodo ingresado como parámetro
                    do
                    {
                        if (_aux == null) { break; } // Si en dos lugares es null; ya encontramos al anteultimo
                        else { _d = _d.Siguiente; _aux = _d.Siguiente.Siguiente; } // Caso general: avanza un casillero cada auxiliar para probar
                    }
                    while (true);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return _d;
        }
        public Disco Ver() // Devuelve el puntero al disco que se va a desapilar, (o sea, devuelve el ultimo disco sin desapilarlo)
        {
            return Ultimo;
        }

    }

    public class Disco
    {
        public Disco() { } // Para que lo instancien pasandole nada
        public Disco(int pSize, Disco pDisco=null) { Size = pSize; Siguiente = pDisco; } // Para que lo instancien pasandole tamaño solamente
        //public Disco(int pSize, Disco pDisco) { Size = pSize; Siguiente = pDisco; } //por si lo instanciamos tambien con un disco
        public int Size { get; set; }
        public Disco Siguiente { get; set; }
    }
    public class MovimientoInvalidoException: Exception
    {
        public override string Message => "Movimiento Inválido!";
    }

}
