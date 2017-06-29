using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Profesor:Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        /// <summary>
        /// Constructor estático que inicializa el atributo estático.
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor para serializar a XML.
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor inicializa dos clases al profesor, pueden ser iguales o no.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            // Llamo al objeto random, ELIJO UN ENUMERADO AL AZAR, luego el resultado de tipo
            // entero lo CASTEO a un enumerado de tipo EClases
            // Y lo agrego a la cola.
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
        }


        /// <summary>
        /// Sobreescritura del método, muestra todos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString(); 
        }

        /// <summary>
        /// Muestran todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Retorna una cadena "CLASES DEL DÍA ", junto con el nombre de la clase del día.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Agrega una clase random a la cola de clases.
        /// </summary>
        private void _randomClases()
        {
            Universidad.EClases clase;
            clase = (Universidad.EClases)_random.Next(0, 4);
            this._clasesDelDia.Enqueue(clase);

        }

        /// <summary>
        /// Retorna true si el profesor da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i._clasesDelDia)
            {
                if (c == clase)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna true si el profesor NO da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        
    }
}
