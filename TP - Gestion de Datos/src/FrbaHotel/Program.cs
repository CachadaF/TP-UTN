using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using FrbaHotel.Login;
using FrbaHotel.Business;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.Commons;
using FrbaHotel.ABM_de_Rol;

namespace FrbaHotel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          /*  Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppExceptionHandler.Invoke);*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Sesion se = new Sesion();

            Application.Run(new FrbaHotel.MainScreen());
        }
    }
}
