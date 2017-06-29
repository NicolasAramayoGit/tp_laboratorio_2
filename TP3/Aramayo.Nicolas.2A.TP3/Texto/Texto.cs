using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texto
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo,true))
                {
                    file.WriteLine(datos);
                }
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }

            return true;
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }

            return true;
        }
    }
}
