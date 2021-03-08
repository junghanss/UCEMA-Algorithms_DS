using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Listas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListaSimpleEnlazada L;
        private void Form1_Load(object sender, EventArgs e)
        {
            L = new ListaSimpleEnlazada();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Mostrar(Nodo pPrimero)
        {/*Queremos recorrer la lista desde el primero*/
            VentanaLista.Items.Clear();
            while (pPrimero != null)
            {
                VentanaLista.Items.Add(pPrimero.Id);
                pPrimero = pPrimero.Siguiente;
            }

        }

        private void button1_Click(object sender, EventArgs e) // Agregar al final
        {
            try
            {
                L.AgregarFinal(); Mostrar(L.Primero());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void button2_Click(object sender, EventArgs e) // Agregar al principio
        {
            try
            {
                L.AgregarPrincipio(); Mostrar(L.Primero());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e) // Cantidad de nodos
        {
            try
            {
                MessageBox.Show(L.CantidadNodos().ToString(), "Cantidad de nodos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
          
        private void button4_Click(object sender, EventArgs e) // Retorna ID dato del Nodo Posicion N
        {
            try
            {
                var x = Interaction.InputBox("Posicion");
                if (!(int.TryParse(x, out int z)))
                { throw new Exception("Error en el ingreso !!1uno"); }
                MessageBox.Show(L.RetornaNodoPosN(z).Id, "Nodo ID");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                L.Insertar(int.Parse(Interaction.InputBox("Posicion:"))); Mostrar(L.Primero());
                //MessageBox.Show(L.Ultimo().Id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        } // Insertar

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                L.BorrarPrincipio(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        } // Borrar principio

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                L.BorrarFin(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        } // Borrar final

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var x = int.Parse(Interaction.InputBox("Posicion"));
                L.BorrarPosicionN(x); Mostrar(L.Primero());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        } // Borrar Posicion N

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                bool resultado = L.BuscarId_N(Interaction.InputBox("Id: ")); MessageBox.Show(resultado.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        } // Buscar ID dato Posicion N
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                L.Invertir(int.Parse(Interaction.InputBox("Posicion: "))); Mostrar(L.Primero());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        } // Swap N Posterior

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                L.BorrarDesde_Hasta_Posicion(int.Parse(Interaction.InputBox("ID Nº1 - Desde: ")), int.Parse(Interaction.InputBox("ID Nº2 - Hasta: ")));
                Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        } // Borrar Rango (desde hasta)

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                L.BorrarId(Interaction.InputBox("ID a borrar:"));
                Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        } // Borrar Nodo por ID Dato

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Cantidad de cambios realizados: " + L.Ordenar_Ascendente().ToString(), "Resultado"); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        } // Orden Ascendente; burbujeo corto

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Cantidad de cambios realizados: " + L.Ordenar_Descendente().ToString(), "Resultado"); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        } // Orden Descendente; burbujeo corto

        private void button15_Click(object sender, EventArgs e) // Swap N Anterior
        {
            try
            {
                L.InvertirAnterior(int.Parse(Interaction.InputBox("Ingrese la Posicion:"))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e) // Swap N con N
        {
            try
            {
                L.InvertirN(int.Parse(Interaction.InputBox("Ingrese una posición: ")), int.Parse(Interaction.InputBox("Ingrese una posición: "))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button17_Click(object sender, EventArgs e) // Nodos para Testear
        {
            try
            {
                L.AgregarNodosTest(); Mostrar(L.Primero());
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                L.CambiarDato(int.Parse(Interaction.InputBox("Ingrese la posición del nodo a seleccionar:"))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        } // Cambiar parámetro ID de un Nodo

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                L.Clear(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        } // Clear: Borra TODOS los elementos de la lista
    }
    public class ListaSimpleEnlazada
    {
        private Nodo CentinelaPrimero;
        private Nodo CentinelaUltimo;
        public ListaSimpleEnlazada()
        {
            CentinelaPrimero = new Nodo("P", null);
            CentinelaUltimo = new Nodo("U", null);
        }

        #region "desarrolladas"
        public Nodo Primero() { return CentinelaPrimero.Siguiente; }
        public Nodo Ultimo() { return CentinelaUltimo.Siguiente; }
        private Nodo CreaNodo(Nodo pSiguiente = null) { return new Nodo(Interaction.InputBox("Nodo ID: "), pSiguiente); }
        public void AgregarFinal()
        {
            if (Primero() == null)
            {   /*No hay nodos*/
                CentinelaPrimero.Siguiente = CreaNodo();
                CentinelaUltimo.Siguiente = CentinelaPrimero.Siguiente;
            }
            else
            {
                /*Hay nodos*/
                Nodo _auxNodoUltimoActual = CentinelaUltimo.Siguiente;
                CentinelaUltimo.Siguiente = CreaNodo();
                _auxNodoUltimoActual.Siguiente = CentinelaUltimo.Siguiente; /*Le metemos el nodo nuevito a la var. auxiliar*/
            }
        }
        public void AgregarPrincipio()
        {
            if (Primero() == null)
            {   /*No hay nodos*/
                CentinelaPrimero.Siguiente = CreaNodo();
                CentinelaUltimo.Siguiente = CentinelaPrimero.Siguiente;                
            }
            else
            {
                /*Hay nodos*/
                //Nodo _auxNodoPrimeroActual = CentinelaPrimero.Siguiente;
                CentinelaPrimero.Siguiente = CreaNodo(CentinelaPrimero.Siguiente);
            }
        }
        public void AgregarNodosTest() 
        {
            // Agrega 7 nodos numerados de 0 a 6 para hacer backtesting
            CentinelaPrimero.Siguiente = new Nodo("0",null);
            CentinelaPrimero.Siguiente.Siguiente = new Nodo("1", null);
            CentinelaPrimero.Siguiente.Siguiente.Siguiente = new Nodo("2", null);
            CentinelaPrimero.Siguiente.Siguiente.Siguiente.Siguiente = new Nodo("3", null);
            CentinelaPrimero.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente = new Nodo("4", null);
            CentinelaPrimero.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente = new Nodo("5", null);
            CentinelaPrimero.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente = new Nodo("6", null);
            CentinelaUltimo.Siguiente = CentinelaPrimero.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente;
        }
        public int CantidadNodos()
        {
            return Recu_CantidadNodos(Primero());
        }
        private int Recu_CantidadNodos(Nodo pNodo)
        {
            int _r;
            if (pNodo == null) { _r = 0; }
            else if (pNodo.Siguiente == null) { _r = 1; }
            else { _r = Recu_CantidadNodos(pNodo.Siguiente) + 1; }
            return _r;
        }
        public Nodo RetornaNodoPosN(int pPosicion)
        {
            //int _auxPos = 0;
            Nodo _rta = null;
            //Lista Vacia:
            if (Primero() != null)
            {
                // Asumimos retornar la posición 0 si el parámetro (posicion) ingresado es menor (como error) o igual a cero
                if (pPosicion <= 0)
                { _rta = Primero(); }
                // Asumimos retornar la última posición si la posición solicitada supera o coincide con el indice maximo
                else if (pPosicion >= CantidadNodos() - 1) //cantidad-1 por el (0,n) indice
                { _rta = Ultimo(); }
                else // Relacion lineal entre el índice y siguiente
                {
                    _rta = Primero();
                    for (int i = 0; i < pPosicion; i++)
                    {
                        _rta = _rta.Siguiente;
                    }
                }
            }
            return _rta;
        }
        public void Insertar(int pPosicion)
        {
            Nodo _aux = RetornaNodoPosN(pPosicion);
            // Caso 1: Lista vacia
            if (_aux == null)
            { AgregarPrincipio(); }
            // Caso 2: 
            else
            {
                Nodo _auxNodo = (pPosicion <= 0 ? CentinelaPrimero : _aux);
                _auxNodo.Siguiente = CreaNodo(_auxNodo.Siguiente);
                if (pPosicion >= CantidadNodos()) { CentinelaUltimo.Siguiente = _aux.Siguiente; }
            }
        }
        public void BorrarPrincipio()
        {
            if (Primero() != null)
            {
                CentinelaPrimero.Siguiente = CentinelaPrimero.Siguiente.Siguiente;
            }
        }
        public void BorrarFin()
        {
            Nodo _aux1 = null;
            if (Ultimo() != null)
            {
                if (CantidadNodos() == 1) { BorrarPrincipio(); }
                else
                {
                    _aux1 = Primero();
                    for (int i = 1; i < CantidadNodos() - 1; i++)
                    {
                        _aux1 = _aux1.Siguiente;
                    }
                    CentinelaUltimo.Siguiente = _aux1;
                    _aux1.Siguiente = null;
                }
            }
            else { return; }
            
        }
        public void Clear()
        {
            // Erases all the elements of a list
            CentinelaPrimero.Siguiente = null;
            CentinelaUltimo.Siguiente = null;
        }
        public void BorrarPosicionN(int pPosicion)
        {
            Nodo _aux2 = null;
            if (Primero() != null)
            {
                if (CantidadNodos() == 1 || pPosicion == 0) { BorrarPrincipio(); }
                else
                {
                    _aux2 = RetornaNodoPosN(pPosicion - 1);
                    if (_aux2.Siguiente.Siguiente == null) { BorrarFin(); }
                    else { _aux2.Siguiente = RetornaNodoPosN(pPosicion + 1); }
                }
            }
            return;
        }
        public void BorrarDesde_Hasta_Posicion(int Posicion1, int Posicion2)
        {
            if (Posicion1 == Posicion2) { BorrarPosicionN(Posicion1); } // Caso con posiciones iguales, o sea, unica posicion
            Nodo _aux = RetornaNodoPosN(Posicion1 - 1); // Casos con posiciones distintas: serán 3 casos
            Nodo _aux2 = RetornaNodoPosN(Posicion2 + 1);
            Nodo _auxPrimero = RetornaNodoPosN(Posicion1);
            Nodo _auxUltimo = RetornaNodoPosN(Posicion2);
            if (_auxUltimo == Ultimo()) { _aux.Siguiente = null; } //Caso para si posicion2 es el ultimo nodo
            else if (_auxPrimero == CentinelaPrimero.Siguiente) { CentinelaPrimero.Siguiente = _aux2; } // Caso para si posicion1 es el primer nodo
            else { _aux.Siguiente = _aux2; } //Caso general
        }
        public void Invertir(int pNodo)
        {
            var QNodos = CantidadNodos();

            if (pNodo >= QNodos - 1 || pNodo < 0) return;
            // Caso Principal
            if (pNodo == 0)
            {
                Nodo _auxPrimero = Primero();
                Nodo _auxNodoPos1 = RetornaNodoPosN(1);
                CentinelaPrimero.Siguiente = _auxNodoPos1;
                _auxPrimero.Siguiente = _auxNodoPos1.Siguiente;
                _auxNodoPos1.Siguiente = _auxPrimero;
                return;
            }
            // Caso Ultimo
            if (pNodo == QNodos - 2)
            {
                Nodo _auxAnterior = RetornaNodoPosN(pNodo - 1);
                Nodo _auxNodo = RetornaNodoPosN(pNodo);
                _auxAnterior.Siguiente = Ultimo();
                _auxNodo.Siguiente.Siguiente = _auxNodo;
                CentinelaUltimo.Siguiente = _auxNodo.Siguiente;
                _auxNodo.Siguiente = null;
                return;
            }
            // Caso General (medio de la lista)
            Nodo _auxAnteriorNodo = RetornaNodoPosN(pNodo - 1);
            Nodo _auxNodoActual = RetornaNodoPosN(pNodo);
            Nodo _auxNodoSiguiente = _auxNodoActual.Siguiente;

            _auxNodoActual.Siguiente = _auxNodoActual.Siguiente.Siguiente;
            _auxNodoSiguiente.Siguiente = _auxNodoActual;
            _auxAnteriorNodo.Siguiente = _auxNodoSiguiente;



        }
        public void InvertirAnterior(int pNodo)
        {
            var QNodos = CantidadNodos();

            if (pNodo > QNodos - 1 || pNodo <= 0 || Primero() == null) { } // Tres posibles casos de error (podriamos llamar a una excepcion)

            if (pNodo == 1) // Caso con Primero()
            {
                Nodo auxiliar = Primero();
                CentinelaPrimero.Siguiente = Primero().Siguiente; // o = CentinelaPrimero.Siguiente.Siguiente
                auxiliar.Siguiente = Primero().Siguiente;
                Primero().Siguiente = auxiliar;
                if (Primero().Siguiente.Siguiente == null) { CentinelaUltimo.Siguiente = auxiliar; }
            }

            if (pNodo == QNodos - 1 && pNodo != 1) // Caso con Ultimo() [distinto de 1, si hay solo dos es caso anterior]
            {
                Nodo auxiliar = RetornaNodoPosN(pNodo);
                Nodo auxiliar2 = RetornaNodoPosN(pNodo - 1);
                Nodo auxiliar3 = RetornaNodoPosN(pNodo - 2);
                CentinelaUltimo.Siguiente = auxiliar2;
                auxiliar2.Siguiente = null;
                auxiliar.Siguiente = auxiliar2;
                auxiliar3.Siguiente = auxiliar;
            }

            else // Caso general del medio
            {
                Nodo auxiliar_anterior = RetornaNodoPosN(pNodo - 1);
                Nodo auxiliar_actual = RetornaNodoPosN(pNodo);
                Nodo auxiliar_anterior2 = RetornaNodoPosN(pNodo - 2);
                auxiliar_anterior.Siguiente = auxiliar_actual.Siguiente;
                auxiliar_actual.Siguiente = auxiliar_anterior;
                auxiliar_anterior2.Siguiente = auxiliar_actual;
            }

        }
        public bool BuscarId_N(string pId_Nodo)
        {
            Nodo _rta = Primero();
            int contador = 0;
            for (int i = 0; i < CantidadNodos() - 1; i++)
            {
                _rta = _rta.Siguiente;
                if (_rta.Id == pId_Nodo) { contador++; }

            }
            if (contador == 0) { return false; }
            return true;
        }
        public int Ordenar_Ascendente()
        {
            bool _cambio = false;
            int _largo = CantidadNodos();
            int _contador = 0;
            for (int i = 0; i < _largo; i++)
            {
                for (int k = 0; k < _largo - 1 - i; k++)
                {
                    Nodo _aux = RetornaNodoPosN(k);
                    if (int.Parse(_aux.Siguiente.Id) < int.Parse(_aux.Id)) { Invertir(k); _cambio = true; _contador++; }
                }
                if (!_cambio) { break; }
            }
            return _contador;
        }
        public int Ordenar_Descendente()
        {
            bool _cambio = false;
            int _contador = 0;
            int _largo = CantidadNodos();
            for (int i = 0; i <= _largo; i++)
            {
                for (int k = 0; k < _largo - 1; k++)
                {
                    Nodo aux = RetornaNodoPosN(k);
                    if (int.Parse(aux.Siguiente.Id) > int.Parse(aux.Id)) { Invertir(k); _cambio = true; _contador++; }
                }
                if (!_cambio) { break; }
            }
            return _contador;
        }
        public void BorrarId(string pId)
        {
            bool _existe = BuscarId_N(pId);

            if (_existe == true)
            {
                int _contador;
                int _cantidadNodos = CantidadNodos();
                Nodo _aux = Primero();
                for (_contador = 0; _contador < _cantidadNodos; _contador++)
                {
                    if (_aux.Id == pId) { BorrarPosicionN(_contador); }
                    _aux = _aux.Siguiente;
                }
            }
            else { return; /*Deberia devolver mensaje NO hay nodos con ID si BuscaId es false*/ }
        } 
        public void InvertirN(int pPosicion1, int pPosicion2)
        {
            Nodo _auxiliarPrimero = Primero();
            Nodo _auxiliarUltimo = Ultimo();
            Nodo _auxiliarN1 = null;
            Nodo _auxiliarN2 = null;
            int _auxPosicionUltimo = CantidadNodos() - 1;
            // Caso Exception: el user nos pasa la misma posicion! 
            if (pPosicion1 == pPosicion2) { return; }
            
            // Caso 1: swap entre Primero() y Ultimo()
            if (pPosicion1 == 0 && pPosicion2 == _auxPosicionUltimo)
            {
                Nodo _auxAnteUltimo = RetornaNodoPosN(_auxPosicionUltimo - 1);
                CentinelaUltimo.Siguiente = _auxiliarPrimero;
                _auxAnteUltimo.Siguiente = _auxiliarPrimero;
                _auxiliarUltimo.Siguiente = _auxiliarPrimero.Siguiente;
                CentinelaPrimero.Siguiente = _auxiliarUltimo;                
            }

            // Caso 2: swap entre Primero() y N
            if (pPosicion1 == 0 && pPosicion2 != _auxPosicionUltimo)
            {
                _auxiliarN2 = RetornaNodoPosN(pPosicion2);
                Nodo _auxiliarN2Anterior = RetornaNodoPosN(pPosicion2 - 1);
                _auxiliarN2Anterior.Siguiente = _auxiliarPrimero;
                _auxiliarN2.Siguiente = _auxiliarPrimero.Siguiente; // o Primero().Siguiente (ya que Primero() sigue siendo el original)
                _auxiliarPrimero.Siguiente = _auxiliarN2.Siguiente;
                CentinelaPrimero.Siguiente = _auxiliarN2;               
            }

            // Caso 3: swap entre N y Ultimo()
            if (pPosicion1 != 0 && pPosicion2==_auxPosicionUltimo)
            {
                _auxiliarN1 = RetornaNodoPosN(pPosicion1);
                Nodo _auxiliarN1Anterior = RetornaNodoPosN(pPosicion1 - 1);
                Nodo _auxAnteUltimo = RetornaNodoPosN(_auxPosicionUltimo - 1);
                _auxiliarN1Anterior.Siguiente = _auxiliarUltimo;
                _auxiliarUltimo.Siguiente = _auxiliarN1.Siguiente;
                _auxAnteUltimo.Siguiente = _auxiliarN1;
                CentinelaUltimo.Siguiente = _auxiliarN1;
                _auxiliarN1.Siguiente = null;
            }

            // Caso 4: swap entre N y N
            else
            {
                _auxiliarN1 = RetornaNodoPosN(pPosicion1);
                Nodo _auxiliarN1Anterior = RetornaNodoPosN(pPosicion1 - 1);
                Nodo _auxiliarN1Siguiente = RetornaNodoPosN(pPosicion1 + 1);
                _auxiliarN2 = RetornaNodoPosN(pPosicion2);
                Nodo _auxiliarN2Anterior = RetornaNodoPosN(pPosicion2 - 1);
                Nodo _auxiliarN2Siguiente = RetornaNodoPosN(pPosicion2 + 1);
                _auxiliarN2Anterior.Siguiente = _auxiliarN1;
                _auxiliarN1Anterior.Siguiente = _auxiliarN2;
                _auxiliarN1.Siguiente = _auxiliarN2Siguiente;
                _auxiliarN2.Siguiente = _auxiliarN1Siguiente;
            }
        }
        public void CambiarDato(int pPosicion)
        {
            // Método para cambiar el parámetro ID del Nodo seleccionado
            Nodo _auxAnterior = RetornaNodoPosN(pPosicion - 1);
            Nodo _auxPosterior = RetornaNodoPosN(pPosicion + 1);
            Nodo _auxiliar = CreaNodo();
            _auxAnterior.Siguiente = _auxiliar;
            _auxiliar.Siguiente = _auxPosterior;
        }

        #endregion


        #region "en desarrollo"





        #endregion



    }

    public class Nodo //Clase autoreferenciada
    {
        public Nodo(string pId, Nodo pSiguienteNodo) 
        { Id = pId; Siguiente = pSiguienteNodo; } //Constructor
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }
    }

}


