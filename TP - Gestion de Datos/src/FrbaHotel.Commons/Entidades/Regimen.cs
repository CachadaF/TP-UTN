using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace FrbaHotel.Commons
{
    public class Regimen
    {
        public int id_regimen { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public bool estado { get; set; }
    }
}
