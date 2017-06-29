using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _rutaDeArchivo;
        /// <summary>
        /// Constructor de la clase Texto
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this._rutaDeArchivo = archivo;
        }

        /// <summary>
        /// Retorna true si guarda datos en un archivo de texto, si falla la escritura lanza una excepcion
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(this._rutaDeArchivo, true)) 
                {
                    escritor.WriteLine(datos);
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return true;
        }
        /// <summary>
        /// Retorna true si lee la ruta del archivo y guarda los datos en un listado de string, si la lectura falla lanza una excepcion
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader lector = new StreamReader(this._rutaDeArchivo))
                {
                    while (lector.EndOfStream == false) 
                    {
                        datos.Add(lector.ReadLine());
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return true;
        }
    }
}
