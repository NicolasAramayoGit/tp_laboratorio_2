using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto:IArchivos<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool estado = true;
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    escritor.Write(datos);
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
            return estado;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool estado = true;
            StringBuilder sb = new StringBuilder();
            string texto;
            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    while ((texto = lector.ReadLine()) != null)
                    {
                        sb.AppendLine(texto);
                    }
                    datos = sb.ToString();
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
            return estado;
        }
    }
}
