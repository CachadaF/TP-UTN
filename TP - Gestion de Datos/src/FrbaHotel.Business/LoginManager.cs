using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Commons;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using Data;
using System.Security.Cryptography;

namespace FrbaHotel.Business
{
    public partial class LoginManager
    {
        public void login(string username, string password)
        {
            string encryp_pass = Encriptacion.get_hash(password);


            DataRow resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETUSUARIO", SqlDataAccessArgs.CreateWith("@ID_USUARIO", username).Arguments);

   
            if (resultado == null || Convert.ToBoolean(resultado["Baja_Logica"])) //Usuario no existe en la BD o no esta habilitado
            {
                throw new Exception("Usuario inválido");
            }

            int intentos_fallidos = Convert.ToInt32(resultado["Intentos"]);

            if (intentos_fallidos == 3) throw new Exception("Usuario bloqueado.\nComuniquese con el Administrador del Sistema");

            if (resultado["Password"].ToString() != encryp_pass)//Usuario existe pero la pass esta mal
            {
                ingresarNuevoFallo(username);
                throw new Exception("Contraseña inválida");
            }
            else //contraseña correcta
            {
                resetearIntentosLogin(username);
            }


          
        }
       

        private void ingresarNuevoFallo(string username)
        {
          SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
           "LOS_NULL.LOGIN_FALLIDO", SqlDataAccessArgs.CreateWith("@ID_USER", username).Arguments);
        
        }

        private void resetearIntentosLogin(string username)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
           "LOS_NULL.RESET_LOGIN_TRIES", SqlDataAccessArgs.CreateWith("@ID_USER", username).Arguments);
        }
    }
}
