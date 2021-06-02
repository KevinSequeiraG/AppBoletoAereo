using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UTN.WinForms.Clases;

namespace UTN.WinForms.Clases
{
    class XML
    {
        public string Ruta
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\BoletosXml.xml"; }
        }

        public void CrearArchivoXML(Usuario user)
        {
            XmlDocument doc = new XmlDocument();
            
            // LoadXml carga un string con formato xml
            doc.LoadXml("<Personas></Personas>");
                        
            XmlElement root = doc.DocumentElement;

            XmlElement newRegistro = doc.CreateElement("persona");

            XmlElement nodoID = doc.CreateElement("identificacion");
            nodoID.InnerText = user.id;
            newRegistro.AppendChild(nodoID);

            XmlElement nodoNombre = doc.CreateElement("nombre");
            nodoNombre.InnerText = user.nombre;
            newRegistro.AppendChild(nodoNombre);

            XmlElement nodoNacionalidad = doc.CreateElement("nacionalidad");
            nodoNacionalidad.InnerText = user.nacionalidad;
            newRegistro.AppendChild(nodoNacionalidad);

            XmlElement nodoCosto = doc.CreateElement("Tax");
            nodoCosto.SetAttribute("Monto",user._Boleto.Monto().ToString());
            nodoCosto.SetAttribute("TAX", user._Boleto.Tax().ToString());
            nodoCosto.InnerText = user._Boleto.Total().ToString();
            newRegistro.AppendChild(nodoCosto);

            
            root.InsertBefore(newRegistro, root.FirstChild);
            doc.Save(Ruta);
        }
    }
}
