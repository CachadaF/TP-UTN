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
    public partial class Tipo_habitacionManager : IBuilder<Tipo_habitacion>
    {
        public Tipo_habitacion GetPorCantidad(int cantidad)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETTIPOHABITACIONPORCANTIDAD", SqlDataAccessArgs.CreateWith("@CANTIDAD",cantidad).Arguments);

            var habitacion_tipo = new Tipo_habitacion();

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {                    
                    habitacion_tipo.codigo_tipo = int.Parse(row["Codigo_Tipo"].ToString());
                    habitacion_tipo.capacidad = int.Parse(row["Capacidad"].ToString());
                    habitacion_tipo.descripcion = row["Descripcion"].ToString();
                    habitacion_tipo.porcentual = decimal.Parse(row["Porcentual"].ToString());
                }
            }
            return habitacion_tipo;
        }

        public BindingList<Tipo_habitacion> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLTIPOHABITACION");
            var lista_habitaciones_tipo = new BindingList<Tipo_habitacion>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var habitacion_tipo = new Tipo_habitacion();
                    habitacion_tipo.codigo_tipo = int.Parse(row["Codigo_Tipo"].ToString());
                    habitacion_tipo.capacidad = int.Parse(row["Capacidad"].ToString());
                    habitacion_tipo.descripcion = row["Descripcion"].ToString();
                    habitacion_tipo.porcentual = decimal.Parse(row["Porcentual"].ToString());    

                    lista_habitaciones_tipo.Add(habitacion_tipo);
                }
            }
            return lista_habitaciones_tipo;
        }

        public String Get_Tipo_Hab(int ID_Tipo)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                         "LOS_NULL.GETTIPOHABITACION", SqlDataAccessArgs.CreateWith("@CODIGOTIPO",ID_Tipo).Arguments);
            String tipo_habi = " ";

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    tipo_habi = (row["Descripcion"].ToString());                    
                }
            }
            return tipo_habi;
        }

        public int Get_ID_Tipo(String string_tipo_hab)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                         "LOS_NULL.GETIDTIPOHABITACION", SqlDataAccessArgs.CreateWith("@DESCRIPCION",string_tipo_hab).Arguments);
            int ID_Tipo = 0;

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    ID_Tipo = int.Parse(row["Codigo_Tipo"].ToString());
                }
            }
            return ID_Tipo;
        }
                
        public Tipo_habitacion Build(System.Data.DataRow row)
        {
            Tipo_habitacion tipo_hab = new Tipo_habitacion();
            tipo_hab.codigo_tipo = int.Parse(row["Codigo_Tipo"].ToString());
            tipo_hab.descripcion = row["Descripcion"].ToString();
            tipo_hab.porcentual = decimal.Parse(row["Porcentual"].ToString());
            tipo_hab.capacidad = int.Parse(row["Capacidad"].ToString());
            return tipo_hab;
        }

        public Tipo_habitacion Build(UInt32 PK)
        {
            Tipo_habitacion tipo_hab = null;

            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETTIPOHABITACION", SqlDataAccessArgs.CreateWith("@CODIGOTIPO", PK).Arguments);

            if (resultado != null)
            {
                tipo_hab = this.Build(resultado);
            }

            return tipo_hab;
        }
        
    }
}
