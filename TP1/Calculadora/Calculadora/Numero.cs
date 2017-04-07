using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Retorna número.
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Valida el string número en double.
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }

        /// <summary>
        /// Convierte un string a double, sino retorna 0.
        /// </summary>
        /// <param name="numeroString">parámetro a convertir.</param>
        /// <returns></returns>
        private double validarNumero(string numeroString)
        {
            double number;

            bool result = double.TryParse(numeroString, out number);

            if (result)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

       

        /// <summary>
        /// Inicializa el atributo número en 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0D;
        }

        /// <summary>
        /// Constructor que valida un string número a double.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Constructor que recibe eun double y lo carga en número.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
    }
}
