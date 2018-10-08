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
    public partial class HabitacionManager : IBuilder<Habitacion>
    {
        public BindingList<String> GetHabitacionUbicacion()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLUBICACIONESHABITACION");
            var lista_ubicaciones = new BindingList<String>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    String ubicacion_hab = (row["Frente"].ToString());
                    lista_ubicaciones.Add(ubicacion_hab);
                }
            }
            return lista_ubicaciones;
        }

        public Habitacion GetHabitacionHotel(int nro_habitacion, int nro_hotel)
        {
            Habitacion get_habitac = new Habitacion();
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
             "LOS_NULL.GETHABITACIONPORHOTELYHABITACION", SqlDataAccessArgs.CreateWith("@NUMERO", nro_habitacion)
             .And("@ID_HOTEL", nro_hotel).Arguments);

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    get_habitac.id_habitacion = int.Parse(row["ID_Habitacion"].ToString());
                    get_habitac.id_hotel = int.Parse(row["ID_Hotel"].ToString());
                    get_habitac.id_tipo_hab = int.Parse(row["Codigo_Tipo"].ToString());
                    get_habitac.numero = int.Parse(row["Numero"].ToString());
                    get_habitac.piso = int.Parse(row["Piso"].ToString());
                    get_habitac.baja_logica = Boolean.Parse(row["Baja_Logica"].ToString());
                    get_habitac.frente = (row["Frente"].ToString());
                    get_habitac.descripcion = (row["Descripcion"].ToString());
                }
            }
            return get_habitac;
        }

        public BindingList<Habitacion> GetAllPorHotel(int ID_Hotel_Habitaciones)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLHABITACIONPORHOTEL", SqlDataAccessArgs.CreateWith("@ID_Hotel_Habitaciones", ID_Hotel_Habitaciones).Arguments);
            var lista_habitaciones = new BindingList<Habitacion>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var habitacion = new Habitacion();
                    habitacion.id_habitacion = int.Parse(row["ID_Habitacion"].ToString());
                    habitacion.id_hotel = int.Parse(row["ID_Hotel"].ToString());
                    habitacion.id_tipo_hab = int.Parse(row["Codigo_Tipo"].ToString());
                    habitacion.numero = int.Parse(row["Numero"].ToString());
                    habitacion.piso = int.Parse(row["Piso"].ToString());
                    habitacion.baja_logica = Boolean.Parse(row["Baja_Logica"].ToString());
                    habitacion.frente = (row["Frente"].ToString());
                    habitacion.descripcion = (row["Descripcion"].ToString());

                    lista_habitaciones.Add(habitacion);
                }
            }
            return lista_habitaciones;
        }
                 
        public BindingList<Habitacion> GetAll()
        {
           var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(), 
               "LOS_NULL.GETALLHABITACION");
           var lista_habitaciones = new BindingList<Habitacion>();
           if (resultado != null && resultado.Rows != null)
           {
               foreach (DataRow row in resultado.Rows)
               {                 
                   var habitacion = new Habitacion();
                   habitacion.id_habitacion = int.Parse(row["ID_Habitacion"].ToString());
                   habitacion.id_hotel =int.Parse(row["ID_Hotel"].ToString());
                   habitacion.id_tipo_hab =int.Parse(row["Codigo_Tipo"].ToString());
                   habitacion.numero = int.Parse(row["Numero"].ToString());
                   habitacion.piso = int.Parse(row["Piso"].ToString());
                   habitacion.baja_logica = Boolean.Parse(row["Baja_Logica"].ToString());
                   habitacion.frente = (row["Frente"].ToString());
                   habitacion.descripcion = (row["Descripcion"].ToString());
                     
                   lista_habitaciones.Add(habitacion);
               }
           }
            return lista_habitaciones;
        }

        public void EliminarHabitacion(int habitacion_id)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                 "LOS_NULL.BAJAHABITACION", SqlDataAccessArgs.CreateWith("@ID_HABITACION",habitacion_id).Arguments);
            return;

        }

        public void InsertarHabitacion(Habitacion hab_Insertar)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.INSERTARHABITACION", SqlDataAccessArgs.CreateWith("@ID_HOTEL",hab_Insertar.id_hotel)
                .And("@NUMERO",hab_Insertar.numero).And("@PISO",hab_Insertar.piso)
                .And("@FRENTE",hab_Insertar.frente).And("@ID_TIPO_HAB",hab_Insertar.id_tipo_hab)
                .And("@DESCRIPCION",hab_Insertar.descripcion).Arguments);
            return;
        }
        public void ModificarHabitacion(Habitacion hab_Modificar)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.MODIFICARHABITACION", SqlDataAccessArgs.CreateWith("@ID_HOTEL", hab_Modificar.id_hotel)
                .And("@NUMERO", hab_Modificar.numero).And("@PISO", hab_Modificar.piso)
                .And("@FRENTE", hab_Modificar.frente).And("@ID_TIPO_HAB", hab_Modificar.id_tipo_hab)
                .And("@BAJA_LOGICA", hab_Modificar.baja_logica).And("@DESCRIPCION", hab_Modificar.descripcion).Arguments);
            return;
        }
        
        public Habitacion Build(System.Data.DataRow row)
        {
            Habitacion habitacion = new Habitacion();
            habitacion.id_habitacion = int.Parse(row["ID_Habitacion"].ToString());
            habitacion.id_hotel = int.Parse(row["ID_Hotel"].ToString());
            habitacion.id_tipo_hab = int.Parse(row["Codigo_Tipo"].ToString());
            habitacion.numero = int.Parse(row["Numero"].ToString());
            habitacion.piso = int.Parse(row["Piso"].ToString());
            habitacion.baja_logica = Boolean.Parse(row["Baja_Logica"].ToString());
            habitacion.frente = (row["Frente"].ToString());
            habitacion.descripcion = (row["Descripcion"].ToString());
            return habitacion;
        }

        public Habitacion Build(UInt32 PK)
        {
            Habitacion habitacion = null;

            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETHABITACION", SqlDataAccessArgs.CreateWith("@ID_HABITACION", PK).Arguments);

            if (resultado != null)
            {
                habitacion = this.Build(resultado);
            }

            return habitacion;
        }
        
    }
}
