using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace FrbaHotel.Commons
{
    public class Reserva
    {
        public int codigo_reserva { get; set; }
        public DateTime fecha_inicio { get; set; }
        public int cant_noches { get; set; }
        public DateTime fecha_realizada { get; set; }
        public int estado { get; set; }
        public string usuario { get; set; }
        public int regimen { get; set; }

    }
}
