using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Propiedades.

        /// <summary>
        /// Propiedad de lectura y escritura, retorna una lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }

            set
            {
                this._alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, retorna un enumerado de tipo EClases.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }

            set
            {
                this._clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que retorna un profesor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }

            set
            {
                this._instructor = value;
            }
        }


        #endregion

        #region Constructores.

        /// <summary>
        /// Constructor por defecto inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que llama al contructor por defecto.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }


        #endregion

        #region Operadores == != + 

        /// <summary>
        /// Jornada es igual a un Alumno si este participa en la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j._alumnos)
            {
                if (a == alumno)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna true si el alumno NO participa en clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega alumnos a la clase validando que no estén previamente cargados.
        /// </summary>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }

        #endregion


        #region Métodos.


        /// <summary>
        /// Muestra todos los datos de la clase Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendLine(this._instructor.ToString());
            if (this.Alumnos.Count == 0)
            {
                sb.AppendLine("NO HAY ALUMNOS");
            }
            sb.AppendLine("ALUMNOS");

            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            sb.AppendLine("<----------------------------------------------->");

            return sb.ToString();
        }


        

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo txt.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());

        }

        /// <summary>
        /// Lee los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto texto = new Texto();
            string datos;
            texto.Leer("Jornada.txt", out datos);
            return datos;

        }

        #endregion

    }
}
