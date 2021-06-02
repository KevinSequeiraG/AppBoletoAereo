using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.Clases;
using UTN.WinForms.Enums;

namespace UTN.WinForms.Clases
{
    class FactoryBoleto
    {
        public static Boleto CreateBoleto(TipoBoleto pTipoBoleto, Pais destino, bool hasEquipaje, String tipo, bool HasAnimales, bool HasOtros)
        {

            Boleto oBoleto = null;

            switch (pTipoBoleto)
            {
                case TipoBoleto.Normal:
                    oBoleto = new Normal(destino, hasEquipaje, tipo);
                    break;
                case TipoBoleto.PrimeraClase:
                    oBoleto = new PrimeraClase(destino, hasEquipaje, tipo, HasAnimales, HasOtros);
                    break;
            }
            return oBoleto;
        }
    }
}
