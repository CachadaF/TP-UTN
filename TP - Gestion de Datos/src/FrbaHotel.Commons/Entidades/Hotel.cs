using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FrbaHotel.Commons
{
    public class Hotel
    {
        public int id_hotel { get; set; }
        public string ciudad { get; set; }
        public string calle { get; set; }
        public int nro_calle { get; set; }
        public int cant_estrellas { get; set; }
        public decimal recarga_estrella { get; set; }
        public string telefono { get; set; }
        public string pais { get; set; }
        public DateTime fecha_creacion { get; set; }
        public BindingList<Regimen> regimenes_list { get; set; }

        public Hotel()
        {

            regimenes_list = new BindingList<Regimen>();
        }
    }
}
