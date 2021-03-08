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

namespace Extension
{
    using ExtensionesPersonalizadas;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
namespace ExtensionesPersonalizadas
{
    #region "Clases para hacer pruebas"
    public class Nodo
    {
        public Nodo(string pId, Nodo pSiguiente, Nodo pAnterior)
        {
            Id = pId; Siguiente = pSiguiente; Anterior = pAnterior;
        }
        public string Id { get; set; }
        public Nodo Anterior { get; set; }
        public Nodo Siguiente { get; set; }
    }
    public class ListaEnlazada
    {
        private Nodo CentinelaPrimero;
        private Nodo CentinelaUltimo;
        public ListaEnlazada()
        {
            CentinelaPrimero = new Nodo("CentinelaPrimero", null, null);
            CentinelaUltimo = new Nodo("CentinelaUltimo", null, null);
        }
        public Nodo Primero() { return CentinelaPrimero.Siguiente; }
        public Nodo Ultimo() { return CentinelaUltimo.Siguiente; }
    }
    #endregion

    // 1ero definimos una clase static publica donde irán los métodos
    public static class Metodos
    {
        // Adentro definimos los metodos
        // Definimos un metodo static con el modificador this antecedido de la clase a la que corresponde!
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        
        public static bool EsPar(this int i)
        {
            return i%2==0 ? true : false;
        }

        public static double Doublete(this int i)
        {
            return Double.Parse(i.ToString());
        }

        

        public static string LeerDato(this Nodo pNodo)
        {
            return pNodo.Id ;
        }
        public static bool ListaVacia(this ListaEnlazada pLista)
        {
            return pLista.Primero() == null ? true : false;
        }
        public static int ContadorNodos(this ListaEnlazada pLista)
        {
            int cantidadNodos = 0;
            Nodo _aux = pLista.Primero();
            if (_aux==null) { return cantidadNodos; }
            else { _aux = _aux.Siguiente; cantidadNodos++; }
            return cantidadNodos;
        }

    }
}



