using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons
{
    public class Tipo_habitacion
    {
        public int codigo_tipo { get; set; }
        public string descripcion { get; set; }
        public decimal porcentual { get; set; }
        public int capacidad { get; set; }
    }
}
