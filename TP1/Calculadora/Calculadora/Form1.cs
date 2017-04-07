using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1;
            Numero numero2;
            double result;

            numero1 = new Numero(this.txtNumero1.Text);
            numero2 = new Numero(this.txtNumero2.Text);

            result = Calculadora.operar(numero1, numero2, this.cmbOperacion.Text);
            this.lblResultado.Text = result.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = string.Empty;
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = string.Empty;
        }
    }
}
