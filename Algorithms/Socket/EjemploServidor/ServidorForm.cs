using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploServidor
{
    public partial class ServidorForm : Form
    {
        Servidor servidor;

        public ServidorForm()
        {
            InitializeComponent();
        }

        private void Log(string texto)
        {
            // Invoke nos permite ejecutar un delegado en el tread de la UI. 
            // El problema radica en que no es seguro interactuar con los controles
            // de Windows Forms desde múltiples threads. Y en este ejemplo, el 
            // método Log se está llamando desde eventos que se disparan desde
            // threads creados en el objeto Servidor.
            // Ver: https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls
            Invoke((Action)delegate
            {
                txtLog.AppendText($"{DateTime.Now.ToLongTimeString()} - {texto}");
                txtLog.AppendText(Environment.NewLine); // Lo reemplazamos por el \n\r porque estaba funcionando mal...
            });
        }
        private void Log2(string texto)
        {
            Invoke((Action)delegate
            {
                txtConectados.AppendText($"{DateTime.Now.ToLongTimeString()} - {texto}");
                txtConectados.AppendText(Environment.NewLine);
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializo el servidor estableciendo el puerto donde escuchar
            servidor = new Servidor(8050);

            // Me suscribo a los eventos
            servidor.NuevaConexion += Servidor_NuevaConexion;
            servidor.ConexionTerminada += Servidor_ConexionTerminada;
            servidor.DatosRecibidos += Servidor_DatosRecibidos;
            servidor.ClientesConectados += Servidor_ClientesConectados;

            // Comienzo la escucha
            servidor.Escuchar();
        }

        private void Servidor_NuevaConexion(object sender, ServidorEventArgs e)
        {
            //  Muestro quién se conectó
            Log($"Se ha conectado un nuevo cliente desde la IP = {e.EndPoint.Address}, Puerto = {e.EndPoint.Port}");
        }

        private void Servidor_ConexionTerminada(object sender, ServidorEventArgs e)
        {
            // Muestro con quién se terminó la conexión
            Log($"Se ha desconectado el cliente de la IP = {e.EndPoint.Address}, Puerto = {e.EndPoint.Port}");
        }

        private void Servidor_DatosRecibidos(object sender, DatosRecibidosEventArgs e)
        {
            if(e.DatosRecibidos.)
            // Muestro quién envió el mensaje
            Log($"Nuevo mensaje desde el cliente de la IP = {e.EndPoint.Address}, Puerto = {e.EndPoint.Port}");

            //  Muestro el mensaje recibido
            Log(e.DatosRecibidos);

            // Juancito: por si queremos que el server repita los mensajes...
            //Log("Mensaje reenviado a todos los clientes."); servidor.EnviarDatos(e.DatosRecibidos);
        }

        private void Servidor_ClientesConectados(object sender, ClientesConectadosEventArgs e)
        {
            txtConectados.Clear();
            Log2("Los clientes conectados al momento son: ");
            int i = 0;
            foreach(var dato in e.ArrayEndPoint) 
            {
                Log2($"Cliente IP = {e.ArrayEndPoint[i].Address}, Puerto = {e.ArrayEndPoint[i].Port}");                
                i++;
            }
            
            
        }
        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            servidor.EnviarDatos(txtMensaje.Text);
            txtMensaje.Clear();
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        // Juancito: controles de windows form para mostrar clientes conectados
        private void btnVerConectados_Click(object sender, EventArgs e)
        {
            servidor.MostrarClientesConectados();
        }
        private void txtConectados_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
