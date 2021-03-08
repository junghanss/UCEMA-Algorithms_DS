using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Lista_DobleCircular
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        ListaDobleCircular L ;
        private void Mostrar(Nodo pPrimero) // Funcion para mostrar nodos en el ListView
        {   // Recorremos la lista desde el primero
            listView1.Items.Clear();
            int _cantidadNodos = L.ContadorNodos(pPrimero);  // Si es la cantidad es 0 equivale a que Nodo Primero() == null
            for(int i = 0 ; i < _cantidadNodos; i++)
            {
                // Notemos que la condición de corte del loop es la cantidad de nodos en sí misma...
                listView1.Items.Add(pPrimero.Id);
                pPrimero = pPrimero.Siguiente; 
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            L = new ListaDobleCircular();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) // Agregar al inicio
        {
            try
            {
                L.AgregarInicio(); Mostrar(L.Primero());
                dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Agregar al final
        {
            try
            {
                L.AgregarFinal(); Mostrar(L.Primero()); dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) // Insertar (*PRIMER CONSIGNA)
        {
            try
            {
                L.Insertar(int.Parse(Interaction.InputBox("Ingrese la posición a insertar el nodo: "))); Mostrar(L.Primero());
                dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Contador Nodos
        {
            try
            {
                MessageBox.Show(L.ContadorNodos(L.Primero()).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e) // Borrar al inicio
        {
            try
            {
                L.BorrarInicio(); Mostrar(L.Primero()); dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        private void button6_Click(object sender, EventArgs e) // Borrar al final
        {
            try
            {
                L.BorrarFinal(); Mostrar(L.Primero()); dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e) // Borrar por posicion
        {
            try
            {
                L.BorrarPosicion(int.Parse(Interaction.InputBox("Ingrese la posición del nodo a borrar: "))); Mostrar(L.Primero());
                dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e) // Borrrar Desde Hasta (*SEGUNDA CONSIGNA)
        {
            try
            {
                int posicion1 = int.Parse(Interaction.InputBox("Ingrese la primer posición: "));
                int posicion2 = int.Parse(Interaction.InputBox("Ingrese la segunda posición: "));
                L.BorrarDesdeHasta(posicion1, posicion2); Mostrar(L.Primero()); dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e) // Inserción de 10 nodos para testear
        {
            try
            {
                L.AgregarNodosTest(); Mostrar(L.Primero()); dataGridView1[0, 0].Value = L.ContadorNodos(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


    public class ListaDobleCircular
    {
        private Nodo CentinelaPrimero;
        private Nodo CentinelaUltimo;
        public ListaDobleCircular()
        {
            CentinelaPrimero = new Nodo("CentinelaPrimero", null, null);
            CentinelaUltimo = new Nodo("CentinelaUltimo", null, null);
        }
        public Nodo Primero() { return CentinelaPrimero.Siguiente; }
        public Nodo Ultimo() { return CentinelaUltimo.Siguiente; }
        private Nodo CreaNodo(Nodo pSiguiente = null, Nodo pAnterior = null) 
        {
            try
            {
                string _id = Interaction.InputBox("Node ID:");
                if(_id == "" || _id == " ") { throw new ArgumentException(); }
                return new Nodo(_id, pSiguiente, pAnterior);
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Error en el dato del nodo"); return null; }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }

        }
        public int ContadorNodos(Nodo pPrimero)
        {
            Nodo _temporal = pPrimero;
            int _contador = 0;
            if (pPrimero != null)
            {
                do
                {
                    _temporal = _temporal.Siguiente;
                    _contador++;
                } while (_temporal != pPrimero);
            }

            return _contador;
        }
        public Nodo RetornaNodoPosicionN(int pPosicion)
        {
            try
            {
                int _cantidadNodos = ContadorNodos(Primero());  // Almacenamos en una auxiliar el dato de la cantidad de nodos

                if (_cantidadNodos == 0) { return null; }       // Caso "Base": si no hay nodos, el resultado es null

                else
                {
                    // El Caso General se compone de varias posibilidades:
                    if (pPosicion < 0 || pPosicion >= _cantidadNodos) { return null; }  // Si la posición ingresada es negativa o excede el indice, el resultado es null
                    if (pPosicion == 0) { return Primero(); }   // Si la posición es cero, corresponde al nodo Primero()
                    else
                    {
                        // Si la posición ingresada cumple con las condiciones y no es cero, entonces buscamos al nodo correspondiente
                        Nodo _auxiliar = Primero();     // Almacenamos el dato del primer nodo (que es distinto de null)
                        for (int i = 1; i <= pPosicion; i++)
                        {
                            // Almacenamos el dato del nodo siguiente hasta que alcancemos la posicion ingresada
                            if (_auxiliar.Siguiente == null) { return Ultimo(); }    // Este condicional reemplaza el caso de que la posición devuelva IndexOutOfRange
                            _auxiliar = _auxiliar.Siguiente;
                        }
                        return _auxiliar; // Devolvemos el dato del nodo auxiliar que corresponde a la posición ingresada por el usuario
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }

        }        
        public void AgregarNodosTest()
        {
            // Función que agrega en una ejecución 8 nodos (ideal para hacer pruebas con otras funciones que requieren nodos)
            int _cantidadNodos = ContadorNodos(Primero());

            if (_cantidadNodos > 0) { CentinelaPrimero.Siguiente = CentinelaUltimo.Siguiente = null; } // Primero vaciamos la lista actual
            else
            {
                Nodo _aux0 = new Nodo("0",null,null);
                Nodo _aux1 = new Nodo("1", null, null);
                Nodo _aux2 = new Nodo("2", null, null);
                Nodo _aux3 = new Nodo("3", null, null);
                Nodo _aux4 = new Nodo("4", null, null);
                Nodo _aux5 = new Nodo("5", null, null);
                Nodo _aux6 = new Nodo("6", null, null);
                Nodo _aux7 = new Nodo("7", null, null);
                Nodo _aux8 = new Nodo("8", null, null);
                Nodo _aux9 = new Nodo("9", null, null);
                CentinelaPrimero.Siguiente = _aux0; CentinelaUltimo.Siguiente = _aux9;
                _aux0.Siguiente = _aux1; _aux0.Anterior = _aux9;
                _aux1.Siguiente = _aux2; _aux1.Anterior = _aux0;
                _aux2.Siguiente = _aux3; _aux2.Anterior = _aux1;
                _aux3.Siguiente = _aux4; _aux3.Anterior = _aux2;
                _aux4.Siguiente = _aux5; _aux4.Anterior = _aux3;
                _aux5.Siguiente = _aux6; _aux5.Anterior = _aux4;
                _aux6.Siguiente = _aux7; _aux6.Anterior = _aux5;
                _aux7.Siguiente = _aux8; _aux7.Anterior = _aux6;
                _aux8.Siguiente = _aux9; _aux8.Anterior = _aux7;
                _aux9.Siguiente = _aux0; _aux9.Anterior = _aux8;
            }

        }
        public void AgregarInicio()
        {
            // Agregar un nodo al inicio de la lista doble enlazada circular
            try
            {
                Nodo _auxiliarPrimero = Primero();  // En una variable nodo auxiliar almacenamos CentinelaPrimero.Siguiente (el primer nodo)

                if (_auxiliarPrimero == null) 
                {
                    // Caso Nº1: la lista no posee ningun nodo
                    Nodo _auxiliar = CreaNodo();    // Creamos el Nodo a insertar
                    CentinelaPrimero.Siguiente = _auxiliar;     // Primero() ahora es igual al nuevo nodo
                    CentinelaUltimo.Siguiente = _auxiliar;      // Ultimo() ahora es igual al nuevo nodo
                    _auxiliar.Siguiente = _auxiliar;    // Primer puntero circular 
                    _auxiliar.Anterior = _auxiliar;     // Segundo puntero circular
                    return;
                }
                else
                {   // Caso Nº2: la lista ya posee un nodo o más    
                    Nodo _auxiliar = CreaNodo();    // Creamos el Nodo a insertar
                    _auxiliar.Siguiente = _auxiliarPrimero;     // El nodo nuevo apunta al primero
                    _auxiliarPrimero.Anterior = _auxiliar;      // Hay bidireccionalidad entre el nuevo y el primero
                    CentinelaPrimero.Siguiente = _auxiliar;     // Primero() ahora es igual al nuevo nodo
                    Ultimo().Siguiente = CentinelaPrimero.Siguiente; // Primer puntero circular (cola de la lista)
                    _auxiliar.Anterior = Ultimo(); // Segundo puntero circular (cabeza de la lista)                                        
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void AgregarFinal()
        {
            // Agregar un nodo al final de la lista doble enlazada circular
            try
            {                
                Nodo _auxiliarPrimero = Primero(); // En una variable nodo auxiliar almacenamos CentinelaPrimero.Siguiente (el primer nodo)

                if (_auxiliarPrimero == null)   
                {
                    // Caso Nº1: la liste no posee ningun nodo
                    Nodo _auxiliar = CreaNodo();    // Creamos el Nodo a insertar
                    CentinelaPrimero.Siguiente = _auxiliar;     // Primero() ahora es igual al nuevo nodo
                    CentinelaUltimo.Siguiente = _auxiliar;      // Ultimo() ahora es igual al nuevo nodo
                    _auxiliar.Siguiente = _auxiliar;    // Primer puntero circular
                    _auxiliar.Anterior = _auxiliar;     // Segundo puntero circular
                    return;
                }
                else
                {
                    // Caso Nº2: la lista ya posee un nodo o más
                    Nodo _auxiliar = CreaNodo(); // Creamos el Nodo a Insertar
                    _auxiliar.Anterior = Ultimo();  // El nuevo nodo apunta al posterior
                    Ultimo().Siguiente = _auxiliar; // Hay bidireccionalidad entre el nuevo y el anterior
                    _auxiliar.Siguiente = _auxiliarPrimero;    // Primer puntero circular (cola de la lista)
                    _auxiliarPrimero.Anterior = _auxiliar;     // Segundo puntero circular (cabeza de la lista)
                    CentinelaUltimo.Siguiente = _auxiliar;  // Ultimo() ahora es igual al nuevo nodo
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void Insertar(int pPosicion) // Primer Consigna
        {
            // (PRIMER CONSIGNA) Insertar un nodo en la posición N cualesquiera de la lista que desee el usuario
            try
            {
                int _cantidadNodos = ContadorNodos(Primero());   // Almacenamos el dato de la cantidad de nodos en una auxiliar

                if (pPosicion < 0 || pPosicion >= _cantidadNodos && pPosicion != 0) { throw new IndexOutOfRangeException(); } // Caso Nº1: si la posición no cumple con las condiciones de rango, devolvemos la excepción IndexOutOfRange

                else if (pPosicion == 0) { AgregarInicio(); return; } // Caso Nº2: la N posición es la primera, se recurre al método de agregar al inicio
                               
                else if (pPosicion == _cantidadNodos - 1) { AgregarFinal(); return; } // Caso Nº3: la N posición es la última, se recurre al método de agregar al final

                else 
                {
                    // Caso General: la posición es N y cumple con las condiciones anteriores
                    Nodo _auxiliarNuevo = CreaNodo();   // Creamos el nodo Nuevo a insertar
                    Nodo _auxiliarN = RetornaNodoPosicionN(pPosicion);  // Almacenamos en una auxiliar el nodo de la posición N donde irá el nuevo
                    Nodo _auxiliarNAnterior = RetornaNodoPosicionN(pPosicion - 1);  // Almacenamos en una auxiliar el nodo anterior a la posición N
                    // Conectamos a continuación los punteros de manera bidireccional
                    _auxiliarNAnterior.Siguiente = _auxiliarNuevo;
                    _auxiliarNuevo.Anterior = _auxiliarNAnterior;
                    _auxiliarNuevo.Siguiente = _auxiliarN;
                    _auxiliarN.Anterior = _auxiliarNuevo;
                    return;
                }
            }
            catch (IndexOutOfRangeException ex) { MessageBox.Show(ex.Message,"Error en la posición ingresada"); }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Error"); }
        }
        public void BorrarInicio()
        {
            // Borrar un nodo al inicio de la lista
            try
            {
                Nodo _auxiliarPrimero = Primero(); // En una variable nodo auxiliar almacenamos CentinelaPrimero.Siguiente (el primer nodo)

                if (_auxiliarPrimero == null) { return; }   // Caso base que no haya nodos en la lista
                else
                {
                    // Caso general donde hay N nodos
                    if (ContadorNodos(Primero()) == 1) { CentinelaPrimero.Siguiente = CentinelaUltimo.Siguiente = null; return; }   // Caso excepcional que haya un solo nodo por borrar
                    else
                    {
                        _auxiliarPrimero.Siguiente.Anterior = Ultimo();     // Primer reasignacion puntero circular (cabeza de la lista)
                        Ultimo().Siguiente = _auxiliarPrimero.Siguiente;    // Segunda reasignacion puntero circular (cola de la lista)
                        CentinelaPrimero.Siguiente = _auxiliarPrimero.Siguiente; // Primero() ahora es el nodo anexo al borrado
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                  
            }

        }
        public void BorrarFinal()
        {
            // Borrar un nodo al final de la lista
            try
            {
                Nodo _auxiliarUltimo = Ultimo();

                if (_auxiliarUltimo == null) { return; } // Case base que no haya nodos en la lista
                else
                {
                    // Caso general donde hay N nodos
                    if (ContadorNodos(Primero()) == 1) { CentinelaUltimo.Siguiente = CentinelaPrimero.Siguiente = null; return; } // Caso excepcional que haya un solo nodo por borrar
                    else
                    {
                        _auxiliarUltimo.Anterior.Siguiente = Primero(); // Primer reasignacion puntero circular (cola de la lista)
                        Primero().Anterior = _auxiliarUltimo.Anterior;  // Segunda reasignacion puntero circular (cabeza de la lista)
                        CentinelaUltimo.Siguiente = _auxiliarUltimo.Anterior;   // Ultimo() ahora es el nodo anexo al borrado
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void BorrarPosicion(int pPosicion)
        {
            // Borrar un nodo de la posición N cualesquiera de la lista que desee el usuario 
            try
            {
                int _cantidadNodos = ContadorNodos(Primero()); // Almacenamos en una variable auxiliar la cantidad de nodos de la lista

                if (_cantidadNodos == 0) { return; } // Caso base en el que la lista está vacía (podríamos crear una excepción personalizada)

                else if (pPosicion < 0 || pPosicion >= _cantidadNodos && _cantidadNodos != 0) { throw new IndexOutOfRangeException(); } // Condiciones de la posición

                else if (pPosicion == 0) { BorrarInicio(); } // Caso en el que la posición es cero, se llama a la función BorrarInicio

                else if (pPosicion == _cantidadNodos - 1) { BorrarFinal(); } // Caso en el que la posición es la última de la lista, se llama a la función BorrarFinal

                else
                {
                    // Caso general para posición N
                    Nodo _auxiliarBorrar = RetornaNodoPosicionN(pPosicion); // Almacenamos en una auxiliar el nodo a borrar
                    Nodo _auxiliarAnterior = RetornaNodoPosicionN(pPosicion - 1);   // Almacenamos en una auxilair el nodo anterior al que se borrará
                    // Conectamos a continuación los punteros de manera bidireccional
                    _auxiliarAnterior.Siguiente = _auxiliarBorrar.Siguiente;    
                    _auxiliarBorrar.Siguiente.Anterior = _auxiliarAnterior;
                    //_auxiliarBorrar.Siguiente = _auxiliarBorrar.Anterior = null;
                }
            }
            catch (IndexOutOfRangeException ex) { MessageBox.Show(ex.Message, "Error en la posición ingresada"); }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Error"); }

        }
        public void BorrarDesdeHasta(int pPosicion1, int pPosicion2) // Segunda Consigna
        {
            // Borrar uno o más nodos desde una posición hasta otra
            try
            {
                int _cantidadNodos = ContadorNodos(Primero()); // Almacenamos en una variable auxiliar la cantidad de nodos de la lista

                if (pPosicion1 < 0 || pPosicion1 > pPosicion2 || pPosicion1 > _cantidadNodos -1 || pPosicion2 < 0 || pPosicion2 > _cantidadNodos-1) 
                { throw new IndexOutOfRangeException(); } // Condiciones de salida para las posiciones ingresadas por el usuario. Con el incumplimiento se arroja excepción IndexOutOfRange

                else if (pPosicion1 == pPosicion2) { BorrarPosicion(pPosicion1); } // Posiciones Iguales

                else if(pPosicion1 == 0 && pPosicion2 == _cantidadNodos - 1) // Posiciones Cero y Ultima
                { 
                    CentinelaPrimero.Siguiente = CentinelaUltimo.Siguiente = null; // Se borra la lista completa
                } 

                else if(pPosicion1 == 0 && pPosicion2 != _cantidadNodos - 1) // Posiciones Cero y N
                {
                    // Se borra desde el primer nodo hasta el N inclusive.
                    Nodo _auxiliarSiguiente = RetornaNodoPosicionN(pPosicion2 + 1); // Almacenamos en una variable auxiliar al nodo siguiente al N
                    _auxiliarSiguiente.Anterior = Ultimo();     // Primer puntero circular (cabeza de la lista)
                    Ultimo().Siguiente = _auxiliarSiguiente;    // Segundo puntero circular (cola de la lista)
                    CentinelaPrimero.Siguiente = _auxiliarSiguiente;    // Primero() ahora es el nodo siguiente al N borrado
                }   

                else if(pPosicion1 != 0 && pPosicion2 == _cantidadNodos -1) // N y Ultima
                {    
                    // Se borra desde el nodo N hasta el último inclusive.
                    Nodo _auxiliarAnterior = RetornaNodoPosicionN(pPosicion1 - 1);  // Almacenamos en una variable auxiliar al nodo anterior al N
                    _auxiliarAnterior.Siguiente = Primero();    // Primer puntero circular (cola de la lista)
                    Primero().Anterior = _auxiliarAnterior;     // Segundo puntero circular (cabeza de la lista)
                    CentinelaUltimo.Siguiente = _auxiliarAnterior;  // Ultimo() ahora es el nodo anterior al N borrado                    
                }

                else // N y N
                {
                    // Se borra desde el nodo N hasta N inclusive.
                    Nodo _auxiliarAnterior1 = RetornaNodoPosicionN(pPosicion1 - 1); // Almacenamos en una variable auxiliar al nodo anterior al N1 (limite inferior)
                    Nodo _auxiliarSiguiente2 = RetornaNodoPosicionN(pPosicion2 + 1); // Almacenamos en una variable auxiliar al nodo siguiente al N2 (limite superior)
                    _auxiliarAnterior1.Siguiente = _auxiliarSiguiente2; 
                    _auxiliarSiguiente2.Anterior = _auxiliarAnterior1;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


    }

    public class Nodo
    {   // Clase autoreferenciada
        public Nodo(string pId, Nodo pSiguiente, Nodo pAnterior)
        {   //Constructor
            Id = pId;
            Siguiente = pSiguiente;
            Anterior = pAnterior;
        }
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }
    }
}
