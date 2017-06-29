using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;
        /// <summary>
        /// Iniciliza el formulario frmwebBrowser e inicializa la ruta del archivo donde estan guardaremos todos los url que ingresemos
        /// </summary>
        public frmWebBrowser()
        {
            InitializeComponent();
            this.archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }
        /// <summary>
        /// Configuramos el formato de texto del textBox donde ingresamos el url 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }
        /// <summary>
        /// Borra el textbox cuando ingresamos un caracter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Escribe un mensaje en el textBox cuando no hay ningun caracter en el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }
        /// <summary>
        /// Selecciona todo el texto del textBox donde cargamos nuestro url al momento de hacerle click con el mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        /// <summary>
        /// Metodo que es llamado con el evento Descargando y se encarga de ir actualizando la barra de progreso hasta que termine
        /// </summary>
        /// <param name="progreso"></param>
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        /// <summary>
        /// Metodo que es llamado con el evento Finalizado y se encarga de cargar el url el ritchTextBox cuando la descarga finaliza
        /// </summary>
        /// <param name="html"></param>
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }
        /// <summary>
        /// Implementa el manejador a los eventos de la clase Descargador, descarga el codigo fuente de la url ingresada y guarda el url en un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                Uri direccionUrl = new Uri("https://" + this.txtUrl.Text);

                if (direccionUrl != null) 
                {
                    Descargador descargador = new Descargador(direccionUrl);
                    descargador.Descargando += new DescargaEnProgreso(this.ProgresoDescarga);
                    descargador.Finalizado += new DescargaTerminada(this.FinDescarga);
                    Thread hilo = new Thread(descargador.IniciarDescarga);
                    hilo.Start();
                    this.archivos.guardar(this.txtUrl.Text);
                }
                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Muestra el historial con todas las paginas buscadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial historial = new frmHistorial();
            historial.Show();
        }
    }
}
