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
    public partial class HotelManager : IBuilder<Hotel>
    {
        public decimal GetValorHabitacion(int ID_Habitacion,int ID_Hotel,string Regimen)
        {
            decimal precio_habitacion = 0;

            precio_habitacion = SqlDataAccess.ExecuteScalarQuery<decimal>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETVALORHABITACION", SqlDataAccessArgs.CreateWith("@ID_HOTEL", ID_Hotel)
               .And("@ID_HABITACION", ID_Habitacion).And("@REGIMEN", Regimen).Arguments);

            return precio_habitacion;
        }

        public BindingList<Habitacion> GetAllHabitacionDisponiblesEnFechaYCantidad(int ID_Hotel_Habitaciones,int tipo_hab,DateTime fecha_ini,DateTime fecha_fin)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLHABITACIONPORHOTELPORFECHAYCANTIDAD", SqlDataAccessArgs.CreateWith("@ID_HOTEL", ID_Hotel_Habitaciones)
                .And("@ID_TIPO_HAB",tipo_hab).And("@FECHA_INI",fecha_ini).And("@FECHA_FIN",fecha_fin).Arguments);
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

                    lista_habitaciones.Add(habitacion);
                }
            }
            return lista_habitaciones;
        }

        public BindingList<int> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
             "LOS_NULL.GETALLHOTEL");

            var hoteles = new BindingList<int>();

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    hoteles.Add(Convert.ToInt32(row["ID_Hotel"]));
                }
            }

            return hoteles;
        }

        
        public void ModificarHotel(Hotel hotel_modificado)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.MODIFICARHOTELPORID", SqlDataAccessArgs.CreateWith("@ID_HOTEL", hotel_modificado.id_hotel)
            .And("@CANTIDAD_ESTRELLAS", hotel_modificado.cant_estrellas).And("@CIUDAD", hotel_modificado.ciudad)
            .And("@PAIS", hotel_modificado.pais).And("@CALLE",hotel_modificado.calle).And("@TELEFONO",hotel_modificado.telefono)
            .And("@RECARGA_ESTRELLA",hotel_modificado.recarga_estrella).And("@NRO_CALLE",hotel_modificado.nro_calle).Arguments);
        }

        public int InsertarHotel(Hotel hotel_a_insertar,string user_admin)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.ALTAHOTEL", SqlDataAccessArgs.CreateWith("@CANTIDAD_ESTRELLAS", hotel_a_insertar.cant_estrellas)
            .And("@ADMINISTRADOR",user_admin).And("@CIUDAD", hotel_a_insertar.ciudad).And("@PAIS", hotel_a_insertar.pais)
            .And("@CALLE", hotel_a_insertar.calle).And("@TELEFONO", hotel_a_insertar.telefono)
            .And("@RECARGA_ESTRELLA", hotel_a_insertar.recarga_estrella).And("@NRO_CALLE", hotel_a_insertar.nro_calle)
            .And("@FECHA_CREACION",hotel_a_insertar.fecha_creacion).Arguments);

            int id_hotel = 0;

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    id_hotel = int.Parse(row["ID_Hotel"].ToString());                    
                }
            }
            return id_hotel;
        }

        public int BajarPorTiempoHotel(int ID_Hotel,DateTime fecha_inicio,DateTime fecha_fin,string descripcion)
        {
            int filas_afectadas = 0;

            filas_afectadas = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.BAJATEMPORALDEHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", ID_Hotel)
               .And("@FECHA_INICIO", fecha_inicio).And("@FECHA_FIN", fecha_fin).And("@DESCRIPCION", descripcion).Arguments);
            
            return filas_afectadas;
        }

        public Hotel GetPorIDHotel(int ID_HOTEL)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", ID_HOTEL).Arguments);

            Hotel hotel = new Hotel();

            if (resultado != null && resultado.Rows != null)
            {
               foreach (DataRow row in resultado.Rows)
               {
                   
                   hotel.id_hotel = int.Parse(row["ID_Hotel"].ToString());
                   hotel.ciudad = Convert.ToString(row["Ciudad"]);
                   hotel.calle = Convert.ToString(row["Calle"]);
                   hotel.nro_calle = int.Parse(row["Nro_Calle"].ToString());
                   hotel.cant_estrellas = int.Parse(row["Cant_Estrellas"].ToString());
                   hotel.recarga_estrella = decimal.Parse(row["Recarga_Estrella"].ToString());
                   hotel.telefono = Convert.ToString(row["Telefono"]);
                   hotel.pais = Convert.ToString(row["Pais"]);
                   hotel.fecha_creacion = Convert.ToDateTime(row["Fecha_Creacion"]);
 
               }
            }           

            return hotel;
        }
 

        public BindingList<Hotel> GetAllHotelesFiltrados(string administrador,int cant_estrellas,string ciudad,string pais)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.FILTRARHOTELESPORCAMPOS",SqlDataAccessArgs.CreateWith("@ADMINISTRADOR",administrador)
                .And("@CANTIDAD_ESTRELLAS",cant_estrellas).And("@CIUDAD",ciudad).And("@PAIS",pais).Arguments);
            var lista_hoteles_filtrados = new BindingList<Hotel>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Hotel hotel = new Hotel();
                    hotel.id_hotel = int.Parse(row["ID_Hotel"].ToString());
                    hotel.ciudad = Convert.ToString(row["Ciudad"]);
                    hotel.calle = Convert.ToString(row["Calle"]);
                    hotel.nro_calle = int.Parse(row["Nro_Calle"].ToString());
                    hotel.cant_estrellas = int.Parse(row["Cant_Estrellas"].ToString());
                    hotel.recarga_estrella = decimal.Parse(row["Recarga_Estrella"].ToString());
                    hotel.telefono = Convert.ToString(row["Telefono"]);
                    hotel.pais = Convert.ToString(row["Pais"]);
                    hotel.fecha_creacion = Convert.ToDateTime(row["Fecha_Creacion"]);
                  
                    lista_hoteles_filtrados.Add(hotel);
                }
            }
            return lista_hoteles_filtrados;
        }

        public BindingList<string> GetAllHotelesCiudades(string administrador)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLHOTELESCIUDADES", SqlDataAccessArgs.CreateWith("@ADMINISTRADOR", administrador).Arguments);
            var lista_ciudades = new BindingList<string>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    string ciudad;
                    ciudad = Convert.ToString(row["Ciudad"]);              
                    lista_ciudades.Add(ciudad);
                }
            }
            return lista_ciudades;
        }

        public BindingList<string> GetAllHotelesPaises(string administrador)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLHOTELESPAISES", SqlDataAccessArgs.CreateWith("@ADMINISTRADOR", administrador).Arguments);
            var lista_paises = new BindingList<string>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    string pais;
                    pais = Convert.ToString(row["Pais"]);
                    lista_paises.Add(pais);
                }
            }
            return lista_paises;
        }
       
        public BindingList<Hotel> GetAllHotelesPorAdministrador(string administrador)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLHOTELESADMINISTRADOR",SqlDataAccessArgs.CreateWith("@ADMINISTRADOR",administrador).Arguments);
            var lista_hoteles = new BindingList<Hotel>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Hotel hotel = new Hotel();
                    hotel.id_hotel = int.Parse(row["ID_Hotel"].ToString());
                    hotel.ciudad = Convert.ToString(row["Ciudad"]);
                    hotel.calle = Convert.ToString(row["Calle"]);
                    hotel.nro_calle = int.Parse(row["Nro_Calle"].ToString());
                    hotel.cant_estrellas = int.Parse(row["Cant_Estrellas"].ToString());
                    hotel.recarga_estrella = decimal.Parse(row["Recarga_Estrella"].ToString());
                    hotel.telefono = Convert.ToString(row["Telefono"]);
                    hotel.pais = Convert.ToString(row["Pais"]);
                    hotel.fecha_creacion = Convert.ToDateTime(row["Fecha_Creacion"]);
                    hotel.regimenes_list = GetAllRegimenPorHotel(hotel.id_hotel);

                    lista_hoteles.Add(hotel);
                }
            }
            return lista_hoteles;
        }

        public BindingList<Regimen> GetAllRegimenPorHotel(int id_hotel)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLREGIMENPORHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel).Arguments);
            var lista_regimenes_del_hotel = new BindingList<Regimen>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Regimen regimen = new Regimen();
                    regimen.id_regimen = int.Parse(row["ID_Regimen"].ToString());
                    regimen.descripcion = Convert.ToString(row["Descripcion"]);
                    regimen.precio = decimal.Parse(row["Precio"].ToString());
                    regimen.estado = Convert.ToBoolean(row["Estado"]);
                    lista_regimenes_del_hotel.Add(regimen);
                }
            }
            return lista_regimenes_del_hotel;
        }

        public Hotel Build(System.Data.DataRow row)
        {
            Hotel hotel = new Hotel();
            hotel.id_hotel = int.Parse(row["ID_Hotel"].ToString());
            hotel.ciudad = Convert.ToString(row["Ciudad"]);
            hotel.calle = Convert.ToString(row["Calle"]);
            hotel.nro_calle = int.Parse(row["Nro_Calle"].ToString());
            hotel.cant_estrellas = int.Parse(row["Cant_Estrellas"].ToString());
            hotel.recarga_estrella = decimal.Parse(row["Recarga_Estrella"].ToString());
            hotel.telefono = Convert.ToString(row["Telefono"]);
            hotel.pais = Convert.ToString(row["Pais"]);
            hotel.fecha_creacion = Convert.ToDateTime(row["Fecha_Creacion"]);
            return hotel;
        }

        public Hotel Build(UInt32 PK)
        {
            Hotel hotel = null;

            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", PK).Arguments);

            if (resultado != null)
            {
                hotel = this.Build(resultado);
            }

            return hotel;
        }

        public BindingList<int> GetAllPorUser(string user_id)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "LOS_NULL.GETALLHOTEL_USER", SqlDataAccessArgs.CreateWith("@ID_User", user_id).Arguments);

            var lista_hoteles = new BindingList<int>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    lista_hoteles.Add(Convert.ToInt32(row["ID_Hotel"]));
                }
            }
            return lista_hoteles;

        }
    }
}
