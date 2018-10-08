using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons
{
    public class PersonaDeUser
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipo_doc { get; set; }
        public Int32 documento { get; set; }
        public DateTime fecha_nac { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public string nro_depto { get; set; }
        public string dom_calle { get; set; }
        public Int32 dom_numero { get; set; }
        public string localidad { get; set; }
        public Int32 piso { get; set; }
    }
}
