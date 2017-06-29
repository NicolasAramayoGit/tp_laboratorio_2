using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        Archivos.Texto archivos;
        /// <summary>
        /// Inicializa el formulario del historial e inicializa la ruta del archivo donde estan guardados todos los url anteriormente ingresados
        /// </summary>
        public frmHistorial()
        {
            InitializeComponent();
            this.archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        /// <summary>
        /// Se le agrega al historial todas las paginas buscadas desde la creacion del archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            List<string> Historial;
            try
            {
                this.archivos.leer(out Historial);
                foreach (String item in Historial)
                {
                    this.lstHistorial.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }
    }
}
