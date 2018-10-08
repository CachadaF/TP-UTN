using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons
{
    public class Habitacion
    {
        public int id_habitacion { get; set; }
        public int numero { get; set; }
        public int piso { get; set; }
        public int id_tipo_hab { get; set; }
        public int id_hotel { get; set; }
        public string frente { get; set; }
        public bool baja_logica { get; set; }
        public string descripcion { get; set; }

    }
}
