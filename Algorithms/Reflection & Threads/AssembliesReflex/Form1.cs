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
using System.Reflection;

namespace AssembliesReflex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Persona p;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (((MiMethodInfo)listBox1.SelectedItem).ToString() == "Genero")
                {
                    MessageBox.Show(((MiMethodInfo)listBox1.SelectedItem).GetMethodInfo.Invoke(p, new object[] { Interaction.InputBox("Genero?") }).ToString());
                }
                else
                {
                    MessageBox.Show(((MiMethodInfo)listBox1.SelectedItem).GetMethodInfo.Invoke(p, null).ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                p = new Persona(Interaction.InputBox("Nombre: "), Interaction.InputBox("Apellido: "), int.Parse(Interaction.InputBox("Edad: ")));
                listBox1.Items.Clear();
            }
            catch (Exception ex){ MessageBox.Show(ex.Message,"Excepcion"); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Type t = p.GetType();
                MethodInfo[] ArrayMethodInfo = t.GetMethods();
                //var nombres = 
                foreach(MethodInfo m in ArrayMethodInfo)
                {
                    if (Attribute.IsDefined(m, typeof(MostrarAttribute)))
                    {
                        if (((MostrarAttribute)Attribute.GetCustomAttribute(m, typeof(MostrarAttribute))).Mostrar)
                        {
                            listBox1.Items.Add(new MiMethodInfo(m));                            
                        }
                    }                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {                
                MessageBox.Show("La persona es menor de edad:  " + p.MenorEdad().ToString(), "Resultado");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MiPropertyInfo _paux = ((MiPropertyInfo)listBox2.SelectedItem);
                if (radioButton1.Checked) //if (((MiPropertyInfo)listBox2.SelectedItem).GetPropertyInfo.CanRead)
                {
                    _paux.GetPropertyInfo.SetValue(p, int.Parse(Interaction.InputBox("Valor: ", "Valor requerido.")));                                                            
                }
                else { MessageBox.Show(_paux.GetPropertyInfo.GetValue(p).ToString()); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                Type t = typeof(Persona);
                PropertyInfo[] ArrayInfoProp = t.GetProperties();
                foreach(PropertyInfo p in ArrayInfoProp)
                {
                    if (Attribute.IsDefined(p, typeof(MostrarAttribute)))
                    {
                        if (((MostrarAttribute)Attribute.GetCustomAttribute(p, typeof(MostrarAttribute))).Mostrar) 
                        { listBox2.Items.Add(new MiPropertyInfo(p)); }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                listBox3.Items.Clear();
                // Loads an assembly using its file name
                Assembly a = Assembly.LoadFrom("AssembliesReflex.exe");
                // Gets the type names from the assembly.
                Type[] types2 = a.GetTypes();
                foreach (Type t in types2)
                {
                    listBox3.Items.Add(t.Name);// + Environment.NewLine); // Podemos usar Name o FullName                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }





    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public int dni { get; set; }
        public Persona (string pNombre, string pApellido, int pEdad)
        {
            nombre = pNombre; apellido = pApellido; edad = pEdad;
        }
        public Persona(string pNombre, string pApellido) { nombre = pNombre; apellido = pApellido;  }
        [Mostrar(true)]
        public string Nombre() { return nombre; }
        [Mostrar(true)]
        public string Apellido() { return apellido; }
        [Mostrar(true)]
        public int Edad() { return edad; }
        [Mostrar(true)]
        public string Genero(string pGenero) 
        {
            return $"{pGenero}";
        }
        [Mostrar(true)]
        public string PermisoConducir { get { return "No, la persona no tiene permitido conducir."; } }
        [Mostrar(true)]
        public int Documento { get { return dni; } set { dni=value; } }

    }


    public class MiMethodInfo
    {
        // Clase para encapsular el MethodInfo cuando lo llevemos al listBox
        // El listBox por lo general devolvería el ToString() normal... nosotros queremos personalizarlo!
        private MethodInfo _m;    // Campo privado
        public MiMethodInfo(MethodInfo pM) { _m = pM; }        // Constructor que recibe el methodinfo
        public MethodInfo GetMethodInfo { get { return _m; } }  // PROPIEDAD solo de lectura que retorna el methodinfo privado - agregacion con contencion fisica
        public override string ToString()       // sobreescribimos el ToString, para que cuando sea consultado haga eso
        {
            return _m.Name.Replace("_","");
        }
    }

    public class MiPropertyInfo
    {
        private PropertyInfo _p;
        public MiPropertyInfo(PropertyInfo pP) { _p = pP; }
        public PropertyInfo GetPropertyInfo { get { return _p; } }
        public override string ToString()
        {
            return _p.Name.Replace("_", " ");
        }
    }

    // CREAMOS EL ATRIBUTO
    [ System.AttributeUsage( AttributeTargets.Method | AttributeTargets.Property, Inherited =true, AllowMultiple = false ) ]
    public class MostrarAttribute : System.Attribute
    {
        public bool _show; // Valor booleano de referencia
        public MostrarAttribute(bool pShow) { _show = pShow; } // Constructor que recibe un parametro y lo asigna al valor booleano

        public bool Mostrar { get { return _show; } } // PROPIEDAD de lectura que retorna el valor booleano de referencia

    }

    // EXTENSIONES DE METODOS...
    public static class ExtensionMethods
    {
        public static bool MenorEdad(this Persona i)
        {
            return i.Edad() < 18 ? true : false;
        }
    }
}
