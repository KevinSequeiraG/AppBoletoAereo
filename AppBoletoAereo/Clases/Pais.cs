using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.WinForms.Clases
{
    class Pais
    {
        public double costo { get; set; }
        public string nombre { get; set; }

        public Pais(string nombre, double costo)
        {
            this.nombre = nombre;
            this.costo = costo;
        }
        public override string ToString()
        {
            return nombre + " " + costo;
        }
    }
}
