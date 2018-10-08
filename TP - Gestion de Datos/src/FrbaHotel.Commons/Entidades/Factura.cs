using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons
{
    public class Factura
    {
        public long nro_factura { get; set; }
        public DateTime fecha { get; set; }
        public UInt32 total { get; set; }
        public string forma_pago { get; set; }
        public long tarj_cred { get; set; }
        public string detalle_estadia { get; set; }

    }
}
