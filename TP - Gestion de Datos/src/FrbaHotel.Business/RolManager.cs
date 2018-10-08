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

namespace FrbaHotel.Business
{
    public partial class RolManager:IBuilder<Rol>
    {

        FuncionalidadManager _funcMan = new FuncionalidadManager();

        public Rol Build(System.Data.DataRow row)
        {
            Rol rol = new Rol();
            rol.id_rol = Convert.ToInt32(row["ID_Rol"]);
            rol.nombre_rol = Convert.ToString(row["Nombre_Rol"]);
            rol.baja_logica = Convert.ToBoolean(row["Baja_Logica"]);
            return rol;
        }

        public Rol Build(string PK)
        {
            Rol rol = null;

            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETROL", SqlDataAccessArgs.CreateWith("@ID_ROL", PK).Arguments);

            if (resultado != null)
            {
                rol = this.Build(resultado);
            }

            return rol;
        }

        public BindingList<Rol> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLROLES");
            var lista_roles = new BindingList<Rol>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var rol = Build(row);

                    lista_roles.Add(rol);
                }
            }
            return lista_roles;
        }

        public void Insertar(Rol rol)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.INSERTARROL", SqlDataAccessArgs.CreateWith("@NOMBRE_ROL", rol.nombre_rol)
                .And("@BAJA_LOGICA", rol.baja_logica).Arguments);

            return;
        }

       public void Modificar(Rol rol)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.MODIFICARROL", SqlDataAccessArgs.CreateWith("ID_ROL",rol.id_rol).And("@NOMBRE_ROL", rol.nombre_rol)
                .And("@BAJA_LOGICA", rol.baja_logica).Arguments);

            return;
        }

        public int GetIdPorNombre(string nombre)
        {
            DataRow row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.GETID_ROL", SqlDataAccessArgs.CreateWith("@NOMBRE_ROL", nombre).Arguments);

            return Convert.ToInt32(row["ID_Rol"]);
        }

        public BindingList<string> GetAllPorUser(string user_id, bool solo_activos)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.GETALLROL_USER", SqlDataAccessArgs.CreateWith("@ID_User", user_id).Arguments);

            var lista_roles = new BindingList<string>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    if (solo_activos)
                    {
                        if (Convert.ToBoolean(row["Baja_Logica"]) == false)
                            lista_roles.Add(Convert.ToString(row["Nombre_Rol"]));
                    }
                    else lista_roles.Add(Convert.ToString(row["Nombre_Rol"]));
                }

            }
            return lista_roles;

        }

        public void AgregarEnUser(string rol, string user)
        {
            int id_rol = this.GetIdPorNombre(rol);
            
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.AGREGARROL_A_USER", SqlDataAccessArgs.CreateWith("@ID_ROL", id_rol)
            .And("@ID_USER", user).Arguments);

            return;
        }

        public void EliminarDeUser(string rol, string user)
        {
            int id_rol = this.GetIdPorNombre(rol);

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.ELIMINAROL_DE_USER", SqlDataAccessArgs.CreateWith("@ID_ROL", id_rol)
            .And("@ID_USER", user).Arguments);

            return;
        }

        public bool estaEnUser(string rol, BindingList<string> l_roles_user)
        {
            if (l_roles_user == null) return false;

            bool ret = false;

            foreach (string rol_en_user in l_roles_user)
            {
                ret = ret || (rol_en_user == rol);
            }

            return ret;
        }
    }
}
