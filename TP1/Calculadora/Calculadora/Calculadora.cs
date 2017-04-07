using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operación, sino puede operar (división por 0), retorna 0.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            if (validarOperador(operador) == "+")
            {
                return numero1.getNumero() + numero2.getNumero();
            }
            if (validarOperador(operador) == "-")
            {
                return numero1.getNumero() - numero2.getNumero();
            }
            if (validarOperador(operador) == "*")
            {
                return numero1.getNumero() * numero2.getNumero(); 
            }
            if (validarOperador(operador) == "/")
            {
                if (numero2.getNumero() != 0)
                {
                    return numero1.getNumero() / numero2.getNumero();
                }
            }
            return 0;
        }

        /// <summary>
        /// Válida que sea un operador, caso contrario retorna "+".
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {
            if (operador == "+")
            {
                return operador;
            }
            if (operador == "-")
            {
                return operador;
            }
            if (operador == "*")
            {
                return operador;
            }
            if (operador == "/")
            {
                return operador;
            }

            return "+";

        }
    }
}
