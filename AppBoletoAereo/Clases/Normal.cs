using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.WinForms.Clases
{
    class Normal : Boleto
    {
        public Normal(Pais destino, bool hasEquipaje, String tipo)
            : base(destino, hasEquipaje, tipo)
        {

        }
        public override double Monto()
        {
            double tot = base._Destino.costo;
            
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
