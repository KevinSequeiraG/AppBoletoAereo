using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.WinForms.Clases
{
    abstract class Boleto
    {
        public Pais _Destino { get; set; }
        public bool hasEquipaje { get; set; }
        public string Tipo { get; set; }

        public Boleto(Pais _Destino, bool hasEquipaje, string Tipo)
        {
            this._Destino = _Destino;
            this.hasEquipaje = hasEquipaje;
            this.Tipo = Tipo;
        }

        public abstract double Monto();
        public abstract double Tax();
        public abstract double Total();
    }
}
