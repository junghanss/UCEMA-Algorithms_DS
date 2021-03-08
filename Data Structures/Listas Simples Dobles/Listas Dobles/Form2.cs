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

namespace Listas_Dobles
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ListaDobleEnlazada L = new ListaDobleEnlazada();
        private void Mostrar(Nodo pPrimero)
        {   /*Queremos recorrer la lista desde el primero*/
            listView.Items.Clear();
            while (pPrimero != null)
            {
                listView.Items.Add(pPrimero.Id);
                pPrimero = pPrimero.Siguiente;
            }
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e) // Agregar final
        {
            try
            {
                L.AgregarFinal(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e) // Agregar principio
        {
            try
            {
                L.AgregarPrincipio(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e) // Retorna Nodo Posicion N
        {
            try
            {
                MessageBox.Show(L.RetornaNodoN(int.Parse(Interaction.InputBox("Posición del Nodo:"))).Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button4_Click(object sender, EventArgs e) // Cantidad de Nodos
        {
            try
            {
                MessageBox.Show(L.CantidadNodos().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e) // Insertar
        {
            try
            {
                L.Insertar(int.Parse(Interaction.InputBox("Posicion a insertar un nodo:"))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ¡Pusiste cualquier cosa!");
            }

        }

        private void button6_Click(object sender, EventArgs e) // Borrar Inicio
        {
            try
            {
                L.BorrarInicio(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button7_Click(object sender, EventArgs e) // Borrar Fin
        {
            try
            {
                L.BorrarFin(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e) // Invertir Posterior
        {
            try
            {
                L.InvertirPosterior(int.Parse(Interaction.InputBox("Posicion"))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button9_Click(object sender, EventArgs e) // Invertir Anterior
        {
            try
            {
                L.InvertirAnterior(int.Parse(Interaction.InputBox("Posicion"))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button10_Click(object sender, EventArgs e) // Borrar Posicion N
        {
            try
            {
                L.BorrarPosicionN(int.Parse(Interaction.InputBox("Posicion"))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e) // Borrar desde hasta
        {
            try
            {
                L.BorrarDH(int.Parse(Interaction.InputBox("Posicion 1:")), int.Parse(Interaction.InputBox("Posicion 2:"))) ; Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ¡Volve a intentarlo!");
            }
        }

        private void button12_Click(object sender, EventArgs e) // Carga de Nodos para Prueba
        {
            L.NumerosPrueba();Mostrar(L.Primero());
        }

        private void button13_Click(object sender, EventArgs e) // Buscar ID Retorna BOOL
        {
            try
            {
                MessageBox.Show(L.BuscaId(Interaction.InputBox("ID a buscar:")).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e) // Borrar por ID
        {
            try
            {
                L.BorrarId(Interaction.InputBox("ID Nodo a borrar:")); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e) // Burbuja Corto por Orden Ascendente
        {
            try
            {
                MessageBox.Show("La cantidad de cambios realizados fue: " + L.BurbujaCortoAscendente().ToString()); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button16_Click(object sender, EventArgs e) // Burbuja Corto por Orden Descendente y con contador
        {
            try
            {
                MessageBox.Show("La cantidad de cambios realizados fue: " + L.BurbujaCortoDescendente().ToString()); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button17_Click(object sender, EventArgs e) // Insertion Sort IN LINE con SwapAnterior
        {
            try
            {
                MessageBox.Show("La cantidad de cambios realizados fue: " + L.InsertionSort().ToString()); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                L.Swap2Posiciones(int.Parse(Interaction.InputBox("Ingrese una posición: ")), int.Parse(Interaction.InputBox("Ingrese una posición: "))); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button19_Click(object sender, EventArgs e) // Borra todos los elementos de la lista
        {
            try
            {
                L.Clear(); Mostrar(L.Primero());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button20_Click(object sender, EventArgs e) // Cambia el "dato" (string pID) del nodo seleccionado
        {
            try
            {
                L.CambiarDato(int.Parse(Interaction.InputBox("Ingrese el nodo a modificar el dato: "))); Mostrar(L.Primero()); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class ListaDobleEnlazada
    {
        private Nodo CentinelaPrimero;  // Nodo auxiliar centinela (apunta al primero)
        private Nodo CentinelaUltimo;   // Nodo auxiliar centinela (apunta al ultimo)
        public ListaDobleEnlazada()
        {
            CentinelaPrimero = new Nodo("CentinelaPrimero", null, null);
            CentinelaUltimo = new Nodo("CentinelaUltimo", null, null);
        }

        public Nodo Primero() { return CentinelaPrimero.Siguiente; }
        public Nodo Ultimo() { return CentinelaUltimo.Siguiente; }
        private Nodo CreaNodo(Nodo pSiguiente = null, Nodo pAnterior = null) { return new Nodo(Interaction.InputBox("Node ID:"),pSiguiente,pAnterior); }
        public void AgregarFinal()
        {
            Nodo _auxUltimo = CentinelaUltimo.Siguiente;
            if (_auxUltimo == null) // Caso cero: No hay nodos
            { CentinelaPrimero.Siguiente = CentinelaUltimo.Siguiente = CreaNodo();  }

            else // Caso general: N nodos
            {
                Nodo _aux = CreaNodo();
                _auxUltimo.Siguiente = _aux;
                _aux.Siguiente = null;
                _aux.Anterior = _auxUltimo;
                CentinelaUltimo.Siguiente = _aux;
            }
        }
        public void AgregarPrincipio()
        {
            Nodo _auxPrimero = Primero();

            if (_auxPrimero == null)    // Caso cero: No hay nodos
            { CentinelaPrimero.Siguiente = CreaNodo(); CentinelaUltimo.Siguiente = CentinelaPrimero.Siguiente; }
            else    // Caso general: N nodos
            {
                _auxPrimero.Anterior = CreaNodo();
                _auxPrimero.Anterior.Siguiente = _auxPrimero;
                CentinelaPrimero.Siguiente = _auxPrimero.Anterior;
            }
        }
        public Nodo RetornaNodoN(int pPosicion)
        {
            int _cantidadNodos = CantidadNodos();
            if (_cantidadNodos == 0) { return null; }
            else
            {
                Nodo _aux = Primero();
                if (pPosicion <= 0) { return _aux; }
                else
                {
                    for (int i = 1; i <= pPosicion; i++)
                    {
                        if (_aux.Siguiente == null) { return Ultimo(); } // Este condicional reemplaza el caso de que la posición devuelva IndexOutOfRange
                        _aux = _aux.Siguiente;
                    }

                    return _aux;
                }
            }

        } 
        public int RetornaPosicionNodoUnico(string pId)
        {
            bool _existe = BuscaId(pId);
            int _contador;
            if (_existe == true)
            {
                int _cantidadNodos = CantidadNodos();
                Nodo _aux = Primero();
                for (_contador = 0; _contador < _cantidadNodos; _contador++)
                {
                    if(_aux.Id == pId) { break; }
                    _aux = _aux.Siguiente;
                }
            }
            else { _contador = int.Parse(_existe.ToString()); return _contador;}
            return _contador;

        }
        private int CantidadNodosRecursiva(Nodo pNodo) // Cuerpo recursivo para la función CantidadNodos
        {
            if (pNodo == null) { return 0; }
            else
            {
                pNodo = pNodo.Anterior;
                return 1 + CantidadNodosRecursiva(pNodo);
            }
        }
        public int CantidadNodos()  
        {
            return CantidadNodosRecursiva(Ultimo());
        }
        public void Insertar(int pPosicion)
        {           
            int IndiceLista = CantidadNodos();
            if (pPosicion <= 0) { AgregarPrincipio(); } // Caso posicion OutOfRange negativa o cero
            else if (pPosicion >= IndiceLista) { AgregarFinal(); } // Caso posicion OutOfRange positiva o ultima posicion
            else
            {
                Nodo _aux = RetornaNodoN(pPosicion);
                Nodo _auxnuevo = CreaNodo();
                _aux.Anterior.Siguiente = _auxnuevo;
                _auxnuevo.Anterior = _aux.Anterior;
                _aux.Anterior = _auxnuevo;
                _auxnuevo.Siguiente = _aux;               
            }

        }
        public void BorrarInicio()
        {
            if (Primero() != null)
            {
                if (CantidadNodos() == 1) { CentinelaPrimero.Siguiente = null ;CentinelaUltimo.Siguiente = null; }
                else
                {
                    CentinelaPrimero.Siguiente = CentinelaPrimero.Siguiente.Siguiente;
                    CentinelaPrimero.Siguiente.Anterior = null;
                }
                
            }
        }
        public void BorrarFin()
        {
            if (Primero() != null)
            {
                if (CantidadNodos() == 1) { CentinelaPrimero.Siguiente = null; CentinelaUltimo.Siguiente = null; }
                else
                {
                    CentinelaUltimo.Siguiente = CentinelaUltimo.Siguiente.Anterior;
                    CentinelaUltimo.Siguiente.Siguiente = null;
                }
            }
        }
        public void BorrarPosicionN(int pPosicion)
        {
            int _cantidadNodos = CantidadNodos();
            if (pPosicion < 0 || pPosicion >= _cantidadNodos) return;
            else if (pPosicion == 0) // Caso 1: Primer nodo
            {
                if (_cantidadNodos == 1) { BorrarInicio(); } // Para el caso particular de tener indice cero, pero una lista de 1 nodo...
                CentinelaPrimero.Siguiente = Primero().Siguiente;
                Primero().Anterior = null;
            }
            else if (pPosicion == _cantidadNodos - 1)
            {
                CentinelaUltimo.Siguiente = Ultimo().Anterior;
                Ultimo().Siguiente = null;
            }
            else
            {
                Nodo _aux = RetornaNodoN(pPosicion);
                _aux.Anterior.Siguiente = _aux.Siguiente;
                _aux.Siguiente.Anterior = _aux.Anterior;
            }
        }
        public void BorrarDH(int pPosicion1, int pPosicion2)
        {
            if (pPosicion1 == pPosicion2) { BorrarPosicionN(pPosicion1); } // Caso con posiciones iguales, o sea, unica posicion
            else if (pPosicion1 <= 0 && pPosicion2 >= CantidadNodos() - 1) { CentinelaPrimero.Siguiente = null; CentinelaUltimo.Siguiente = null; }
            else if (pPosicion1 > pPosicion2) { return; }
            else
            {
                Nodo _aux = RetornaNodoN(pPosicion1 - 1); // Casos con posiciones distintas: serán 3 casos
                Nodo _aux2 = RetornaNodoN(pPosicion2 + 1);
                Nodo _auxPrimero = RetornaNodoN(pPosicion1);
                Nodo _auxUltimo = RetornaNodoN(pPosicion2);
                if (_auxUltimo == Ultimo()) { _aux.Siguiente = null; } //Caso para si posicion2 es el ultimo nodo
                else if (_auxPrimero == CentinelaPrimero.Siguiente) { CentinelaPrimero.Siguiente = _aux2; _aux2.Anterior = null; } // Caso para si posicion1 es el primer nodo
                else { _aux.Siguiente = _aux2; _aux2.Anterior = _aux; } //Caso general
            }
        }
        public void InvertirPosterior(int pPosicion)
        {
            //Falta anotar que contemple el caso especial de 2 nodos!! 
            int _cantidadNodos = CantidadNodos();

            if (_cantidadNodos <= 1 || pPosicion>=_cantidadNodos-1 || pPosicion<0) { return; }

            else if (pPosicion == 0) // Caso 1: primer nodo
            {
                Nodo _auxP = Primero();
                CentinelaPrimero.Siguiente = Primero().Siguiente;
                _auxP.Siguiente = Primero().Siguiente;
                _auxP.Siguiente.Anterior = _auxP;
                _auxP.Anterior = Primero();
                Primero().Siguiente = _auxP;
                Primero().Anterior = null;
            }

            else if (pPosicion == _cantidadNodos - 2) // Caso 2: anteultimo nodo
            {
                Nodo _auxU = Ultimo();
                _auxU.Anterior.Anterior.Siguiente = Ultimo();
                CentinelaUltimo.Siguiente = _auxU.Anterior;
                _auxU.Anterior = Ultimo().Anterior;
                _auxU.Siguiente = Ultimo();
                Ultimo().Siguiente = null;
                Ultimo().Anterior = _auxU;
            }

            else // Caso General
            {
                Nodo _aux1 = RetornaNodoN(pPosicion);
                //Nodo _aux2 = RetornaNodoN(pPosicion + 1);
                _aux1.Siguiente = _aux1.Siguiente.Siguiente;
                _aux1.Siguiente.Anterior.Siguiente = _aux1;
                _aux1.Anterior.Siguiente = _aux1.Siguiente.Anterior;
                _aux1.Anterior.Siguiente.Anterior = _aux1.Anterior;
                _aux1.Siguiente.Anterior = _aux1;
                _aux1.Anterior = _aux1.Anterior.Siguiente;
            }
        }
        public void InvertirAnterior(int pPosicion)
        {
            int _cantidadNodos = CantidadNodos();
            if (_cantidadNodos <= 1 || pPosicion >= _cantidadNodos || pPosicion < 1) return;
            else if (pPosicion==1) // Caso 1: Nodo 1 (siguiente al primero)
            {
                Nodo _aux1 = RetornaNodoN(pPosicion);
                Nodo _aux0 = RetornaNodoN(pPosicion - 1);
                Nodo _aux2 = RetornaNodoN(pPosicion + 1);
                //CentinelaPrimero.Siguiente = _aux2;
                _aux0.Siguiente = _aux2;
                _aux1.Siguiente = _aux0;
                CentinelaPrimero.Siguiente = _aux1;
                _aux2.Anterior = _aux0;
                _aux0.Anterior = _aux1;
                _aux1.Anterior = null;
            }
            else if (pPosicion == _cantidadNodos - 1) // Caso 2: Nodo ultimo
            {
                Nodo _auxU = RetornaNodoN(pPosicion);
                Nodo _auxAU = RetornaNodoN(pPosicion - 1);
                Nodo _auxAAU = RetornaNodoN(pPosicion - 2);
                _auxAAU.Siguiente = _auxU;
                _auxU.Siguiente = _auxAU;
                _auxAU.Anterior = _auxU;
                _auxU.Anterior = _auxAAU;
                CentinelaUltimo.Siguiente = _auxAU;
                _auxAU.Siguiente = null;
            }
            else // Caso General
            {
                Nodo _auxMedio = RetornaNodoN(pPosicion);
                Nodo _auxAnt = RetornaNodoN(pPosicion - 1);
                Nodo _auxAnt2 = RetornaNodoN(pPosicion - 2);
                _auxAnt.Siguiente = _auxMedio.Siguiente;
                _auxMedio.Siguiente = _auxAnt;
                _auxAnt2.Siguiente = _auxMedio;
                _auxAnt.Siguiente.Anterior = _auxAnt;
                _auxAnt.Anterior = _auxMedio;
                _auxMedio.Anterior = _auxAnt2;
            }

        }
        public void NumerosPrueba()
        {
            Nodo pSiguiente = null;
            Nodo pAnterior = null;
            CentinelaPrimero.Siguiente = new Nodo(0.ToString(), pSiguiente, pAnterior);
            Nodo _auxP = Primero();
            _auxP.Siguiente = new Nodo(1.ToString(), pSiguiente, _auxP);
            _auxP.Siguiente.Siguiente = new Nodo(2.ToString(), pSiguiente, _auxP.Siguiente);
            _auxP.Siguiente.Siguiente.Siguiente = new Nodo(3.ToString(), pSiguiente, _auxP.Siguiente.Siguiente);
            _auxP.Siguiente.Siguiente.Siguiente.Siguiente = new Nodo(4.ToString(), pSiguiente, _auxP.Siguiente.Siguiente.Siguiente);
            _auxP.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente = new Nodo(5.ToString(), pSiguiente, _auxP.Siguiente.Siguiente.Siguiente.Siguiente);
            CentinelaUltimo.Siguiente = _auxP.Siguiente.Siguiente.Siguiente.Siguiente.Siguiente;
        } // Para cargar nodos rapido cuando testeamos
        public bool BuscaId(string pId)
        {
            int _cantidadNodos = CantidadNodos();
            Nodo _aux = null;
            bool flag = false;
            if (_cantidadNodos == 0) { return flag; }
            else
            {
                _aux = Primero();
                for (int i = 0; i < _cantidadNodos; i++)
                {
                    if (_aux.Id == pId) { flag = true; }
                    _aux = _aux.Siguiente;
                }
            }
            return flag;
        }                    
        public void BorrarId(string pId)
        {
            bool _existe = BuscaId(pId);
            
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
        public int BurbujaCortoAscendente()
        {
            int _cantidadNodos = CantidadNodos();
            bool _cambio;
            Nodo _aux = null;
            int _contador = 0;
            if (_cantidadNodos == 0 || _cantidadNodos == 1) { return _contador; }
            else
            {
               for (int i = 0; i < _cantidadNodos; i++)
                {
                    _cambio = false;
                    for (int k = 0; k < _cantidadNodos - 1 - i; k++) // cantidad - 1; y para reducir iteraciones - i 
                    {
                        _aux = RetornaNodoN(k);
                        if (int.Parse(_aux.Id) > int.Parse(_aux.Siguiente.Id)) { InvertirPosterior(k); _cambio = true; _contador ++; }
                        //_aux = _aux.Siguiente;
                    }
                    if (!_cambio) { break; }
                }
            }
            return _contador;
        }
        public int BurbujaCortoDescendente() // Retorna cantidad de cambios
        {
            int _cantidadNodos = CantidadNodos();
            Nodo _aux;
            bool _flag; // Para optimizar el burbujeo
            int _contador = 0;

            for(int i=0; i < _cantidadNodos; i++)
            {
                _flag = false;
                for(int k=0; k < _cantidadNodos - 1 - i; k++)
                {
                    _aux = RetornaNodoN(k);
                    if(int.Parse(_aux.Id) < int.Parse(_aux.Siguiente.Id)) { InvertirPosterior(k); _flag = true; _contador++; }
                }
                if (!_flag) { break; }
            }
            return _contador;
        }
        public int InsertionSort()
        {
            int _cantidadNodos = CantidadNodos();
            Nodo _aux = null;
            Nodo _auxAnterior = null;
            int _pPosicion = 0;
            int _contador = 0;

            for (int i=0; i<_cantidadNodos; i++)
            {
                _aux = RetornaNodoN(i); // dato
                _auxAnterior = RetornaNodoN(i - 1);
                _pPosicion = i;
                while (_pPosicion > 0 && int.Parse(_auxAnterior.Id) > int.Parse(_aux.Id)) // mientras el agujero sea >0 y el nodo anterior > dato
                {
                    InvertirAnterior(_pPosicion);
                    _pPosicion = _pPosicion - 1;
                    _contador++;
                }
            }
            return _contador;
        }
        public int SelectionSort()
        {
            int _cantidadNodos = CantidadNodos();
            int _contador = 0;
            //int _indice = 0;
            Nodo _auxMinimo = null;
            Nodo _aux = null;

            for(int i = 0; i <= _cantidadNodos - 1; i++)
            {
                _auxMinimo = RetornaNodoN(i); // Asumimos el nodo menor al actual que tenemos (i)
                for(int x = i + 1; x < _cantidadNodos; x++) // Loop para buscar el menor
                {
                    _aux = RetornaNodoN(x);
                    if (int.Parse(_aux.Id) < int.Parse(_auxMinimo.Id)) { _auxMinimo = RetornaNodoN(x); }
                }

                // Insertar y borrar Id o SWAP entre dos posiciones.

            }



            return _contador;
        }  // EN PROGRESO
        public void Swap2Posiciones(int pPosicion1, int pPosicion2) // Swap entre 2 posiciones elegidas por el usuario
        {
            int _auxCantidadNodos = CantidadNodos();

            if (pPosicion1 <= _auxCantidadNodos - 1 && pPosicion2 <= _auxCantidadNodos - 1 && pPosicion1 >= 0 && pPosicion2 >= 0) // Valida el rango para las posiciones ingresadas
            {
                if (_auxCantidadNodos > 1) // Valida que la lista tenga al menos dos elementos
                {
                    if (_auxCantidadNodos == 2) // Caso especial: que la lista tenga dos nodos nada más
                    {
                        Nodo _auxiliarPrimero = Primero();
                        Nodo _auxiliarUltimo = Ultimo();
                        CentinelaPrimero.Siguiente = _auxiliarUltimo;
                        CentinelaUltimo.Siguiente = _auxiliarPrimero;
                        _auxiliarUltimo.Anterior = null;
                        _auxiliarPrimero.Siguiente = null;
                    }
                    if (pPosicion1 == 0 && pPosicion2 == _auxCantidadNodos-1 || pPosicion2 == 0 && pPosicion1 == _auxCantidadNodos-1) //Caso 1: Primero() con Ultimo()
                    {
                        Nodo _auxiliarPrimero = Primero();
                        Nodo _auxiliarPrimeroSiguiente = Primero().Siguiente;
                        Nodo _auxiliarUltimo = Ultimo();
                        Nodo _auxiliarUltimoAnterior = Ultimo().Anterior;

                        _auxiliarUltimo.Siguiente = _auxiliarPrimero.Siguiente;
                        _auxiliarPrimeroSiguiente.Anterior = _auxiliarUltimo;
                        _auxiliarPrimero.Anterior = _auxiliarUltimo.Anterior;
                        _auxiliarUltimoAnterior.Siguiente = _auxiliarPrimero;
                        _auxiliarUltimo.Anterior = null;
                        _auxiliarPrimero.Siguiente = null;
                        CentinelaPrimero.Siguiente = _auxiliarUltimo;
                        CentinelaUltimo.Siguiente = _auxiliarPrimero;
                    }
                    if(pPosicion1 == 0 && pPosicion2>0 && pPosicion2 < _auxCantidadNodos-1) // Caso 2: Primero() con N
                    {
                        Nodo _auxiliarPrimero = Primero();
                        Nodo _auxiliarPrimeroSiguiente = Primero().Siguiente;
                        Nodo _auxiliarN = RetornaNodoN(pPosicion2);
                        Nodo _auxiliarNSiguiente = RetornaNodoN(pPosicion2 + 1);

                        _auxiliarN.Siguiente = _auxiliarPrimeroSiguiente;
                        _auxiliarPrimero.Siguiente = _auxiliarNSiguiente;
                        _auxiliarPrimeroSiguiente.Anterior = _auxiliarN;
                        _auxiliarNSiguiente.Anterior = _auxiliarPrimero;
                        _auxiliarPrimero.Anterior = _auxiliarN.Anterior;
                        _auxiliarN.Anterior.Siguiente = _auxiliarPrimero;
                        CentinelaPrimero.Siguiente = _auxiliarN;
                        _auxiliarN.Anterior = null;

                    }
                    if (pPosicion1 > 0 && pPosicion1 < _auxCantidadNodos - 1 && pPosicion2 == _auxCantidadNodos - 1) // Caso 3: N con Ultimo()
                    {
                        Nodo _auxiliarUltimo = Ultimo();
                        Nodo _auxiliarUltimoAnterior = RetornaNodoN(pPosicion2 - 1);
                        Nodo _auxiliarN = RetornaNodoN(pPosicion1);
                        Nodo _auxiliarNAnterior = RetornaNodoN(pPosicion1 - 1);
                        Nodo _auxiliarNSiguiente = RetornaNodoN(pPosicion1 + 1);
                        _auxiliarUltimo.Siguiente = _auxiliarNSiguiente;
                        _auxiliarUltimo.Anterior.Siguiente = _auxiliarN;
                        _auxiliarUltimo.Anterior = _auxiliarNAnterior;
                        _auxiliarN.Siguiente.Anterior = _auxiliarUltimo;
                        _auxiliarN.Anterior.Siguiente = _auxiliarUltimo;
                        _auxiliarN.Anterior = _auxiliarUltimoAnterior;
                        CentinelaUltimo.Siguiente = _auxiliarN;
                        _auxiliarN.Siguiente = null;
                    }
                    if(pPosicion1 > 0 && pPosicion1 < _auxCantidadNodos - 1 && pPosicion2 > 0 && pPosicion2 < _auxCantidadNodos - 1) // Caso 4: N con N
                    {
                        Nodo _auxiliarN1 = RetornaNodoN(pPosicion1);
                        Nodo _auxiliarN1Anterior = RetornaNodoN(pPosicion1 - 1);
                        Nodo _auxiliarN2 = RetornaNodoN(pPosicion2);
                        Nodo _auxiliarN2Siguiente = RetornaNodoN(pPosicion2 + 1);
                        Nodo _auxiliarN2Anterior = RetornaNodoN(pPosicion2 - 1);
                        _auxiliarN2.Siguiente = _auxiliarN1.Siguiente;
                        _auxiliarN1.Siguiente.Anterior = _auxiliarN2;
                        _auxiliarN2.Anterior = _auxiliarN1Anterior;
                        _auxiliarN1Anterior.Siguiente = _auxiliarN2;
                        _auxiliarN1.Siguiente = _auxiliarN2Siguiente;
                        _auxiliarN2Siguiente.Anterior = _auxiliarN1;
                        _auxiliarN1.Anterior = _auxiliarN2Anterior;
                        _auxiliarN2Anterior.Siguiente = _auxiliarN1;
                    }

                }
            }

            return;    
        } 
        public void Clear()
        {
            // Erases all elements on the list
            CentinelaPrimero.Siguiente = null;
            CentinelaUltimo.Siguiente = null;            
        }
        public void CambiarDato(int pPosicion)
        {
            // Cambia el pID del nodo seleccionado:
            Nodo _auxiliarAnterior = RetornaNodoN(pPosicion - 1);
            Nodo _auxiliarSiguiente = RetornaNodoN(pPosicion + 1);
            Nodo _nuevoDato = CreaNodo();

            _auxiliarAnterior.Siguiente = _nuevoDato;
            _nuevoDato.Anterior = _auxiliarAnterior;
            _nuevoDato.Siguiente = _auxiliarSiguiente;
            _auxiliarSiguiente.Anterior = _nuevoDato;

        }
        

        
    }
    public class Nodo //Clase autoreferenciada
    {
        public Nodo(string pId, Nodo pSiguienteNodo, Nodo pAnteriorNodo)
        { Id = pId; Siguiente = pSiguienteNodo; Anterior = pAnteriorNodo; } //Constructor
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }
    }

}
