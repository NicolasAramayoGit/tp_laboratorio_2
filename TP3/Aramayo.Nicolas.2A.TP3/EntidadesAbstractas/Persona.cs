using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }


        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (!String.IsNullOrEmpty(ValidarNombreApellido(value)))
                {
                    this._apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (!String.IsNullOrEmpty(ValidarNombreApellido(value)))
                {
                    this._nombre = value;
                }
            }
        }

        public string StringToDni
        {
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }

        /// <summary>
        /// Constructor vacio para serializar en XML.
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Constructor que toma 3 parametros nombre, apellido y nacionalidad.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor toma un parametro entero DNI.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que toma un parametro string DNI.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        /// <summary>
        /// Retorna los datos de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("DNI: " + this.DNI.ToString());
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el DNI sea correcto, segun nacionalidad. Si no lanza una exepcion.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                case ENacionalidad.Extranjero:
                    if (dato < 90000000)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                default:
                    return dato;
            }
        }

        /// <summary>
        /// Valida el DNI de tipo string, caso contrario lanza una exception.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoaux;

            if (int.TryParse(dato, out datoaux) && !String.IsNullOrEmpty(dato))
            {
                return this.ValidarDni(nacionalidad, datoaux);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Valida que sean caracteres validos para nombre, caso contrario no se carga.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (string.IsNullOrEmpty(dato))
            {
                return null;
            }

            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato, i))
                {
                    return null;
                }
            }

            return dato;
        }
    }
}
