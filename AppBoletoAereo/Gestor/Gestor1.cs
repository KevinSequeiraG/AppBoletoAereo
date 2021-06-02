using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.Clases;

namespace UTN.WinForms.Gestor
{
    class Gestor1
    {
        private Usuario _Usuario;
        public Gestor1(Usuario pUsuario)
        {
            _Usuario = pUsuario;
        }
        public double GetTax()
        {
            return _Usuario._Boleto.Tax();
        }
        public double GetTotal()
        {
            return _Usuario._Boleto.Total();
        }
        public double GetMonto()
        {
            return _Usuario._Boleto.Monto();
        }
        public void SalvarXML()
        {
            string xml = _Usuario.ToString();
            //XML.CrearArchivoXML(xml);
        }
    }
}
