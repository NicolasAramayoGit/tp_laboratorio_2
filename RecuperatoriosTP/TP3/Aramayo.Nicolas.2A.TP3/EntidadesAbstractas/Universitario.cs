using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int _legajo;

        /// <summary>
        /// Constructor para serializar a XML.
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor que llama al base y que toma un parametro legajo entero.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        /// <summary>
        /// Muestra todos los datos de la clase.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("\nLEGAJO NÚMERO: {0} ", this._legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Método abstracto, retorna un string.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga del operador == comparar dos objetos de tipo Universitario.
        /// </summary>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI) && pg1.Equals(pg2);
        }

        /// <summary>
        /// Sobrecarga del operador != compara dos objetos de tipo Universitario.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Sobrecarga del Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
    }
}
