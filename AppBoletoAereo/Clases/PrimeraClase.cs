using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.WinForms.Clases
{
    class PrimeraClase : Boleto

    {
        public bool HasAnimales { get; set; }
        public bool HasOtros { get; set; }
        public PrimeraClase(Pais destino, bool hasEquipaje, String tipo, bool HasAnimales, bool HasOtros)
            : base(destino, hasEquipaje, tipo)
        {
            this.HasAnimales = HasAnimales;
            this.HasOtros = HasOtros;
        }

        public override double Monto()
        {
            double tot = 200 + base._Destino.costo;
            if (HasAnimales)
            {
                tot += 50;
            }
            if (HasOtros)
            {
                tot += 100;
            }
            if (base.hasEquipaje)
            {
                tot += 25;
            }
            return tot;
        }

        public override double Tax()
        {
            return Monto() * 0.13;
        }

        public override double Total()
        {
            return Monto() + Tax();
        }
    }
}
