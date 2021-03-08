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

namespace TP_Recursividad___Libre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana1.Items.Clear();
                double _inputTasa = double.Parse(Interaction.InputBox("Ingrese la tasa de interés correspondiente: ")) / 100;
                int _inputPeriodos = int.Parse(Interaction.InputBox("Ingrese la cantidad de períodos: "));
                double _output = (TasaDeRetorno(_inputTasa, _inputPeriodos) - 1)*100;
                _output = Math.Round(_output,3);
                MessageBox.Show("La tasa de interés compuesta es " + _output + "%", "Resultado");
                Ventana1.Items.Add("Tasa simple: " + _inputTasa);
                Ventana1.Items.Add("Cantidad períodos: " + _inputPeriodos);
                Ventana1.Items.Add("Tasa compuesta: " + _output + "%");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   // Tasa de interés compuesta
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana2.Items.Clear();
                MessageBox.Show("Recuerde que la función de Ackermann es sensible a números enteros mayores a 4, tenga a bien ingresar números menores.", "Precaución");
                int _input1 = int.Parse(Interaction.InputBox("Ingrese el primer número"));
                int _input2 = int.Parse(Interaction.InputBox("Ingrese el segundo número"));
                if (_input1 > 4 || _input2 >= 4)
                {
                    MessageBox.Show("Ingresaste números mayores que 5 en alguna entrada, pruebe con enteros menores por favor.");
                    _input1 = int.Parse(Interaction.InputBox("Ingrese el primer número"));
                    _input2 = int.Parse(Interaction.InputBox("Ingrese el segundo número"));
                }
                int _output = Ackermann(_input1, _input2);
                MessageBox.Show("Para los numeros " + _input1 + " y " + _input2 + ", el resultado de la función Ackermann es: " + _output, "Resultado");
                Ventana2.Items.Add("Primer número: " + _input1);
                Ventana2.Items.Add("Segundo número: " + _input2);
                Ventana2.Items.Add("Resultado Ackermann: " + _output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   // Función de Ackermann
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana3.Items.Clear();
                string _input = Interaction.InputBox("Ingrese la palabra por transformar: ");
                string _output = ReversaPrueba(_input, 0);
                MessageBox.Show("El resultado de la palabra " + _input + " es: " + _output);
                Ventana3.Items.Add("Palabra ingresada: " + _input);                
                Ventana3.Items.Add("Resultado: " + _output);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }   // Transformación Reversa String
        private void Ventana3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana4.Items.Clear();
                string _input = Interaction.InputBox("Ingrese la palabra en mayúsculas a modificar: ");
                bool _flag = MinusculasBool(_input);
                if (_flag == true) { MessageBox.Show("La palabra ya está completamente en minúsculas.", "Resultado"); }
                else
                {
                    string _output = Minusculas(_input);
                    MessageBox.Show("El resultado es: " + _output, "Resultado");
                    Ventana4.Items.Add("Palabra ingresada: " + _input);
                    Ventana4.Items.Add("Resultado: " + _output);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   // Transformación a Minusculas
        private void Ventana4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana5.Items.Clear();
                string _input1 = Interaction.InputBox("Ingrese la primer palabra a evaluar: ");
                string _input2 = Interaction.InputBox("Ingrese la segunda palabra a evaluar: ");
                bool _output = ComparacionStrings(_input1, _input2, 0); // el parámetro Posición debe cargarse como cero la primera vez. No dejamos que el usuario lo haga.
                MessageBox.Show("La validación entre la palabra '" + _input1 + "' y '" + _input2 + "' es: " + _output, "Resultado");
                Ventana5.Items.Add("Primer palabra: " + _input1);
                Ventana5.Items.Add("Segunda palabra: " + _input2);
                Ventana5.Items.Add("Resultado: " + _output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }   // Comparacion Dos Strings 
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   



        public double TasaDeRetorno(double tasa, int periodos) 
        {
            // Recursiva para calcular una tasa de interés compuesta (tiempo discreto)
            if (periodos == 0) { return 1.0; } // Caso Base
            else // Caso Recursivo
            { return ((1.0 + tasa) * TasaDeRetorno(tasa, periodos - 1)); }
        } 
        public int Ackermann(int n, int m) 
        {
            // Función de Ackermann... ojo con enteros mayores a 4 por OverFlow...
            if (n == 0) 
            { return m + 1; }

            if (n != 0 && m == 0)
            { return Ackermann(n - 1, 1); } 

            else 
            { return Ackermann(n - 1, Ackermann(n, m - 1)); }

        } // Funcion de Ackermann
        public bool MinusculasBool(string input)
        {
            // Función para determinar si un string ya está escrito completamente en minúsculas
            int _largo = input.Length;
            int _contador = 0;
            bool _flag;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLower(input[i]) == true) { _contador++; }             
            }
            if(_contador == _largo) { _flag = true; }
            else { _flag = false; }

            return _flag;
        }       // Función auxiliar de validacion para recursiva Minusculas
        public string Minusculas(string palabra)
        {
            // Función recursiva para modificar un string a minúsculas.
            if (palabra.Length == 1) { return palabra.ToLower(); } // Caso Base: 1 solo caracter

            else
            {   // Caso General/Recursivo: substrae de a una letra, la convierte en minuscula y la resta del string para hacer el llamado recursivo
                string letra;
                letra = palabra.Substring(0, 1);
                letra= letra.ToLower();
                palabra = palabra.Remove(0, 1);
                return letra + Minusculas(palabra);
            }
        }
        public bool ComparacionStrings(string pPalabraPrimera, string pPalabraSegunda, int pPosicion)
        {
            // Funcion recursiva para validar igualdad en dos strings. Se cumple si:
            // (1) Las palabras poseen el mismo largo + (2) Las palabras tengan las mismas letras
            if (pPalabraPrimera.Length != pPalabraSegunda.Length) { return false; } // Validamos condición necesaria

            else
            {
                int _largo = pPalabraPrimera.Length;
                if (pPosicion < _largo) // Validación para efectuar llamado recursivo o cortar
                {
                    if(pPalabraPrimera[pPosicion] != pPalabraSegunda[pPosicion])    // Validación de 2da condición necesaria - Primer Potencial Corte de la función
                    {
                        return false;                         
                    }
                    else
                    {
                        // Llamado recursivo
                        pPosicion = pPosicion + 1;
                        return ComparacionStrings(pPalabraPrimera, pPalabraSegunda, pPosicion);
                    }  
                }

                else // Segundo Potencial Corte de la función - La posición recorrió los strings completos: el resultado es true
                { return true; }                
            }

        }
        public string ReversaPrueba(string pPalabra, int pPosicion)
        {
            // Método recursivo para reversa de una cadena de strings (orden reversivo)
            if(pPosicion < pPalabra.Length)
            {
                return pPalabra[pPalabra.Length - pPosicion - 1].ToString() + ReversaPrueba(pPalabra, pPosicion + 1);
            }
            else
            {
                return "";
            }
        }
        public string ReversaString(string pPalabra)
        {
            // Método alternativo sin auxiliar contador
            if (pPalabra.Length > 0) // Caso Recursivo 
            { return pPalabra[pPalabra.Length - 1] + ReversaString(pPalabra.Substring(0, pPalabra.Length - 1)); }

            else { return pPalabra; } // Condición de Corte
        }   // Metodo alternativo a ReversaPrueba
    }
    
}



