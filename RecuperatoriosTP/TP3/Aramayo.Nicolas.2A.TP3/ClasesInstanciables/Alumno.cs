using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Alumno:Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        /// <summary>
        /// Constructor para serializar a XML.
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor que llama al base y toma como párametro un EClase.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Sobreecarga del constructor que llama al anterior y que agrega un EEstadoCuenta.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna un string con los datos de la clase.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Hace público los datos de la Clase Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Retorna una cadena "TOMA CLASE DE: ", con la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Alumno es igual EClase si toma esa clase y su estado de cuenta no es deudor.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase que toma</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Un Alumno es distinto a un EClase si no toma esa clase.
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a1, Universidad.EClases clase)
        {
            return a1._claseQueToma != clase;
        }

    }
}
