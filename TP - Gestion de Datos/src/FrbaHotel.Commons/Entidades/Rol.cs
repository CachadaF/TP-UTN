using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrbaHotel.Commons;

namespace FrbaHotel.Commons
{
    public class Rol
    {
        public int id_rol { get; set; }
        public string nombre_rol { get; set; }
        public BindingList<Funcionalidad> funcionalidad {get;set;}
        public bool baja_logica { get; set; }

    }
}
