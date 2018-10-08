using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons
{
    public class Cliente
    {
        public Int32 id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Int32 pasaporte { get; set; }
        public Int32 nacionalidad { get; set; }
        public DateTime fecha_nac { get; set; }
        public string mail { get; set; }
        public string nro_depto { get; set; }       
        public string dom_calle { get; set; }
        public Int32 dom_numero { get; set; }
        public Int32? piso { get; set; }
        public bool baja_logica { get; set; }
        public bool Duplicado_Pasaporte { get; set; }
        public bool Duplicado_Mail { get; set; }

    }
}
