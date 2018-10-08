using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrbaHotel.Commons;

namespace FrbaHotel.Commons
{
    public class Usuario
    {
        public string id_usuario { get; set; }
        public string password { get; set; }
        public Int32 intentos { get; set; }
        public bool baja_logica { get; set; }
        public BindingList<int> hoteles {get;set;}
        public BindingList<string> roles { get; set; }
        

    }
}
