using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
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
            set { this._dni = value; }
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

        //public string StringToDni
        //{
        //    set { this._dni = Validar(); }
        //}

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (ENacionalidad.Argentino == nacionalidad && 1 <= dato || dato <= 89999999)
            {
                return dato;
            }
            throw new DniInvalidoException();
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }

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
