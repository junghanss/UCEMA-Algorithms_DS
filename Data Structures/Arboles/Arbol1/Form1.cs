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

namespace Arbol1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Declaro los Nodos
        Nodo a; Nodo b; Nodo c; Nodo d; Nodo e; Nodo f; Nodo g;
       
        private void Form1_Load(object sender, EventArgs ex)
        {

            // Instancio los Nodos
            a = new Nodo() { texto = "A" };
            b = new Nodo() { texto = "B" };
            c = new Nodo() { texto = "C" };
            d = new Nodo() { texto = "D" };
            e = new Nodo() { texto = "E" };
            f = new Nodo() { texto = "F" };
            //g = new Nodo() { texto = "G" };


            // Se arma el árbol
            a.Izq = b;
            a.Der = c;
            //b.Izq = d;
            b.Der = d;
            c.Izq = e;
            c.Der = f;

            // Se limpian: treeView1, treeView2 y treeView3 
            treeView1.Nodes.Clear(); treeView2.Nodes.Clear(); treeView3.Nodes.Clear();

            // Se crea la lista de Nodos para la recursiva Mostrar (como punto de entrada se carga nodo raiz)
            List<Nodo> LN = new List<Nodo>(); LN.Add(a);

            // Se llama a la recursiva Mostrar. El algoritmo plantea recibir una lista de TreeNodes que representan los nodos
            // a los cuales se les deben colgar los nuevos elementos y una lista de Nodos que son los que debemos colgar.
            // En el punto de entrada la primera lista se pasa el null pues se trata de mostrar el nodo raiz.
            Mostrar(null, LN,treeView1);

            // Se expande: treeView1
            treeView1.ExpandAll(); 
        }
        private void Mostrar(List<TreeNode> pTreeNode, List<Nodo> pNodo, TreeView pTreeView)
        {
            // Si la lista pNodo está vacia no se hace nada
            if (pNodo != null)
            {
                // La variable Sale se usa para determinar si se debe terminar con la recursividada.
                // Se termina con la recursividad si todos los Nodos de la lista pNodo llegan en null
                bool Sale = true;
                foreach (Nodo N in pNodo)
                {
                    if (N != null) { Sale = false; break; }
                }
                // Se pregunta si Sale==falso para entrar a Mostrar el árbol en el treeview y entrar a la recursividad
                if (!Sale)
                {
                    // Lista temporal que se carga con los Nodos a mostrar.
                    List<Nodo> LNT = new List<Nodo>();
                    // Lista temporal que se carga con los TreeNodes de los que debe colgar los nodos a mostrar.
                    List<TreeNode> LTNT = new List<TreeNode>();
                    // Si pTreeNode es igual a null se asume que el TreeNode a mostrar es el raiz.
                    if (pTreeNode == null)
                    {
                        // Se agrega un treeNode a TreeView y como texto se coloca el que posee el Nodo raiz del árbol.
                        pTreeView.Nodes.Add(pNodo[0].texto);
                        // Se agrega a la lista de nodos temporal el nodo izquierdo del actual o null si no posee nada
                        if (pNodo[0].Izq != null) { LNT.Add(pNodo[0].Izq); }
                        else { LNT.Add(null); }
                        // Se agrega a la lista de nodos temporal el nodo derecho del actual o null si no posee nada
                        if (pNodo[0].Der != null) { LNT.Add(pNodo[0].Der); }
                        else { LNT.Add(null); }
                        // Se agrega a la lista de treenode temporal el nodo raiz del treenode
                        LTNT.Add(pTreeView.Nodes[0]);
                    }
                    else
                    {
                        // En caso que el Treenode posea nodo raiz se recorre la colecciónn de nodos del treeNode a la
                        // cual se le deben colgar nodos. 
                        int cont = 0;
                        foreach (TreeNode N in pTreeNode)
                        {
                            // Si el nodo que se está recorriendo dice Null en su texto se asume que no hay nada
                            // para colgar. En caso contrario se debe colgar algo.
                            if (N.Text != "Null")
                            {
                                string texto= "Null";
                                // Si lo que hay para colgar a la izquierda es distinto de null se extrae el texto 
                                // y se agrega la lista de nodos temporal lo que posee a la izq y a
                                // la derecha.
                                if (pNodo.ElementAt(cont) != null)
                                {
                                    texto = pNodo.ElementAt(cont).texto;
                                    LNT.Add(pNodo.ElementAt(cont).Izq);
                                    LNT.Add(pNodo.ElementAt(cont).Der);
                                }
                                // Si lo que hay para colgar es null la variable texto por defecto ya posee el string "Null"
                                // y a la lista de nodos temporales de le cualgan dos null, uno por el elemento de la derecha 
                                // y otro por el de la izquierda.
                                else
                                {
                                    LNT.Add(null); LNT.Add(null);
                                }
                                cont++;
                                // Se agrega el TreeNode a nodo N actual
                                N.Nodes.Add(new TreeNode(texto));
                                // Se agrega el último nodo agregado a la Lista de TreeNode temporal.
                                LTNT.Add(N.LastNode);


                                texto = "Null";
                                // Si lo que hay para colgar a la derecha es distinto de null se extrae el texto 
                                // y se agrega la llista de nodos temporal lo que posee a la izq y a
                                // la derecha.
                                if (pNodo.ElementAt(cont) != null)
                                {
                                    texto = pNodo.ElementAt(cont).texto;
                                    LNT.Add(pNodo.ElementAt(cont).Izq);
                                    LNT.Add(pNodo.ElementAt(cont).Der);
                                }
                                // Si lo que hay para colgar es null la variable texto por defecto ya posee el string "Null"
                                // y a la lista de nodos temporales de le cualgan dos null, uno por el elemento de la derecha 
                                // y otro por el de la izquierda.
                                else
                                {
                                    LNT.Add(null); LNT.Add(null);
                                }
                                cont++;

                                // Se agrega el TreeNode a nodo N actual
                                N.Nodes.Add(new TreeNode(texto));
                                // Se agrega el último nodo agregado a la Lista de TreeNode temporal.
                                LTNT.Add(N.LastNode);
                            }
                            else { cont += 2; }
                        }
                    }
                    // Llamada recursiva.
                    Mostrar(LTNT, LNT,pTreeView);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Agrega nodos a mano al Treeview2
            if (treeView2.Nodes.Count == 0) { treeView2.Nodes.Add("A"); treeView2.SelectedNode = treeView2.Nodes[0]; }
            else
            {
                try
                {
                    TreeNode tn = treeView2.SelectedNode;
                    if (tn.Nodes.Count < 2) { tn.Nodes.Add(Interaction.InputBox("¿Texto?: ")); }
                    treeView2.ExpandAll();
                   
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Preorder(a);
        }
        private void Preorder(Nodo pNodo)
        {
            if (pNodo != null)  
            {
                textBox1.Text += pNodo.texto + " ";     // A B D C E F
                Preorder(pNodo.Izq); 
                Preorder(pNodo.Der); 
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            Inorder(a);
        }
        private void Inorder(Nodo pNodo)
        {
            if (pNodo != null)
            {
                Inorder(pNodo.Izq); 
                textBox2.Text += pNodo.texto + " ";    // B D A E C F
                Inorder(pNodo.Der); 
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            Posorder(a);
        }
        private void Posorder(Nodo pNodo)
        {
            if (pNodo != null)
            {
                Posorder(pNodo.Izq);
                Posorder(pNodo.Der);
                textBox3.Text += pNodo.texto + " ";     // D B E F C A
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            List<Nodo> L = new List<Nodo>(); L.Add(a);
            Anchura(L);
        }
        private void Anchura(List<Nodo> pNodo)
        {
             if (pNodo.Count > 0)
            {
                List<Nodo> LT = new List<Nodo>();
                foreach (Nodo N in pNodo)
                {
                    textBox4.Text += N.texto + " ";
                    if (N.Izq != null)
                    { LT.Add(N.Izq); }
                    else
                    { LT.Add(new Nodo("@")); }

                    if (N.Der != null)
                    { LT.Add(N.Der); }
                    else
                    { LT.Add(new Nodo("@")); }

                }
                bool _fin = true;
                for (int X = 0; X < LT.Count; X++)
                {
                    if (LT.ElementAt(X).texto != "@") { _fin = false; break; }
                }
                if (!_fin) { Anchura(LT); }
             }


            
        }
        // Variable que apunta al nodo raiz del arbol que se construirá
        Nodo A = null;
        private void button6_Click(object sender, EventArgs e)
        {
            // Verificamos si la caja4 contiene información.
            if (textBox4.Text == "")
            { MessageBox.Show("La caja de texto 4 debe contener la información del recorrido en amplitud !!!"); }
            else
            {
                // Se limplia el treeview
                treeView3.Nodes.Clear();

                // Se toma el texto de textBox4 ( A B C @ D E F ) y se le quitan los espacios ( ABC@DEF ) y se almacena en la variable s
                string s = textBox4.Text.Replace(" ", "");
                                                            
                //Para la cantidad de caracteres a cortar
                int cant = 1;
                // Se usa para determinar el nuevo valor de cant
                double ncant = 1;
               
                // Para discriminar entre el nodo raiz y el resto de los niveles (0=raiz y distinto de cero para el resto de los nodos)
                int nivel = 0;

                // Se declara una lista L para alimentar el foreach que realiza la tarea de crear los nodos hijos y asignarlos a la izq y der del 
                // nodo padre
                List<Nodo> L = new List<Nodo>();

                // Se repiten las siguientes lineas de código mientras s tenga caracteres (Estos caracteres representan cada uno de los nodos a crear)
                while (s.Length > 0)
                {                 
                    // Se toma de la cadena s el/los caracteres desde el índice 0 la cantidad indicada por cant
                    string xs = s.Substring(0,cant);
                    // Se determina si estamos en el nivel raiz (nivel == 0) 
                    if (nivel == 0)
                        {
                            // Se crea un nuevo nodo y se le pasa como texto el caracter que se encuentra en el índice cero de xs                     
                            A = new Nodo(xs[0].ToString()); 
                            // Se incrementa nivel
                            nivel++; 
                            // Se guarda el nodo creado como raiz en la lista L para proceder a asignarle su hijos (Izq y Der)
                            L.Add(A);
                        }
                     else
                        {
                        // Se crea la variable pos y se inicializa en cero para utilizarla en el posicionamiento del string xs
                        int pos = 0;
                        // Se crea una lista de nodos auxiliar para cargar los hijos del nodo que se recorrerá de la lista L
                        List<Nodo> Laux = new List<Nodo>();
                        // Se recorre cada nodo de la lista L y se realiza:
                        //      1. A cada nodo se le asigna lo que posee a la izquierda y derecha.
                        //      2. Se carga la lista auxiliar Laux con los nodos creados que van a la izquierda y derecha del nodo que se está recorriendo
                        //      3. Se incremente la variable pos.
                        foreach (Nodo d in L)
                            {
                                // Se le asigna a la izquierda del nodo actual lo que posee el string xs en la posición pos.
                                // Para ello se evalúa si es un ´@´, en caso afirmativo se asigna null, en caso negativo se asigna un nuevo nodo cuyo
                                // texto es el caracter que se encuentra en xs posición pos.
                                // Luego se agrega en la lista Laux el nuevo nodo creado.
                                // Finalmente se incrementa pos en 1 para trabajar con el siguiente elemento de xs.
                                d.Izq = xs[pos].ToString() == "@" ? null : new Nodo(xs[pos].ToString()); Laux.Add(d.Izq); pos++;
                                // Se le asigna a la deracha del nodo actual lo que posee el string xs en la posición pos.
                                // Para ello se evalúa si es un ´@´, en caso afirmativo se asigna null, en caso negativo se asigna un nuevo nodo cuyo
                                // texto es el caracter que se encuentra en xs posición pos.
                                // Luego se agrega en la lista Laux el nuevo nodo creado.
                                // Finalmente se incrementa pos en 1 para trabajar con el siguiente elemento de xs.
                                d.Der = xs[pos].ToString() == "@" ? null : new Nodo(xs[pos].ToString()); Laux.Add(d.Der); pos++;
                        }
                        // Se limpia la lista L y se le asigna lo que posee Laux.
                        L.Clear();L = Laux;
                     }                   
                    // Se actualiza la variable s recortando un substring de s actual desde el valor de cant hasta el final
                    s = s.Substring(cant);
                    // Se actualiza cant haciendo 2 elevado a la ncant y luego se incrementa ncant
                    cant = int.Parse(Math.Pow(2, ncant).ToString()); ncant++;
                }
               // Se muestra el Árboen el treeview3
                Mostrar(null, new List<Nodo>(new Nodo[] {A}),treeView3);
                treeView3.ExpandAll();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            List<Nodo> L = new List<Nodo>(); L.Add(a);
            Anchura2(L);
        }
        private void Anchura2(List<Nodo> pNodo)
        {
            if (pNodo.Count > 0)
            {
                List<Nodo> LT = new List<Nodo>();
                foreach (Nodo N in pNodo)
                {
                    textBox5.Text += N.texto + " ";
                    if (N.Izq != null) { LT.Add(N.Izq); }         
                    if (N.Der != null) { LT.Add(N.Der); }
                }
                Anchura2(LT);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                treeView2.SelectedNode.Remove();
            }
            catch (Exception)
            {

     
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Se rearma el Árbol
                button6_Click(null, null);
                // Se evalúa si el treeview posee nodos
                if (treeView3.Nodes.Count > 0)
                {
                   // Se solicita los datos necesarios al usuario para insertar un nodo.
                    string _texto = Interaction.InputBox("Ingrese el texto del nodo al que le desea agregar: ");
                    string _izde = Interaction.InputBox("Ingrese si agrega a la derecha (D o d) o izquierda (I o i): ");
                    string _izdeexistente = Interaction.InputBox("Si el lugar hubiera otro nodo. Ingrese si desea que se coloque a la derecha (D o d) o izquierda (I o i) del nuevo nodo: ");
                    string _nuevotexto = Interaction.InputBox("Ingrese le texto que desea colocarle al nuevo nodo: ");
                    //busqueda del nodo al cuál se le agregará un nuevo nodo
                    Nodo _n = BusquedaDeNodo(new List<Nodo>() { A }, _texto);
                    // Se evalua si el nodo buscado es distinto de null
                    if (_n != null)
                    {
                        // Se crea el nuevo nodo a agregar
                        Nodo _nuevo = new Nodo(_nuevotexto);

                        // Se evalúa si se agrega a la derecha del nodo _n
                        if (_izde == "D" || _izde == "d")
                        {
                            // Se evalúa si a la derecha del nodo al cual se le desea insertar hay un null. En caso afirmativo, se asigna el nuevo nodo.
                            if (_n.Der == null) { _n.Der = _nuevo; }
                            // Caso contrario, si hay algo a la derecha de _n, se guarda en una variable auxiliar lo que se encuentra actualmente a la derecha.
                            else
                            {
                                Nodo _Naux = _n.Der;
                                // Se coloca a la derecha de _n el nuevo nodo
                                _n.Der = _nuevo;
                                // Si se solicitó colocar lo anterior a la derecha del nuevo nodo
                                if (_izdeexistente == "D" || _izdeexistente == "d")
                                {
                                    _n.Der.Der = _Naux;
                                    _n.Der.Izq = null;
                                }
                                // Caso contrario se coloca a la izquierda
                                else
                                {
                                    _n.Der.Der = null;
                                    _n.Der.Izq = _Naux;

                                }
                            }
                        }
                        // Se agrega a la izquierda del nodo _n
                        else
                        {
                            // Se evalúa si a la izquierda del nodo al cual se le desea insertar hay un null. En caso afirmativo, se asigna el nuevo nodo.

                            if (_n.Izq == null) { _n.Izq = _nuevo; }
                            // Caso contrario, si hay algo a la izquierda de _n, se guarda en una variable auxiliar lo que se encuentra actualmente a la izquierda
                            else
                            {
                                Nodo _Naux = _n.Izq;
                                // Se coloca a la izquierda de _n el nuevo nodo
                                _n.Izq = _nuevo;
                                // Si se solicitó colocar lo anterior a la izquierda del nuevo nodo
                                if (_izdeexistente == "I" || _izdeexistente == "i")
                                {
                                    _n.Izq.Der = null;
                                    _n.Izq.Izq = _Naux;
                                }
                                // Caso contrario se coloca a la derecha
                                else
                                {
                                    _n.Izq.Izq = null;
                                    _n.Izq.Der = _Naux;

                                }
                            }


                        }
                    }
                // Se limpia em treeview.
                treeView3.Nodes.Clear();
                // Se muestra como queda el Árbol en la memoria.
                Mostrar(null, new List<Nodo>(new Nodo[] { A }), treeView3);
                treeView3.ExpandAll();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        // Variables  auxiliares para los algoritmos:
        //      BusquedaDeNodo -> que se utiliza en insertar nodo.
        //      BusquedaDeNodoABorrar -> que se utiliza para borrar nodo.
        // ********************
        Nodo rta =null;
        List<Nodo> ant = null;
        bool _b;
        bool _f;
        string lado = "";

        // ********************
        private Nodo BusquedaDeNodo(List<Nodo> pNodo,string pTexto)
        {
           
           // Se verifica que la lista pNodo tenga elementos en caso contrario se aborta la llamada recursiva.
            if (pNodo.Count > 0)
            {
                // Se crea una lista auxiliar
                List<Nodo> LT = new List<Nodo>();
                // Se recorren todos los nodos de la lista pNodo
                foreach (Nodo N in pNodo)
                {
                    // Si N el distinto de null en caso afirmativo se procede a verificar si es el nodo buscado
                    if (N != null)
                    {
                        // Si el texto del nodo actual N coincide con el texto busca se limpia la lista LT, se coloca en rta el nodo N (buscado) y se aborta el foreach.
                        if (N.texto == pTexto) { LT.Clear();rta = N; break; }
                        // Si no se encuentra se carga en la lista temporal LT los nodos hijos del nodo N
                        else
                        {
                            if (N.Izq != null) { LT.Add(N.Izq); }
                            if (N.Der != null) { LT.Add(N.Der); }
                        }
                    }
                }
                // Se llama a la función recursiva
                BusquedaDeNodo(LT,pTexto);
            }
            // Se retorna el nodo encontrado.
            return rta;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try 
            {
                // Se rearma el Árbol
                button6_Click(null, null);
                // Se solicita el texto del nodo a borrar
                string _texto = Interaction.InputBox("Ingrese le texto del nodo que desea borrar: ");
                // Se inicializa _bm ant y _f. _b, ant y _f se utilizan en el algoritmo BusquedaDeNodoABorrar
                _b = true;ant = new List<Nodo>(); _f = false;
                // Se ejecuta BusquedaDeNodoABorrar enviando una lista de Nodos con el nodo raiz y el texto del nodo a borrar.
                // Se recibe un array con: 1. el nodo padre o null si se borra el raiz. 2. Si lo que se desea borrar está a la izquirda (I) o la derecha (D). 3. True si el nodo existe o Fase si no existe
                object[]  Datos =  BusquedaDeNodoABorrar(new List<Nodo>() { A }, _texto);
                // Se toma el padre del array devuelto por la función
                Nodo _n =(Nodo)Datos[0];
               

                // Si _n es null y si Datos[2] es verdadero, implica que se desea borrar el raiz. Si Datos[2] es false implica que el nodo no fue encontrado
                if (_n == null && (bool)Datos[2])
                { A = null; }
                // Caso contrario es un nodo distinto al raiz y debe existir (Datos[2]==true)
                else if((bool)Datos[2])
                {
                   // Se evalúa si lo que se desea borrar está a la derecha del nodo padre. 
                   //    En caso afirmativo se pasa a nulo lo de la derecha del nodo padre.
                   //    En casp negativo se pasa a nulo lo de la izquierda del nodo padre.
                    if (lado == "D") { _n.Der = null; }
                    else { _n.Izq = null; }
                }
                // Se limpia el treeview
                treeView3.Nodes.Clear();
                // Se muestra como queda el Árbol en la memoria.
                Mostrar(null, new List<Nodo>(new Nodo[] { A }), treeView3);
                treeView3.ExpandAll();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private object[] BusquedaDeNodoABorrar(List<Nodo> pNodo, string pTexto)
        {
            // Si la lista pNodo no posee elementos se retorna el array con los valores de rta y lado
            if (pNodo.Count > 0)
            {
                // Lista temporal de nodos para alimentar a la funcion recursiva
                List<Nodo> LT = new List<Nodo>();
                // Iterativa para recorre los nodos y realizar:
                //      1. La verificación sobre si se encontró el nodo buscado
                //      2. Cargar la lista temporal LT con los nodos hijos del nodo N que se está utiizando y que servirá para alimentar la función recursiva
                foreach (Nodo N in pNodo)
                {
                    // Se evalúa si el nodo es distinto de nulo para proceder.
                    if (N != null)
                    {
                        // Se evalúa si el texto del nodo actual N es igual a texto buscado. En caso afirnativoÑ
                        //      1. Se limpia la lista temporal LT
                        //      2. Se determina si el nodo encontrado corresponde al lado izquierdo (I) o derecho (D). Para ello se determina si la posición
                        //         del nodo el la lista corresponde a una ubicación par o impar. Se asume que la posición 0 y pares corresponden a elementos 
                        //         izquierdos y las posiciones impares a elementos derechos. Esto es debido a que se toman de dos en dos en base cero.
                        //      3. Se determina el valor de rta que es el nodo padre de donde depende el nodo a borrar. la lista ant contine los nodos del nivel anterior (Padres)
                        //         a los que se está analizando. Si el nodo buscado es el raiz, ant no posee elementos y se asigna null a rta. Si ant posee elementos se busca dentro de esa lista el elemento correspondiente
                        //         al índice que corresponde al lugar que ucupa el hijo (índice del hijo en la lista pNodo) dividido 2.
                        //      4. Se le asigna false a _b para determinar si se debe actualizar la lista temporal ant.
                        //      5. Se realiza un break para abortar el foreach pues se encontró el nodo requerido.
                        //      6. Se le asigna a la variable _f verdadero para indicar que se encontr'o el nodo buscado.
                        if (N.texto == pTexto) { LT.Clear(); lado = pNodo.FindIndex(x => x == N) % 2 == 0 ? "I" : "D";  rta =ant.Count>0 ? ant.ElementAt(((int)(pNodo.FindIndex(x => x == N) / 2))):null;_b = false;_f = true; break; }
                        // Si no coincide el texto del nodo N con el buscado se carga la lista temporal LT con los nodos hijos del nodo actual N
                        else
                        {
                            if (N.Izq != null)
                            { LT.Add(N.Izq); }
                            else
                            { LT.Add(new Nodo("@")); }

                            if (N.Der != null)
                            { LT.Add(N.Der); }
                            else
                            { LT.Add(new Nodo("@")); }

                        }
                    }
                    
                }
                // Se actualiza la lista temporal ant con el contenido de pNodo.
                if (_b) { ant = pNodo; }
                // Se inicializa una variable bool como semáforo para determinar si se llama aplica la recursividad.
                bool _fin = true;
                // Se busca determinar si el texto de todos los nodos de LT son @ lo que indica que no hay mas nodos por recorrer y se aborta el llamado recursivo
                for (int X = 0; X < LT.Count; X++)
                {
                    if (LT.ElementAt(X).texto != "@") { _fin = false; break; }
                }
                // Se evalúa si se llama a la función recursiva
                if (!_fin) { BusquedaDeNodoABorrar(LT, pTexto); };
            }
            // Se retorna el Array con rta (el nodo padre del que se desea borrar) y lado (que indica si el nodo a borrar se encuantra a la derecha o izquierda)
            return new object[] {rta,lado,_f};
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
    public class Nodo
    {
        public Nodo(string pTexto = "") { Izq = null; Der = null; texto = pTexto; }
        public string texto { get; set; }
        public Nodo Izq { get; set; }
        public Nodo Der { get; set; }
    }
}
