using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Texto
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (XmlTextWriter escritor = new XmlTextWriter(archivo,Encoding.UTF8))
                {
                    serializador.Serialize(escritor,datos);
                }
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            return true;
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    datos =(T)serializador.Deserialize(lector);
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
