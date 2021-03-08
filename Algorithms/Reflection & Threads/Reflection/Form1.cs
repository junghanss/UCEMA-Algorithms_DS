using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Reflection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Type t;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e)
        {
            // Ingresamos el nombre específico para obtener el objeto Type
            t = Type.GetType(Interaction.InputBox("Ingrese la clase u objeto: "));
            MessageBox.Show("Nombre ingresado: " + t, "Resultado");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Llamamos a la función características
            listBox1.Items.Clear();
            CaracteristicasTipo(t);
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e)
        {
            // Llamamos a la funcion para encontrar las propiedades
            listBox2.Items.Clear();
            EncuentraPropiedades(t);
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e)
        {
            // Llamamos a la funcion para encontrar los metodos
            listBox3.Items.Clear();
            EncuentraMetodos(t);
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e)
        {
            // Llamamos a la funcion para encontrar interfaces 
            listBox4.Items.Clear();
            EncuentraInterfaces(t);
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button6_Click(object sender, EventArgs e)
        {
            // Llamamos a la funcion para campos
            listBox5.Items.Clear();
            EncuentraCampos(t);
        }

        #region "Funciones"
        public void CaracteristicasTipo(Type t)
        {
            listBox1.Items.Add("Las caracteristicas son: ");
            listBox1.Items.Add("Clase base: " + t.BaseType);
            listBox1.Items.Add("Es clase: " + t.IsClass);
            listBox1.Items.Add("Abstracta: " + t.IsAbstract);
            listBox1.Items.Add("Sellada: " + t.IsSealed);
            listBox1.Items.Add("Generica: " + t.IsGenericType);
        }

        public void EncuentraPropiedades(Type t)
        {
            listBox2.Items.Add("Las propiedades son: ");
            var nombres = from p in t.GetProperties() select p.Name;
            foreach(var nombre in nombres)
            {
                listBox2.Items.Add(nombre);
            }
        }

        public void EncuentraMetodos(Type t)
        {
            listBox3.Items.Add("Los metodos son: ");
            var metodos = from m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static) select m.Name;
            foreach(var metodo in metodos)
            {
                listBox3.Items.Add(metodo);
            }
        }

        public void EncuentraInterfaces(Type t)
        {
            listBox4.Items.Add("Las interfaces son: ");
            var interfaces = from i in t.GetInterfaces() select i;
            foreach(var interfaz in interfaces)
            {
                listBox4.Items.Add(interfaz);
            }
        }

        public void EncuentraCampos(Type t)
        {
            listBox5.Items.Add("Los campos son: ");
            var campos = from f in t.GetFields() select f.Name;
            foreach(var campo in campos)
            {
                listBox5.Items.Add(campo);
            }
        }

        #endregion


    }



}
