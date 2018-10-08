using System.ComponentModel;
using FrbaHotel.Commons;

namespace FrbaHotel.Business
{
    //"Clase Global" en la aplicacion

    public class Sesion
    {
        public static string user_id { get; set; }
        public static string password { get; set; } //hasheada
        public static string rol { get; set; }
        public static int id_hotel = 0;
        public static BindingList<Funcionalidad> funcionalidades { get; set; }
        public static bool iniciada = false;


        public static void cerrar_se()
        {
            iniciada = false;
            id_hotel = 0;
            funcionalidades.Clear();
            password = "";
            rol = "";
            user_id = "";
        }

        public static void iniciar_se(string user, string pass, string r, int h, BindingList<Funcionalidad> lf)
        {
            user_id = user;
            password = pass;
            rol = r;
            id_hotel = h;
            funcionalidades = lf;
            iniciada = true;
        }
    }
}
