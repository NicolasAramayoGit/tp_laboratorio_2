using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace ClasesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
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
            { 
                if (profesor == clase)
                {
                    return profesor;
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


        /// <summary>
        /// Agrega un alumno a la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            bool estado = true;

            foreach (Alumno alumno in u.Alumnos)
            {
                if (alumno == a)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            bool estado = true;
            foreach (Profesor item in u.Instructores)
            {
                if (item == i)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Agrega una clase a la universidad y agrega una nueva jornada.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (u == clase));
            foreach (Alumno item in u.Alumnos)
            {
                if (item == clase)
                {
                    nuevaJornada = nuevaJornada + item;
                }
            }
            u._jornada.Add(nuevaJornada);
            return u;
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
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Guardar("Universidad.xml", gim);
            }
            catch (Exception)
            {
                throw new ArchivosException();
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
            Universidad u;
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();

                xml.Leer("Universidad.xml", out u);
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }

            return u;
        }

        #endregion

        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
    }

}
