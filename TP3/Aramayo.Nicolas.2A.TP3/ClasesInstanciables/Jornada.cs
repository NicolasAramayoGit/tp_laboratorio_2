using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Propiedades.

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
                if (a == j._clase)
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

            return j;
        }

        #endregion

        /// <summary>
        /// Muestra todos los datos de la clase Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendLine(this._instructor.ToString());
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
        public bool Guardar(Jornada jornada)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter("Jornada.txt"))
                {
                    escritor.WriteLine(jornada.ToString());
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }

            return true;
        }

        /// <summary>
        /// Lee los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader lector = new StreamReader("Jornada.txt"))
                {
                    sb.AppendLine(lector.ReadLine());
                }
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }

            return sb.ToString();
        }

    }
}
