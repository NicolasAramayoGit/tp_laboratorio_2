using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>:IArchivos<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool estado = true;
            try
            {

                using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(escritor, datos);
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
            return estado;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool estado = true;
            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(lector);
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
