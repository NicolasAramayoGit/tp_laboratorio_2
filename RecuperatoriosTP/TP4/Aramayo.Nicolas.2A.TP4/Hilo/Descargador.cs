using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{   
    public delegate void DescargaEnProgreso(int Progreso);
    public delegate void DescargaTerminada(string html);
    public class Descargador
    {
        //private string html;
        private Uri direccion;
        /// <summary>
        /// Constructor del descargador
        /// </summary>
        /// <param name="direccion"></param>
        public Descargador(Uri direccion)
        {
            //this.html = "";
            this.direccion = direccion;
        }
        /// <summary>
        /// Se inicia la descarga del codigo fuente de la url ingresada
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public event DescargaEnProgreso Descargando;
        public event DescargaTerminada Finalizado;
        /// <summary>
        /// Se invoca al evento que muestra el progreso de la descarga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Descargando(e.ProgressPercentage);
        }
        /// <summary>
        /// Se invoca el evento que carga el codigo fuente en el ritchTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {   
            this.Finalizado(e.Result);
        }
    }
}
