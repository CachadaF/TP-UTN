using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons
{
    public class Item_factura
    {
        public int id_item { get; set; }
        public int cantidad { get; set; }
        public decimal monto { get; set; }
        public int factura { get; set; }
        public int estadia { get; set; }
        public int consumible { get; set; }
        public string descripcion { get; set; }
    }
}
