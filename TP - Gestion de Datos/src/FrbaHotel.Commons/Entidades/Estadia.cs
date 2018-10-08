using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons
{
    public class Estadia
    {
        public int id_estadia { get; set; }
        public DateTime fecha_inicio { get; set; }
        public int cant_noches { get; set; }
        public int reserva { get; set; }
        public string user_ingreso { get; set; }
        public string user_egreso { get; set; }

    }
}
