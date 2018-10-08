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
    public partial class FuncionalidadManager : IBuilder<Funcionalidad>
    {
        public Funcionalidad Build(System.Data.DataRow row)
        {
            Funcionalidad fun = new Funcionalidad();
            fun.id_funcionalidad = Convert.ToInt32(row["ID_Funcionalidad"]);
            fun.nombre_funcionalidad = Convert.ToString(row["Nombre_Func"]);
            return fun;
        }



        public BindingList<Funcionalidad> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLFUNCS");

            var lista_func = new BindingList<Funcionalidad>();

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var func = Build(row);
                    lista_func.Add(func);
                }
            }

            return lista_func;
        }

        public BindingList<Funcionalidad> GetPorRol(int id_rol)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLFUNCXROL", SqlDataAccessArgs.CreateWith("@ID_ROL", id_rol).Arguments);

            var lista_func = new BindingList<Funcionalidad>();

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var func = Build(row);
                    lista_func.Add(func);
                }
            }

            return lista_func;
        }

        public void AgregarEnRol(Funcionalidad func, int id_rol)
        {
          //  try{

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.AGREGARFUNC_A_ROL", SqlDataAccessArgs.CreateWith("@ID_ROL", id_rol)
                .And("@ID_FUNC",(int) func.id_funcionalidad).Arguments);
         //   }
         /*   catch(SqlException ex)
            {
                if (ex.ErrorCode == -2146232060) return; //si ya existe la PK
            }*/
            
        }

        public void EliminarDeRol(Funcionalidad func, int id_rol)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.ELIMINARFUNC_DE_ROL", SqlDataAccessArgs.CreateWith("@ID_FUNC", func.id_funcionalidad)
                .And("@ID_ROL",id_rol).Arguments);

            return;
        }

        public bool estaEnLista(Funcionalidad f, BindingList<Funcionalidad> lista)
        {
            if (lista == null) return false;
            
            bool ret = false;

            foreach (Funcionalidad func in lista)
            {
                ret = ret || (func.id_funcionalidad == f.id_funcionalidad);
            }

            return ret;
        }

        public int GetIdPorNombre(string nombre)
        {
            DataRow row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.GETID_FUNC", SqlDataAccessArgs.CreateWith("@NOMBRE_FUNC", nombre).Arguments);

            return Convert.ToInt32(row["ID_Funcionalidad"]);

        }
    }
}
