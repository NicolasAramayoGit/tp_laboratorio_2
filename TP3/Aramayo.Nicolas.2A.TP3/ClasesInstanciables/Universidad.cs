using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        #region Propiedades.

        /// <summary>
        /// Propiedad de lectura y escritura que retorna Lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que retorna una lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que retorna una lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }

        /// <summary>
        /// Indexador que devuelve una Jornada específica.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this._jornada[i]; }
            set { this._jornada[i] = value; }
        }

        #endregion


        #region Constructor.

        /// <summary>
        /// Constructor por defecto, inicializa los atributos.
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornada = new List<Jornada>();
        }

        #endregion

        #region Sobrecarga de Operadores = != +

        /// <summary>
        /// Devuelve true si el alumno esta inscrito en al universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno alumno in u._alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna true si el alumnos NO esta inscript en la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }


        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            { // Si no hay profesores ???
                if (profesor == clase)
                {
                    return profesor; // revisar si funciona correctamente.
                }
            }
            
            throw new SinProfesorException();
        }


        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna true si el profesor esta dando clases en la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == p)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna true si el profesor NO esta dando clases en la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }


        #endregion


        #region Métodos.

        /// <summary>
        /// Devuelve una cadena con todos los datos de la Universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Retorna una cadena con los datos de clase Universidad.
        /// </summary>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada j in gim._jornada)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Serializa los datos de la Universidad en un XML, incluyendo los datos de Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Universidad));
                using (XmlTextWriter escritor = new XmlTextWriter("Datos.xml",Encoding.UTF8))
                {
                    serializador.Serialize(escritor, gim);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un Error al Serializar objeto Universidad..." + ex.Message);
            }
            
            return true;
        }

        /// <summary>
        /// Retorna una Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static Universidad Leer(Universidad gim)
        {
            if (Universidad.Guardar(gim))
            {
                return gim;
            }

            return null;
        }

        #endregion

        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
    }
}
